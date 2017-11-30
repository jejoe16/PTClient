using PTClient.Logic.LogicController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    
                textBoxUsername.Text.Insert(1, "Mangler noget");

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
