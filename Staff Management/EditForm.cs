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
    public partial class EditForm : Form
    {
        public EditForm(string ID)
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            //ListViewItem item = new ListViewItem((++ID).toString());
            MessageBox.Show("Update Successfully!", "Update");
            this.Close();
        }
    }
}
