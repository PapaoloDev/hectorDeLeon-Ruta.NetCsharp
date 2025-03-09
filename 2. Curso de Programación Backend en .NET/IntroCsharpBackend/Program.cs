var names = new List<string>()
{
    "John", "Jane", "Jack", "Jilll"
};

var namesResult = from name in names
                  where name.Length > 4
                  orderby name descending
                  select name;

var nameResult2 = names.Where(name => name.Length <= 4)
    .OrderByDescending(name => name);

foreach (var name in nameResult2)
{
    Console.WriteLine(name);
}