using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_Management
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo(string ID, string Name, string Phone, int Year, int Month, int Day, TimeSpan Duration, string Email, string Gender)
        {
            InitializeComponent();
            if (Gender == "Male") pictureBox2.Image = Properties.Resources.man;
            else pictureBox2.Image = Properties.Resources.woman;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            lblIDE.Text = ID;
            lblNameE.Text = Name;
            lblPhoneE.Text = Phone;
            lblAgeE.Text = Year + " years, " + Month + " months, " + Day + " days";
            lblWHE.Text = Duration.Hours + " Hours";
            lblEmailE.Text = Email;
            lblGenderE.Text = Gender;
        }
    }
}
