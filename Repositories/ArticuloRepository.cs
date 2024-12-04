using TrabajoPracticoFinal.Data;
using TrabajoPracticoFinal.Models;  // Asegúrate de agregar este using

namespace TrabajoPracticoFinal.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor que inyecta el contexto
        public ArticuloRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener todos los artículos (seguro de que no sea null)
        public IEnumerable<Articulo> GetAll()
        {
            return _context.Articulos?.ToList() ?? new List<Articulo>();  // Devuelve una lista vacía si Articulos es null
        }

        // Obtener un artículo por su ID (puede devolver null)
        public Articulo? GetById(int id)
        {
            return _context.Articulos?.Find(id);  // Puede devolver null si no se encuentra el artículo
        }

        // Agregar un nuevo artículo (sin verificar null porque Articulos debería ser válido)
        public void Add(Articulo articulo)
        {
            if (articulo != null)
            {
                _context.Articulos?.Add(articulo);
                _context.SaveChanges();  // Guardamos los cambios después de agregar
            }
        }

        // Actualizar un artículo
        public void Update(Articulo articulo)
        {
            if (articulo != null)
            {
                _context.Articulos?.Update(articulo);
                _context.SaveChanges();  // Guardamos los cambios después de actualizar
            }
        }

        // Eliminar un artículo
        public void Delete(int id)
        {
            var articulo = GetById(id);
            if (articulo != null)
            {
                _context.Articulos?.Remove(articulo);
                _context.SaveChanges();  // Guardamos los cambios después de la eliminación
            }
        }

        // Guardar cambios en la base de datos
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
