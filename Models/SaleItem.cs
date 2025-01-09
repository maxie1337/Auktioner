using System;

namespace Auktioner.Models;

public class SaleItem
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string Description {get; set;}
    public decimal StartingPrice {get; set;}
    public bool IsSold {get; set;}
    public decimal? FinalPrice {get; set;}
    public string CreatedByUserId {get; set;}

}
