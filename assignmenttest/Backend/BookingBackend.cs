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
            this.hotels = this.GetHotels();
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
            return true;
        }

		public void MakeBooking(Room room, List<DateTime> datesReserved,List<BillableItem> billableItems, Customer customer)
        {
            //this will be passed to a helper class that handles booking in a batch process
            //throw new NotImplementedException();
        }

		public List<Hotel> GetHotels()
		{
            //return a list of hotels
            List<Hotel> myhotels = new List<Hotel>();

            string mydescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ligula turpis, vestibulum nec pharetra quis, ullamcorper sit amet orci. Mauris eget velit ac urna tempus sagittis vel sit amet elit. Integer auctor accumsan urna, imperdiet semper neque aliquet sit amet. In augue nisl, blandit sodales lectus eu, porttitor semper nulla. Nullam vitae nunc ligula. Interdum et malesuada fames ac ante ipsum primis in faucibus. ";

            string myaddress = " fake road\nfake city\nfake county\nPU4 2MT";

            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 14; i++)
            {
                DateTime day = new DateTime(2016,1,i+1);
                dates.Add(day);
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime day = new DateTime(2016, 3, i+10);
                dates.Add(day);
            }
            for (int i = 0; i < 3; i++)
            {
                DateTime day = new DateTime(2016, 7, i+20);
                dates.Add(day);
            }

            for (int i = 0; i < 25; i++)
            {
                Hotel myHotel = new Hotel(i, "hotel " + i, (i % 5) + 1, mydescription, (1 + i) + myaddress);

                for (int j = 0; j < 50; j++)
                {
                    myHotel.AddRoom(j,"room "+(j+1),"a nice room",50f,dates);
                }
                myhotels.Add(myHotel);
            }

            return myhotels;
		}

        public List<Hotel> GetHotels(int rating)
        {
            //return a list of hotels by rating
            List<Hotel> myhotels = new List<Hotel>();

            string mydescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ligula turpis, vestibulum nec pharetra quis, ullamcorper sit amet orci. Mauris eget velit ac urna tempus sagittis vel sit amet elit. Integer auctor accumsan urna, imperdiet semper neque aliquet sit amet. In augue nisl, blandit sodales lectus eu, porttitor semper nulla. Nullam vitae nunc ligula. Interdum et malesuada fames ac ante ipsum primis in faucibus. ";

            string myaddress = " fake road\nfake city\nfake county\nPU4 2MT";

            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 14; i++)
            {
                DateTime day = new DateTime(2016, 1, i + 1);
                dates.Add(day);
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime day = new DateTime(2016, 3, i + 10);
                dates.Add(day);
            }
            for (int i = 0; i < 3; i++)
            {
                DateTime day = new DateTime(2016, 7, i + 20);
                dates.Add(day);
            }

            for (int i = 0; i < 7; i++)
            {
                Hotel myHotel = new Hotel(i, "hotel " + i, rating, mydescription, (1 + i) + myaddress);

                for (int j = 0; j < 50; j++)
                {
                    myHotel.AddRoom(j, "room " + (j + 1), "a nice room", 50f, dates);
                }
                myhotels.Add(myHotel);
            }

            return myhotels;
        }

        public List<Room> GetRooms()
		{
            //return a list of all rooms from all hotels
            List<Hotel> myhotels = new List<Hotel>();
            List<Room> myrooms = new List<Room>();

            string mydescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ligula turpis, vestibulum nec pharetra quis, ullamcorper sit amet orci. Mauris eget velit ac urna tempus sagittis vel sit amet elit. Integer auctor accumsan urna, imperdiet semper neque aliquet sit amet. In augue nisl, blandit sodales lectus eu, porttitor semper nulla. Nullam vitae nunc ligula. Interdum et malesuada fames ac ante ipsum primis in faucibus. ";

            string myaddress = " fake road\nfake city\nfake county\nPU4 2MT";

            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 14; i++)
            {
                DateTime day = new DateTime(2016, 1, i + 1);
                dates.Add(day);
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime day = new DateTime(2016, 3, i + 10);
                dates.Add(day);
            }
            for (int i = 0; i < 3; i++)
            {
                DateTime day = new DateTime(2016, 7, i + 20);
                dates.Add(day);
            }

            for (int i = 0; i < 25; i++)
            {
                Hotel myHotel = new Hotel(i, "hotel " + i, (i % 5) + 1, mydescription, (1 + i) + myaddress);

                for (int j = 0; j < 50; j++)
                {
                    myHotel.AddRoom(j, "room " + (j + 1), "a nice room", 50f, dates);
                    myrooms.Add(myHotel.Rooms[myHotel.Rooms.Count - 1]);
                }
                myhotels.Add(myHotel);
            }

            return myrooms;
        }

        public List<Room> GetRooms(List<DateTime> freeDates)
        {
            //return a list of all available rooms from all hotels 
            //return a list of all rooms from all hotels
            List<Hotel> myhotels = new List<Hotel>();
            List<Room> myrooms = new List<Room>();

            string mydescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum ligula turpis, vestibulum nec pharetra quis, ullamcorper sit amet orci. Mauris eget velit ac urna tempus sagittis vel sit amet elit. Integer auctor accumsan urna, imperdiet semper neque aliquet sit amet. In augue nisl, blandit sodales lectus eu, porttitor semper nulla. Nullam vitae nunc ligula. Interdum et malesuada fames ac ante ipsum primis in faucibus. ";

            string myaddress = " fake road\nfake city\nfake county\nPU4 2MT";

            List<DateTime> dates = new List<DateTime>();
            for (int i = 0; i < 14; i++)
            {
                DateTime day = new DateTime(2016, 1, i + 1);
                dates.Add(day);
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime day = new DateTime(2016, 3, i + 10);
                dates.Add(day);
            }
            for (int i = 0; i < 3; i++)
            {
                DateTime day = new DateTime(2016, 7, i + 20);
                dates.Add(day);
            }

            for (int i = 0; i < 7; i++)
            {
                Hotel myHotel = new Hotel(i, "hotel " + i, (i % 5) + 1, mydescription, (1 + i) + myaddress);

                for (int j = 0; j < 45; j++)
                {
                    myHotel.AddRoom(j, "room " + (j + 1), "a nice room", 50f, dates);
                    myrooms.Add(myHotel.Rooms[myHotel.Rooms.Count - 1]);
                }
                myhotels.Add(myHotel);
            }

            return myrooms;
        }

        public List<BillableItem> GetBillableItems()
		{
            //return a list of available items
            List<BillableItem> bills = new List<BillableItem>();
            for (int i = 0; i < 15; i++)
            {
                BillableItem bill = new BillableItem(i,"item "+(i + 1),"this is a billable item, it can be purchased in addition to a room booking.",25f);
                bills.Add(bill);
            }
            return bills;
		}

    }
}
