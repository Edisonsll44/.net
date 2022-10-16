using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Soulsplit.Api.AccesoDatos.Migrations
{
    public partial class ModeloDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoEnumeracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 60, nullable: true),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoEnumeracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormaPago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormaPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionalidades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreFuncionalidad = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionalidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombrePagina = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    IconoMenu = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    UrlMenu = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Orden = table.Column<int>(type: "integer", nullable: false),
                    PorDefecto = table.Column<bool>(type: "boolean", nullable: false),
                    PadreId = table.Column<Guid>(type: "uuid", nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_PadreId",
                        column: x => x.PadreId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombrePais = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Nacionalidad = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Latitud = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    Longitud = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    CodigoRegional = table.Column<string>(type: "varchar", maxLength: 7, nullable: true),
                    Bandera = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParametrosSistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreParametro = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    DescripcionParametro = table.Column<string>(type: "varchar", nullable: true),
                    Valor1 = table.Column<string>(type: "varchar", maxLength: 1024, nullable: true),
                    Valor2 = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Valor3 = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParametrosSistema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreRol = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    RolInstalacion = table.Column<bool>(type: "boolean", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCuenta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 30, nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCuenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPersona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPersona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetalleEstado",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 60, nullable: true),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    EstadoEnumeracionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleEstado_EstadoEnumeracion_EstadoEnumeracionId",
                        column: x => x.EstadoEnumeracionId,
                        principalTable: "EstadoEnumeracion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuncionalidadesParametroSistema",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FuncionalidadId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParametroSistemaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuncionalidadesParametroSistema", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuncionalidadesParametroSistema_Funcionalidades_Funcionalid~",
                        column: x => x.FuncionalidadId,
                        principalTable: "Funcionalidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FuncionalidadesParametroSistema_ParametrosSistema_Parametro~",
                        column: x => x.ParametroSistemaId,
                        principalTable: "ParametrosSistema",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoIdentificacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    LongitudMaxima = table.Column<short>(type: "smallint", nullable: false),
                    LongitudMinima = table.Column<short>(type: "smallint", nullable: false),
                    AplicaNacionalidad = table.Column<bool>(type: "boolean", nullable: false),
                    AlgoritmoValidacion = table.Column<string>(type: "varchar", nullable: true),
                    PaisId = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoPersonaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIdentificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoIdentificacion_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoIdentificacion_TipoPersona_TipoPersonaId",
                        column: x => x.TipoPersonaId,
                        principalTable: "TipoPersona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RolId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    DetalleEstadoEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolMenu_DetalleEstado_DetalleEstadoEntityId",
                        column: x => x.DetalleEstadoEntityId,
                        principalTable: "DetalleEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolMenu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolMenu_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Apellidos = table.Column<string>(type: "varchar", maxLength: 50, nullable: true),
                    Identificacion = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    RazonSocial = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    Compuesto = table.Column<string>(type: "varchar", maxLength: 300, nullable: true),
                    NombreComercial = table.Column<string>(type: "varchar", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    Telefono = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Celular = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SaldoActual = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    TelefonoPaisId = table.Column<Guid>(type: "uuid", nullable: true),
                    TipoIdentificacionId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Pais_TelefonoPaisId",
                        column: x => x.TelefonoPaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Persona_TipoIdentificacion_TipoIdentificacionId",
                        column: x => x.TipoIdentificacionId,
                        principalTable: "TipoIdentificacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferidosPersona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferidosPersona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferidosPersona_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreUsuario = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "varchar", maxLength: 60, nullable: false),
                    Clave = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    CodigoReferencia = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    Token = table.Column<string>(type: "varchar", maxLength: 1024, nullable: true),
                    RefreshToken = table.Column<string>(type: "varchar", maxLength: 1024, nullable: true),
                    CodigoOTP = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    VencimientoToken = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EmailConfirmado = table.Column<bool>(type: "boolean", nullable: false),
                    Bloqueado = table.Column<bool>(type: "boolean", nullable: false),
                    OlvidoClave = table.Column<bool>(type: "boolean", nullable: false),
                    SesionActiva = table.Column<bool>(type: "boolean", nullable: false),
                    EsAdministrador = table.Column<bool>(type: "boolean", nullable: false),
                    NumeroIntentos = table.Column<short>(type: "smallint", nullable: true),
                    FotoUsuario = table.Column<byte[]>(type: "bytea", nullable: true),
                    PersonaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriaAccesoUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoConfirmacion = table.Column<string>(type: "varchar", maxLength: 40, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriaAccesoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuditoriaAccesoUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Identificacion = table.Column<string>(type: "varchar", maxLength: 13, nullable: true),
                    TipoIdentificacion = table.Column<string>(type: "varchar", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    UrlImagen = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    IdImagen = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    RespuestaCDN = table.Column<string>(type: "varchar", nullable: true),
                    Comprobante = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    CuentaDeposito = table.Column<string>(type: "varchar", maxLength: 40, nullable: true),
                    IdTransaccional = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    NumeroTarjeta = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    RequestId = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Referencia = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    NombreOperador = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Autorizacion = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Recibo = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    MetodoPago = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(20, 6)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PersonaId = table.Column<Guid>(type: "uuid", nullable: false),
                    BancoId = table.Column<Guid>(type: "uuid", nullable: false),
                    TipoCuentaId = table.Column<Guid>(type: "uuid", nullable: false),
                    FormaPagoId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstadoPagoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioConciliacionId = table.Column<Guid>(type: "uuid", nullable: true),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pago_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_DetalleEstado_EstadoPagoId",
                        column: x => x.EstadoPagoId,
                        principalTable: "DetalleEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_FormaPago_FormaPagoId",
                        column: x => x.FormaPagoId,
                        principalTable: "FormaPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_TipoCuenta_TipoCuentaId",
                        column: x => x.TipoCuentaId,
                        principalTable: "TipoCuenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pago_Usuario_UsuarioConciliacionId",
                        column: x => x.UsuarioConciliacionId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RolId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolUsuario_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialPago",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EstadoConciliacion = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Comprobante = table.Column<string>(type: "varchar", maxLength: 80, nullable: true),
                    NombreOperador = table.Column<string>(type: "varchar", maxLength: 120, nullable: true),
                    Observacion = table.Column<string>(type: "varchar", maxLength: 1024, nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PagoId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    EstadoPagoId = table.Column<Guid>(type: "uuid", nullable: false),
                    Estado = table.Column<string>(type: "varchar", maxLength: 10, nullable: false, unicode: false, defaultValue: "ACTIVO"),
                    UsuarioCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: false, unicode: false, defaultValue: "SOULSPLIT"),
                    UsuarioModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "SOULSPLIT"),
                    HostNameCreacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    HostNameModificacion = table.Column<string>(type: "varchar", maxLength: 80, nullable: true, unicode: false, defaultValue: "HOST"),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    FechaModificacion = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialPago_DetalleEstado_EstadoPagoId",
                        column: x => x.EstadoPagoId,
                        principalTable: "DetalleEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialPago_Pago_PagoId",
                        column: x => x.PagoId,
                        principalTable: "Pago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialPago_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriaAccesoUsuario_UsuarioId",
                table: "AuditoriaAccesoUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleEstado_EstadoEnumeracionId",
                table: "DetalleEstado",
                column: "EstadoEnumeracionId");

            migrationBuilder.CreateIndex(
                name: "IX_NombreDetalleEstado",
                table: "DetalleEstado",
                columns: new[] { "Nombre", "Estado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NombreEstado",
                table: "EstadoEnumeracion",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NombreFuncionalidad",
                table: "Funcionalidades",
                column: "NombreFuncionalidad",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalidadesParametroSistema_FuncionalidadId",
                table: "FuncionalidadesParametroSistema",
                column: "FuncionalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_FuncionalidadesParametroSistema_ParametroSistemaId",
                table: "FuncionalidadesParametroSistema",
                column: "ParametroSistemaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPago_EstadoPagoId",
                table: "HistorialPago",
                column: "EstadoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPago_PagoId",
                table: "HistorialPago",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPago_UsuarioId",
                table: "HistorialPago",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_PadreId",
                table: "Menu",
                column: "PadreId");

            migrationBuilder.CreateIndex(
                name: "IX_NombrePagina",
                table: "Menu",
                columns: new[] { "NombrePagina", "PadreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pago_BancoId",
                table: "Pago",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_EstadoPagoId",
                table: "Pago",
                column: "EstadoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_FormaPagoId",
                table: "Pago",
                column: "FormaPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_PersonaId",
                table: "Pago",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_TipoCuentaId",
                table: "Pago",
                column: "TipoCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_UsuarioConciliacionId",
                table: "Pago",
                column: "UsuarioConciliacionId");

            migrationBuilder.CreateIndex(
                name: "IX_NombrePais",
                table: "Pais",
                column: "NombrePais",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NombreParametro",
                table: "ParametrosSistema",
                column: "NombreParametro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Identificacion",
                table: "Persona",
                column: "Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TelefonoPaisId",
                table: "Persona",
                column: "TelefonoPaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_TipoIdentificacionId",
                table: "Persona",
                column: "TipoIdentificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferidosPersona_PersonaId",
                table: "ReferidosPersona",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_NombreRol",
                table: "Rol",
                column: "NombreRol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuRol",
                table: "RolMenu",
                columns: new[] { "MenuId", "RolId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_DetalleEstadoEntityId",
                table: "RolMenu",
                column: "DetalleEstadoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_RolMenu_RolId",
                table: "RolMenu",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario",
                table: "RolUsuario",
                columns: new[] { "RolId", "UsuarioId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolUsuario_UsuarioId",
                table: "RolUsuario",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_PaisId",
                table: "TipoIdentificacion",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_TipoPersonaId",
                table: "TipoIdentificacion",
                column: "TipoPersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailUsuario",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PersonaId",
                table: "Usuario",
                column: "PersonaId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditoriaAccesoUsuario");

            migrationBuilder.DropTable(
                name: "FuncionalidadesParametroSistema");

            migrationBuilder.DropTable(
                name: "HistorialPago");

            migrationBuilder.DropTable(
                name: "ReferidosPersona");

            migrationBuilder.DropTable(
                name: "RolMenu");

            migrationBuilder.DropTable(
                name: "RolUsuario");

            migrationBuilder.DropTable(
                name: "Funcionalidades");

            migrationBuilder.DropTable(
                name: "ParametrosSistema");

            migrationBuilder.DropTable(
                name: "Pago");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "DetalleEstado");

            migrationBuilder.DropTable(
                name: "FormaPago");

            migrationBuilder.DropTable(
                name: "TipoCuenta");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "EstadoEnumeracion");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "TipoIdentificacion");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropTable(
                name: "TipoPersona");
        }
    }
}
