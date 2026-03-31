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
    }
}
