using PTClient.Logic.LogicController;
using System;
using System.Windows.Forms;

namespace PTClient.GUI
{
    public partial class LoginScreen : Form
    {
        Controller control = Controller.GetController();
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ServerCheck = control.CheckConnection();
            if (ServerCheck.Equals(false))
            {
                StatusLabel.Text = "Server Unavailable! Try again later.";
            }
            else
            {
                Boolean LoginCheck = control.Login(textBoxUsername.Text, textBoxPassword.Text);
                if (LoginCheck == true)
                {
                    if (control.CaptainCheck() == true)
                    {

                        Map.CaptainScreen cap = new Map.CaptainScreen();
                        cap.ShowDialog();
                    }
                    else if (control.CaptainCheck() == false)
                    {
                        WorkerScreen wor = new WorkerScreen();
                        wor.ShowDialog();
                    }

                }
                else if (LoginCheck == false)
                {
                    StatusLabel.Text = "Username or Password is wrong";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
