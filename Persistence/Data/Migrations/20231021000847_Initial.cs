using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del cargo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SueldoBase = table.Column<int>(type: "int", nullable: false, comment: "Sueldo base del cargo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del color")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion de la forma de pago")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del genero")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del insumo")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnit = table.Column<int>(type: "int", nullable: false, comment: "Valor unitario del insumo"),
                    StockMin = table.Column<int>(type: "int", nullable: false, comment: "Stock minimo del insumo"),
                    StockMax = table.Column<int>(type: "int", nullable: false, comment: "Stock maximo del insumo")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del pais")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Nombre del rol")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Talla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion de la talla")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talla", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del tipo de estado")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEstado", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del tipo de persona")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TipoProteccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del tipo de proteccion")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProteccion", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false, comment: "Correo del usuario")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, comment: "Contraseña del usuario")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del departamento")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPaisFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_IdPaisFK",
                        column: x => x.IdPaisFK,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, comment: "Descripcion del estado")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estado_TipoEstado_IdTipoEstadoFK",
                        column: x => x.IdTipoEstadoFK,
                        principalTable: "TipoEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdUserFK = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Expires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Revoked = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRol",
                columns: table => new
                {
                    IdUserFK = table.Column<int>(type: "int", nullable: false),
                    IdRolFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRol", x => new { x.IdUserFK, x.IdRolFK });
                    table.ForeignKey(
                        name: "FK_UserRol_Rol_IdRolFK",
                        column: x => x.IdRolFK,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRol_User_IdUserFK",
                        column: x => x.IdUserFK,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del municipio")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdDepartamentoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_IdDepartamentoFK",
                        column: x => x.IdDepartamentoFK,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Prenda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPrenda = table.Column<int>(type: "int", maxLength: 9, nullable: false, comment: "Id unico de prenda"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre de la prenda")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorUnitCOP = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Valor unitario de la prenda en Pesos Colombianos"),
                    ValorUnitUSD = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Valor unitario de la prenda en Dolares Estadounidenses"),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false),
                    IdTipoProteccionFK = table.Column<int>(type: "int", nullable: false),
                    IdGeneroFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prenda_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenda_Genero_IdGeneroFK",
                        column: x => x.IdGeneroFK,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenda_TipoProteccion_IdTipoProteccionFK",
                        column: x => x.IdTipoProteccionFK,
                        principalTable: "TipoProteccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdCliente = table.Column<int>(type: "int", maxLength: 9, nullable: false, comment: "Id unico del cliente"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del cliente")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersonaFK = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Fecha de registro del cliente"),
                    IdMunicipioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Municipio_IdMunicipioFK",
                        column: x => x.IdMunicipioFK,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cliente_TipoPersona_IdTipoPersonaFK",
                        column: x => x.IdTipoPersonaFK,
                        principalTable: "TipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdEmpleado = table.Column<int>(type: "int", maxLength: 9, nullable: false, comment: "Id unico del empleado"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del empleado")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCargoFK = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Fecha de ingreso del empleado"),
                    IdMunicipioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleado_Cargo_IdCargoFK",
                        column: x => x.IdCargoFK,
                        principalTable: "Cargo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleado_Municipio_IdMunicipioFK",
                        column: x => x.IdMunicipioFK,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nit = table.Column<int>(type: "int", maxLength: 9, nullable: false, comment: "Nit de la empresa"),
                    RazonSocial = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Razon social de la empresa")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepresentanteLegal = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Representante legal de la empresa")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "Fecha de creacion de la empresa"),
                    IdMunicipioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Municipio_IdMunicipioFK",
                        column: x => x.IdMunicipioFK,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NitProveedor = table.Column<int>(type: "int", maxLength: 9, nullable: false, comment: "Nit del proveedor"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Nombre del proveedor")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdTipoPersonaFK = table.Column<int>(type: "int", nullable: false),
                    IdMunicipioFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_Municipio_IdMunicipioFK",
                        column: x => x.IdMunicipioFK,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proveedor_TipoPersona_IdTipoPersonaFK",
                        column: x => x.IdTipoPersonaFK,
                        principalTable: "TipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InsumoPrenda",
                columns: table => new
                {
                    IdInsumoFK = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad del insumo de prendas")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoPrenda", x => new { x.IdInsumoFK, x.IdPrendaFK });
                    table.ForeignKey(
                        name: "FK_InsumoPrenda_Insumo_IdPrendaFK",
                        column: x => x.IdPrendaFK,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsumoPrenda_Prenda_IdInsumoFK",
                        column: x => x.IdInsumoFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodInv = table.Column<int>(type: "int", nullable: false, comment: "Codigo unico del inventario"),
                    IdPrendaFK = table.Column<int>(type: "int", nullable: false),
                    ValorVtaCOP = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Valor de venta del inventario en Pesos Colombia"),
                    ValorVtaUSD = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Valor de venta del inventario en Dolares Estadounidenses")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventario_Prenda_IdPrendaFK",
                        column: x => x.IdPrendaFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false, comment: "Fecha de la orden"),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_Cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateOnly>(type: "date", nullable: false, comment: "Fecha de la venta"),
                    IdEmpleadoFK = table.Column<int>(type: "int", nullable: false),
                    IdClienteFK = table.Column<int>(type: "int", nullable: false),
                    IdFormaPagoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_IdClienteFK",
                        column: x => x.IdClienteFK,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Empleado_IdEmpleadoFK",
                        column: x => x.IdEmpleadoFK,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_FormaPago_IdFormaPagoFK",
                        column: x => x.IdFormaPagoFK,
                        principalTable: "FormaPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InsumoProveedor",
                columns: table => new
                {
                    IdInsumoFK = table.Column<int>(type: "int", nullable: false),
                    IdProveedorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoProveedor", x => new { x.IdInsumoFK, x.IdProveedorFK });
                    table.ForeignKey(
                        name: "FK_InsumoProveedor_Insumo_IdInsumoFK",
                        column: x => x.IdInsumoFK,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsumoProveedor_Proveedor_IdProveedorFK",
                        column: x => x.IdProveedorFK,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InventarioTalla",
                columns: table => new
                {
                    IdInventarioFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad del inventario en tallas")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioTalla", x => new { x.IdInventarioFK, x.IdTallaFK });
                    table.ForeignKey(
                        name: "FK_InventarioTalla_Inventario_IdInventarioFK",
                        column: x => x.IdInventarioFK,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioTalla_Talla_IdTallaFK",
                        column: x => x.IdTallaFK,
                        principalTable: "Talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdenFK = table.Column<int>(type: "int", nullable: false),
                    IdPrendaFK = table.Column<int>(type: "int", nullable: false),
                    CantidadProduccir = table.Column<int>(type: "int", nullable: false, comment: "Cantidad a producir"),
                    IdColorFK = table.Column<int>(type: "int", nullable: false),
                    CantidadProducida = table.Column<int>(type: "int", nullable: false, comment: "Cantidad ya producida"),
                    IdEstadoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Color_IdColorFK",
                        column: x => x.IdColorFK,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Estado_IdEstadoFK",
                        column: x => x.IdEstadoFK,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_IdOrdenFK",
                        column: x => x.IdOrdenFK,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Prenda_IdPrendaFK",
                        column: x => x.IdPrendaFK,
                        principalTable: "Prenda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 3, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdVentaFK = table.Column<int>(type: "int", nullable: false),
                    IdProductoFK = table.Column<int>(type: "int", nullable: false),
                    IdTallaFK = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false, comment: "Cantidad del detalle de venta"),
                    ValorUnit = table.Column<decimal>(type: "decimal(65,30)", nullable: false, comment: "Valor unitario del detalle de venta")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Inventario_IdProductoFK",
                        column: x => x.IdProductoFK,
                        principalTable: "Inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Talla_IdTallaFK",
                        column: x => x.IdTallaFK,
                        principalTable: "Talla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleVenta_Venta_IdVentaFK",
                        column: x => x.IdVentaFK,
                        principalTable: "Venta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdCliente",
                table: "Cliente",
                column: "IdCliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdMunicipioFK",
                table: "Cliente",
                column: "IdMunicipioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdTipoPersonaFK",
                table: "Cliente",
                column: "IdTipoPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPaisFK",
                table: "Departamento",
                column: "IdPaisFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdColorFK",
                table: "DetalleOrden",
                column: "IdColorFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdEstadoFK",
                table: "DetalleOrden",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdOrdenFK",
                table: "DetalleOrden",
                column: "IdOrdenFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdPrendaFK",
                table: "DetalleOrden",
                column: "IdPrendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdProductoFK",
                table: "DetalleVenta",
                column: "IdProductoFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdTallaFK",
                table: "DetalleVenta",
                column: "IdTallaFK");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleVenta_IdVentaFK",
                table: "DetalleVenta",
                column: "IdVentaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdCargoFK",
                table: "Empleado",
                column: "IdCargoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdEmpleado",
                table: "Empleado",
                column: "IdEmpleado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_IdMunicipioFK",
                table: "Empleado",
                column: "IdMunicipioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_IdMunicipioFK",
                table: "Empresa",
                column: "IdMunicipioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Nit",
                table: "Empresa",
                column: "Nit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estado_IdTipoEstadoFK",
                table: "Estado",
                column: "IdTipoEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_Nombre",
                table: "Insumo",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsumoPrenda_IdPrendaFK",
                table: "InsumoPrenda",
                column: "IdPrendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoProveedor_IdProveedorFK",
                table: "InsumoProveedor",
                column: "IdProveedorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_CodInv",
                table: "Inventario",
                column: "CodInv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventario_IdPrendaFK",
                table: "Inventario",
                column: "IdPrendaFK");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioTalla_IdTallaFK",
                table: "InventarioTalla",
                column: "IdTallaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_IdDepartamentoFK",
                table: "Municipio",
                column: "IdDepartamentoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdClienteFK",
                table: "Orden",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdEmpleadoFK",
                table: "Orden",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_IdEstadoFK",
                table: "Orden",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdEstadoFK",
                table: "Prenda",
                column: "IdEstadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdGeneroFK",
                table: "Prenda",
                column: "IdGeneroFK");

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdPrenda",
                table: "Prenda",
                column: "IdPrenda",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prenda_IdTipoProteccionFK",
                table: "Prenda",
                column: "IdTipoProteccionFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdMunicipioFK",
                table: "Proveedor",
                column: "IdMunicipioFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_IdTipoPersonaFK",
                table: "Proveedor",
                column: "IdTipoPersonaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_NitProveedor",
                table: "Proveedor",
                column: "NitProveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_IdUserFK",
                table: "RefreshTokens",
                column: "IdUserFK");

            migrationBuilder.CreateIndex(
                name: "IX_Talla_Descripcion",
                table: "Talla",
                column: "Descripcion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRol_IdRolFK",
                table: "UserRol",
                column: "IdRolFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdClienteFK",
                table: "Venta",
                column: "IdClienteFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdEmpleadoFK",
                table: "Venta",
                column: "IdEmpleadoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_IdFormaPagoFK",
                table: "Venta",
                column: "IdFormaPagoFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "DetalleVenta");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "InsumoPrenda");

            migrationBuilder.DropTable(
                name: "InsumoProveedor");

            migrationBuilder.DropTable(
                name: "InventarioTalla");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "UserRol");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Inventario");

            migrationBuilder.DropTable(
                name: "Talla");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "Prenda");

            migrationBuilder.DropTable(
                name: "TipoPersona");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "TipoProteccion");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "TipoEstado");

            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
