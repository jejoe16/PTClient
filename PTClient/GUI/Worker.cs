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
        Logic.LogicController.Controller Controller = Logic.LogicController.Controller.GetController();
        public Worker()
        {
            InitializeComponent();

        }
        private String currentPos = "nowhere";

        private void button3_Click(object sender, EventArgs e)
        {
            Controller.Logout();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controller.CheckIn(currentPos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controller.CheckOut(currentPos);
        }
    }
}
