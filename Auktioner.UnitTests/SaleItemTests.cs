namespace Auktioner.UnitTests;
using Xunit;
using Auktioner.Models;
using Auktioner.Controllers;
public class SaleItemTests
{
    [Fact]
    public void TestSaleItemCreation()
    {
        var saleItem = new SaleItem
        {
            Name = "Test Item",
            Category = "Electronics",
            StartingPrice = 100,
            Description = "A test item."
        };

        Assert.NotNull(saleItem);
        Assert.Equal("Test Item", saleItem.Name);
    }

    [Fact]
    public void TestEditSaleItem()
    {
        var saleItem = new SaleItem
        {
            Name = "Old Item",
            StartingPrice = 50
        };

        saleItem.Name = "Updated Item";
        saleItem.StartingPrice = 75;

        Assert.Equal("Updated Item", saleItem.Name);
        Assert.Equal(75, saleItem.StartingPrice);
    }
}
