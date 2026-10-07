namespace MenuApp
{
    public class Company
    {
        private readonly List<Person> _people;

        public Company(int companySize)
        {
            _people = new List<Person>(companySize);
        }

        public int Size => _people.Count;

        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        public decimal GetTicketPrice()
        {
            decimal totalPrice = 0.0M;

            foreach (var person in _people)
            {
                totalPrice += Cinema.GetTicketPrice(person);
            }

            return totalPrice;
        }
    }
}
