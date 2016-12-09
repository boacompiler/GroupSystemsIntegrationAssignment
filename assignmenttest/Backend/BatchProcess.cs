using System;
using System.Data;
using MySql.Data.MySqlClient;
//TODO remove
using System.Windows.Forms;

namespace assignmenttest
{
	public class BatchProcess
	{
        private MySqlConnection conDataBase;
        private string constring;
        DataSet dataSet;
        DataTable dataChanges;
        MySqlDataAdapter dataAdapter;
        
        

		public BatchProcess ()
		{

		}

        public void MakeBooking()
        {
            
        }

        public bool IsDatabaseActive()
        {
            return connecttest();
        }

        private bool connecttest()
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
            }

            return verified;
        }

        public void getdatatest()
        {
            if (connecttest())
            {
                try
                {
                    conDataBase.Open();
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM hotel;",conDataBase);

                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    MessageBox.Show("got " + dataSet.Tables[0].Rows[0][1].ToString());
                    
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
            if (connecttest())
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

