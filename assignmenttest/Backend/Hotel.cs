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
        }

        public List<Room> GetRooms()
        {
            //return a list of rooms
            throw new NotImplementedException();
        }

        public List<Room> GetRooms(List<DateTime> freeDates)
        {
            //return a list of rooms based on the dates they are available
            throw new NotImplementedException();
        }
			
    }
}
