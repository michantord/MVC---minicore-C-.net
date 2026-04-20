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
                new Vendedor{Id=1, Nombre="Ana Gomez"},
                new Vendedor{Id=2, Nombre="Carlos Ruiz"},
                new Vendedor{Id=3, Nombre="María López"},
                new Vendedor{Id=4, Nombre="Pedro Sánchez"},
                new Vendedor{Id=5, Nombre="Lucía Martínez"}
            };
            foreach (var v in vendedores)
            {
                context.Vendedores.Add(v);
            }
            context.SaveChanges();

            var ventas = new Venta[]
            {
                new Venta{Id=1, Fecha=DateTime.Parse("2025-06-01"), Monto=500, VendedorId=1, ReglaId=1, PorcentajeComision=5, Comision=25},
                new Venta{Id=2, Fecha=DateTime.Parse("2025-06-02"), Monto=1200, VendedorId=1, ReglaId=2, PorcentajeComision=10, Comision=120},
                new Venta{Id=3, Fecha=DateTime.Parse("2025-06-03"), Monto=6000, VendedorId=1, ReglaId=3, PorcentajeComision=15, Comision=900},
                new Venta{Id=4, Fecha=DateTime.Parse("2025-06-04"), Monto=300, VendedorId=2, ReglaId=1, PorcentajeComision=5, Comision=15},
                new Venta{Id=5, Fecha=DateTime.Parse("2025-06-05"), Monto=2000, VendedorId=2, ReglaId=2, PorcentajeComision=10, Comision=200},
                new Venta{Id=6, Fecha=DateTime.Parse("2025-06-06"), Monto=7000, VendedorId=2, ReglaId=3, PorcentajeComision=15, Comision=1050},
                new Venta{Id=7, Fecha=DateTime.Parse("2025-06-07"), Monto=800, VendedorId=3, ReglaId=1, PorcentajeComision=5, Comision=40},
                new Venta{Id=8, Fecha=DateTime.Parse("2025-06-08"), Monto=3500, VendedorId=3, ReglaId=2, PorcentajeComision=10, Comision=350},
                new Venta{Id=9, Fecha=DateTime.Parse("2025-06-09"), Monto=5500, VendedorId=3, ReglaId=3, PorcentajeComision=15, Comision=825},
                new Venta{Id=10, Fecha=DateTime.Parse("2025-06-10"), Monto=400, VendedorId=4, ReglaId=1, PorcentajeComision=5, Comision=20},
                new Venta{Id=11, Fecha=DateTime.Parse("2025-06-11"), Monto=1800, VendedorId=4, ReglaId=2, PorcentajeComision=10, Comision=180},
                new Venta{Id=12, Fecha=DateTime.Parse("2025-06-12"), Monto=8000, VendedorId=4, ReglaId=3, PorcentajeComision=15, Comision=1200},
                new Venta{Id=13, Fecha=DateTime.Parse("2025-06-13"), Monto=900, VendedorId=5, ReglaId=1, PorcentajeComision=5, Comision=45},
                new Venta{Id=14, Fecha=DateTime.Parse("2025-06-14"), Monto=2500, VendedorId=5, ReglaId=2, PorcentajeComision=10, Comision=250},
                new Venta{Id=15, Fecha=DateTime.Parse("2025-06-15"), Monto=6500, VendedorId=5, ReglaId=3, PorcentajeComision=15, Comision=975},
                new Venta{Id=16, Fecha=DateTime.Parse("2025-06-16"), Monto=700, VendedorId=1, ReglaId=1, PorcentajeComision=5, Comision=35},
                new Venta{Id=17, Fecha=DateTime.Parse("2025-06-16"), Monto=3000, VendedorId=2, ReglaId=2, PorcentajeComision=10, Comision=300},
                new Venta{Id=18, Fecha=DateTime.Parse("2025-06-17"), Monto=7500, VendedorId=3, ReglaId=3, PorcentajeComision=15, Comision=1125},
                new Venta{Id=19, Fecha=DateTime.Parse("2025-06-17"), Monto=1000, VendedorId=4, ReglaId=1, PorcentajeComision=5, Comision=50},
                new Venta{Id=20, Fecha=DateTime.Parse("2025-06-17"), Monto=4500, VendedorId=5, ReglaId=2, PorcentajeComision=10, Comision=450}
            };
            foreach (var v in ventas)
            {
                context.Ventas.Add(v);
            }
            context.SaveChanges();
        }
    }
}
