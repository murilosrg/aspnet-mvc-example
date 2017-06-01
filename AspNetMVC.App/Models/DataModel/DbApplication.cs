using AspNetMVC.App.Models.DataModel.Mappers;
using AspNetMVC.App.Models.DomainModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetMVC.App.Models.DataModel
{
    public class DbApplication : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        public DbApplication()
            : base("name=db_teste")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new ContatoMap());
            modelBuilder.Configurations.Add(new PessoaMap());
        }

        public void RegistrarNovo(object entidade)
        {
            Set(entidade.GetType()).Add(entidade);
        }

        public void RegistrarAlterado(object entidade)
        {
            Entry(entidade).State = EntityState.Modified;
        }

        public void RegistrarRemovido(object entidade)
        {
            Entry(entidade).State = EntityState.Deleted;
        }

        public void Salvar()
        {
            SaveChanges();
        }
    }
}