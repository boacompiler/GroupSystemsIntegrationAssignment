using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO remove dis
using assignmenttest.Backend;

namespace assignmenttest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //TODO remove dis
            BookingBackend bb = new BookingBackend();
            string s = "";
            //foreach (var hotel in bb.GetHotels())
            //{
            //    s = s + hotel.Rooms[49].Description + "\n";
            //}
            //foreach (var item in bb.Hotels[0].Rooms[0].ReservedDates)
            //{
            //    s = s + item + "\n";
            //}

            //foreach (var hotel in bb.GetRooms(new List<DateTime>() { new DateTime(2016, 1, 1) }))
            //{
            //    s = s + hotel.Name + "\n";
            //}
            foreach (var item in bb.GetBillableItems())
            {
                s = s + item.Name + "\n";
            }
            MessageBox.Show(s);
            Environment.Exit(0);
        }
    }
}
