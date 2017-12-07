using PTClient.Logic.LogicController;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Windows.Forms;

namespace PTClient.GUI
{
    public partial class WorkerScreen : Form
    {
        GUIController GUIControl = new GUIController();
        IController controller;
        IBoatPosition Boat = BoatPosition.GetBoatPosition();
        public WorkerScreen(String Username, String Password)
        {
            InitializeComponent();
            controller = GUIControl.GetLogicController();
            controller.NewSession(Username, Password);
            GUIControl.generateMap();

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            controller.Logout();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean check = controller.CheckIn(Boat.GetNextLatitude(), Boat.GetNextLongitude());
            if (check == false)
            {
                CheckLabel.Text = "No turbines nearby!" + Boat.GetNextLatitude() + " + " + Boat.GetNextLongitude();
            } else
            {
                CheckLabel.Text = "Position Updated";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Boolean check = controller.CheckOut();
            if (check == true)
            {
                CheckLabel.Text = "Position Updated";
            }
        }

        

        
    }
}
