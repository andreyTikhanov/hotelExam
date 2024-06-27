using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Model
{
    public class User
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private string userName;

		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}
		private string userEmail;

		public string UserEmail
		{
			get { return userEmail; }
			set { userEmail = value; }
		}
		private string userPhone;

		public string UserPhone
		{
			get { return userPhone; }
			set { userPhone = value; }
		}




	}
}
