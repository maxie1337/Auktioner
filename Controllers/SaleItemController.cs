using Microsoft.AspNetCore.Mvc;
using Auktioner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class SaleItemController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public SaleItemController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SaleItem item)
    {
        item.Id = GenerateUniqueId();
        item.CreatedByUserId = _userManager.GetUserId(User);
        item.IsSold = false;
        _context.SaleItems.Add(item);
        await _context.SaveChangesAsync();

        return RedirectToAction("MyItems");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(string id)
    {
        var item = await _context.SaleItems.FindAsync(id);
        if (item == null || item.CreatedByUserId != _userManager.GetUserId(User))
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(SaleItem item)
    {
        var existingItem = await _context.SaleItems.FindAsync(item.Id);
        if (existingItem == null || existingItem.CreatedByUserId != _userManager.GetUserId(User))
        {
            return NotFound();
        }

        existingItem.Name = item.Name;
        existingItem.Description = item.Description;
        existingItem.StartingPrice = item.StartingPrice;
        existingItem.Category = item.Category;
        existingItem.Decade = item.Decade;

        await _context.SaveChangesAsync();
        return RedirectToAction("MyItems");
    }

    public async Task<IActionResult> MyItems()
    {
        var userId = _userManager.GetUserId(User);
        var items = await _context.SaleItems
            .Where(i => i.CreatedByUserId == userId)
            .ToListAsync();

        return View(items);
    }
   
    private string GenerateUniqueId()
    {
        var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        var random = new Random();
        var idPart1 = new string(Enumerable.Range(0, 3).Select(x => letters[random.Next(letters.Length)]).ToArray());
        var idPart2 = random.Next(100000, 999999);
        return $"{idPart1}{idPart2}";
    }
}