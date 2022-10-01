using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework01
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string? Titulo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Precio PrecioPromocion { get; set; }
        public ICollection <Comentario> ComentarioLista { get; set; }
        public ICollection <LibroAutor> AutorLink { get; set; }
    }
}
