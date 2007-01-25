#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
http://www.taoframework.com
All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Permissions;
using Settings = Tao.OpenGl.Bind.Properties.Bind;
using System.Threading;
using System.Collections.Generic;

namespace Tao.GlBindGen
{
    static class MainClass
    {
        static void Main(string[] arguments)
        {
            Console.WriteLine("OpenGL binding generator {0} for the Tao framework.",
                System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
            Console.WriteLine("For comments, bugs and suggestions visit www.taoframework.com");
            Console.WriteLine(" - the Tao framework team");
            Console.WriteLine();

            #region Handle Arguments

            try
            {
                foreach (string a in arguments)
                {
                    if (a.StartsWith("--") || a.StartsWith("-") || a.StartsWith("/"))
                    {
                        string[] b = a.Split(new char[] { '-', '/', ':', '=' }, StringSplitOptions.RemoveEmptyEntries);
                        switch (b[0])
                        {
                            case "?":
                            case "help":
                                Console.WriteLine("Help not implemented yet.");
                                return;
                            case "in":
                            case "input":
                                Properties.Bind.Default.InputPath = b[1];
                                break;
                            case "out":
                            case "Properties.Bind.Default.OutputPath":
                                Properties.Bind.Default.OutputPath = b[1];
                                break;
                            case "class":
                                Properties.Bind.Default.OutputClass = b[1];
                                break;
                            default:
                                throw new ArgumentException("Argument " + a + " not recognized. Use the '/?' switch for help.");
                        }
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Argument error ({0}). Please use the '/?' switch for help.", e.ToString());
                return;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Argument error ({0}). Please use the '/?' switch for help.", e.ToString());
                return;
            }

            #endregion

            try
            {
                long ticks = System.DateTime.Now.Ticks;

                // GL binding generation.

                Translation.GLTypes = SpecReader.ReadTypeMap("gl.tm");
                Translation.CSTypes = SpecReader.ReadTypeMap("csharp.tm");

                List<Function> wrappers;
                List<Function> functions = SpecReader.ReadFunctionSpecs("gl.spec");
                List<Constant> constants = SpecReader.ReadConstantSpecs("enum.spec");
                List<Constant> constants2 = SpecReader.ReadConstantSpecs("enumext.spec");
                foreach (Constant c in constants2)
                    if (!SpecReader.ListContainsConstant(constants, c))
                        constants.Add(c);

                Translation.TranslateFunctions(functions, out wrappers);
                constants = Translation.TranslateConstants(constants);

                SpecWriter.WriteSpecs(Properties.Bind.Default.OutputPath, functions, wrappers, constants);

                ticks = System.DateTime.Now.Ticks - ticks;

                Console.WriteLine("Bindings generated in {0} seconds.", ticks / (double)10000000.0);
                Console.WriteLine();
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Security violation \"{0}\" in method \"{1}\".", e.Message, e.Method);
                Console.WriteLine("This application does not have permission to take the requested actions.");
            }
        }
    }
}
