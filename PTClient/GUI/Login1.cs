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
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           if( Logic.LogicController.Controller.GetController().Login(textBox1.Text, textBox2.Text)== true)
            {
                if (Logic.LogicController.Controller.GetController().getCaptain() == true)
                {
                    Map.Overview cap = new Map.Overview();
                    cap.ShowDialog();
                } else if (Logic.LogicController.Controller.GetController().getCaptain() == false)
                {
                    Worker wor = new Worker();
                    wor.ShowDialog();
                }
               
            } else if (Logic.LogicController.Controller.GetController().Login(textBox1.Text, textBox2.Text) == false)
                {
                
                textBox1.Text.Insert(1, "Mangler noget");
                }
           //if (Controller.Instance.Login(textBox1.Text, textBox2.Text).Captain == true)
           // {
           //     Map.Overview cap = new Map.Overview();
           //     cap.ShowDialog();
           // }
           //else if (Controller.Instance.Login(textBox1.Text, textBox2.Text).Captain == false)
           // {
           //     Worker wor = new Worker();
           //     wor.ShowDialog();
           // }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
