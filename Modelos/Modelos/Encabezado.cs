using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
   public class Encabezado
    {
        [Key]
        public int id { get; set; }
        public string Cliente { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public double Subtotal { get; set; }
        public double Impuestos { get; set; }
        public double Total { get; set; }





    }
}
