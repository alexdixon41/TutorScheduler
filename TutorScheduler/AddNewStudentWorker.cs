﻿using System;
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
            string position = positionTextbox.Text;
            int color = colorPicker.Color.ToArgb() & 0x00FFFFFF;

            //verify user input
            if (!StudentWorker.verifyID(idString))
            {
                return;
            }
            int id = Int32.Parse(idString);

            //Create and save student worker
            bool success = StudentWorker.createStudentWorker(id, name, position, color);
            if (success)
            {
                this.Close();
            }
            else
            {
                //TODO: Display error
            }
        }

    }
}
