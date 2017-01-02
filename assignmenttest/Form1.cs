using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using assignmenttest;

namespace assignmenttest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BatchProcess bp = new BatchProcess();

            //string hotels = "";
            //for (int i = 0; i < bp.Hotels.Count; i++)
            //{
            //    hotels = hotels + "Id: " + bp.Hotels[i].Id;
            //    hotels = hotels + " Name: " + bp.Hotels[i].Name;
            //    hotels = hotels + " Rating: " + bp.Hotels[i].Rating;
            //    hotels = hotels + " Description: " + bp.Hotels[i].Description;
            //    hotels = hotels + " Address: " + bp.Hotels[i].Address;
            //    hotels = hotels + " No of Rooms: " + bp.Hotels[i].Rooms.Count;

            //    hotels = hotels + "\n\n";

            //}

            //MessageBox.Show(hotels);

            //string rooms = "";
            //for (int i = 0; i < bp.Hotels.Count; i++)
            //{
            //    rooms = rooms + "Id: " + bp.Hotels[i].Rooms[0].Id;
            //    rooms = rooms + " Hotel Id: " + bp.Hotels[i].Rooms[0].Hotel.Id;
            //    rooms = rooms + " Price: £" + bp.Hotels[i].Rooms[0].Price;
            //    rooms = rooms + " Name: " + bp.Hotels[i].Rooms[0].Name;
            //    rooms = rooms + " Details: " + bp.Hotels[i].Rooms[0].Description;

            //    rooms = rooms + "\n\n";

            //}

            //MessageBox.Show(rooms);

            //string items = "";
            //for (int i = 0; i < bp.Items.Count; i++)
            //{
            //    items = items + "Id: " + bp.Items[i].Id;
            //    items = items + " Name: " + bp.Items[i].Name;
            //    items = items + " Description: " + bp.Items[i].Description;
            //    items = items + " Price: £" + bp.Items[i].Price;

            //    items = items + "\n\n";

            //}

            //MessageBox.Show(items);

            //MessageBox.Show("DB connection active: " + bp.IsDatabaseActive());
            //Backend.Customer c = new Backend.Customer(42,"Bob", "thebuilder", "Fake house, Fake Street");

            //bp.MakeBooking(bp.Hotels[0].Rooms[0],new List<DateTime>{new DateTime(2016,03,14), new DateTime(2016, 03, 22) },new List<Backend.BillableItem>() {bp.Items[0],bp.Items[1]},c);
        }
    }
}
