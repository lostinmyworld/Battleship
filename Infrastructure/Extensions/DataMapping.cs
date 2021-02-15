using AutoMapper;
using Contracts.Responses;
using Data.EfCore.Models;
using Data.Types;
using Domain.DTOs;

namespace Infrastructure.Extensions
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            CreateMap<SessionIds, CreateGameResponse>().ReverseMap();
            CreateMap<CannonBallDto, CannonBall>().ReverseMap();
            CreateMap<BattleshipDto, Battleship>().ReverseMap();
            CreateMap<BoardDto, Board>().ReverseMap();
            CreateMap<CannonBallDto, Coordinate>().ReverseMap();
        }
    }
}
