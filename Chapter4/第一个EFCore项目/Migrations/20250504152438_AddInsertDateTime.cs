using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace 第一个EFCore项目.Migrations
{
    /// <inheritdoc />
    public partial class AddInsertDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDateTime",
                table: "T_Books",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InsertDateTime",
                table: "T_Books");
        }
    }
}
