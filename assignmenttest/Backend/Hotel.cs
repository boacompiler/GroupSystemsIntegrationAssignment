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
		private string name;
		private string description;

        public Hotel()
        {
			
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
