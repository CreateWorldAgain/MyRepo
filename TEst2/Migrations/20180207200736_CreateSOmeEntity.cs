using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TEst2.Migrations
{
    public partial class CreateSOmeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImportFileInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateFile = table.Column<DateTime>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    ImportDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportFileInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportFileInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SerialInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ImportFileInfoId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Reference1 = table.Column<string>(nullable: true),
                    Reference2 = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerialInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SerialInfo_ImportFileInfo_ImportFileInfoId",
                        column: x => x.ImportFileInfoId,
                        principalTable: "ImportFileInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImportFileInfo_UserId",
                table: "ImportFileInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SerialInfo_ImportFileInfoId",
                table: "SerialInfo",
                column: "ImportFileInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerialInfo");

            migrationBuilder.DropTable(
                name: "ImportFileInfo");
        }
    }
}
