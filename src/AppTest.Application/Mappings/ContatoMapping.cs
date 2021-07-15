using AppTest.Application.DTOs;
using AppTest.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppTest.Application.Mappings
{
    public class ContatoMapping : Profile
    {
        public ContatoMapping()
        {
            CreateMap<Contato, ContatoDTO>().ReverseMap();
        }
    }
}
