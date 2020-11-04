using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.Template.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    idUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    DNI = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FechaNac = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    idDireccion = table.Column<int>(nullable: false),
                    idCuenta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__645723A605ACEEA6", x => x.idUsuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
