using Infraestructura.Repositorio.Interfaz;
using Microsoft.EntityFrameworkCore;
using Modelos.Datos;
using Modelos.Entidad;

namespace Infraestructura.Repositorio.Repositorio
{
    public class AutorRepo : IAutorRepo
    {
        private readonly AppDbContexts _Conexion;
        public AutorRepo(AppDbContexts appDbContexts)
        {
            _Conexion = appDbContexts;
        }
        public async Task<bool> AddAutoresRepo(Autores _autores)
        {
            try
            {
                 _Conexion.Autores.Add(_autores);
                return await SaveAutors();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hay un error en la funcion AddAutores {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAutoresRepo(Autores _autores)
        {
            try
            {
                _Conexion.Autores.Remove(_autores);
                return await SaveAutors();
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion DeleteAutores {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ExisteAutoByNombreRepo(string Nombre)
        {
            try
            {
                int Valor = await _Conexion.Autores.CountAsync(a=>a.Nombre==Nombre);
                return Valor > 0;
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion ExisteAutoByNombre {ex.Message}");
                return false;
            }
        }

        public async Task<ICollection<Autores>> GetAutoresRepo()
        {
            try
            {
                return await _Conexion.Autores.ToListAsync();
            }
            catch (Exception ex) {

                Console.WriteLine($"Hay un error en la funcion: GetAutores {ex.Message}");
                return null;
            }
          
        }

        public async Task<Autores> GetAutoresByIdRepo(int Id)
        {

            try
            {

                Autores Repuesta = await _Conexion.Autores.FirstOrDefaultAsync(a => a.Id == Id);
                return Repuesta;
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion: GetAutoresById {ex.Message}");
                return null;

            }

        }

        public async Task<bool> SaveAutors()
        {
            try
            {
                return await _Conexion.SaveChangesAsync()>=0 ? true :false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" hay un error en la funcion GuardarCategoriaRepo {ex.Message}");
                return false;
            }
        }

        public async Task<bool> UpdateAutoresByIdRepo(Autores _autores)
        {
            try
            {
                _Conexion.Autores.Update(_autores);
                return await SaveAutors();
            }
            catch (Exception ex) {
                Console.WriteLine($"Hay un error en la funcion: UpdateAutoresById {ex.Message}");
                return false;
            }
        }
    }
}
