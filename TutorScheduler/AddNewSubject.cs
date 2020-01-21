using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace TutorScheduler
{
    public partial class AddNewSubject : Form
    {
        TextBox[,] subjectBoxes;

        int numOfBoxesShowing = 1;      //number of boxes currently visible

        /// <summary>
        /// Initializes the subjectBoxes array with the number and name textboxes
        /// </summary>
        void populateSubjectBoxes()
        {
            subjectBoxes = new TextBox[5,2] { 
                {numBox1, nameBox1 }, 
                {numBox2, nameBox2 },
                {numBox3, nameBox3 },
                {numBox4, nameBox4 },
                {numBox5, nameBox5 }
            };
        }

        public AddNewSubject()
        {
            InitializeComponent();
            populateSubjectBoxes();
        }

        private void AddTextboxButton_Click(object sender, EventArgs e)
        {
            if (numOfBoxesShowing < 5)
            {
                subjectBoxes[numOfBoxesShowing,0].Show();
                subjectBoxes[numOfBoxesShowing,1].Show();
                numOfBoxesShowing++;
            }
        }

        private void AddNewSubject_Load(object sender, EventArgs e)
        {
            
        }

        //User clicks to save the new subjects
        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Get user input
            //TODO: Verify abbreviation
            String abbreviation = abbreviationBox.Text;
            for (int i = 0; i < subjectBoxes.GetLength(0); i++)
            {
                if (subjectBoxes[i, 0].Visible == true && !subjectBoxes[i,0].Text.Equals(""))
                {
                        string num = subjectBoxes[i, 0].Text;
                        String name = subjectBoxes[i, 1].Text;

                        //Create and save subject
                        Subject.Create(abbreviation, num, name);   
                }
            }
            this.Close();
        }
    }
}
