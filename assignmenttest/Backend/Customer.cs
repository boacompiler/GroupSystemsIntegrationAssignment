using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmenttest.Backend
{
    class Customer
    {
        private int id;
        private string firstName;
        private string secondName;
        private string address;

        #region Getters and Setters
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return secondName;
            }

            set
            {
                secondName = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        #endregion

        public Customer(int id, string firstName, string secondName, string address)
        {
            this.id = id;
            this.firstName = firstName;
            this.secondName = secondName;
            this.address = address;
        }

    }
}
