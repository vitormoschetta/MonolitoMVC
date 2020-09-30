using System;
using System.ComponentModel.DataAnnotations;
using Projeto.Models;
using Projeto.Validators.DataAnnotations;

namespace Projeto.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Nome { get; set; }

        [ValidaMaiorDeIdade]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string Cpf { get; set; }
    }
}