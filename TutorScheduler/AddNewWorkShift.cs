using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TutorScheduler
{
    public partial class AddNewWorkShift : Form
    {
        public AddNewWorkShift()
        {
            InitializeComponent();
        }

        //Create button is clicked
        private void CreateButton_Click(object sender, EventArgs e)
        {
            //TODO: Make sure that the new work shift doesn't conflict with student worker's class schedule
            //TODO: Create shift
            this.Close();
        }
    }
}
