
namespace AspNetMVC.App.Models.DomainModel
{
    public class Endereco
    {
        public int IdPessoa { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}