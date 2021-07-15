using AppTest.Application.DTOs;
using AppTest.Application.Validations;
using AppTest.Domain.Entities;
using AppTest.Test.Util;
using ExpectedObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AppTest.Test
{
    public class ContatoUnitTest
    {
        public string _nome;
        public DateTime _dataNascimento;
        public bool _isAtivo;
        public string _sexo;
        public int? _idade;

        public ContatoUnitTest()
        {
            _nome = "João da Silva";
            _dataNascimento = DateTime.Now;
            _isAtivo = true;
            _sexo = "Masculino";
            _idade = 30;
        }

        [Fact]
        public void CreateContato_WithValidObject_ResultSuccess()
        {
            var contatoObj = new
            {
                Nome = _nome,
                DataNascimento = _dataNascimento,
                IsAtivo = _isAtivo,
                Sexo = _sexo,
                Idade = _idade
            };

            var contato = new Contato(contatoObj.Nome, contatoObj.DataNascimento, contatoObj.IsAtivo, contatoObj.Sexo, contatoObj.Idade);
            contatoObj.ToExpectedObject().ShouldMatch(contato);
        }

        [Fact]
        public void CreateContato_WithEmptyName_ResultError()
        {
            Assert.Throws<ArgumentException>(() => new Contato(string.Empty, _dataNascimento, _isAtivo, _sexo, _idade))
                .WithMessage("O nome não pode ser vazio.");
        }
    }
}
