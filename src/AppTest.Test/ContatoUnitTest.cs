using AppTest.Api.Controllers;
using AppTest.Application.DTOs;
using AppTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AppTest.Test
{
    public class ContatoUnitTest
    {
        private List<ContatoDTO> GetContatoTeste()
        {
            return new List<ContatoDTO>()
            {
                new ContatoDTO
                {
                    Id = 1,
                    Nome = "Maria",
                    DataNascimento = new DateTime(2020,3,3)
                },
                new ContatoDTO
                {
                    Id = 2,
                    Nome = "Joao"
                },
                new ContatoDTO
                {
                    Id = 0,
                    Nome = "Erro",
                    DataNascimento = new DateTime(2022,3,3),
                    Sexo = "Masculino"

                }
            };
        }


        [Fact]
        public void Get_Contato_With_ResultSuccess()
        {
            //arrange
            var mockServico = new Mock<IContatoService>();
            mockServico.Setup(mockServico => mockServico.GetAll()).Returns(GetContatoTeste());

            var controllerS = new ContatoController(mockServico.Object);

            //act
            var result = controllerS.GetAll();
            var resultOk = result.Result as OkObjectResult;

            //assert
            Assert.Equal(3, (resultOk.Value as List<ContatoDTO>).Count);

        }

        //[Fact]
        //public void CreateContato_WithEmptyName_ResultError()
        //{
        //    //arrange
        //    var mockServico = new Mock<IContatoService>();
        //    mockServico.Setup(mockServico => mockServico.Add(GetContatoTeste()[2])).Returns(GetContatoTeste()[2]);
        //    var controllerS = new ContatoController(mockServico.Object);

        //    //act
        //    var result = controllerS.Post(GetContatoTeste()[2]);
        //    var resultOk = result.Result as OkObjectResult;

        //    Assert.False((resultOk.Value as ContatoDTO).Valido);

        //}

        //[Fact]
        //public void CreateContato_WithEmptyName_ResultError()
        //{
        //    //arrange
        //    var mockServico = new Mock<IContatoService>();
        //    mockServico.Setup(mockServico => mockServico.Add(GetContatoTeste()[2])).Returns(GetContatoTeste()[2]);
        //    var controllerS = new ContatoController(mockServico.Object);

        //    //act
        //    var result = controllerS.Post(GetContatoTeste()[2]);
        //    var resultOk = result.Result as OkObjectResult;

        //    Assert.False((resultOk.Value as ContatoDTO).Valido);

        //}



    }
}
