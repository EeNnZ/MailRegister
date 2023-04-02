using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MailRegisterServer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationScaffold : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Age = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((18))"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC0736C0F0DB", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddresseeId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: true),
                    rowguid = table.Column<Guid>(type: "uniqueidentifier", nullable: true, defaultValueSql: "(newid())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Mail__3214EC07EFC40749", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Mail__AddresseeI__3D5E1FD2",
                        column: x => x.AddresseeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Mail__SenderId__3E52440B",
                        column: x => x.SenderId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mail_AddresseeId",
                table: "Mail",
                column: "AddresseeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mail_SenderId",
                table: "Mail",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mail");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
