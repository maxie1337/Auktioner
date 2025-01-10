using Microsoft.AspNetCore.Mvc;
using Auktioner.Models;

public class InventoryController : Controller
{
    private readonly AppDbContext _context;

    public InventoryController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var items = _context.SaleItems.ToList();
        return View(items);
    }
}