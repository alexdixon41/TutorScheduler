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
        //Possible TODO: Could make these a 2D array instead??
        TextBox[] numBoxes;
        TextBox[] nameBoxes;

        int numOfBoxesShowing = 1;      //number of boxes currently visible
        

        public AddNewSubject()
        {
            InitializeComponent();
        }

        private void AddTextboxButton_Click(object sender, EventArgs e)
        {
            if (numOfBoxesShowing < 5)
            {
                numBoxes[numOfBoxesShowing].Show();
                nameBoxes[numOfBoxesShowing].Show();
                numOfBoxesShowing++;
            }
        }

        private void AddNewSubject_Load(object sender, EventArgs e)
        {
            populateNumBoxes();
            populateNameBoxes();
        }

        //Add the number text boxes into the array
        private void populateNumBoxes()
        {
            numBoxes = new TextBox[5] { numBox1, numBox2, numBox3, numBox4, numBox5};
        }

        //Add the name text boxes into the array
        private void populateNameBoxes()
        {
            nameBoxes = new TextBox[5] { nameBox1, nameBox2, nameBox3, nameBox4, nameBox5 };
        }

        //User clicks to save the new subjects
        private void SaveButton_Click(object sender, EventArgs e)
        {
            addPanel.Hide();
            confirmationPanel.Show();
        }

        //User confirms they want to add the new subjects
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            //TODO: Save the new subjects
            this.Close();
        }

        //User does not confirm the changes
        private void CancelButton_Click(object sender, EventArgs e)
        {
            addPanel.Show();
            confirmationPanel.Hide();
        }
    }
}
