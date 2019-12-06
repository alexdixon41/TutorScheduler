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
    public partial class Login : Form
    {
        public static bool loginSuccess = false;

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (Manager.Login(usernameBox.Text, pwordBox.Text))
            {
                loginSuccess = true;
                this.Close();
            }
            else
            {
                new AlertDialog("Invalid username or password.").ShowDialog();
            }
        }        
    }
}
