using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.IO;

namespace SdlExamples
{
    class SdlExamplesConsole
    {
        public SdlExamplesConsole()
        {
            Initialize();
        }

        List<string> lstExamples = new List<string>();

        private void Initialize()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                MemberInfo[] runMethods = type.GetMember("Run");
                foreach (MemberInfo run in runMethods)
                {
                    this.lstExamples.Add(type.Name);
                }
            }
        }

        public void Go()
        {
            Console.WriteLine("Press a number to run an example.");
            Console.WriteLine("Press a 'Q' to quit");
            Console.WriteLine();
            foreach (string s in lstExamples)
            {
                Console.Write(lstExamples.IndexOf(s) + ") ");
                Console.WriteLine(s);
            }
            bool quit = false;
            while (!quit)
            {
                try
                {
                    string input = Console.ReadLine();
                    int i;
                    if (Int32.TryParse(input.Trim(), out i))
                    {
                        if (i >= 0 && i < lstExamples.Count)
                        {
                            Type example = Assembly.GetExecutingAssembly().GetType("SdlExamples." + lstExamples[i], true, true);
                            example.InvokeMember("Run", BindingFlags.InvokeMethod, null, null, null);
                        }
                    }
                    else if (input.ToUpper() == "Q")
                    {
                        quit = true;
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.ToString());
                    quit = true;
                }
                catch (IOException e)
                {
                    e.ToString();
                    quit = true;
                }
            }
        }
    }
}
