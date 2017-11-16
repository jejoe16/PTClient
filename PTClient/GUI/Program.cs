using System;
using System.Windows.Forms;
using PTClient.Logic.LogicController;
using PTClient.GUI.Map;
using System.Collections.Generic;

namespace PTClient.GUI
{
    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run();
            Controller control = Controller.GetController();
        }

    }
}
