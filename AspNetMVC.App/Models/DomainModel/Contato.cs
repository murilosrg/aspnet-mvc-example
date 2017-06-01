
namespace AspNetMVC.App.Models.DomainModel
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}