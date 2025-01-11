using Microsoft.AspNetCore.Mvc;
using Auktioner.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
        item.CreatedByUserId = _userManager.GetUserId(User);
        _context.SaleItems.Add(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Inventory");
    }

    [Authorize]
    public async Task<IActionResult> Edit(int id)
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

    await _context.SaveChangesAsync();
    return RedirectToAction("Index", "Inventory");
}
}