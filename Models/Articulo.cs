namespace TrabajoPracticoFinal.Models
{
    public class Articulo
    {
        public int Id { get; set; }
        public required string Descripcion { get; set; } // Es obligatorio asignar un valor
        public decimal Precio { get; set; }
    }
}
