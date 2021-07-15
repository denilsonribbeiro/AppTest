using AppTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Application.Interfaces
{
    public interface IContatoService
    {
        List<ContatoDTO> GetAll();
        Task<ContatoDTO> GetById(int id);
        ContatoDTO Add(ContatoDTO contato);
        Task Update(ContatoDTO contato);
        Task Delete(int id);
    }
}
