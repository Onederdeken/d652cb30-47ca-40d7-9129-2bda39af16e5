using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace job_tasks.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    INN = table.Column<string>(type: "longtext", nullable: false),
                    TypeClient = table.Column<string>(type: "longtext", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "founders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    INN = table.Column<string>(type: "longtext", nullable: false),
                    PersonName = table.Column<string>(type: "longtext", nullable: false),
                    PersonSecondName = table.Column<string>(type: "longtext", nullable: false),
                    PersonDadName = table.Column<string>(type: "longtext", nullable: false),
                    ClientId = table.Column<Guid>(type: "char(36)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_founders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_founders_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_founders_ClientId",
                table: "founders",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "founders");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
