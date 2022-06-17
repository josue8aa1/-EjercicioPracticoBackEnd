using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class version03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Prospectos_ProspectoId",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "ProspectoId",
                table: "Documentos",
                newName: "ProspectosId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_ProspectoId",
                table: "Documentos",
                newName: "IX_Documentos_ProspectosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Prospectos_ProspectosId",
                table: "Documentos",
                column: "ProspectosId",
                principalTable: "Prospectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Prospectos_ProspectosId",
                table: "Documentos");

            migrationBuilder.RenameColumn(
                name: "ProspectosId",
                table: "Documentos",
                newName: "ProspectoId");

            migrationBuilder.RenameIndex(
                name: "IX_Documentos_ProspectosId",
                table: "Documentos",
                newName: "IX_Documentos_ProspectoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Prospectos_ProspectoId",
                table: "Documentos",
                column: "ProspectoId",
                principalTable: "Prospectos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
