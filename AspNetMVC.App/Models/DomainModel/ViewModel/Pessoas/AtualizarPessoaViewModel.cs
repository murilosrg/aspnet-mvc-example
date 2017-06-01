using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.App.Models.DomainModel.ViewModel.Pessoas
{
    public class AtualizarPessoaViewModel
    {
        [Required(ErrorMessage = "Pessoa precisa ser informada.")]
        public int IdPessoa { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "Campo '{0}' deve conter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        public Nullable<DateTime> DataNascimento { get; set; }
    }
}