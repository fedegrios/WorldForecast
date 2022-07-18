using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false),
                    VisitId = table.Column<int>(type: "int", nullable: false),
                    LocalScore = table.Column<int>(type: "int", nullable: false),
                    VisitScore = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_VisitId",
                        column: x => x.VisitId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Predictions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LocalScore = table.Column<int>(type: "int", nullable: false),
                    VisitScore = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predictions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Predictions_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Predictions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Deleted", "Group", "Name" },
                values: new object[,]
                {
                    { 1, false, "A", "Qatar" },
                    { 2, false, "A", "Ecuador" },
                    { 3, false, "A", "Senegal" },
                    { 4, false, "A", "Países Bajos" },
                    { 5, false, "B", "Inglaterra" },
                    { 6, false, "B", "Irán" },
                    { 7, false, "B", "Estados Unidos" },
                    { 8, false, "B", "Gales" },
                    { 9, false, "C", "Argentina" },
                    { 10, false, "C", "Arabia Saudita" },
                    { 11, false, "C", "México" },
                    { 12, false, "C", "Polonia" },
                    { 13, false, "D", "Francia" },
                    { 14, false, "D", "Australia" },
                    { 15, false, "D", "Dinamarca" },
                    { 16, false, "D", "Túnez" },
                    { 17, false, "E", "España" },
                    { 18, false, "E", "Costa Rica" },
                    { 19, false, "E", "Alemania" },
                    { 20, false, "E", "Japón" },
                    { 21, false, "F", "Bélgica" },
                    { 22, false, "F", "Canadá" },
                    { 23, false, "F", "Marruecos" },
                    { 24, false, "F", "Croacia" },
                    { 25, false, "G", "Brasil" },
                    { 26, false, "G", "Serbia" },
                    { 27, false, "G", "Suiza" },
                    { 28, false, "G", "Camerún" },
                    { 29, false, "H", "Portugal" },
                    { 30, false, "H", "Ghana" },
                    { 31, false, "H", "Uruguay" },
                    { 32, false, "H", "Corea" }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Code", "Date", "Deleted", "LocalId", "LocalScore", "VisitId", "VisitScore" },
                values: new object[,]
                {
                    { 1, "E", new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 18, 0, 19, 0 },
                    { 2, "F", new DateTime(2022, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 24, 0, 21, 0 },
                    { 3, "F", new DateTime(2022, 12, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 22, 0, 23, 0 },
                    { 4, "E", new DateTime(2022, 12, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 20, 0, 17, 0 },
                    { 5, "G", new DateTime(2022, 12, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 28, 0, 25, 0 },
                    { 6, "G", new DateTime(2022, 12, 2, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 26, 0, 27, 0 },
                    { 7, "H", new DateTime(2022, 12, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 32, 0, 29, 0 },
                    { 8, "H", new DateTime(2022, 12, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 30, 0, 31, 0 },
                    { 9, "A", new DateTime(2022, 11, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 0, 2, 0 },
                    { 10, "A", new DateTime(2022, 11, 21, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 3, 0, 4, 0 },
                    { 11, "B", new DateTime(2022, 11, 21, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 5, 0, 6, 0 },
                    { 12, "B", new DateTime(2022, 11, 21, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 7, 0, 8, 0 },
                    { 13, "C", new DateTime(2022, 11, 22, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 9, 0, 10, 0 },
                    { 14, "C", new DateTime(2022, 11, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 11, 0, 12, 0 },
                    { 15, "D", new DateTime(2022, 11, 22, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 13, 0, 14, 0 },
                    { 16, "D", new DateTime(2022, 11, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 15, 0, 16, 0 },
                    { 17, "E", new DateTime(2022, 11, 23, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 17, 0, 18, 0 },
                    { 18, "E", new DateTime(2022, 11, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 19, 0, 20, 0 },
                    { 19, "F", new DateTime(2022, 11, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 21, 0, 22, 0 },
                    { 20, "F", new DateTime(2022, 11, 23, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 23, 0, 24, 0 },
                    { 21, "G", new DateTime(2022, 11, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 25, 0, 26, 0 },
                    { 22, "G", new DateTime(2022, 11, 24, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 27, 0, 28, 0 },
                    { 23, "H", new DateTime(2022, 11, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 29, 0, 30, 0 },
                    { 24, "H", new DateTime(2022, 11, 24, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 31, 0, 32, 0 },
                    { 25, "A", new DateTime(2022, 11, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 0, 3, 0 },
                    { 26, "A", new DateTime(2022, 11, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 0, 2, 0 },
                    { 27, "B", new DateTime(2022, 11, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 5, 0, 7, 0 },
                    { 28, "B", new DateTime(2022, 11, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 8, 0, 6, 0 },
                    { 29, "C", new DateTime(2022, 11, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 9, 0, 11, 0 },
                    { 30, "C", new DateTime(2022, 11, 26, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 0, 10, 0 },
                    { 31, "D", new DateTime(2022, 11, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 13, 0, 15, 0 },
                    { 32, "D", new DateTime(2022, 11, 26, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 16, 0, 14, 0 },
                    { 33, "E", new DateTime(2022, 11, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 17, 0, 19, 0 },
                    { 34, "E", new DateTime(2022, 11, 27, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 20, 0, 18, 0 },
                    { 35, "F", new DateTime(2022, 11, 27, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 21, 0, 23, 0 },
                    { 36, "F", new DateTime(2022, 11, 27, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 24, 0, 22, 0 },
                    { 37, "G", new DateTime(2022, 11, 28, 13, 0, 0, 0, DateTimeKind.Unspecified), false, 25, 0, 27, 0 },
                    { 38, "G", new DateTime(2022, 11, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), false, 28, 0, 26, 0 },
                    { 39, "H", new DateTime(2022, 11, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 29, 0, 31, 0 },
                    { 40, "H", new DateTime(2022, 11, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 32, 0, 30, 0 },
                    { 41, "A", new DateTime(2022, 11, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 4, 0, 1, 0 },
                    { 42, "A", new DateTime(2022, 11, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 0, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Matches",
                columns: new[] { "Id", "Code", "Date", "Deleted", "LocalId", "LocalScore", "VisitId", "VisitScore" },
                values: new object[,]
                {
                    { 43, "B", new DateTime(2022, 11, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 8, 0, 5, 0 },
                    { 44, "B", new DateTime(2022, 11, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 6, 0, 7, 0 },
                    { 45, "C", new DateTime(2022, 11, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 12, 0, 9, 0 },
                    { 46, "C", new DateTime(2022, 11, 30, 16, 0, 0, 0, DateTimeKind.Unspecified), false, 10, 0, 11, 0 },
                    { 47, "D", new DateTime(2022, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 16, 0, 13, 0 },
                    { 48, "D", new DateTime(2022, 11, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 14, 0, 15, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_LocalId",
                table: "Matches",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_VisitId",
                table: "Matches",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_MatchId",
                table: "Predictions",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Predictions_UserId",
                table: "Predictions",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predictions");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
