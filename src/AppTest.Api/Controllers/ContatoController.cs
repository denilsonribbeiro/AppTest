using AppTest.Application.DTOs;
using AppTest.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContatoDTO>> GetAll()
        {
            var contatos = _contatoService.GetAll();

            if (contatos == null)
                return NotFound("Contatos não encontrados");

            return Ok(contatos);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContatoDTO>> GetById(int id)
        {
            var contato = await _contatoService.GetById(id);

            if (contato == null)
                return NotFound("Contato não encontrado");

            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContatoDTO contato)
        {
            if (contato == null)
                return BadRequest("Dados inválidos!");

            var contatoResult = _contatoService.Add(contato);

            if (contatoResult.Valido)
                return Ok(contato);
            else
                return BadRequest(contato.Erro);
        }
    }
}
