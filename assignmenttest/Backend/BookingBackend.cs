using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmenttest.Backend
{
    class BookingBackend
    {
        private List<Hotel> hotels;

        public BookingBackend()
        {

        }

        #region Getters and Setters

        public List<Hotel> Hotels
        {
            get
            {
                return hotels;
            }

            set
            {
                hotels = value;
            }
        }

        #endregion

        public bool DatabaseConnectionActive()
        {
			//returns a bool relating to the status of the db connection
			throw new NotImplementedException();
        }

		public void MakeBooking(Room room, List<DateTime> datesReserved, Customer customer)
        {
            //this will be passed to a helper class that handles booking in a batch process
            throw new NotImplementedException();
        }

		public List<Hotel> GetHotels()
		{
			//return a list of hotels
			throw new NotImplementedException();
		}

		public List<Room> GetRooms()
		{
			//return a list of all rooms from all hotels
			throw new NotImplementedException();
		}

		public List<BillableItem> GetBillableItems()
		{
			//return a list of available items
			throw new NotImplementedException();
		}

    }
}
