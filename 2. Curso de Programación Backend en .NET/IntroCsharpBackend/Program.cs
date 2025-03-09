var numbers = new MyList<int>(5);
var names = new MyList<string>(5);
var beers = new MyList<Beer>(2);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);
Console.WriteLine(numbers.GetContent());

names.Add("John");
names.Add("Doe");
names.Add("Jane");
names.Add("Smith");
names.Add("Alice");
names.Add("Bob");
Console.WriteLine(names.GetContent());

beers.Add(new Beer { Name = "Beer1", Price = 1.5 });
beers.Add(new Beer { Name = "Beer2", Price = 2.5 });
beers.Add(new Beer { Name = "Beer3", Price = 3.5 });
Console.WriteLine(beers.GetContent());

public class MyList<T>
{
    private List<T> _list;
    private int _limit;

    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>(); // Initialize _list to avoid CS8618
    }

    public void Add(T elem)
    {
        if (_list.Count < _limit)
            _list.Add(elem);
        else
            Console.WriteLine("List is full");
    }

    public string GetContent()
    {
        string content = "";
        foreach (var elem in _list)
        {
            content += elem + ", ";
        }

        return content;
    }
}

public class Beer
{
    public string Name { get; set; }
    public double Price { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
}
