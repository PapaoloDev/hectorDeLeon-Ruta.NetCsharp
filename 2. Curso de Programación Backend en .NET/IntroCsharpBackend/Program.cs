Console.WriteLine(Sub(5, 3));
Console.WriteLine(GetTomorrow(DateTime.Now));

Beer beer = new Beer { Name = "Heineken", Price = 2.5 };
Beer beerUpper = ToUpper(beer);
Console.WriteLine(beerUpper.Name);

int Sub(int a, int b) => a - b;
DateTime GetTomorrow(DateTime date) => date.AddDays(1);

Beer ToUpper(Beer beer)
{
    Beer beerUpper = new()
    {
        Name = beer.Name.ToUpper(),
        Price = beer.Price
    };
    return beerUpper;
}

var show = Show;
Some(show, "Hello");

string Show(string message)
{
    return message.ToUpper();
}
;

void Some(Func<string, string> fn, string message)
{
    Console.WriteLine("Before");
    Console.WriteLine(fn(message));
    Console.WriteLine("After");
}

class Beer
{
    public string Name { get; set; }
    public double Price { get; set; }
}

