using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppTest.Domain.Entities
{
    public class Contato : EntityBase
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool IsAtivo { get; set; }
        public string Sexo { get; set; }
        public int? Idade { get; set; }


        public Contato(string nome, DateTime dataNascimento, bool isAtivo, string sexo, int? idade)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            IsAtivo = isAtivo;
            Sexo = sexo;
            Idade = idade;
        }
    }
}
