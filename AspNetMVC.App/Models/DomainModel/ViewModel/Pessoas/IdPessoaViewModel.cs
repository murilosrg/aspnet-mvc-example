using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.App.Models.DomainModel.ViewModel.Pessoas
{
    public class IdPessoaViewModel
    {
        [Required(ErrorMessage = "Pessoa deve ser informada")]
        public int IdPessoa { get; set; }
    }
}