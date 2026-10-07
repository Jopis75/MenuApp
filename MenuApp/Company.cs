namespace MenuApp
{
    public class Company
    {
        private readonly List<Person> _persons;

        public Company(int companySize)
        {
            _persons = new List<Person>(companySize);
        }

        public int Size => _persons.Count;

        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        public decimal GetTicketPrice()
        {
            decimal totalPrice = 0.0M;

            foreach (var person in _persons)
            {
                totalPrice += person.GetTicketPrice();
            }

            return totalPrice;
        }
    }
}
