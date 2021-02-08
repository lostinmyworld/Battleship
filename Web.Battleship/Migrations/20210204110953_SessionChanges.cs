using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Battleship.Migrations
{
    public partial class SessionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CannonBall_Grids_GridId",
                table: "CannonBall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CannonBall",
                table: "CannonBall");

            migrationBuilder.RenameTable(
                name: "CannonBall",
                newName: "CannonBalls");

            migrationBuilder.RenameIndex(
                name: "IX_CannonBall_GridId",
                table: "CannonBalls",
                newName: "IX_CannonBalls_GridId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlayerId",
                table: "Players",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "GridId",
                table: "CannonBalls",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CannonBalls",
                table: "CannonBalls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Player1Id = table.Column<int>(type: "int", nullable: true),
                    Player2Id = table.Column<int>(type: "int", nullable: true),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sessions_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Player1Id",
                table: "Sessions",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_Player2Id",
                table: "Sessions",
                column: "Player2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CannonBalls_Grids_GridId",
                table: "CannonBalls",
                column: "GridId",
                principalTable: "Grids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CannonBalls_Grids_GridId",
                table: "CannonBalls");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CannonBalls",
                table: "CannonBalls");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "CannonBalls",
                newName: "CannonBall");

            migrationBuilder.RenameIndex(
                name: "IX_CannonBalls_GridId",
                table: "CannonBall",
                newName: "IX_CannonBall_GridId");

            migrationBuilder.AlterColumn<int>(
                name: "GridId",
                table: "CannonBall",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CannonBall",
                table: "CannonBall",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CannonBall_Grids_GridId",
                table: "CannonBall",
                column: "GridId",
                principalTable: "Grids",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
