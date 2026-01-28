using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_slider1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tilte3",
                table: "Sliders",
                newName: "Title3");

            migrationBuilder.RenameColumn(
                name: "Tilte2",
                table: "Sliders",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "Tilte1",
                table: "Sliders",
                newName: "Title1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title3",
                table: "Sliders",
                newName: "Tilte3");

            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "Sliders",
                newName: "Tilte2");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "Sliders",
                newName: "Tilte1");
        }
    }
}
