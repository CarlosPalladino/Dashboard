using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newClientColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Cuit", "Name" },
                values: new object[] { new Guid("ee1560cf-efb0-458a-a3d8-e4dd16958461"), "Av. Siempre Viva 321", 20456789012L, "Juan Pérez" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: new Guid("ee1560cf-efb0-458a-a3d8-e4dd16958461"));
        }
    }
}
