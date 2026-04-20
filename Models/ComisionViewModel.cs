using System;
using System.Collections.Generic;

namespace ComisionesVentas.Models
{
    public class ComisionViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? VendedorId { get; set; }

        public List<Vendedor> Vendedores { get; set; } = new List<Vendedor>();
        public List<Venta> Resultados { get; set; } = new List<Venta>();
        
        public decimal TotalComision { get; set; }
    }
}
