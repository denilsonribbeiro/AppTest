using AppTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Application.Validations
{
    public class ContatoValidation : Exception
    {
        public ContatoValidation(string error) : base(error) { }

        private static void When(bool hasError, string error)
        {
            if (hasError)
                throw new ContatoValidation(error);
        }

        public static ContatoDTO ValidarCadastroContato(ContatoDTO contato)
        {
            contato.Valido = true;

            if (string.IsNullOrEmpty(contato.Nome))
            {
                contato.Erro = "Campo nao pode ser vazio";
                contato.Valido = false;
            }

            if (contato.DataNascimento > DateTime.Now)
            {
                contato.Erro = "Data de nascimento é maior que a data atual";
                contato.Valido = false;
            }

            return contato;
        }
    }
}
