﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XMLDataImporter.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrientacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Codigo",
                table: "Orientaciones",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Orientaciones");
        }
    }
}
