using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabajoPracticoFinal.Models;
using TrabajoPracticoFinal.Repositories;

namespace TrabajoPracticoFinal.Controllers
{
    public class ArticuloController : Controller
    {
        private readonly IArticuloRepository _repository;
        private readonly IMapper _mapper;

        // Inyectamos AutoMapper y el repositorio en el controlador
        public ArticuloController(IArticuloRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;  // Inicializamos AutoMapper
        }

        // Mostrar todos los artículos
        public IActionResult Index()
        {
            var articulos = _repository.GetAll();  // Obtenemos los artículos desde el repositorio
            var articulosDto = _mapper.Map<IEnumerable<ArticuloDto>>(articulos);  // Mapeamos Articulo a ArticuloDto
            return View(articulosDto);  // Pasamos los DTOs a la vista
        }

        // Mostrar el formulario para agregar un artículo
        public IActionResult Create()
        {
            return View();
        }

        // Guardar el nuevo artículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ArticuloDto articuloDto)
        {
            if (ModelState.IsValid)
            {
                var articulo = _mapper.Map<Articulo>(articuloDto);  // Convertimos el DTO a Articulo
                _repository.Add(articulo);
                return RedirectToAction("Index");
            }
            return View(articuloDto);  // Retorna la vista si el modelo no es válido
        }

        // Mostrar el formulario para editar un artículo
        public IActionResult Edit(int id)
        {
            var articulo = _repository.GetById(id);
            if (articulo == null)
            {
                return NotFound();  // Si el artículo no se encuentra, devolver NotFound
            }
            var articuloDto = _mapper.Map<ArticuloDto>(articulo);  // Mapear Articulo a ArticuloDto
            return View(articuloDto);  // Pasar el DTO a la vista
        }

        // Acción POST para actualizar el artículo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ArticuloDto articuloDto)
        {
            if (id != articuloDto.Id)
            {
                return NotFound();  // Si el ID no coincide, retornar NotFound
            }

            if (ModelState.IsValid)
            {
                var articulo = _mapper.Map<Articulo>(articuloDto);  // Convertir ArticuloDto a Articulo
                _repository.Update(articulo);  // Actualizar el artículo
                return RedirectToAction("Index");  // Redirigir a la vista de índice
            }
            return View(articuloDto);  // Si el modelo no es válido, regresar con el DTO
        }

        // Confirmación de eliminación
        public IActionResult Delete(int id)
        {
            var articulo = _repository.GetById(id);
            if (articulo == null)
            {
                return NotFound();  // Si el artículo no existe, devolver NotFound
            }
            var articuloDto = _mapper.Map<ArticuloDto>(articulo);  // Convertir Articulo a ArticuloDto
            return View(articuloDto);  // Pasar el DTO a la vista
        }

        // Eliminar el artículo
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var articulo = _repository.GetById(id);
            if (articulo == null)
            {
                return NotFound();  // Si el artículo no existe, devolver NotFound
            }

            _repository.Delete(id);  // Eliminar el artículo
            return RedirectToAction("Index");  // Redirigir a la vista Index
        }
    }
}
