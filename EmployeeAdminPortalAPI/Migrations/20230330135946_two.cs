using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAdminPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Employee",
                newName: "roleId");

            migrationBuilder.AddColumn<long>(
                name: "deptId",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentID",
                table: "Department",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "deptId",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "roleId",
                table: "Employee",
                newName: "role");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentID",
                table: "Department",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Department",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");
        }
    }
}
