using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;
namespace Persistence;

public class DbAppContextSeed
{
    public static async Task SeedAsync(DbAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            // * Inicio de las insersiones en la Database
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Users.Any())
            {
                using (var reader = new StreamReader(ruta + @"/Data/Csv/User.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<User>();
                        context.Users.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }

            }

            if (!context.UserRols.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\UserRol.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<UserRol>();
                        List<UserRol> entidad = new List<UserRol>();
                        foreach (var item in list)
                        {
                            entidad.Add(new UserRol
                            {
                                IdUserFK = item.IdUserFK,
                                IdRolFK = item.IdRolFK
                            });
                        }
                        context.UserRols.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Cargos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Cargo.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Cargo>();
                        List<Cargo> entidad = new List<Cargo>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Cargo
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion,
                                SueldoBase = item.SueldoBase
                            });
                        }
                        context.Cargos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Paises.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Pais.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Pais>();
                        List<Pais> entidad = new List<Pais>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Pais
                            {
                                Id = item.Id,
                                Nombre = item.Nombre
                            });
                        }
                        context.Paises.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Departamentos.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Departamento.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Departamento>();
                        List<Departamento> entidad = new List<Departamento>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Departamento
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                IdPaisFK = item.IdPaisFK
                            });
                        }
                        context.Departamentos.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Municipios.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Municipio.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Municipio>();
                        List<Municipio> entidad = new List<Municipio>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Municipio
                            {
                                Id = item.Id,
                                Nombre = item.Nombre,
                                IdDepartamentoFK = item.IdDepartamentoFK
                            });
                        }
                        context.Municipios.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Empresas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Empresa.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Empresa>();
                        List<Empresa> entidad = new List<Empresa>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Empresa
                            {
                                Id = item.Id,
                                Nit = item.Nit,
                                RazonSocial = item.RazonSocial,
                                RepresentanteLegal = item.RepresentanteLegal,
                                FechaCreacion = item.FechaCreacion,
                                IdMunicipioFK = item.IdMunicipioFK
                            });
                        }
                        context.Empresas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Colors.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Color.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Color>();
                        List<Color> entidad = new List<Color>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Color
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion,
                            });
                        }
                        context.Colors.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.TipoEstados.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\TipoEstado.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<TipoEstado>();
                        List<TipoEstado> entidad = new List<TipoEstado>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TipoEstado
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion,
                            });
                        }
                        context.TipoEstados.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.Estados.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\Estado.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<Estado>();
                        List<Estado> entidad = new List<Estado>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Estado
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion,
                            });
                        }
                        context.Estados.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }

            if (!context.TipoPersonas.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\TipoPersona.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null,
                        MissingFieldFound = null
                    }))
                    {
                        var list = csv.GetRecords<TipoPersona>();
                        List<TipoPersona> entidad = new List<TipoPersona>();
                        foreach (var item in list)
                        {
                            entidad.Add(new TipoPersona
                            {
                                Id = item.Id,
                                Descripcion = item.Descripcion,
                            });
                        }
                        context.TipoPersonas.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
            // * Fin de las insersiones en la Database
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<DbAppContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(DbAppContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Rols.Any())
            {
                var roles = new List<Rol>()
                        {
                            new Rol{Id=1, Nombre="Administrador"},
                            new Rol{Id=2, Nombre="Empleado"},
                        };
                context.Rols.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<DbAppContext>();
            logger.LogError(ex.Message);
        }
    }
}