namespace MyHotel.Model
{
    public class Room
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private int numberRoom;

		public int NumberRoom
		{
			get { return numberRoom; }
			set { numberRoom = value; }
		}
		private int countPersons;

		public int CountPersons
		{
			get { return countPersons; }
			set { countPersons = value; }
		}
		private bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; }
		}
		private bool isLux;

		public bool IsLux
		{
			get { return isLux; }
			set { isLux = value; }
		}
		private int price;

		public int Price
		{
			get { return price; }
			set { price = value; }
		}






	}
}
