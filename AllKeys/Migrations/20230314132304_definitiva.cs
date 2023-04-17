using Microsoft.EntityFrameworkCore.Migrations;

namespace AllKeys.Migrations
{
    public partial class definitiva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Descuentos",
                columns: table => new
                {
                    DescuentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescuentoCod = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descuentos", x => x.DescuentoId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolNombre = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "Videojuegos",
                columns: table => new
                {
                    VideojuegoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideojuegoName = table.Column<string>(maxLength: 20, nullable: false),
                    VideojuegoCompania = table.Column<string>(maxLength: 30, nullable: false),
                    Descripccion = table.Column<string>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    Tipo = table.Column<string>(maxLength: 20, nullable: false),
                    Disponible = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videojuegos", x => x.VideojuegoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioNombre = table.Column<string>(maxLength: 30, nullable: false),
                    UsuarioContra = table.Column<string>(maxLength: 20, nullable: false),
                    UsuarioCorreo = table.Column<string>(nullable: false),
                    UsuarioTlf = table.Column<string>(nullable: false),
                    UsuarioColor_Fav = table.Column<string>(maxLength: 20, nullable: false),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRegistrados",
                columns: table => new
                {
                    UsuarioRegistradoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarjeta = table.Column<string>(maxLength: 18, nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRegistrados", x => x.UsuarioRegistradoId);
                    table.ForeignKey(
                        name: "FK_UsuarioRegistrados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Copias",
                columns: table => new
                {
                    CopiaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CopiaCod = table.Column<string>(maxLength: 20, nullable: false),
                    VideojuegoId = table.Column<int>(nullable: false),
                    UsuarioRegistradoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Copias", x => x.CopiaId);
                    table.ForeignKey(
                        name: "FK_Copias_UsuarioRegistrados_UsuarioRegistradoId",
                        column: x => x.UsuarioRegistradoId,
                        principalTable: "UsuarioRegistrados",
                        principalColumn: "UsuarioRegistradoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Copias_Videojuegos_VideojuegoId",
                        column: x => x.VideojuegoId,
                        principalTable: "Videojuegos",
                        principalColumn: "VideojuegoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObtenerDescuento",
                columns: table => new
                {
                    ObtenerDescuentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescuentoId = table.Column<int>(nullable: false),
                    UsuarioRegistradoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObtenerDescuento", x => x.ObtenerDescuentoId);
                    table.ForeignKey(
                        name: "FK_ObtenerDescuento_Descuentos_DescuentoId",
                        column: x => x.DescuentoId,
                        principalTable: "Descuentos",
                        principalColumn: "DescuentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObtenerDescuento_UsuarioRegistrados_UsuarioRegistradoId",
                        column: x => x.UsuarioRegistradoId,
                        principalTable: "UsuarioRegistrados",
                        principalColumn: "UsuarioRegistradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RolId", "RolNombre" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Usuario" },
                    { 3, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "Videojuegos",
                columns: new[] { "VideojuegoId", "Descripccion", "Disponible", "Precio", "Tipo", "VideojuegoCompania", "VideojuegoName" },
                values: new object[,]
                {
                    { 1, "Juego competitivo basado en plantar bombas y cubrir", 1, 12.5, "Shooter", "Valve", "Csgo" },
                    { 2, "Juego competitivo basado en plantar bombas y cubrir", 1, 14.0, "Shooter", "Riot Games", "Valorant" },
                    { 3, "Shooter", 1, 30.0, "Shooter", "Activision", "Call of Duty" },
                    { 4, "Juego creativo", 1, 16.0, "Survival", "Mojang", "Minecraft" },
                    { 5, "Perdida de tiempo", 1, 0.0, "MMO", "Riot Games", "League of Legends" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "RolId", "UsuarioColor_Fav", "UsuarioContra", "UsuarioCorreo", "UsuarioNombre", "UsuarioTlf" },
                values: new object[,]
                {
                    { 1, 1, "amarillo", "abc123.", "admin@gmail.com", "Admin", "616756340" },
                    { 2, 2, "amarillo", "abc123.", "user1@gmail.com", "User1", "694234651" },
                    { 4, 2, "azul", "abc123.", "carlos@gmail.com", "Carlos", "616736340" },
                    { 5, 2, "verde", "abc123.", "martin@gmail.com", "Martin", "611236340" },
                    { 3, 3, "azul", "abc123.", "user2@gmail.com", "User2", "194244554" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Copias_UsuarioRegistradoId",
                table: "Copias",
                column: "UsuarioRegistradoId");

            migrationBuilder.CreateIndex(
                name: "IX_Copias_VideojuegoId",
                table: "Copias",
                column: "VideojuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObtenerDescuento_DescuentoId",
                table: "ObtenerDescuento",
                column: "DescuentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObtenerDescuento_UsuarioRegistradoId",
                table: "ObtenerDescuento",
                column: "UsuarioRegistradoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRegistrados_UsuarioId",
                table: "UsuarioRegistrados",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Copias");

            migrationBuilder.DropTable(
                name: "ObtenerDescuento");

            migrationBuilder.DropTable(
                name: "Videojuegos");

            migrationBuilder.DropTable(
                name: "Descuentos");

            migrationBuilder.DropTable(
                name: "UsuarioRegistrados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
