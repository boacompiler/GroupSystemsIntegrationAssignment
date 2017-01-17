using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmenttest.Backend
{
    class Hotel
    {
        private List<Room> rooms;
        private int id;
		private string name;
        private int rating;
		private string description;
        private string address;
        public static string Hotel_name;
        public static int Hotel_rating;

        #region Getters
        internal List<Room> Rooms
        {
            get
            {
                return rooms;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Rating
        {
            get
            {
                return rating;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
        }
        #endregion

        public Hotel(int id, string name, int rating, string description, string address)
        {
            this.id = id;
            this.name = name;
            this.rating = rating;
            this.description = description;
            this.address = address;
            rooms = new List<Room>();
            Hotel_name = name;
            Hotel_rating = rating;

        }

        public void AddRoom(int id, string name, string description, float price, List<DateTime> reservedDates)
        {
            //cannot be added at construction. so we have to add them later
            Room room = new Room(this,id,name,description,price,reservedDates);
            rooms.Add(room);
        }

        public List<Room> GetRooms()
        {
            //return a list of rooms
            return(rooms); // simply returning and throwing an error if rooms is empty
            if(rooms == null)
            {
                throw new NotImplementedException();
            }
        }

        public List<Room> GetRooms(List<DateTime> freeDates)
        {
            //return a list of rooms based on the dates they are available
            while (id != null)// this should be a foreach for the rooms
            {
                
                    if (freeDates != Room.ReservedDate) ;
                    {
                        return (rooms);
                    }
                
            }
            if (rooms == null)
            {
                throw new NotImplementedException(); //throwing an error if the rooms list is empty
            }
            return(null);//returning something if the other statements come back empty, this shouldn't happen but the program errors without it
        }
			
    }
}
