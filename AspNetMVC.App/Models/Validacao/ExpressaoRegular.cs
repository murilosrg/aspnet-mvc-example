
namespace AspNetMVC.App.Models.Validacao
{
    public static class ExpressaoRegular
    {
        public const string CPF = @"([0-9]{3}\.){2}[0-9]{3}-[0-9]{2}";
        public const string CNPJ = @"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}";
        public const string CEP = @"^\d{5}-\d{3}$";
        public const string EMAIL = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        public const string HORA = @"^[0-2][0-3]:[0-5][0-9]$";
    }
}