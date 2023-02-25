namespace ApiRestBambishop.Modelos
{
    public class Mproveedor_producto
    {
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public DateOnly FechaObtencion { get; set; }
        public decimal CostoTotal { get; set; }
        public int CantidadObtenida { get; set; }
    }
}
