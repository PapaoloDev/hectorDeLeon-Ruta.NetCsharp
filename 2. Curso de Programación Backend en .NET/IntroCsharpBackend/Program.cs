using System.Text.Json;

People people = new People()
{
    Name = "John",
    Age = 25
};
string json = JsonSerializer.Serialize(people);
Console.WriteLine(json);

string myJson = @"{""Name"":""John"",""Age"":25}";
People? myPeople = JsonSerializer.Deserialize<People>(myJson);
if (myPeople != null)
    Console.WriteLine(myPeople.Name);

public class People
{
    public string Name { get; set; }
    public int Age { get; set; }
}