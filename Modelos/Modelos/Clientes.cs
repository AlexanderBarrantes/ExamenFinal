using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
  public  class Clientes
    {
        [Key]
        public int id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string Dirección { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        public string Tipo { get; set; }
        public double Descuento { get; set; }
    }
}
