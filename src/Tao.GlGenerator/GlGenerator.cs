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
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Tao.GlGenerator
{
	/// <summary>
	/// 
	/// </summary>
	class GlGenerator
	{
		#region	Main

		[STAThread]
		static void	Main(string[] args)	
		{
            WriteGl(false);
            WriteGl(true);
		}

        private static void WriteGl(bool isInstance)
        {
            StreamWriter streamWriter;
            if (isInstance)
            {
                streamWriter = new StreamWriter(Gl.FileNameInstance);
            }
            else
            {
                streamWriter = new StreamWriter(Gl.FileNameStatic);
            }
            streamWriter.AutoFlush = true;
            Common.WriteLicense(streamWriter);
            Common.WriteEmptyLine(streamWriter);
            Gl.WriteUsing(streamWriter);
            Gl.WriteNamespace(streamWriter);
            Common.WriteOpenBrace(streamWriter);
            Gl.WriteClassDefinition(streamWriter, isInstance);
            streamWriter.Write("\t");
            Common.WriteOpenBrace(streamWriter);
            Gl.WriteClass(streamWriter, isInstance);
            streamWriter.Write("\t");
            Common.WriteCloseBrace(streamWriter);
            Common.WriteCloseBrace(streamWriter);
            streamWriter.Close();
        }
		#endregion

		#region	Private	Methods
		
		#endregion
	}
}
