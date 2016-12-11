using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using assignmenttest.Backend;
//TODO remove
using System.Windows.Forms;

using System.IO;

namespace assignmenttest
{
	class BatchProcess
	{
        private MySqlConnection conDataBase;
        private string constring;
        DataSet dataSet;
        MySqlDataAdapter dataAdapter;

        private List<Hotel> hotels = new List<Hotel>();
        private List<BillableItem> items = new List<BillableItem>();

        List<string> commandBatch;

		public BatchProcess ()
		{
            getdatatest();//TODO replace this
            ConvertData();
            //BookingToDatabase();
            commandBatch = new List<string>();
            LoadBatch();
            //MessageBox.Show(commandBatch[0]);
            ProcessBatch();

            //MakeBooking(hotels[0].Rooms[0], new List<DateTime> { new DateTime(2016, 11, 11), new DateTime(2016, 12, 12) }, new List<BillableItem>(), new Customer(420, "bob", "bobson", "fake land"));
            //MakeBooking(hotels[0].Rooms[0], new List<DateTime> { new DateTime(2016, 11, 11), new DateTime(2016, 12, 12) }, new List<BillableItem> { new BillableItem(34, "", "", 1f), new BillableItem(62, "", "", 1f) }, new Customer(52, "bob", "bobson", "fake land"));
        }

        public void MakeBooking(Room room, List<DateTime> datesReserved, List<BillableItem> billableItems, Customer customer)
        {
            int idbooking = 0; //TODO id gen
            int idroom = room.Id;
            string datebegin = datesReserved[0].Year + "-" + datesReserved[0].Month + "-" + datesReserved[0].Day;
            int l = datesReserved.Count - 1;
            string dateend = datesReserved[l].Year + "-" + datesReserved[l].Month + "-" + datesReserved[l].Day; ;
            int customerid = customer.Id; // TODO why can frontend team not set id?
            //TODO make customer insert
            commandBatch.Add("INSERT INTO booking (`idbooking`, `idroom`, `date_begin`, `date_end`, `billable_person`) VALUES ('"+idbooking+"', '"+idroom+"', '"+datebegin+"', '"+dateend+"', '"+customerid+"');");
            //TODO 0 gives an autoincrement, but this does not work for billable items reference
            for (int i = 0; i < billableItems.Count; i++)
            {
                commandBatch.Add("INSERT INTO bookingitems (`billable_item`, `idbooking`) VALUES ('"+billableItems[i].Id+"','"+idbooking+"');");
            }
            //SaveBatch();
            if (ConnectTest())
            {
                ProcessBatch();
            }
            else
            {
                SaveBatch();
            }
        }

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            conDataBase.Close();
        }

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

        public bool IsDatabaseActive()
        {
            return ConnectTest();
        }

        private bool ConnectTest()
        {
            //server=localhost;user id=VSTEST;database=vstestdb;persistsecurityinfo=True
            //TODO temp server details
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
                //TODO connect test exception
                throw;
            }

            return verified;
        }

        private void GetData()
        {

        }

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
                        //TODO MessageBox.Show(start + " ~ " + start.Substring(6, 4) + " ~ " + start.Substring(3, 2) + " ~ " + start.Substring(0, 2) + ": " + start);
                        DateTime startingDate = new DateTime(Int32.Parse(start.Substring(6,4)), Int32.Parse(start.Substring(3,2)), Int32.Parse(start.Substring(0,2)));
                        DateTime endingDate = new DateTime(Int32.Parse(end.Substring(6, 4)), Int32.Parse(end.Substring(3, 2)), Int32.Parse(end.Substring(0,2)));

                        //generates all dates betweeen start and end
                        for (DateTime date = startingDate; date <= endingDate; date = date.AddDays(1))
                        {
                            reservedDates.Add(date);
                        }
                    }
                }
                
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

        }

        public void getdatatest()
        {   
            if (ConnectTest())
            {
                try
                {
                    conDataBase.Open();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM hotel; SELECT * FROM room; SELECT * FROM booking; SELECT * FROM bookingitems; SELECT * FROM person; SELECT * FROM `billable item`;", conDataBase);

                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    //TODO MessageBox.Show("got " + dataSet.Tables[1].Rows[0][1].ToString());
                    
                }
                catch (Exception ex)
                {

                    MessageBox.Show("data loading failed: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("connection failed");
            }

            conDataBase.Close();
        }

        public void insertdatatest()
        {
            if (ConnectTest())
            {
                MySqlCommand command = conDataBase.CreateCommand();
                command.CommandText = "INSERT INTO hotel (`idhotel`, `hotel_name`, `star_rating`, `description`, `address`) VALUES ('9', 'hotel 9', '2', 'pretty bad 9 hotel', '9 road');";

                try
                {
                    conDataBase.Open();

                    command.ExecuteNonQuery();

                    MessageBox.Show("inserted!");
                }
                catch (Exception ex)
                {

                    MessageBox.Show("data inserting failed: " + ex.Message);
                }

                
            }
            else
            {
                MessageBox.Show("connection failed");
            }

            conDataBase.Close();
        }
	}
}

