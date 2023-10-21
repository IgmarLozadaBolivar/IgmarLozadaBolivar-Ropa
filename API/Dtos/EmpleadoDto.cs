using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class EmpleadoDto : BaseEntity
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public int IdCargoFK { get; set; }
        //public Cargo Cargo { get; set; }
        public List<EstadoDto> EstadoDtos { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdMunicipioFK { get; set; }
    }
}