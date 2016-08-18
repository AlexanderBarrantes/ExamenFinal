using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Modelos
{
    public class Factura
    {
        [Key]
        public int id { get; set; }
        public string NumeroFactura { get; set; }
        public string productos { get; set; }
        public bool Activo { get; set; }

    }
}
