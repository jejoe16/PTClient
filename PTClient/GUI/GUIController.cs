using PTClient.GUI.Map;
using PTClient.Logic.LogicController;
using PTClient.SimPositionProgram.BoatGenerator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PTClient.GUI
{
    class GUIController
    {
        
        private IMap map = new MapControl();
        private IController controller = new Controller();
        private System.Object lockThis = new System.Object();
        private BoatPosition boat = BoatPosition.GetBoatPosition();
        public GUIController()
        {

        }

        public IController GetLogicController()
        {
            return controller;
        }

        public void generateMap() 
        {
            List<String> TurbineNames = controller.GetTurbineNames();
            foreach(String Name in TurbineNames)
            {
                map.AddTurbineMarker(Name, controller.GetTurbineLatitude(Name), controller.GetTurbineLongitude(Name));
            }
        }

        public Bitmap rotateImage(Bitmap rotateMe, float degrees)
        {
            lock (lockThis)
            {
                var bmp = new Bitmap(rotateMe.Width + (rotateMe.Width / 2), rotateMe.Height + (rotateMe.Height / 2));

                using (Graphics g = Graphics.FromImage(bmp))
                    g.DrawImageUnscaled(rotateMe, (rotateMe.Width / 4), (rotateMe.Height / 4), bmp.Width, bmp.Height);

                
                rotateMe = bmp;
                Bitmap rotatedImage = new Bitmap(rotateMe.Width, rotateMe.Height);

                using (Graphics g = Graphics.FromImage(rotatedImage))
                {
                    g.TranslateTransform(rotateMe.Width / 2, rotateMe.Height / 2);  
                    g.RotateTransform(degrees);                                        
                    g.TranslateTransform(-rotateMe.Width / 2, -rotateMe.Height / 2); 
                    g.DrawImage(rotateMe, new Point(0, 0));                          
                }

                
                return rotatedImage;
            }
        }


    }
}
