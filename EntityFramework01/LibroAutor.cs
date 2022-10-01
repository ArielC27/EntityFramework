using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework01
{
    public class LibroAutor
    {
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
        public int LibroId { get; set; }
        public Libro Libro { get; set; }

    }
}
