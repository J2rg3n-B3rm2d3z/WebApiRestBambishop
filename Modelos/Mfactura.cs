namespace ApiRestBambishop.Modelos
{
    public class Mfactura
    {
        public int IdFactura { get; set; }
        public int IdCliente { get; set; }
        public DateOnly FechaEmision { get; set; }
        public decimal Impuestos { get; set; }
        public decimal Descuento { get; set; }
    }
}
