using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private readonly DbAppContext context;
        private RolRepo _roles;
        private UserRepo _users;
        private OrdenRepo _ordenes;
        private EmpleadoRepo _empleados;
        private CargoRepo _cargos;
        private TipoEstadoRepo _tipoEstados;
        private EmpresaRepo _empresas;
        private TipoPersonaRepo _tipoPersonas;
        private TipoProteccionRepo _tipoProtecciones;
        private ColorRepo _colores;
        private VentaRepo _ventas;
        private TallaRepo _tallas;
        private ProveedorRepo _proveedores;
        private PrendaRepo _prendas;
        private PaisRepo _paises;
        private MunicipioRepo _municipios;
        private InsumoRepo _insumos;
        private InventarioRepo _inventarios;
        private GeneroRepo _generos;
        private ClienteRepo _clientes;
        private DepartamentoRepo _departamentos;
        private FormaPagoRepo _formaPagos;
        private EstadoRepo _estados;
        private DetalleOrdenRepo _detalleOrdenes;
        private DetalleVentaRepo _detalleVentas;

        public UnitOfWork(DbAppContext _context)
        {
            context = _context;
        }

        public IRol Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RolRepo(context);
                }
                return _roles;
            }
        }

        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepo(context);
                }
                return _users;
            }
        }

        public IOrden Ordenes
        {
            get
            {
                if (_ordenes == null)
                {
                    _ordenes = new OrdenRepo(context);
                }
                return _ordenes;
            }
        }

        public IEmpleado Empleados
        {
            get
            {
                if (_empleados == null)
                {
                    _empleados = new EmpleadoRepo(context);
                }
                return _empleados;
            }
        }

        public ICargo Cargos
        {
            get
            {
                if (_cargos == null)
                {
                    _cargos = new CargoRepo(context);
                }
                return _cargos;
            }
        }

        public ICliente Clientes
        {
            get
            {
                if (_clientes == null)
                {
                    _clientes = new ClienteRepo(context);
                }
                return _clientes;
            }
        }

        public IColor Colores
        {
            get
            {
                if (_colores == null)
                {
                    _colores = new ColorRepo(context);
                }
                return _colores;
            }
        }

        public IDepartamento Departamentos
        {
            get
            {
                if (_departamentos == null)
                {
                    _departamentos = new DepartamentoRepo(context);
                }
                return _departamentos;
            }
        }

        public IDetalleOrden DetalleOrdenes
        {
            get
            {
                if (_detalleOrdenes == null)
                {
                    _detalleOrdenes = new DetalleOrdenRepo(context);
                }
                return _detalleOrdenes;
            }
        }

        public IDetalleVenta DetalleVentas
        {
            get
            {
                if (_detalleVentas == null)
                {
                    _detalleVentas = new DetalleVentaRepo(context);
                }
                return _detalleVentas;
            }
        }

        public IEstado Estados
        {
            get
            {
                if (_estados == null)
                {
                    _estados = new EstadoRepo(context);
                }
                return _estados;
            }
        }

        public IFormaPago FormaPagos
        {
            get
            {
                if (_formaPagos == null)
                {
                    _formaPagos = new FormaPagoRepo(context);
                }
                return _formaPagos;
            }
        }

        public IGenero Generos
        {
            get
            {
                if (_generos == null)
                {
                    _generos = new GeneroRepo(context);
                }
                return _generos;
            }
        }

        public IInsumo Insumos
        {
            get
            {
                if (_insumos == null)
                {
                    _insumos = new InsumoRepo(context);
                }
                return _insumos;
            }
        }

        public IInventario Inventarios
        {
            get
            {
                if (_inventarios == null)
                {
                    _inventarios = new InventarioRepo(context);
                }
                return _inventarios;
            }
        }

        public IMunicipio Municipios
        {
            get
            {
                if (_municipios == null)
                {
                    _municipios = new MunicipioRepo(context);
                }
                return _municipios;
            }
        }

        public IPrenda Prendas
        {
            get
            {
                if (_prendas == null)
                {
                    _prendas = new PrendaRepo(context);
                }
                return _prendas;
            }
        }

        public IPais Paises
        {
            get
            {
                if (_paises == null)
                {
                    _paises = new PaisRepo(context);
                }
                return _paises;
            }
        }

        public IProveedor Proveedores
        {
            get
            {
                if (_proveedores == null)
                {
                    _proveedores = new ProveedorRepo(context);
                }
                return _proveedores;
            }
        }

        public ITalla Tallas
        {
            get
            {
                if (_tallas == null)
                {
                    _tallas = new TallaRepo(context);
                }
                return _tallas;
            }
        }

        public ITipoEstado TipoEstados
        {
            get
            {
                if (_tipoEstados == null)
                {
                    _tipoEstados = new TipoEstadoRepo(context);
                }
                return _tipoEstados;
            }
        }

        public ITipoPersona TipoPersonas
        {
            get
            {
                if (_tipoPersonas == null)
                {
                    _tipoPersonas = new TipoPersonaRepo(context);
                }
                return _tipoPersonas;
            }
        }

        public ITipoProteccion TipoProtecciones
        {
            get
            {
                if (_tipoProtecciones == null)
                {
                    _tipoProtecciones = new TipoProteccionRepo(context);
                }
                return _tipoProtecciones;
            }
        }

        public IVenta Ventas
        {
            get
            {
                if (_ventas == null)
                {
                    _ventas = new VentaRepo(context);
                }
                return _ventas;
            }
        }

        public IEmpresa Empresas
        {
            get
            {
                if (_empresas == null)
                {
                    _empresas = new EmpresaRepo(context);
                }
                return _empresas;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }

}