using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetMVC.App.Models.DomainModel
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }
        public string Nome { get; set; }
        public Nullable<DateTime> DataNascimento { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Contato> Contatos { get; set; }
    }
}