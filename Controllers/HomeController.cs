using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComisionesVentas.Models;
using ComisionesVentas.Data;
using System.Linq;

namespace ComisionesVentas.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index(DateTime? startDate, DateTime? endDate, int? vendedorId)
    {
        var ventasQuery = _context.Ventas.Include(v => v.Vendedor).AsQueryable();

        // Defaults from HTML
        if (!startDate.HasValue && !endDate.HasValue && !vendedorId.HasValue && Request.Method == "GET" && !Request.Query.Any())
        {
            startDate = new DateTime(2025, 6, 1);
            endDate = new DateTime(2025, 6, 17);
        }

        if (startDate.HasValue)
        {
            ventasQuery = ventasQuery.Where(v => v.Fecha >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            ventasQuery = ventasQuery.Where(v => v.Fecha <= endDate.Value);
        }

        if (vendedorId.HasValue && vendedorId.Value > 0)
        {
            ventasQuery = ventasQuery.Where(v => v.VendedorId == vendedorId.Value);
        }

        var resultados = ventasQuery.OrderBy(v => v.Fecha).ToList();

        // Server-side calculation of commissions
        foreach (var venta in resultados)
        {
            if (venta.Monto <= 1000)
            {
                venta.ReglaId = 1;
                venta.PorcentajeComision = 5;
            }
            else if (venta.Monto <= 5000)
            {
                venta.ReglaId = 2;
                venta.PorcentajeComision = 10;
            }
            else
            {
                venta.ReglaId = 3;
                venta.PorcentajeComision = 15;
            }
            venta.Comision = venta.Monto * venta.PorcentajeComision / 100m;
        }

        var viewModel = new ComisionViewModel
        {
            StartDate = startDate,
            EndDate = endDate,
            VendedorId = vendedorId,
            Vendedores = _context.Vendedores.ToList(),
            Resultados = resultados,
            TotalComision = resultados.Sum(v => v.Comision)
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
