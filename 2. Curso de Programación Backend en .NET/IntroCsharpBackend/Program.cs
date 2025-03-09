
Sale sale = new();
Beer beer = new();

Some(sale);
Some(beer);

void Some(ISave save)
{
    save.Save();
}

interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

public class Sale : ISale, ISave
{
    public decimal Total { get; set; }

    public void Save()
    {
        Console.WriteLine("se guardo en BD");
    }
}

public class Beer: ISave
{
    public void Save()
    {
        Console.WriteLine("se guardo beer en BD");
    }
}