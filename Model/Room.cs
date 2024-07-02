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
		private int titleRoom;
		public int TitleRoom
		{
			get { return titleRoom; }
			set { titleRoom = value; }
		}
		private bool isBusy;
		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; }
		}
		private int price;
		public int Price
		{
			get { return price; }
			set { price = value; }
		}
		private DateTime dateCheckIn;

		public DateTime DateCheckIn
		{
			get { return dateCheckIn; }
			set { dateCheckIn = value; }
		}
		private DateTime dateCheckOut;

		public DateTime DateCheckOut
		{
			get { return dateCheckOut; }
			set { dateCheckOut = value; }
		}








	}
}
