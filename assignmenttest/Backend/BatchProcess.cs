using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using assignmenttest.Backend;
using System.IO;

namespace assignmenttest
{
    //handles loading and inserting data into database, if the database connection is lost, inserts are stored to file.
	class BatchProcess
	{
        private MySqlConnection conDataBase;
        private string constring;
        DataSet dataSet;
        MySqlDataAdapter dataAdapter;

        private List<Hotel> hotels = new List<Hotel>();
        private List<BillableItem> items = new List<BillableItem>();

        int currentBookingID = 0;
        int currentCustomerID = 0;

        List<string> commandBatch;

        #region Getters

        internal List<Hotel> Hotels
        {
            get
            {
                return hotels;
            }
        }

        internal List<BillableItem> Items
        {
            get
            {
                return items;
            }
        }

        #endregion

        public BatchProcess ()
		{
            GetData();
            ConvertData();

            commandBatch = new List<string>();
            LoadBatch();
            ProcessBatch();
        }
        /// <summary>
        /// Makes a booking in the database using the provided arguments
        /// </summary>
        /// <param name="room">the room that is being booked</param>
        /// <param name="datesReserved">a list of the consecutive days it is booked for (can be just the first and last date it is reserved)</param>
        /// <param name="billableItems">a list of the billable items attached to the booking</param>
        /// <param name="customer">the customer making the booking</param>
        public void MakeBooking(Room room, List<DateTime> datesReserved, List<BillableItem> billableItems, Customer customer)
        {
            int idbooking = currentBookingID;
            currentBookingID++;
            int idroom = room.Id;
            string datebegin = datesReserved[0].Year + "-" + datesReserved[0].Month + "-" + datesReserved[0].Day;
            int last = datesReserved.Count - 1;
            string dateend = datesReserved[last].Year + "-" + datesReserved[last].Month + "-" + datesReserved[last].Day;
            //we set the customer id to something that is definitely unique
            customer.Id = currentCustomerID;
            currentCustomerID++;
            int customerid = customer.Id;

            commandBatch.Add("INSERT INTO booking (`idbooking`, `idroom`, `date_begin`, `date_end`, `billable_person`) VALUES ('"+idbooking+"', '"+idroom+"', '"+datebegin+"', '"+dateend+"', '"+customerid+"');");
            commandBatch.Add("INSERT INTO person (`idperson`, `first_name`, `second_name`, `contact_details`) VALUES ('"+customer.Id+"','"+customer.FirstName+"','"+customer.SecondName+"','"+customer.Address+"');");
            for (int i = 0; i < billableItems.Count; i++)
            {
                commandBatch.Add("INSERT INTO bookingitems (`billable_item`, `idbooking`) VALUES ('"+billableItems[i].Id+"','"+idbooking+"');");
            }
  
            if (ConnectTest())
            {
                ProcessBatch();
            }
            else
            {
                SaveBatch();
            }
        }
        /// <summary>
        /// queries the database connection
        /// </summary>
        /// <returns>if true, the database connection is active, if false, it is not active</returns>
        public bool IsDatabaseActive()
        {
            return ConnectTest();
        }
        //performs all queued commands in the batch
        private void ProcessBatch()
        {
            List<MySqlCommand> commands = new List<MySqlCommand>();

            for (int i = 0; i < commandBatch.Count; i++)
            {
                MySqlCommand command = conDataBase.CreateCommand();
                command.CommandText = commandBatch[i];
                commands.Add(command);
            }

            try
            {
                conDataBase.Open();
                for (int i = 0; i < commands.Count; i++)
                {
                    commands[i].ExecuteNonQuery();
                }

                commandBatch = new List<string>();
                SaveBatch();
            }
            catch (Exception)
            {
                throw;
            }

            conDataBase.Close();
        }
        //saves the current batch of commands to file
        private void SaveBatch()
        {
            File.Create(@".\batch.txt").Close();
            
            StreamWriter writer = new StreamWriter(@".\batch.txt", true);

            for (int i = 0; i < commandBatch.Count; i++)
            {
                writer.WriteLine(commandBatch[i]);
            }

            writer.Close();

        }
        //loads saved commands from a file to the current batch
        private void LoadBatch()
        {
            if (File.Exists(@".\batch.txt"))
            {
                StreamReader reader = new StreamReader(@".\batch.txt");

                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    commandBatch.Add(line);
                }

                reader.Close();
            }
            
        }
        //queries the database connection
        private bool ConnectTest()
        {
            constring = @"server=localhost;database=vstestdb;username=VSTEST;password=password;";
            conDataBase = new MySqlConnection(constring);

            bool verified = false;

            try
            {
                conDataBase.Open();
                conDataBase.Close();
                verified = true;
            }
            catch (Exception)
            {
                throw;
            }

            return verified;
        }
        //takes data from dataSet and uses it to populate classes
        private void ConvertData()
        {
            
            //Create and store hotel classes
            for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
            {
                Hotel hotel = new Hotel(Int32.Parse(dataSet.Tables[0].Rows[i][0].ToString()), dataSet.Tables[0].Rows[i][1].ToString(), Int32.Parse(dataSet.Tables[0].Rows[i][2].ToString()), dataSet.Tables[0].Rows[i][3].ToString(), dataSet.Tables[0].Rows[i][4].ToString());

                hotels.Add(hotel);
            }

            //Create and store room classes
            for (int i = 0; i < dataSet.Tables[1].Rows.Count; i++)
            {
                int id = Int32.Parse(dataSet.Tables[1].Rows[i][0].ToString());
                int hotelid = Int32.Parse(dataSet.Tables[1].Rows[i][1].ToString());
                float price = float.Parse(dataSet.Tables[1].Rows[i][2].ToString());
                string name = dataSet.Tables[1].Rows[i][3].ToString();
                string description = dataSet.Tables[1].Rows[i][4].ToString();

                List<DateTime> reservedDates = new List<DateTime>();

                //get reserved dates for room
                for (int j = 0; j < dataSet.Tables[2].Rows.Count; j++)
                {
                    if(Int32.Parse(dataSet.Tables[2].Rows[j][1].ToString()) == id)
                    {
                        string start = dataSet.Tables[2].Rows[j][2].ToString();
                        string end = dataSet.Tables[2].Rows[j][3].ToString();

                        DateTime startingDate = new DateTime(Int32.Parse(start.Substring(6,4)), Int32.Parse(start.Substring(3,2)), Int32.Parse(start.Substring(0,2)));
                        DateTime endingDate = new DateTime(Int32.Parse(end.Substring(6, 4)), Int32.Parse(end.Substring(3, 2)), Int32.Parse(end.Substring(0,2)));

                        //generates all dates betweeen start and end
                        for (DateTime date = startingDate; date <= endingDate; date = date.AddDays(1))
                        {
                            reservedDates.Add(date);
                        }
                    }
                }
                //add rooms to appropriate hotel
                hotels.Find(hotel => hotel.Id == hotelid).AddRoom(id,name,description,price,reservedDates);
            }

            //create and store billable item classes
            for (int i = 0; i < dataSet.Tables[5].Rows.Count; i++)
            {
                int id = Int32.Parse(dataSet.Tables[5].Rows[i][0].ToString());
                string name = dataSet.Tables[5].Rows[i][1].ToString();
                string description = dataSet.Tables[5].Rows[i][2].ToString();
                float price = float.Parse(dataSet.Tables[5].Rows[i][3].ToString());
                BillableItem billableItem = new BillableItem(id,name,description,price);
                items.Add(billableItem);
            }
            //get largest id and set currentid to one larger.
            for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
            {
                int bookingid = Int32.Parse(dataSet.Tables[2].Rows[i][0].ToString());
                if (bookingid >= currentBookingID)
                {
                    currentBookingID = bookingid + 1;
                }
            }
            //get largest id and set currentid to one larger.
            for (int i = 0; i < dataSet.Tables[4].Rows.Count; i++)
            {
                int customerid = Int32.Parse(dataSet.Tables[4].Rows[i][0].ToString());
                if (customerid >= currentCustomerID)
                {
                    currentCustomerID = customerid + 1;
                }
            }      

        }
        //retrieves data from the database and stores in a dataset
        private void GetData()
        {
            if (ConnectTest())
            {
                try
                {
                    conDataBase.Open();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM hotel; SELECT * FROM room; SELECT * FROM booking; SELECT * FROM bookingitems; SELECT * FROM person; SELECT * FROM `billable item`;", conDataBase);

                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                }
                catch (Exception)
                {

                    throw;
                }

                conDataBase.Close();
            }
        }

	}
}

