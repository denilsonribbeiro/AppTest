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

        public static bool ValidarCadastroContato(ContatoDTO contato)
        {
            When(string.IsNullOrEmpty(contato.Nome), "O nome não pode ser vazio.");

            return false;
        }
    }
}
