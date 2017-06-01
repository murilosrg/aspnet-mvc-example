using AspNetMVC.App.Extensions;
using AspNetMVC.App.Models.DomainModel;
using System.Data.Entity.ModelConfiguration;

namespace AspNetMVC.App.Models.DataModel.Mappers
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco", "dbo");

            HasKey(e => e.IdPessoa);

            Property(e => e.IdPessoa).IsRequired().HasIndex();
            Property(e => e.Logradouro).HasMaxLength(250).IsRequired();
            Property(e => e.Numero).HasMaxLength(10).IsOptional();

            HasRequired(e => e.Pessoa).WithOptional(e => e.Endereco);
        }
    }
}