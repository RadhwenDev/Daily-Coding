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
    public partial class Form1 : Form
    {
        int ID = 1000;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtPhoneNumber.Text))
                return;
            if (!maskedTextBox1.MaskFull)
            {
                errorProvider1.SetError(maskedTextBox1, "This field is required!");
                maskedTextBox1.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, "");
            }
            if (!maskedTextBox2.MaskFull)
            {
                errorProvider1.SetError(maskedTextBox2, "This field is required!");
                maskedTextBox2.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox2, "");
            }
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select Gender!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox2, "");
            }
            ListViewItem item = new ListViewItem((++ID).ToString());
            if(rbMale.Checked) item.ImageIndex = 0;
            else item.ImageIndex = 1;
            item.SubItems.Add(txtFullName.Text.Trim());
            item.SubItems.Add(txtEmail.Text.Trim());
            item.SubItems.Add(txtPhoneNumber.Text.Trim());
            item.SubItems.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy"));
            item.SubItems.Add(maskedTextBox1.Text.Trim());
            item.SubItems.Add(maskedTextBox2.Text.Trim());
            listView1.Items.Add(item);
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            dateTimePicker1.Value = DateTime.Now;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
                pbManWoman.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                lblID.Text = "";
                lblName.Text = "";
                lblPhone.Text = "";
                lblAge.Text = "";
                lblWH.Text = "";
                lblEmail.Text = "";
                lblGender.Text = "";
                ID--;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
                listView1.View = View.Details;
            else if(comboBox1.SelectedIndex == 1)
                listView1.View = View.LargeIcon;
            else if(comboBox1.SelectedIndex == 2)
                listView1.View = View.SmallIcon;
            else if(comboBox1.SelectedIndex == 3)
                listView1.View = View.List;
            else if(comboBox1.SelectedIndex == 4)
                listView1.View = View.Tile;
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (!maskedTextBox1.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox1, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox1, "");
            }
        }

        private void maskedTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (!maskedTextBox2.MaskFull)
            {
                e.Cancel = true;
                errorProvider1.SetError(maskedTextBox2, "This field is required!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(maskedTextBox2, "");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Details";
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("ID", 100);
            listView1.Columns.Add("Full Name", 150);
            listView1.Columns.Add("Phone", 100);
            listView1.Columns.Add("Email", 150);
        }
        
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                string ID = clickedItem.SubItems[0].Text;
                string Name = clickedItem.SubItems[1].Text;
                string email = clickedItem.SubItems[2].Text;
                string phone = clickedItem.SubItems[3].Text;
                string date = clickedItem.SubItems[4].Text;
                string HourStart = clickedItem.SubItems[5].Text;
                string HourEnd = clickedItem.SubItems[6].Text;
                string gender = "";
                if (clickedItem.ImageIndex == 0)
                {
                    gender = "Male";
                    pbManWoman.Visible = true;
                    pbManWoman.Image = Properties.Resources.man;
                }
                else 
                {
                    gender = "Female";
                    pbManWoman.Visible = true;
                    pbManWoman.Image = Properties.Resources.woman;
                }

                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;

                DateTime Date = DateTime.Parse(date);
                DateTime today = DateTime.Today;

               
                int years = today.Year - Date.Year;

                
                if (Date.Date > today.AddYears(-years))
                    years--;

                
                DateTime lastBirthday = Date.AddYears(years);
                int months = today.Month - lastBirthday.Month;
                if (months < 0)
                {
                    months += 12;
                }

                DateTime lastMonthAnniversary = lastBirthday.AddMonths(months);
                int days = (today - lastMonthAnniversary).Days;

                DateTime HS = DateTime.Parse(HourStart);
                DateTime HE = DateTime.Parse(HourEnd);
                TimeSpan duration = new TimeSpan();
                if (HS > HE) duration = (TimeSpan.FromHours(24) - HS.TimeOfDay) + HE.TimeOfDay;
                else duration = HE - HS;
                lblID.Text = ID;
                lblName.Text = Name;
                lblPhone.Text = phone;
                lblAge.Text = years + " years, " + months + " months, " + days + " days";
                lblWH.Text = duration.Hours + " Hours";
                lblEmail.Text = email;
                lblGender.Text = gender;
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);
            if (clickedItem != null)
            {
                string ID = clickedItem.SubItems[0].Text;
                string Name = clickedItem.SubItems[1].Text;
                string email = clickedItem.SubItems[2].Text;
                string phone = clickedItem.SubItems[3].Text;
                string date = clickedItem.SubItems[4].Text;
                string HourStart = clickedItem.SubItems[5].Text;
                string HourEnd = clickedItem.SubItems[6].Text;
                string gender = "";
                if (clickedItem.ImageIndex == 0)
                {
                    gender = "Male";
                    pbManWoman.Visible = true;
                    pbManWoman.Image = Properties.Resources.man;
                }
                else
                {
                    gender = "Female";
                    pbManWoman.Visible = true;
                    pbManWoman.Image = Properties.Resources.woman;
                }

                DateTime Date = DateTime.Parse(date);
                DateTime today = DateTime.Today;

                int years = today.Year - Date.Year;

                if (Date.Date > today.AddYears(-years))
                    years--;

                DateTime lastBirthday = Date.AddYears(years);
                int months = today.Month - lastBirthday.Month;
                if (months < 0)
                {
                    months += 12;
                }

                DateTime lastMonthAnniversary = lastBirthday.AddMonths(months);
                int days = (today - lastMonthAnniversary).Days;
                DateTime HS = DateTime.Parse(HourStart);
                DateTime HE = DateTime.Parse(HourEnd);
                TimeSpan duration = new TimeSpan();
                if (HS > HE) duration = (TimeSpan.FromHours(24) - HS.TimeOfDay) + HE.TimeOfDay;
                else duration = HE - HS;

                Form frmInfo = new EmployeeInfo(ID, Name, phone, years, months, days, duration, email, gender);
                frmInfo.ShowDialog();

            }
        }
    }
}
