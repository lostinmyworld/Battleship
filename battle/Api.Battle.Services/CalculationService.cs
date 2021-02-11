using Api.Base.DataTypes;
using Api.Battle.DataTypes;
using Api.Battle.DataTypes.DTOs;
using Api.Battle.DataTypes.Requests;
using Api.Battle.Interfaces;
using Api.Battle.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Battle.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly Dictionary<ShipTypeEnum, int> ShipSize = new Dictionary<ShipTypeEnum, int>
        {
            { ShipTypeEnum.Carrier, 5 },
            { ShipTypeEnum.Battleship, 4 },
            { ShipTypeEnum.Cruiser, 3 },
            { ShipTypeEnum.Submarine, 3 },
            { ShipTypeEnum.Destroyer, 2 }
        };

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
                        && cannonBall.Column <= (ship.ColumnStart + ShipSize[ship.ShipType] - 1))
                    {
                        SuccessfulCannonball(ship, cannonBall);

                        return true;
                    }
                }
                else
                {
                    if (cannonBall.Column == ship.ColumnStart
                        && cannonBall.Row >= ship.RowStart
                        && cannonBall.Row <= (ship.RowStart + ShipSize[ship.ShipType] - 1))
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
            ship.IsDestroyed = ship.HitsTaken == ShipSize[ship.ShipType];
        }
    }
}
