﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.App.Models.DomainModel.ViewModel.Pessoas
{
    public class CadastrarPessoaViewModel
    {
        [Required]
        [StringLength(150, ErrorMessage = "Campo '{0}' deve conter no máximo {1} caracteres.")]
        public string Nome { get; set; }

        public Nullable<DateTime> DataNascimento { get; set; }
    }
}