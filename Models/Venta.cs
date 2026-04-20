using System;

namespace ComisionesVentas.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public int VendedorId { get; set; }
        public Vendedor? Vendedor { get; set; }
        
        public int ReglaId { get; set; }
        public int PorcentajeComision { get; set; }
        public decimal Comision { get; set; }
    }
}
