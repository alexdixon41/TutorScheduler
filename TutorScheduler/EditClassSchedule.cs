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
    public partial class EditClassSchedule : Form
    {
        public EditClassSchedule()
        {
            InitializeComponent();
        }

        private void AddClassButton_Click(object sender, EventArgs e)
        {
            new AddClass().Show();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if(colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorPicker.Color;
            }
        }
    }
}
