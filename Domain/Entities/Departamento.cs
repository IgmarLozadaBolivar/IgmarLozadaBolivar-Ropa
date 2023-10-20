namespace Domain.Entities;

public class Departamento : BaseEntity
{
    public string Nombre { get; set; }
    public int IdPaisFK { get; set; }
    public Pais Pais { get; set; }
    public ICollection<Municipio> Municipios { get; set; }
}