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
    public partial class AddNewStudentWorker : Form
    {
        public AddNewStudentWorker()
        {
            InitializeComponent();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                colorButton.BackColor = colorPicker.Color;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Get user's input
            string idString = IDTextbox.Text;
            string name = nameTextbox.Text;
            string position = positionComboBox.Text;
            int color = colorButton.BackColor.ToArgb() & 0x00FFFFFF;

            //verify user input
            if (!StudentWorker.VerifyID(idString))
            {
                return;
            }
            int id = Int32.Parse(idString);

            //Create and save student worker
            bool success = StudentWorker.CreateStudentWorker(id, name, position, color);
            if (success)
            {                
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                new AlertDialog("Could not save new student worker.").ShowDialog();
            }
        }

        private void AddNewStudentWorker_FormClosed(object sender, FormClosedEventArgs e)
        {
            // [Version 2] - use this to open the edit form immediately after closing this form
            //if (DialogResult == DialogResult.Yes)
            //{

            //}
        }
    }
}
