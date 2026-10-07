namespace MenuApp
{
    public class Person(int age)
    {
        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Age cannot be negative.");
                }

                age = value;
            }
        }

        public bool IsYouth => Age < 20;
        
        public bool IsPensioner => Age > 64;

        public decimal GetTicketPrice()
        {
            if (IsYouth)
            {
                return Cinema.YouthTicketPrice;
            }
            else if (IsPensioner)
            {
                return Cinema.PensionerTicketPrice;
            }
            else
            {
                return Cinema.RegularTicketPrice;
            }
        }
    }
}
