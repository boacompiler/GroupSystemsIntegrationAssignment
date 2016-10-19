using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmenttest.Backend
{
    class Room
    {
        private List<DateTime> reservedDates;
		private string name;
		private string description;
		private float price;
		private Hotel hotel;

		public Room(Hotel hotel)
        {
			this.hotel = hotel;
        }

    }
}
