using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework01
{
    public class Precio
    {
        public int PrecioId { get; set; }
        public decimal PrecioActual { get; set; }
        public decimal Promocion { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }
    }
}
