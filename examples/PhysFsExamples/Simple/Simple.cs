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
using System.IO;
using System.Text;
using Tao.PhysFs;

namespace PhysFsExamples
{
	/// <summary>
	/// PhysFS Tutorial - http://icculus.org/physfs/physfstut.txt
	/// </summary>
	/// <remarks>Here are some simple steps to getting PhysFS working in your program.
	/// <p>
	///		Originally created by some friendly people in #icculus.org in the freenode IRC network.
	///	</p>
	/// <p>
	///		C# Implementation by Rob Loach (http://www.robloach.net).
	/// </p>
	/// </remarks>
	public class Simple
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";
            string fileName = "PhysFsExamples.Simple.MyZip.zip";

            /* 
			 * First thing you need to do is initialize the filesystem.  You simply call 
			 * PHYSFS_init();
			 * to do this.
			 * 
			 * From the docs:
			 * argv0 the argv[0] string passed to your program's mainline. This may be NULL 
			 * on most platforms (such as ones without a standard main() function), but you 
			 * should always try to pass something in here. Unix-like systems such as Linux 
			 * _need_ to pass argv[0] from main() in here.
			 */
			Fs.PHYSFS_init("init");

			/*
			 * After you have it initialized, then you need to set up any archives that 
			 * will be read from.  You can do this by using the 
			 * PHYSFS_AddToSearchPath(char*, int); function.  The 1 makes it added to the 
			 * end of the search path so that it is the last looked at.  You could instead 
			 * put a 0 there and have it be the first thing looked at.
			 */
            Fs.PHYSFS_addToSearchPath(Path.Combine(Path.Combine(filePath, fileDirectory), fileName), 1);
            Fs.PHYSFS_addToSearchPath(Path.Combine(fileDirectory, fileName), 1);

			/*
			 * Now that we have initialized physfs and added an archive to its search path, 
			 * we can do some file reading.  First thing you will want to do is check to 
			 * make sure that the file exists.  You can do this by calling 
			 * PHYSFS_exists(char*);
			 */
			Console.WriteLine("Exists: " + Fs.PHYSFS_exists("myfile.txt"));

			/*
			 * Then you can use PHYSFS_openRead(char*); to get a PHYSFS_file pointer to 
			 * that file.  There is also available: PHYSFS_openWrite(char*); and 
			 * PHYSFS_openAppend(char*);
			 * 
			 * NOTE: If you would like to do any writing you need to set a dir to write 
			 * too.  You can do this by using PHYSFS_setWriteDir(const char *newDir);
			 */
			IntPtr myfile = Fs.PHYSFS_openRead("myfile.txt");

			/*
			 * If you are going to be reading this file into memory, you can use 
			 * PHYSFS_fileLength(PHYSFS_file*) to find out how many bytes you need to 
			 * allocate for the file.  You can also use this to check and make sure the 
			 * file isn't larger than the max file size you want to open.
			 */
            long file_size = Fs.PHYSFS_fileLength(myfile);
            Console.WriteLine("Filesize: " + file_size);

			/*
			 * Now it is time to read the file into memory.  In this tutorial I am simply 
			 * going to read it all into a byte array using PHYSFS_read (PHYSFS_file *fp, 
			 * your_buffer, size_of_object_to_read, number_of_objects_to_read); and it 
			 * returns the number of objects read.
			 */
            byte[] array;
            Fs.PHYSFS_read(myfile, out array, 1, (uint)file_size);
			for(int i = 0; i < array.Length; i++)
			{
				Console.Write((char)array[i]);
			}

			/*
			 * When you are finished with your file you need to close it.  You can do so 
			 * with the function PHYSFS_close(PHYSFS_file*);
			 */
			Fs.PHYSFS_close(myfile);

			/*
			 * When you are finished with PHYSFS completely, you need to call the 
			 * PHYSFS_deinit(void) function.
			 * 
			 * From the docs:
			 * This closes any files opened via PhysicsFS, blanks the search/write paths, 
			 * frees memory, and invalidates all of your file handles.
			 */
			Fs.PHYSFS_deinit();

			/*
			 * Ok that is it for the tutorial.  It should give you a rough overview of how 
			 * things are structured and you can check the online docs for more information 
			 * on using the rest of the API.
			 */
			Console.ReadLine();
		}
	}
}
