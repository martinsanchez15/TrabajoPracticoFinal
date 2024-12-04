using TrabajoPracticoFinal.Models;  // Agrega este using

namespace TrabajoPracticoFinal.Repositories
{
    public interface IArticuloRepository
    {
        IEnumerable<Articulo> GetAll();  // Este es el tipo correcto
        Articulo? GetById(int id);
        void Add(Articulo articulo);  // Implementado en ArticuloRepository
        void Update(Articulo articulo);
        void Delete(int id);
        void Save();
    }
}
