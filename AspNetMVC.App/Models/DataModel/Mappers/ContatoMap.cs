using AspNetMVC.App.Models.DomainModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace AspNetMVC.App.Models.DataModel.Mappers
{
    public class ContatoMap : EntityTypeConfiguration<Contato>
    {
        public ContatoMap()
        {
            ToTable("Contato", "dbo");

            HasKey(c => c.IdContato);

            Property(c => c.IdContato).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Descricao).HasMaxLength(50).IsRequired();
            Property(c => c.Numero).HasMaxLength(10).IsRequired();

            HasRequired(c => c.Pessoa).WithMany(c => c.Contatos).HasForeignKey(c => c.IdPessoa);
        }
    }
}