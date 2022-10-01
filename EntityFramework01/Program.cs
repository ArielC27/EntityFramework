using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EntityFramework01
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppVentaLibrosContext())
            {
                //// CONSULTA SIMPLE DE LA TABLA LIBRO
                var Libros = db.Libro.AsNoTracking();
                foreach (var Libro in Libros)
                {
                    Libro libro = new Libro();
                    Console.WriteLine(Libro.LibroId);
                    Console.WriteLine(Libro.Titulo);
                    Console.WriteLine(Libro.Descripcion);
                    Console.WriteLine(Libro.FechaPublicacion);
                    Console.WriteLine("------------------------");
                }

                ////-----------------------------------------------------------------------------------------------------------

                // CONSULTA CON TABLA LIBRO RELACIONADA CON PRECIO POR FK
                // USO INCLUDE PARA DECIRLE CUÁL ES LA FK

                var librosA = db.Libro.Include(x => x.PrecioPromocion).AsNoTracking();
                foreach (var libro in librosA)
                {
                    // libro.PrecioPromocion.PrecioActual PARA ITERAR ENTRE LAS PROPERTYS DE LA ENTIDAD PRECIOPROMOCION RELACIONADA POR FK 
                    Console.WriteLine(libro.Titulo + " -- $" + libro.PrecioPromocion.PrecioActual);
                }

                ////-----------------------------------------------------------------------------------------------------------
                // CONSULTA CON TABLA LIBRO RELACIONADA CON COMENTARIOS
                // USO INCLUDE PARA DECIRLE CUÁL ES LA FK

                var libros1 = db.Libro.Include(x => x.ComentarioLista).AsNoTracking();
                foreach (var libro in libros1)
                {
                    Console.WriteLine(libro.Titulo);
                    foreach (var comentario in libro.ComentarioLista)
                    {
                        Console.WriteLine("---- " + comentario.ComentarioTexto);
                    }
                }

                ////-----------------------------------------------------------------------------------------------------------
                //// CONSULTA CON TABLA LIBRO RELACIONADA CON LIBROAUTOR POR FK RELACIONADA A SU VEZ CON AUTOR
                //// Uso ThenInclude para seguir la cadena de relaciones

                var libros2 = db.Libro.Include(x => x.AutorLink).ThenInclude(xi => xi.Autor);
                foreach (var libro in libros2)
                {
                    Console.WriteLine(libro.Titulo);
                    foreach (var autlink in libro.AutorLink)
                    {
                        Console.WriteLine("---- " + autlink.Autor.Nombre);
                    }
                }

                ///=============== INSERT ===============//

                //*** Insertar Autores en la base de datos
                var autor1 = new Autor
                {
                    Nombre = "Lorenzo",
                    Apellidos = "Insigne",
                    Grado = "Master"
                };
                db.Add(autor1);

                var autor2 = new Autor
                {
                    Nombre = "Pedro",
                    Apellidos = "Paredes",
                    Grado = "Master"
                };
                db.Add(autor2);

                var autor3 = new Autor
                {
                    Nombre = "Paola",
                    Apellidos = "Martinez",
                    Grado = "Master"
                };
                db.Add(autor3);

                var estadoInsert = db.SaveChanges();
                Console.WriteLine("Estado transaccion ===> " + estadoInsert);

                ///=============== UPDATE ===============//

                //*** Modificar autores en la base de datos
                var autorupdate = db.Autor.Single(x => x.Nombre == "Paola");
                if (autorupdate != null)
                {
                    autorupdate.Apellidos = "Mendez";
                    autorupdate.Grado = "Biologo";
                    var estadoUpdate = db.SaveChanges();
                    Console.WriteLine("Estado transaccion ==> " + estadoUpdate);
                }

                ///=============== DELETE ===============//

                //*** Eliminar autores en la base de datos
                var autordelete = db.Autor.Single(x => x.AutorId == 6);
                if (autordelete != null)
                {
                    db.Remove(autordelete);
                    var estado = db.SaveChanges();
                    Console.WriteLine("Estado de trasaccion ===> " + estado);
                }

            }
            Console.ReadLine();
        }
    }
}