using System;
using System.Windows.Forms;
using PTClient.LogicController;

namespace PTClient
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

            Controller control = Controller.GetController();
            Application.Run(new Map.Overview());

        }
    }
}
