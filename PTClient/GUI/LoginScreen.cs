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

        /// <summary>
        /// Starts new thread with Login() on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Click(object sender, EventArgs e)
        {
            ThreadStart starter = new ThreadStart(Login);
            Thread LoginThread = new Thread(starter);
            LoginThread.Start();
            StatusLabel.Text = "Connecting...";
        }

        /// <summary>
        /// First checks if server is available. after check if the username and password in the field marches anything in the database on the server. 
        /// lastly a check to see if it's a captain or a technician.
        /// creates a  thread with either captain or technician screen-
        /// </summary>
        private void Login()
        {
            var ServerCheck = control.CheckConnection();
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            if (ServerCheck.Equals(false))
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Server unavailable! try again later."));
            }
            else
            {
                Boolean LoginCheck = control.Login(Username, Password);
                if (LoginCheck == true)
                {
                    StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Success!"));
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
                    StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Username or Password is incorrect."));
                }
            }
        }
        
        /// <summary>
        /// Opens a new screen with the Capatain Interfacce
        /// </summary>
        private void BootCaptainScreen()
        {
            Map.CaptainScreen cap = new Map.CaptainScreen(Username, Password);
            Clients.Add(cap);
            cap.ShowDialog();
        }

        /// <summary>
        /// Opens a new screen with the Technician Interface
        /// </summary>
        private void BootWorkerScreen()
        {
            WorkerScreen wor = new WorkerScreen(Username, Password);
            Clients.Add(wor);
            wor.ShowDialog();
        }
        
        
        /// <summary>
        /// keeps checking the connection is stable. if the connection is lost all screens will be closed.
        /// </summary>
        private void CheckCon()
        {
            if (control.CheckConnection() == false)
            {
                foreach(Form client in Clients)
                {
                    client.Close();
                    StatusLabel.Invoke(new Action(() => StatusLabel.Text = "Server unavailable!"));
                    button1.Invoke(new Action(() => button1.Enabled = false));
                }
            } else
            {
                StatusLabel.Invoke(new Action(() => StatusLabel.Text = ""));
                button1.Invoke(new Action(() => button1.Enabled = true));
            }
        }

        /// <summary>
        /// stops connection thread  if the login window is closed, this prevents an Error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConCheckThread.Abort();
        }


    }
}
