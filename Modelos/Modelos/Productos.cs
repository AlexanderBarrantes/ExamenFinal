using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    public class Productos
    {
        [Key]
        public int Identificador { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string CasaFabricación { get; set; }
        public string TipoUnidad { get; set; }
        public string Departamento { get; set; }
        public bool Activo { get; set; }
        public double Descuento { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        public int Unidad { get; set; }
        public double Impuesto { get; set; }
    }
}
