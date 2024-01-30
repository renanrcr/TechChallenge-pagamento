using AutoMapper;
using TechChallenge.src.Adapters.Driving.Api.DTOs;
using TechChallenge.src.Core.Domain.Entities;

namespace TechChallenge.src.Core.Domain.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<PedidoDTO, Pedido>().ReverseMap();
        }
    }
}