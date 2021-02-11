using Api.Battle.DataTypes.DTOs;
using Api.Battle.DataTypes.Responses;
using AutoMapper;
using Data.EfCore.Models;
using Data.Types;

namespace Api.Battle.Services.Extensions
{
    public class DataMapping : Profile
    {
        public DataMapping()
        {
            CreateMap<SessionIds, CreateGameResponse>().ReverseMap();
            CreateMap<CannonBallDto, CannonBall>().ReverseMap();
            CreateMap<BattleshipDto, Battleship>().ReverseMap();
            CreateMap<BoardDto, Board>().ReverseMap();
        }
    }
}
