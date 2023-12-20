using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AssociateV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_to_do_projects_project_id",
                table: "to_do");

            migrationBuilder.AlterColumn<long>(
                name: "project_id",
                table: "to_do",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_to_do_projects_project_id",
                table: "to_do",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_to_do_projects_project_id",
                table: "to_do");

            migrationBuilder.AlterColumn<long>(
                name: "project_id",
                table: "to_do",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "fk_to_do_projects_project_id",
                table: "to_do",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id");
        }
    }
}
