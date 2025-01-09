using System;
using Microsoft.EntityFrameworkCore;

namespace Auktioner.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<SaleItem> SaleItems {get; set;}

}
