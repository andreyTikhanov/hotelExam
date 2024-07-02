namespace MyHotel.Model
{
    public class UserDiscountCard
    {
        private decimal welcomeBonus = 500;
        private string cardName = "Бонуная карта";
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string title;

        public string Tilte
        {
            get { return title; }
            set { title = value; }
        }
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public UserDiscountCard()
        {
            title = cardName;
            balance = welcomeBonus;
        }





    }
}
