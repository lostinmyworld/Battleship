using Api.Battle.DataTypes.DTOs;
using Api.Battle.DataTypes.Requests;

namespace Api.Battle.Interfaces
{
    public interface ICalculationService
    {
        BoardDto CreatePlayerBoard(DeployShipsRequest request);
        bool CannonBallHit(BoardDto enemyBoard, CannonBallDto cannonBall);
    }
}
