
using System;

Sale sale = new Sale(100);
var sale2 = new Sale(200);
Sale sale3 = new(300);

SaleWithTax saleWithTax = new SaleWithTax(400, 19);

Console.WriteLine(sale.GetInfo());
Console.WriteLine(sale2.GetInfo());
Console.WriteLine(sale3.GetInfo());

Console.WriteLine(saleWithTax.GetInfo());
Console.WriteLine(saleWithTax.GetInfoTax());

class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        Tax = tax;
    }

    public string GetInfoTax()
    {
        return $"Total: {Total + Tax}";
    }

    public override string GetInfo()
    {
        return $"Total: {Total}, Tax: {Tax}";
    }
}

class Sale
{
    public decimal Total { get; set; }

    public Sale(decimal total)
    {
        Total = total;
    }

    public virtual string GetInfo()
    {
        return $"Total: {Total}";
    }

}