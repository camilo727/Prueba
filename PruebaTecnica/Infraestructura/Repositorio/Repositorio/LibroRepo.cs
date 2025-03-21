using Infraestructura.Repositorio.Interfaz;
using Microsoft.EntityFrameworkCore;
using Modelos.Datos;
using Modelos.Entidad;

namespace Infraestructura.Repositorio.Repositorio
{
    public class LibroRepo : ILibroRepo
    {
        private readonly AppDbContexts _Conexion;
        public LibroRepo(AppDbContexts appDbContexts)
        {
            _Conexion = appDbContexts;
        }
        public async Task<bool> AddLibroRepo(Libro _libro)
        {
            try
            {
                await _Conexion.Libros.AddAsync(_libro);
                return await SaveLibroRepo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hay un error en la funcion AddLibroRepo {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteLibroRepo(Libro _libro)
        {
            try
            {
                _Conexion.Libros.Remove(_libro);
                return await SaveLibroRepo();
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion DeleteLibroRepo {ex.Message}");
                return false;
            }
            
        }

        public async Task<bool> ExisteLibroAndAutorById(int Id)
        {
            try
            {
                int Valor = await _Conexion.Libros.CountAsync(x => x.AutorId == Id);
                return Valor > 0;
            }
            catch (Exception ex) {
                Console.WriteLine($" hay un error en la funcion ExisteLibroRepo {ex.Message}");
                return false;
            }
           

        }

        public async Task<bool> ExisteLibroNombreRepo(string Nombre)
        {
            try
            {
                int Valor = await _Conexion.Libros.CountAsync(x => x.Titulo == Nombre);
                return Valor > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" hay un error en la funcion ExisteLibroRepo {ex.Message}");
                return false;
            }
           
        }

        public async Task<Libro> GetLibroByIdRepo(int id)
        {
            try
            {
               Libro Result = await _Conexion.Libros.FirstOrDefaultAsync(x => x.Id == id);
                return Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" hay un error en la funcion GetLibroByIdRepo {ex.Message}");
                return null;
            }
        }

        public async Task<ICollection<Libro>> GetLibroRepo()
        {
            try
            {
                return await _Conexion.Libros.Include(x=>x.Autores).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" hay un error en la funcion GetLibroRepo {ex.Message}");
                return null;
            }
        }

        public async Task<bool> SaveLibroRepo()
        {
            try
            {
                return await _Conexion.SaveChangesAsync() >= 0 ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" hay un error en la funcion SaveLibroRepo {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateLibroRepo(Libro _libro)
        {
            try
            {
                _Conexion.Libros.Update(_libro);
                return await SaveLibroRepo();
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion UpdateLibroRepo {ex.Message}");
                return false;
            }
        }
    }
}
