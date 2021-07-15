using AppTest.Domain.Entities;
using AppTest.Domain.Interfaces;
using AppTest.Infra.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Infra.Data.Repositories
{
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        public ContatoRepository(AppTestContext context) : base(context)
        {
        }
    }
}
