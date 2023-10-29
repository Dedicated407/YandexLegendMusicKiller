using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YandexLegendMusicKiller.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nick_name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    full_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("genres_pkey", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "music_collections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_music_collections", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    authors_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.id);
                    table.ForeignKey(
                        name: "FK_albums_authors_authors_id",
                        column: x => x.authors_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "songs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    albums_id = table.Column<Guid>(type: "uuid", nullable: false),
                    genres_id = table.Column<string>(type: "character varying(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_songs", x => x.id);
                    table.ForeignKey(
                        name: "FK_songs_albums_albums_id",
                        column: x => x.albums_id,
                        principalTable: "albums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_songs_genres_genres_id",
                        column: x => x.genres_id,
                        principalTable: "genres",
                        principalColumn: "name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicCollectionSong",
                columns: table => new
                {
                    MusicCollectionsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SongsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicCollectionSong", x => new { x.MusicCollectionsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_MusicCollectionSong_music_collections_MusicCollectionsId",
                        column: x => x.MusicCollectionsId,
                        principalTable: "music_collections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicCollectionSong_songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "songs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_authors_id",
                table: "albums",
                column: "authors_id");

            migrationBuilder.CreateIndex(
                name: "IX_MusicCollectionSong_SongsId",
                table: "MusicCollectionSong",
                column: "SongsId");

            migrationBuilder.CreateIndex(
                name: "IX_songs_albums_id",
                table: "songs",
                column: "albums_id");

            migrationBuilder.CreateIndex(
                name: "IX_songs_genres_id",
                table: "songs",
                column: "genres_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicCollectionSong");

            migrationBuilder.DropTable(
                name: "music_collections");

            migrationBuilder.DropTable(
                name: "songs");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
