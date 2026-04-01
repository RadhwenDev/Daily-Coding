using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalBusinessLayer;

namespace HospitalSystem
{
    public partial class PatientForm : Form
    {
        public PatientForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = clsPatient.GetAllPatient();
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsPatient patient = new clsPatient();
            patient.Name = name.Text;
            patient.Gender = rdbtnMale.Checked || false;
            patient.BirthDate = BirthDate.Value;
            patient.isSmoke = isSmoke.Checked;
            patient.isFat = isFat.Checked;
            if (patient.Save())
                MessageBox.Show("🎉Patient Added Successfully with ID = " + patient.ID);
                
        }

        private void btnSearchByID_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ID.Text, out int patientID))
            {
                clsPatient patient = clsPatient.Find(patientID);
                if (patient != null)
                {
                    name.Text = patient.Name;
                    if (patient.Gender) rdbtnMale.Checked = true;
                    else rdbtnFemale.Checked = true;
                    BirthDate.Value = Convert.ToDateTime(patient.BirthDate);
                    if (patient.isSmoke) isSmoke.Checked = true;
                    else isSmoke.Checked = false;
                    if (patient.isFat) isFat.Checked = true;
                    else isFat.Checked = false;
                }
                else
                {
                    MessageBox.Show("⚠️ Patient with ID = " + patientID + " Not Found");
                }
                    
            }
                
            
        }
    }
}
