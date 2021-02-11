using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Battleship.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensionX = table.Column<int>(type: "int", nullable: false),
                    DimensionY = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battleship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowStart = table.Column<byte>(type: "tinyint", nullable: false),
                    ColumnStart = table.Column<byte>(type: "tinyint", nullable: false),
                    Orientation = table.Column<int>(type: "int", nullable: false),
                    ShipType = table.Column<int>(type: "int", nullable: false),
                    HitsTaken = table.Column<byte>(type: "tinyint", nullable: false),
                    IsDestroyed = table.Column<bool>(type: "bit", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battleship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battleship_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CannonBall",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<byte>(type: "tinyint", nullable: false),
                    Column = table.Column<byte>(type: "tinyint", nullable: false),
                    Hit = table.Column<bool>(type: "bit", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CannonBall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CannonBall_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: true),
                    IsWinner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BattleSession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: true),
                    Player2Id = table.Column<int>(type: "int", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BattleSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BattleSession_Player_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BattleSession_Player_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BattleSession_Player1Id",
                table: "BattleSession",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_BattleSession_Player2Id",
                table: "BattleSession",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Battleship_BoardId",
                table: "Battleship",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_CannonBall_BoardId",
                table: "CannonBall",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_BoardId",
                table: "Player",
                column: "BoardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BattleSession");

            migrationBuilder.DropTable(
                name: "Battleship");

            migrationBuilder.DropTable(
                name: "CannonBall");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Board");
        }
    }
}
