namespace TrabajoPracticoFinal.Models
{
    public class ArticuloDto
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; }  // Marcar como "required"
        public decimal Precio { get; set; }
    }
}
