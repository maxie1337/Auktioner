using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auktioner.Models;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions <AppDbContext> options) : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<SaleItem> SaleItems {get; set;}

}
