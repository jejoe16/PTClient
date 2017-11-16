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
        
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Logic.LogicController.Controller.GetController().Login(textBoxUsername.Text, textBoxPassword.Text) == true)
           {
              if (Logic.LogicController.Controller.GetController().getCaptain() == true)
                {
                    Map.CaptainScreen cap = new Map.CaptainScreen();
                   cap.ShowDialog();
                }
                else if (Logic.LogicController.Controller.GetController().getCaptain() == false)
                {
                   WorkerScreen wor = new WorkerScreen();
                    wor.ShowDialog();
                }

            }
            else if (Logic.LogicController.Controller.GetController().Login(textBoxUsername.Text, textBoxPassword.Text) == false)
            {
    
                textBoxUsername.Text.Insert(1, "Mangler noget");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
