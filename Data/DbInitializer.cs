using ComisionesVentas.Models;
using System;
using System.Linq;

namespace ComisionesVentas.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Ventas.Any())
            {
                return;
            }

            var vendedores = new Vendedor[]
            {
                new Vendedor{Id=1, Nombre="Fernando Galindo"},
                new Vendedor{Id=2, Nombre="Juan Feijoo"},
                new Vendedor{Id=3, Nombre="Michelle Reyes"},
                new Vendedor{Id=4, Nombre="Gabriel Bortoleto"},
                new Vendedor{Id=5, Nombre="Charles Lecrec"}
            };
            foreach (var v in vendedores)
            {
                context.Vendedores.Add(v);
            }
            context.SaveChanges();

            var ventas = new Venta[]
            {
                new Venta{Id=1, Fecha=new DateTime(2026, 1, 1), Monto=500, VendedorId=1, ReglaId=1, PorcentajeComision=5, Comision=25},
                new Venta{Id=2, Fecha=new DateTime(2026, 1, 12), Monto=1200, VendedorId=1, ReglaId=2, PorcentajeComision=10, Comision=120},
                new Venta{Id=3, Fecha=new DateTime(2026, 2, 5), Monto=6000, VendedorId=1, ReglaId=3, PorcentajeComision=15, Comision=900},
                new Venta{Id=4, Fecha=new DateTime(2026, 1, 8), Monto=300, VendedorId=2, ReglaId=1, PorcentajeComision=5, Comision=15},
                new Venta{Id=5, Fecha=new DateTime(2026, 2, 10), Monto=2000, VendedorId=2, ReglaId=2, PorcentajeComision=10, Comision=200},
                new Venta{Id=6, Fecha=new DateTime(2026, 3, 1), Monto=7000, VendedorId=2, ReglaId=3, PorcentajeComision=15, Comision=1050},
                new Venta{Id=7, Fecha=new DateTime(2026, 1, 15), Monto=800, VendedorId=3, ReglaId=1, PorcentajeComision=5, Comision=40},
                new Venta{Id=8, Fecha=new DateTime(2026, 2, 18), Monto=3500, VendedorId=3, ReglaId=2, PorcentajeComision=10, Comision=350},
                new Venta{Id=9, Fecha=new DateTime(2026, 3, 10), Monto=5500, VendedorId=3, ReglaId=3, PorcentajeComision=15, Comision=825},
                new Venta{Id=10, Fecha=new DateTime(2026, 1, 20), Monto=400, VendedorId=4, ReglaId=1, PorcentajeComision=5, Comision=20},
                new Venta{Id=11, Fecha=new DateTime(2026, 2, 22), Monto=1800, VendedorId=4, ReglaId=2, PorcentajeComision=10, Comision=180},
                new Venta{Id=12, Fecha=new DateTime(2026, 3, 15), Monto=8000, VendedorId=4, ReglaId=3, PorcentajeComision=15, Comision=1200},
                new Venta{Id=13, Fecha=new DateTime(2026, 1, 25), Monto=900, VendedorId=5, ReglaId=1, PorcentajeComision=5, Comision=45},
                new Venta{Id=14, Fecha=new DateTime(2026, 2, 28), Monto=2500, VendedorId=5, ReglaId=2, PorcentajeComision=10, Comision=250},
                new Venta{Id=15, Fecha=new DateTime(2026, 3, 20), Monto=6500, VendedorId=5, ReglaId=3, PorcentajeComision=15, Comision=975},
                new Venta{Id=16, Fecha=new DateTime(2026, 2, 2), Monto=700, VendedorId=1, ReglaId=1, PorcentajeComision=5, Comision=35},
                new Venta{Id=17, Fecha=new DateTime(2026, 3, 5), Monto=3000, VendedorId=2, ReglaId=2, PorcentajeComision=10, Comision=300},
                new Venta{Id=18, Fecha=new DateTime(2026, 3, 25), Monto=7500, VendedorId=3, ReglaId=3, PorcentajeComision=15, Comision=1125},
                new Venta{Id=19, Fecha=new DateTime(2026, 3, 28), Monto=1000, VendedorId=4, ReglaId=1, PorcentajeComision=5, Comision=50},
                new Venta{Id=20, Fecha=new DateTime(2026, 3, 30), Monto=4500, VendedorId=5, ReglaId=2, PorcentajeComision=10, Comision=450}
            };
            foreach (var v in ventas)
            {
                context.Ventas.Add(v);
            }
            context.SaveChanges();
        }
    }
}
