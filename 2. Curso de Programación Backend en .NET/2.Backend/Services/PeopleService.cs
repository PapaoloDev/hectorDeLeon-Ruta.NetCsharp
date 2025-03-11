using _2.Backend.Controllers;

namespace _2.Backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (string.IsNullOrEmpty(people.Name) ||
                people.Name.Length <= 2)
                return false;
            else
                return true;
        }
    }
}
