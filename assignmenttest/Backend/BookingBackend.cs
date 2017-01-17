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
        private List<BillableItem> items;

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

		public void MakeBooking(Room room, List<DateTime> datesReserved,List<BillableItem> billableItems, Customer customer)
        {
            //this will be passed to a helper class that handles booking in a batch process
            throw new NotImplementedException();
        }

		public List<Hotel> GetHotels()
		{
			//return a list of hotels
            return(hotels);
            if (hotels == null) //returning hotels and throwing an error if there are no hotels
            {
                throw new NotImplementedException();
            }
		}

        public List<Hotel> GetHotels(int rating)
        {
          
            //return a list of hotels by rating
            if (Hotel.Hotel_rating == 5)
            {
                
                return (Hotel.Hotel_name);// the list does not want to return a string, and i have not been able to change this
                                          // this return also goes in all the ifs down to if rating =1
            }
            else if (Hotel.Hotel_rating == 4)
            {
                
            }
            else if (Hotel.Hotel_rating == 3)
            {
                
            }
            else if (Hotel.Hotel_rating == 2)
            {
                
            }
            else if (Hotel.Hotel_rating == 1)
            {
                
            }
            else
            {
               return(null);
            }

            //throw new NotImplementedException();
        }

        public List<Room> GetRooms()
		{
			//return a list of all rooms from all hotels
            //for(all hotels);  //this should be a foreach in hotels
            {
            // return(Room.RoomID);
            }
            
			throw new NotImplementedException();
		}

        public List<Room> GetRooms(List<DateTime> freeDates)
        {
            //return a list of all available rooms from all hotels 

            if (Room.ReservedDate != freeDates)
            {
                // return (Room.RoomID); 
            }

            //then as above

            // if (hotels == null)
            {
                throw new NotImplementedException();
            }

        }

        public List<BillableItem> GetBillableItems()
		{
			//return a list of available items
            return (Hotel.Hotel_name);
            if (hotels == null)
            {
                throw new NotImplementedException();
            }
		}

    }
}
