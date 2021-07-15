using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppTest.Application.DTOs
{
    public class ContatoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(30)]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        [Display(Name = "Ativo")]
        public bool IsAtivo { get; set; }

        public string Sexo { get; set; }
        public int? Idade { get; set; }

    }
}
