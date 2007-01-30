using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SdlExamples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool consoleMode = false;
            foreach (string arg in args)
            {
                if (arg == "--console")
                {
                    consoleMode = true;
                }
            }

            if (consoleMode)
            {
                SdlExamplesConsole t = new SdlExamplesConsole();
                t.Go();
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SdlExamples());
            }
            
        }
    }
}
