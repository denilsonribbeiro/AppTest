using AppTest.Application.DTOs;
using AppTest.Application.Interfaces;
using AppTest.Application.Validations;
using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTest.Application.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public List<ContatoDTO> GetAll()
        {
            var contatos = _contatoRepository.GetAll();
            return _mapper.Map<List<ContatoDTO>>(contatos);
        }

        public async Task<ContatoDTO> GetById(int id)
        {
            var contato = await _contatoRepository.GetById(id);
            return _mapper.Map<ContatoDTO>(contato);
        }

        public ContatoDTO Add(ContatoDTO contatoDTO)
        {
            var validaNuloOuVazio = ContatoValidation.ValidarCadastroContato(contatoDTO);
            if (validaNuloOuVazio.Valido)
            {
                var contato = _mapper.Map<Contato>(contatoDTO);
                _contatoRepository.Add(contato);
            }

            return validaNuloOuVazio;
        }

        public async Task Update(ContatoDTO contatoDTO)
        {
            var contato = _mapper.Map<Contato>(contatoDTO);
            await _contatoRepository.Update(contato);
        }

        public async Task Delete(int id)
        {
            var contato = _contatoRepository.GetById(id).Result;
            await _contatoRepository.Delete(contato);
        }
    }
}
