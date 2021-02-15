using Application;
using Contracts.Requests;
using Domain;
using Domain.DTOs;
using Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class CalculationService : ICalculationService
    {


        public BoardDto CreatePlayerBoard(DeployShipsRequest request)
        {
            if (!request.IsValid())
            {
                throw new ArgumentNullException(nameof(request));
            }

            var ships = request.Ships.Select(s => CreateShip(s));

            return new BoardDto
            {
                DimensionX = 10,
                DimensionY = 10,
                Ships = ships.ToHashSet()
            };
        }

        public bool CannonBallHit(BoardDto enemyBoard, CannonBallDto cannonBall)
        {
            if (enemyBoard == null)
            {
                throw new ArgumentNullException(nameof(enemyBoard));
            }
            if (cannonBall == null)
            {
                throw new ArgumentNullException(nameof(cannonBall));
            }

            var hitSuccess = IsHit(enemyBoard, cannonBall);

            return hitSuccess;
        }

        private BattleshipDto CreateShip(Ship ship)
        {
            return new BattleshipDto
            {
                RowStart = ship.CoordinateStart.Row,
                ColumnStart = ship.CoordinateStart.Column,
                Orientation = ship.Orientation,
                ShipType = ship.Type
            };
        }

        private bool IsHit(BoardDto board, CannonBallDto cannonBall)
        {
            if (board.CannonBallsShot == null)
            {
                board.CannonBallsShot = new HashSet<CannonBallDto>();
            }

            foreach (var ship in board.Ships)
            {
                if (ship.Orientation == ShipOrientationEnum.Horizontal)
                {
                    if (cannonBall.Row == ship.RowStart
                        && cannonBall.Column >= ship.ColumnStart
                        && cannonBall.Column <= (ship.ColumnStart + Common.ShipSizes[ship.ShipType] - 1))
                    {
                        SuccessfulCannonball(ship, cannonBall);

                        return true;
                    }
                }
                else
                {
                    if (cannonBall.Column == ship.ColumnStart
                        && cannonBall.Row >= ship.RowStart
                        && cannonBall.Row <= (ship.RowStart + Common.ShipSizes[ship.ShipType] - 1))
                    {
                        SuccessfulCannonball(ship, cannonBall);

                        return true;
                    }
                }
            }

            return false;
        }

        private void SuccessfulCannonball(BattleshipDto ship, CannonBallDto cannonBall)
        {
            cannonBall.Hit = true;
            ship.HitsTaken++;
            ship.IsDestroyed = ship.HitsTaken == Common.ShipSizes[ship.ShipType];
        }
    }
}
