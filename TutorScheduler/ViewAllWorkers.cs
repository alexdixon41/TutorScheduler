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
    public partial class ViewAllWorkers : Form
    {
        public ViewAllWorkers()
        {
            InitializeComponent();
        }

        private void SelectedButton_Click(object sender, EventArgs e)
        {
            StudentWorkerInfoForm form = new StudentWorkerInfoForm();
            form.Show();
        }
    }
}
