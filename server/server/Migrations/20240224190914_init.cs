using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardType = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    CardCategory = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Sate = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_game", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gameCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlipedState = table.Column<int>(type: "INTEGER", nullable: false),
                    FlippedPlayerId = table.Column<int>(type: "INTEGER", nullable: true),
                    FlippedOrder = table.Column<int>(type: "INTEGER", nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: false),
                    IsMatch = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gameCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gameCard_cards_CardId",
                        column: x => x.CardId,
                        principalTable: "cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameCard_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gameCard_player_FlippedPlayerId",
                        column: x => x.FlippedPlayerId,
                        principalTable: "player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "gamePlayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gamePlayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gamePlayer_game_GameId",
                        column: x => x.GameId,
                        principalTable: "game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gamePlayer_player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 1, 1, 14, "AC.png", "CLUBS A" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 2, 1, 2, "2C.png", "CLUBS 2" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 3, 1, 3, "3C.png", "CLUBS 3" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 4, 1, 4, "4C.png", "CLUBS 4" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 5, 1, 5, "5C.png", "CLUBS 5" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 6, 1, 6, "6C.png", "CLUBS 6" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 7, 1, 7, "7C.png", "CLUBS 7" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 8, 1, 8, "8C.png", "CLUBS 8" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 9, 1, 9, "9C.png", "CLUBS 9" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 10, 1, 10, "10C.png", "CLUBS 10" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 11, 1, 11, "JC.png", "CLUBS J" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 12, 1, 13, "QC.png", "CLUBS Q" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 13, 1, 12, "KC.png", "CLUBS K" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 14, 2, 14, "AD.png", "DIAMONDS A" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 15, 2, 2, "2D.png", "DIAMONDS 2" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 16, 2, 3, "3D.png", "DIAMONDS 3" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 17, 2, 4, "4D.png", "DIAMONDS 4" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 18, 2, 5, "5D.png", "DIAMONDS 5" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 19, 2, 6, "6D.png", "DIAMONDS 6" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 20, 2, 7, "7D.png", "DIAMONDS 7" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 21, 2, 8, "8D.png", "DIAMONDS 8" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 22, 2, 9, "9D.png", "DIAMONDS 9" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 23, 2, 10, "10D.png", "DIAMONDS 10" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 24, 2, 11, "JD.png", "DIAMONDS J" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 25, 2, 13, "QD.png", "DIAMONDS Q" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 26, 2, 12, "KD.png", "DIAMONDS K" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 27, 3, 14, "AH.png", "HEARTS A" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 28, 3, 2, "2H.png", "HEARTS 2" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 29, 3, 3, "3H.png", "HEARTS 3" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 30, 3, 4, "4H.png", "HEARTS 4" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 31, 3, 5, "5H.png", "HEARTS 5" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 32, 3, 6, "6H.png", "HEARTS 6" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 33, 3, 7, "7H.png", "HEARTS 7" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 34, 3, 8, "8H.png", "HEARTS 8" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 35, 3, 9, "9H.png", "HEARTS 9" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 36, 3, 10, "10H.png", "HEARTS 10" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 37, 3, 11, "JH.png", "HEARTS J" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 38, 3, 13, "QH.png", "HEARTS Q" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 39, 3, 12, "KH.png", "HEARTS K" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 40, 4, 14, "AS.png", "SPADES A" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 41, 4, 2, "2S.png", "SPADES 2" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 42, 4, 3, "3S.png", "SPADES 3" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 43, 4, 4, "4S.png", "SPADES 4" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 44, 4, 5, "5S.png", "SPADES 5" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 45, 4, 6, "6S.png", "SPADES 6" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 46, 4, 7, "7S.png", "SPADES 7" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 47, 4, 8, "8S.png", "SPADES 8" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 48, 4, 9, "9S.png", "SPADES 9" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 49, 4, 10, "10S.png", "SPADES 10" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 50, 4, 11, "JS.png", "SPADES J" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 51, 4, 13, "QS.png", "SPADES Q" });

            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "CardCategory", "CardType", "Image", "Name" },
                values: new object[] { 52, 4, 12, "KS.png", "SPADES K" });

            migrationBuilder.InsertData(
                table: "player",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Player 1" });

            migrationBuilder.InsertData(
                table: "player",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Player 2" });

            migrationBuilder.CreateIndex(
                name: "IX_gameCard_CardId",
                table: "gameCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_gameCard_FlippedPlayerId",
                table: "gameCard",
                column: "FlippedPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_gameCard_GameId",
                table: "gameCard",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_gamePlayer_GameId",
                table: "gamePlayer",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_gamePlayer_PlayerId",
                table: "gamePlayer",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gameCard");

            migrationBuilder.DropTable(
                name: "gamePlayer");

            migrationBuilder.DropTable(
                name: "cards");

            migrationBuilder.DropTable(
                name: "game");

            migrationBuilder.DropTable(
                name: "player");
        }
    }
}
