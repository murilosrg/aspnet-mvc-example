using AspNetMVC.App.Models.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AspNetMVC.App.Models.DataModel.Mappers
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("Pessoa", "dbo");

            HasKey(p => p.IdPessoa);

            Property(p => p.IdPessoa).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Nome).HasMaxLength(150).IsRequired();
            Property(p => p.DataNascimento).IsOptional();

            HasOptional(p => p.Endereco).WithRequired(p => p.Pessoa);
            HasMany(i => i.Contatos).WithRequired(p => p.Pessoa).HasForeignKey(p => p.IdPessoa);
        }
    }
}