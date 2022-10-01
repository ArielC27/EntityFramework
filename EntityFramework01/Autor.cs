using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework01
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Grado { get; set; }
        public byte[]? FotoPerfil { get; set; }
        public ICollection<LibroAutor> AutorLink { get; set; }

    }
}
