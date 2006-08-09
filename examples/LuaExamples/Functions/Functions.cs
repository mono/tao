using System;
using System.IO;
using Tao.Lua;

namespace LuaExamples
{
    /// <summary>
    ///     Simple execution of calling a C# function from Lua.
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
    public class Functions
    {
        private static int my_function(IntPtr L)
        {
            int argc = Lua.lua_gettop(L);

            Console.WriteLine("-- my_function() called with " + argc + " arguments:");

            for (int n = 1; n <= argc; n++)
            {
                Console.WriteLine("-- argument " + n + ": " + Lua.lua_tostring(L, n));
            }
            Lua.lua_pushnumber(L, 123); // return value
            return 1; // number of return values
        }

        private static void report_errors(IntPtr L, int status)
        {
            if (status != 0)
            {
                Console.WriteLine("-- " + Lua.lua_tostring(L, -1));
                Lua.lua_pop(L, 1); // remove error message
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";
            string fileName = "LuaExamples.Functions.Script.lua";
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

            // make my_function() available to Lua programs
            Lua.lua_register(L, "my_function", new Lua.lua_CFunction(my_function));

            Console.WriteLine("-- Loading file: " + file);

            int s = Lua.luaL_loadfile(L, file);

            if (s == 0)
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
