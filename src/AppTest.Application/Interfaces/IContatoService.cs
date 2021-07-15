using AppTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.Application.Interfaces
{
    public interface IContatoService
    {
        Task<IEnumerable<ContatoDTO>> GetAll();
        Task<ContatoDTO> GetById(int id);
        Task Add(ContatoDTO contato);
        Task Update(ContatoDTO contato);
        Task Delete(int id);
    }
}
