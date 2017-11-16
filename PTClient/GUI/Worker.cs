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
    public partial class Worker : Form
    {
        public Worker()
        {
            InitializeComponent();

        }
        private String currentPos = "nowhere";

        private void button3_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().Logout();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().CheckIn(currentPos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logic.LogicController.Controller.GetController().CheckOut(currentPos);
        }
    }
}
