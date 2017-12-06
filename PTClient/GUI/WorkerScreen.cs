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
    public partial class WorkerScreen : Form
    {
        GUIController GUIControl = new GUIController();
        IController control;
        public WorkerScreen(String Username, String Password)
        {
            InitializeComponent();
            control = GUIControl.GetLogicController();
            control.NewSession(Username, Password);

        }
        private String currentPos = "nowhere";

        private void button3_Click(object sender, EventArgs e)
        {
            control.Logout();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.CheckIn(currentPos);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.CheckOut(currentPos);
        }
    }
}
