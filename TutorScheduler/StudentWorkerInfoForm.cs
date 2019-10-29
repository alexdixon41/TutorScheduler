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
    public partial class StudentWorkerInfoForm : Form
    {
        StudentWorker selectedStudentWorker;
        public StudentWorkerInfoForm(StudentWorker selected)
        {
            InitializeComponent();
            selectedStudentWorker = selected;
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

        private void displayInfo()
        {
            nameLabel.Text = selectedStudentWorker.Name;
            positionLabel.Text = selectedStudentWorker.JobPosition;
            int baseColor = selectedStudentWorker.DisplayColor;
            int red = baseColor / 256 / 256;
            int green = baseColor % (256 * 256) / 256;
            int blue = baseColor % 256;
            colorButton.BackColor = Color.FromArgb(255, red, green, blue);     
            //Display color, subjects, classes
        }

        private void StudentWorkerInfoForm_Load(object sender, EventArgs e)
        {
            displayInfo();
        }
    }
}
