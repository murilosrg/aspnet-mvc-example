using AspNetMVC.App.Extensions;
using AspNetMVC.App.Models.DataModel;
using AspNetMVC.App.Models.DataModel.Queries;
using AspNetMVC.App.Models.DomainModel;
using AspNetMVC.App.Models.DomainModel.ViewModel;
using AspNetMVC.App.Models.DomainModel.ViewModel.Pessoas;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AspNetMVC.App.Controllers
{
    public class PessoasController : Controller
    {
        [HttpGet]
        [Route("Pessoas")]
        public ActionResult Index()
        {
            return View("~/Views/Pessoas/Consultar.cshtml");
        }

        [HttpPost]
        [Route("Pessoas/Atualizar")]
        public async Task<ActionResult> Atualizar(AtualizarPessoaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            using (DbApplication db = new DbApplication())
            {
                Pessoa pessoa = await db
                 .Pessoas
                 .ComId(viewModel.IdPessoa)
                 .SingleOrDefaultAsync();

                if (pessoa == null)
                {
                    return this.ErrorMessage("Pessoa não cadastrada.");
                }

                pessoa.Nome = viewModel.Nome;
                pessoa.DataNascimento = viewModel.DataNascimento;

                db.RegistrarAlterado(pessoa);
                db.Salvar();
            }

            return this.Message("Pessoa atualizada com sucesso.");
        }

        [HttpPost]
        [Route("Pessoas/Cadastrar")]
        public ActionResult Cadastrar(CadastrarPessoaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            using (DbApplication db = new DbApplication())
            {
                Pessoa pessoa = new Pessoa()
                {
                    Nome = viewModel.Nome,
                    DataNascimento = viewModel.DataNascimento
                };

                db.RegistrarNovo(pessoa);
                db.Salvar();
            }

            return this.Message("Pessoa cadastrada com sucesso.");

        }

        [Route("Pessoas/Consultar")]
        public async Task<ActionResult> Consultar(PessoasCadastradasViewModel viewModel)
        {
            using (DbApplication db = new DbApplication())
            {

                IQueryable<Pessoa> pessoasQuery = db
                    .Pessoas
                    .OndeNomeContem(viewModel.Nome)
                    .OrdenadasPorNome();

                int totalRegistros = await pessoasQuery.CountAsync();

                List<dynamic> pessoasCadastradas = new List<dynamic>();

                ICollection<Pessoa> pessoas = await pessoasQuery
                    .Skip(viewModel.APartirDo)
                    .Take(TotalRegistrosViewModel.Quantidade)
                    .ToListAsync();

                foreach (Pessoa pessoa in pessoas)
                {
                    pessoasCadastradas.Add(new
                    {
                        idPessoa = pessoa.IdPessoa,
                        nome = pessoa.Nome,
                        dataNascimento = pessoa.DataNascimento.HasValue ? pessoa.DataNascimento.Value.ToString("dd/MM/yyyy") : ""
                    });
                }

                return Json(new
                {
                    pessoas = pessoasCadastradas,
                    totalRegistros = totalRegistros
                });
            }

        }
        
        [HttpPost]
        [Route("Pessoas/Remover")]
        public async Task<ActionResult> Remover(IdPessoaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            using (DbApplication db = new DbApplication())
            {
                Pessoa pessoa = await db
                .Pessoas
                .ComId(viewModel.IdPessoa)
                .SingleOrDefaultAsync();

                if (pessoa == null)
                {
                    return this.ErrorMessage("Pessoa não cadastrada.");
                }

                db.RegistrarRemovido(pessoa);
                db.Salvar();

            }

            return this.Message("Pessoa removida com sucesso.");
        }
    }
}