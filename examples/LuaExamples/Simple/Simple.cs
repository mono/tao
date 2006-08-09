using System;
using System.IO;
using Tao.Lua;

namespace LuaExamples
{
	/// <summary>
	///		Simple execution of a Lua script.
	/// </summary>
	/// <remarks>
	///		<para>
	///			Originally written by Christian Stigen Larsen (csl@sublevel3.org).
	///			The original article is available at http://csl.sublevel3.org/lua .
	///		</para>
	///		<para>
	///			Translated to Tao.Lua by Rob Loach (http://www.robloach.net)
	///		</para>
	/// </remarks>
	public class Simple
	{
		private static void report_errors(IntPtr L, int status)
		{
			if ( status!=0 ) 
			{
				Console.WriteLine("-- " + Lua.lua_tostring(L, -1));
				Lua.lua_pop(L, 1); // remove error message
			}
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";
            string fileName = "LuaExamples.Simple.lua";
			if (File.Exists(fileName))
			{
				filePath = "";
                fileDirectory = "";
			}
            else if (File.Exists(Path.Combine(fileDirectory, fileName)))
            {
                filePath = "";
            }

            string file = Path.Combine(Path.Combine(filePath, fileDirectory), fileName);

			IntPtr L = Lua.luaL_newstate();

            Lua.luaL_openlibs(L);

			System.Console.WriteLine("-- Loading file: " + file);

			int s = Lua.luaL_loadfile(L, file);

			if(s == 0) 
			{
				// execute Lua program
				s = Lua.lua_pcall(L, 0, Lua.LUA_MULTRET, 0);
			}

			report_errors(L, s);
			Lua.lua_close(L);
			System.Console.ReadLine();
		}
	}
}
