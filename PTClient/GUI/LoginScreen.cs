using PTClient.Logic.LogicController;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PTClient.GUI
{
    public partial class LoginScreen : Form
    {
        GUIController GUIControl = new GUIController();
        IController control;
        String Username;
        String Password;

        public LoginScreen()
        {
            InitializeComponent();
            control = GUIControl.GetLogicController();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var ServerCheck = control.CheckConnection();
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            if (ServerCheck.Equals(false))
            {
                StatusLabel.Text = "Server Unavailable! Try again later.";
            }
            else
            {
                Boolean LoginCheck = control.Login(Username, Password);
                if (LoginCheck == true)
                {
                    Boolean CaptainCheck = control.CaptainCheck();
                    if (CaptainCheck == true)
                    {
                        ThreadStart starter = new ThreadStart(BootCaptainScreen);
                        Thread thread = new Thread(starter);
                        thread.Start();
                        
                    }
                    else if (CaptainCheck == false)
                    {
                        ThreadStart starter = new ThreadStart(BootWorkerScreen);
                        Thread thread = new Thread(starter);
                        thread.Start();
                      
                    }

                }
                else if (LoginCheck == false)
                {
                    StatusLabel.Text = "Username or Password is wrong";
                }
            }
        }



        private void BootCaptainScreen()
        {
            Map.CaptainScreen cap = new Map.CaptainScreen(Username, Password);
            cap.ShowDialog();
        }

        private void BootWorkerScreen()
        {
            WorkerScreen wor = new WorkerScreen(Username, Password);
            wor.ShowDialog();
        }
    }
}
