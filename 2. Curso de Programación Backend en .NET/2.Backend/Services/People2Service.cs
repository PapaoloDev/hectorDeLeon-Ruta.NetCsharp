using _2.Backend.Controllers;

namespace _2.Backend.Services
{
    public class People2Service : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) ||
                people.Name.Length <= 2 ||
                people.Name.Length > 50)
                return false;
            else
                return true;
        }
    }
}
