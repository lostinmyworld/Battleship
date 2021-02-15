using Contracts.Requests;
using Domain.DTOs;

namespace Application
{
    public interface ICalculationService
    {
        BoardDto CreatePlayerBoard(DeployShipsRequest request);
        bool CannonBallHit(BoardDto enemyBoard, CannonBallDto cannonBall);
    }
}
