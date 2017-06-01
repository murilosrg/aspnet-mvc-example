using AspNetMVC.App.Models.DomainModel;
using System.Linq;

namespace AspNetMVC.App.Models.DataModel.Queries
{
    public static class PessoasQuery
    {
        public static IQueryable<Pessoa> ComId(this IQueryable<Pessoa> pessoas, int? id)
        {
            if (id.HasValue)
                return pessoas.Where(p => p.IdPessoa == id.Value);

            return pessoas;
        }

        public static IQueryable<Pessoa> OndeNomeContem(this IQueryable<Pessoa> pessoas, string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return pessoas;
            return pessoas.Where(p => p.Nome.Contains(nome));
        }

        public static IQueryable<Pessoa> OrdenadasPorNome(this IQueryable<Pessoa> pessoas)
        {
            return pessoas.OrderBy(p => p.Nome);
        }
    }
}