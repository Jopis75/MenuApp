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
        
        public bool IsSeniorCitizen => Age > 64;

        public bool HasFreeTicket => Age < 5 || Age > 100;

        public decimal GetTicketPrice()
        {
            if (HasFreeTicket)
            {
                return Cinema.FreeTicketPrice;
            }
            else if (IsYouth)
            {
                return Cinema.YouthTicketPrice;
            }
            else if (IsSeniorCitizen)
            {
                return Cinema.SeniorCitizenTicketPrice;
            }
            else
            {
                return Cinema.RegularTicketPrice;
            }
        }
    }
}
