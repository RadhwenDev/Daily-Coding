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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ID.Text, out int patientID))
            {
                clsPatient patient = clsPatient.Find(patientID);
                if (patient != null)
                {
                    patient.Name = name.Text;
                    if(patient.Gender) patient.Gender = rdbtnMale.Checked;
                    else patient.Gender = rdbtnFemale.Checked;
                    patient.BirthDate = BirthDate.Value;
                    if (patient.isSmoke) patient.isSmoke = isSmoke.Checked;
                    else patient.isSmoke = isSmoke.Checked;
                    if (patient.isFat) patient.isFat = isFat.Checked;
                    else patient.isFat = isFat.Checked;

                    if(patient.Save())
                        MessageBox.Show("🎉Patient Updated Successfully with ID = " + patient.ID);
                }
                else
                    MessageBox.Show("⚠️Patient with ID = " + patientID + " doesn't exist");
            }
            else
                MessageBox.Show("⚠️Please enter a correct ID");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (int.TryParse(ID.Text, out int patientID))
            {
                if (clsPatient.DeletePatientByID(patientID))
                    MessageBox.Show("🎉Patient Deleted Successfully with ID = " + patientID);
            } 
            else
                MessageBox.Show("⚠️Please enter a correct ID");
        }
    }
}
