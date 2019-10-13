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
    public partial class DisplayStudentWorkers : Form
    {
        public DisplayStudentWorkers()
        {
            InitializeComponent();
        }

        private void DisplayStudentWorkers_Load(object sender, EventArgs e)
        {
            List<StudentWorker> studentWorkers = StudentWorker.GetStudentWorkers();
            foreach(StudentWorker sw in studentWorkers)
            {
                displayStudentWorkersListView.Items.Add(sw.Name).SubItems.Add(sw.JobPosition);
            }
        }
    }
}
