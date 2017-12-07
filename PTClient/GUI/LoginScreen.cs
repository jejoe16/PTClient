using PTClient.Logic.LogicController;
using PTClient.SimPosition;
using System;
using System.Collections.Generic;
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
        List<Form> Clients = new List<Form>();
        Thread ConCheckThread;

        public LoginScreen()
        {
            InitializeComponent();
            control = GUIControl.GetLogicController();
            ThreadStart starter = new ThreadStart(CheckCon);
            ConCheckThread = new Thread(starter);
            ConCheckThread.Start();
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
            Clients.Add(cap);
            cap.ShowDialog();
        }

        private void BootWorkerScreen()
        {
            WorkerScreen wor = new WorkerScreen(Username, Password);
            Clients.Add(wor);
            wor.ShowDialog();
        }
        
        

        private void CheckCon()
        {
            if (control.CheckConnection() == false)
            {
                foreach(Form client in Clients)
                {
                    client.Close();
                    StatusLabel.Invoke(new Action(() => Text = "Username or Password is wrong"));
                }
            } else
            {
                StatusLabel.Invoke(new Action(() => Text = ""));
            }
        }

        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConCheckThread.Abort();
        }

        
    }
}
