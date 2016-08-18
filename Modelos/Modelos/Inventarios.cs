using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    public class Inventarios
    {
        [Key]
        public int id { get; set; }
        public string Producto { get; set; }
        public string Precio { get; set; }
        public int Cantidad { get; set; }
        public int CantidadMinima { get; set; }
        public int CantidadMaxima { get; set; }
        public bool GravadoExento { get; set; }
    }
}
