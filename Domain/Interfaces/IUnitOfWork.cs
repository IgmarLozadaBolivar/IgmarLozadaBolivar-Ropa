namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRol Roles { get; }
    IUser Users { get; }
    IOrden Ordenes { get; }
    IEmpleado Empleados { get; }
    ICargo Cargos { get; }
    ICliente Clientes { get; }
    IColor Colores { get; }
    IDepartamento Departamentos { get; }
    IDetalleOrden DetalleOrdenes { get; }
    IDetalleVenta DetalleVentas { get; }
    IEmpresa Empresas { get; }
    IEstado Estados { get; }
    IFormaPago FormaPagos { get; }
    IGenero Generos { get; }
    IInsumo Insumos { get; }
    IInventario Inventarios { get; }
    IMunicipio Municipios { get; }
    IPais Paises { get; }
    IPrenda Prendas { get; }
    IProveedor Proveedores { get; }
    ITalla Tallas { get; }
    ITipoEstado TipoEstados { get; }
    ITipoPersona TipoPersonas { get; }
    ITipoProteccion TipoProtecciones  { get; }
    IVenta Ventas { get; }
    Task<int> SaveAsync();
}