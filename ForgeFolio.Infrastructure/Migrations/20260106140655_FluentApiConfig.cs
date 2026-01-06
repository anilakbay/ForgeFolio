using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForgeFolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FluentApiConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MessageDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_IsDeleted",
                table: "ToDoLists",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_Status",
                table: "ToDoLists",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Testimonials_IsDeleted",
                table: "Testimonials",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedias_IsDeleted",
                table: "SocialMedias",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_IsDeleted",
                table: "Portfolios",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IsDeleted",
                table: "Messages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_IsRead",
                table: "Messages",
                column: "IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_Features_IsDeleted",
                table: "Features",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_IsDeleted",
                table: "Experiences",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IsDeleted",
                table: "Contacts",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_IsDeleted",
                table: "Abouts",
                column: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_IsDeleted",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_Status",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_Testimonials_IsDeleted",
                table: "Testimonials");

            migrationBuilder.DropIndex(
                name: "IX_SocialMedias_IsDeleted",
                table: "SocialMedias");

            migrationBuilder.DropIndex(
                name: "IX_Skills_IsDeleted",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Portfolios_IsDeleted",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Messages_IsDeleted",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_IsRead",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Features_IsDeleted",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_IsDeleted",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_IsDeleted",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_IsDeleted",
                table: "Abouts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MessageDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
