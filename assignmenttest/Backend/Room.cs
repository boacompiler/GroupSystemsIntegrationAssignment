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
        private int id;
		private string name;
		private string description;
		private float price;
		private Hotel hotel;

        #region Getters
        public List<DateTime> ReservedDates
        {
            get
            {
                return reservedDates;
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

        public string Description
        {
            get
            {
                return description;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }
        }

        internal Hotel Hotel
        {
            get
            {
                return hotel;
            }
        }
        #endregion

        public Room(Hotel hotel, int id, string name, string description, float price, List<DateTime> reservedDates)
        {
			this.hotel = hotel;
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.reservedDates = reservedDates;
        }

    }
}
