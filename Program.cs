using Tracking_and_Queuing_System;

namespace Abot_Kamay_Tracking_and_Queuing_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string userRole = "Admin Clerk 3";
            string firstName = "Jose";
           //Application.Run(new MainForm(userRole, firstName));
            //Application.Run(new InputQueueForm());
           Application.Run(new LoginForm());
        }
    }
}