#region License
/*
 MIT License
 Copyright 2003-2006 Tao Framework Team
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
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Collections;

namespace Tao.PhysFs
{
	#region Aliases
	using PHYSFS_uint8 = System.Byte;
	using PHYSFS_sint8 = System.SByte;
	using PHYSFS_uint16 = System.UInt16;
	using PHYSFS_sint16 = System.Int16;
	using PHYSFS_uint32 = System.UInt32;
	using PHYSFS_sint32 = System.Int32;
	using PHYSFS_uint64 = System.UInt64;
	using PHYSFS_sint64 = System.Int64;
	#endregion Aliases

	#region Class Documentation
	/// <summary>
	///     PhysFS bindings for .NET, implementing PhysFS 1.0.1 (http://icculus.org/physfs/).
	/// </summary>
	/// <remarks>
	///		PhysicsFS is a library to provide abstract access to
	///		various archives. It is intended for use in video games,
	///		and the design was somewhat inspired by Quake 3's file
	///		subsystem.
	///	<p>More information can be found at the official website (http://icculus.org/physfs/).</p>
	///	</remarks>
	#endregion Class Documentation
	[SuppressUnmanagedCodeSecurityAttribute()]
	public static class Fs
	{
		#region Private Constants
		#region string PHYSFS_NATIVE_LIBRARY
		/// <summary>
		/// Specifies the PhysicsFS native library used in the bindings
		/// </summary>
		/// <remarks>
		/// The Windows dll is specified here universally - note that
		/// under Mono the non-windows native library can be mapped using
		/// the ".config" file mechanism.  Kudos to the Mono team for this
		/// simple yet elegant solution.
		/// </remarks>
		private const string PHYSFS_NATIVE_LIBRARY = "physfs.dll";
		#endregion string PHYSFS_NATIVE_LIBRARY
		
		#region CallingConvention CALLING_CONVENTION
		/// <summary>
		///     Specifies the calling convention used for the binding.
		/// </summary>
		/// <remarks>
		///     Specifies <see cref="CallingConvention.Winapi" />.
		/// </remarks>
		private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
		#endregion CallingConvention CALLING_CONVENTION
		#endregion Private Constants

		#region physfs.h
		#region Public Structs

		#region PHYSFS_Version
		/// <summary>
		/// Information the version of PhysicsFS in use.
		/// </summary>
		/// <remarks>Represents the library's version as three levels: major revision (increments with massive changes, additions, and enhancements), minor revision (increments with backwards-compatible changes to the major revision), and patchlevel (increments with fixes to the minor revision).</remarks>
		/// <seealso cref="PHYSFS_VERSION"/>
		/// <seealso cref="PHYSFS_getLinkedVersion"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct PHYSFS_Version
		{
			/// <summary>
			/// major revision
			/// </summary>
			public PHYSFS_uint8 major;
			/// <summary>
			/// minor revision
			/// </summary>
			public PHYSFS_uint8 minor;
			/// <summary>
			/// patchlevel
			/// </summary>
			public PHYSFS_uint8 patch;
			/// <summary>
			/// Returns a string representation of the version number (x.x.x).
			/// </summary>
			/// <returns>A string representing the version.</returns>
			public override string ToString()
			{
				return major.ToString() + "." + minor.ToString() + "." + patch.ToString();
			}
		}
		#endregion PHYSFS_Version

		#region PHYSFS_ArchiveInfo
		/// <summary>
		/// Information on various PhysicsFS-supported archives.
		/// </summary>
		/// <remarks>
		/// This structure gives you details on what sort of archives are supported by this implementation of PhysicsFS. Archives tend to be things like ZIP files and such.
		/// <p>
		/// Not all binaries are created equal! PhysicsFS can be built with or without support for various archives. You can check with PHYSFS_supportedArchiveTypes() to see if your archive type is supported.
		/// </p>
		/// </remarks>
		/// <seealso cref="PHYSFS_supportedArchiveTypes"/>
		// This is the public class declaration to use strings instead of IntPtrs.
		public class PHYSFS_ArchiveInfo
		{
			/// <summary>
			/// Creates a PHYSFS_ArchiveInfo structure.
			/// </summary>
			/// <param name="extension">The archive's file extension.</param>
			/// <param name="description">The description of the archive.</param>
			/// <param name="author">Who created this implementation.</param>
			/// <param name="url">The URL of the archive.</param>
			// This is a strongly typed implementation of PHYSFS_ArchiveInfo that uses strings instead of IntPtrs.
			public PHYSFS_ArchiveInfo(string extension, string description, string author, string url)
			{
				this.extension = extension;
				this.description = description;
				this.author = author;
				this.url = url;
			}
			/// <summary>
			/// Archive file extension: "ZIP", for example.
			/// </summary>
			public string extension;
			/// <summary>
			/// Human-readable archive description.
			/// </summary>
			public string description;
			/// <summary>
			/// Person who did support for this archive.
			/// </summary>
			public string author;
			/// <summary>
			/// URL related to this archive.
			/// </summary>
			public string url;
			/// <summary>
			/// A human-readable representation of the archive info
			/// </summary>
			/// <returns></returns>
			public override string ToString()
			{
				return string.Format("{0} - {1} ({2} - {3})", extension, description, author, url);
			}
		}
		#endregion PHYSFS_ArchiveInfo

		#region PHYSFS_ArchiveInfoInternal
		/// <summary>
		/// Information on various PhysicsFS-supported archives.
		/// </summary>
		/// <remarks>
		/// This structure gives you details on what sort of archives are supported by this implementation of PhysicsFS. Archives tend to be things like ZIP files and such.
		/// <p>
		/// Not all binaries are created equal! PhysicsFS can be built with or without support for various archives. You can check with PHYSFS_supportedArchiveTypes() to see if your archive type is supported.
		/// </p>
		/// </remarks>
		/// <seealso cref="PHYSFS_supportedArchiveTypes"/>\
		// This is the internal PHYSFS_ArchiveInfo using IntPtrs for marshalling.
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		private struct PHYSFS_ArchiveInfoInternal
		{
			/// <summary>
			/// Archive file extension: "ZIP", for example.
			/// </summary>
			public IntPtr extension;
			/// <summary>
			/// Human-readable archive description.
			/// </summary>
			public IntPtr description;
			/// <summary>
			/// Person who did support for this archive.
			/// </summary>
			public IntPtr author;
			/// <summary>
			/// URL related to this archive.
			/// </summary>
			public IntPtr url;
		}
		#endregion PHYSFS_ArchiveInfoInternal

		#region PHYSFS_File
		/// <summary>
		/// A PhysicsFS file handle.
		/// </summary>
		/// <remarks>You get a pointer to one of these when you open a file for reading, writing, or appending via PhysicsFS.
		/// <p>As you can see from the lack of meaningful fields, you should treat this as opaque data. Don't try to manipulate the file handle, just pass the pointer you got, unmolested, to various PhysicsFS APIs.</p>
		/// </remarks>
		/// <seealso cref="PHYSFS_openRead"/>
		/// <seealso cref="PHYSFS_openWrite"/>
		/// <seealso cref="PHYSFS_openAppend"/>
		/// <seealso cref="PHYSFS_close"/>
        /// <seealso cref="PHYSFS_read(System.IntPtr, System.IntPtr, uint, uint)"/>
		/// <seealso cref="PHYSFS_write"/>
		/// <seealso cref="PHYSFS_seek"/>
		/// <seealso cref="PHYSFS_tell"/>
		/// <seealso cref="PHYSFS_eof"/>
		/// <seealso cref="PHYSFS_setBuffer"/>
		/// <seealso cref="PHYSFS_flush"/>
		[StructLayout(LayoutKind.Sequential, Pack=4)]
		public struct PHYSFS_File
		{
			/// <summary>
			/// That's all you get. Don't touch. 
			/// </summary>
			public IntPtr opaque;
		}
		#endregion PHYSFS_File

		#endregion Public Structs

		#region Public Defines

		/// <summary>
		/// Tao.PhysFs's major version.
		/// </summary>
		public const int PHYSFS_VER_MAJOR = 1;
		/// <summary>
		/// Tao.PhysFs's minor version.
		/// </summary>
		public const int PHYSFS_VER_MINOR = 0;
		/// <summary>
		/// Tao.PhysFs's patch version.
		/// </summary>
		public const int PHYSFS_VER_PATCH = 1;

		#endregion Public Defines

		#region Public Functions
		
		#region PHYSFS_VERSION
		/// <summary>
		/// Information the version of PhysicsFS in use.
		/// </summary>
		/// <remarks>Represents the library's version as three levels: major revision (increments with massive changes, additions, and enhancements), minor revision (increments with backwards-compatible changes to the major revision), and patchlevel (increments with fixes to the minor revision).</remarks>
		/// <param name="ver">The <see cref="PHYSFS_Version"/> to change.</param>
		/// <seealso cref="PHYSFS_Version"/>
		/// <seealso cref="PHYSFS_getLinkedVersion"/>
		// Since this is dependant on the header file, we wrap our own.
		[CLSCompliant(false)] // Not CLS Compliant because it's named the same as PHYSFS_Version
		public static void PHYSFS_VERSION(out PHYSFS_Version ver)
		{
			ver.major = PHYSFS_VER_MAJOR;
			ver.minor = PHYSFS_VER_MINOR;
			ver.patch = PHYSFS_VER_PATCH;
		}
		#endregion PHYSFS_VERSION

		#region PHYSFS_addToSearchPath
		/// <summary>
		/// Add an archive or directory to the search path.
		/// </summary>
		/// <remarks>If this is a duplicate, the entry is not added again, even though the function succeeds.</remarks>
		/// <param name="newDir">directory or archive to add to the path, in platform-dependent notation.</param>
		/// <param name="appendToPath">nonzero to append to search path, zero to prepend.</param>
		/// <returns>nonzero if added to path, zero on failure (bogus archive, dir missing, etc). Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_removeFromSearchPath"/>
		/// <seealso cref="PHYSFS_getSearchPath"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_addToSearchPath(string newDir, int appendToPath);
		#endregion PHYSFS_addToSearchPath
		
		#region PHYSFS_close
		/// <summary>
		/// Close a PhysicsFS filehandle.
		/// </summary>
		/// <remarks>This call is capable of failing if the operating system was buffering writes to the physical media, and, now forced to write those changes to physical media, can not store the data for some reason. In such a case, the filehandle stays open. A well-written program should ALWAYS check the return value from the close call in addition to every writing call!</remarks>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_openRead"/>
		/// <seealso cref="PHYSFS_openWrite"/>
		/// <seealso cref="PHYSFS_openAppend"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_close(IntPtr handle);
		#endregion PHYSFS_close

		#region PHYSFS_deinit
		/// <summary>
		/// Deinitialize the PhysicsFS library.
		/// </summary>
		/// <remarks>This closes any files opened via PhysicsFS, blanks the search/write paths, frees memory, and invalidates all of your file handles.
		/// <p>Note that this call can FAIL if there's a file open for writing that refuses to close (for example, the underlying operating system was buffering writes to network filesystem, and the fileserver has crashed, or a hard drive has failed, etc). It is usually best to close all write handles yourself before calling this function, so that you can gracefully handle a specific failure.</p>
		/// <p>Once successfully deinitialized, <see cref="PHYSFS_init"/> can be called again to restart the subsystem. All defaults API states are restored at this point.</p></remarks>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>. If failure, state of PhysFS is undefined, and probably badly screwed up.</returns>
		/// <seealso cref="PHYSFS_init"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_deinit();
		#endregion PHYSFS_deinit

		#region PHYSFS_delete
		/// <summary>
		/// Delete a file or directory.
		/// </summary>
		/// <remarks>(filename) is specified in platform-independent notation in relation to the write dir.
		/// <p>A directory must be empty before this call can delete it.</p>
		/// <p>Deleting a symlink will remove the link, not what it points to, regardless of whether you "permitSymLinks" or not.</p>
		/// <p>So if you've got the write dir set to "C:\mygame\writedir" and call PHYSFS_delete("downloads/maps/level1.map") then the file "C:\mygame\writedir\downloads\maps\level1.map" is removed from the physical filesystem, if it exists and the operating system permits the deletion.</p>
		/// <p>Note that on Unix systems, deleting a file may be successful, but the actual file won't be removed until all processes that have an open filehandle to it (including your program) close their handles.</p>
		/// <p>Chances are, the bits that make up the file still exist, they are just made available to be written over at a later point. Don't consider this a security method or anything.</p></remarks>
		/// <param name="filename">Filename to delete.</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_delete(string filename);
		#endregion PHYSFS_delete

		#region PHYSFS_enumerateFilesInternal
		/// <summary>
		/// Get a file listing of a search path's directory.
		/// </summary>
		/// <param name="dir">directory in platform-independent notation to enumerate.</param>
		/// <returns>Null-terminated array of null-terminated strings.</returns>
		/// <remarks>Matching directories are interpolated. That is, if "C:\mydir" is in the search path and contains a directory "savegames" that contains "x.sav", "y.sav", and "z.sav", and there is also a "C:\userdir" in the search path that has a "savegames" subdirectory with "w.sav", then the following code:
		/// <code>
		/// char **rc = PHYSFS_enumerateFiles("savegames");
		/// char **i;
		/// for (i = rc; *i != NULL; i++)
		///		printf(" * We've got [%s].\n", *i);
		///		PHYSFS_freeList(rc);
		/// </code>
		/// ...will print:
		/// <code>
		///  * We've got [x.sav].
		///  * We've got [y.sav].
		///  * We've got [z.sav].
		///  * We've got [w.sav].
		/// </code>
		/// <p>Feel free to sort the list however you like. We only promise there will be no duplicates, but not what order the final list will come back in.</p>
		/// <p>Don't forget to call <see cref="PHYSFS_freeList"/> with the return value from this function when you are done with it.</p>
		/// </remarks>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="PHYSFS_enumerateFiles"), SuppressUnmanagedCodeSecurity]
		private extern static IntPtr PHYSFS_enumerateFilesInternal(string dir);
		#endregion PHYSFS_enumerateFilesInternal

		#region PHYSFS_enumerateFiles
		/// <summary>
		/// Get a file listing of a search path's directory.
		/// </summary>
		/// <param name="dir">directory in platform-independent notation to enumerate.</param>
		/// <returns>Null-terminated array of null-terminated strings.</returns>
		/// <remarks>Matching directories are interpolated. That is, if "C:\mydir" is in the search path and contains a directory "savegames" that contains "x.sav", "y.sav", and "z.sav", and there is also a "C:\userdir" in the search path that has a "savegames" subdirectory with "w.sav", then the following code:
		/// <code>
		/// char **rc = PHYSFS_enumerateFiles("savegames");
		/// char **i;
		/// for (i = rc; *i != NULL; i++)
		///		printf(" * We've got [%s].\n", *i);
		///		PHYSFS_freeList(rc);
		/// </code>
		/// ...will print:
		/// <code>
		///  * We've got [x.sav].
		///  * We've got [y.sav].
		///  * We've got [z.sav].
		///  * We've got [w.sav].
		/// </code>
		/// <p>Feel free to sort the list however you like. We only promise there will be no duplicates, but not what order the final list will come back in.</p>
		/// <p>Don't forget to call <see cref="PHYSFS_freeList"/> with the return value from this function when you are done with it.</p>
		/// <p>Note that Tao.PhysFs calls <see cref="PHYSFS_freeList"/> for you.</p>
		/// </remarks>
		public static string[] PHYSFS_enumerateFiles(string dir)
		{
			ArrayList strings = new ArrayList(); // Use System.Collections.Generic.List if you're on .NET 2.0
			IntPtr p = PHYSFS_enumerateFilesInternal(dir);
			IntPtr original = p;
			unsafe
			{
				int* ptr = (int*)p.ToPointer();
				while( *ptr != 0 ) 
				{
					string s = Marshal.PtrToStringAnsi(new IntPtr(*ptr));
					strings.Add(s);
					p = new IntPtr(ptr + 1);
					ptr++;
				}
			}
			PHYSFS_freeList(original);
			return (string[])strings.ToArray(typeof(string));
		}
		#endregion PHYSFS_enumerateFiles

		#region PHYSFS_eof
		/// <summary>
		/// Check for end-of-file state on a PhysicsFS filehandle.
		/// </summary>
		/// <remarks>Determine if the end of file has been reached in a PhysicsFS filehandle.</remarks>
		/// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
		/// <returns>nonzero if EOF, zero if not.</returns>
        /// <seealso cref="PHYSFS_read(System.IntPtr, System.IntPtr, uint, uint)"/>
		/// <seealso cref="PHYSFS_tell"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_eof(IntPtr handle);
		#endregion PHYSFS_eof

		#region PHYSFS_exists
		/// <summary>
		/// Determine if a file exists in the search path.
		/// </summary>
		/// <remarks>Reports true if there is an entry anywhere in the search path by the name of (fname).
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, so you might end up further down in the search path than expected.</p></remarks>
		/// <param name="fname">filename in platform-independent notation.</param>
		/// <returns>non-zero if filename exists. zero otherwise.</returns>
		/// <seealso cref="PHYSFS_isDirectory"/>
		/// <seealso cref="PHYSFS_isSymbolicLink"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_exists(string fname);
		#endregion PHYSFS_exists

		#region PHYSFS_fileLength
		/// <summary>
		/// Get total length of a file in bytes.
		/// </summary>
		/// <remarks>Note that if the file size can't be determined (since the archive is "streamed" or whatnot) than this will report (-1). Also note that if another process/thread is writing to this file at the same time, then the information this function supplies could be incorrect before you get it. Use with caution, or better yet, don't use at all.</remarks>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <returns>size in bytes of the file. -1 if can't be determined.</returns>
		/// <seealso cref="PHYSFS_tell"/>
		/// <seealso cref="PHYSFS_seek"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_fileLength(IntPtr handle);
		#endregion PHYSFS_fileLength

		#region PHYSFS_flush
		/// <summary>
		/// Flush a buffered PhysicsFS file handle.
		/// </summary>
		/// <remarks>For buffered files opened for writing, this will put the current contents of the buffer to disk and flag the buffer as empty if possible.
		/// <p>For buffered files opened for reading or unbuffered files, this is a safe no-op, and will report success.</p></remarks>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <returns>nonzero if successful, zero on error.</returns>
		/// <seealso cref="PHYSFS_setBuffer"/>
		/// <seealso cref="PHYSFS_close"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_flush(IntPtr handle);
		#endregion PHYSFS_flush

		#region PHYSFS_freeList
		/// <summary>
		/// Deallocate resources of lists returned by PhysicsFS.
		/// </summary>
		/// <remarks>Certain PhysicsFS functions return lists of information that are dynamically allocated. Use this function to free those resources.</remarks>
		/// <param name="listVar">List of information specified as freeable by this function.</param>
		/// <seealso cref="PHYSFS_getCdRomDirs"/>
		/// <seealso cref="PHYSFS_enumerateFiles"/>
		/// <seealso cref="PHYSFS_getSearchPath"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void PHYSFS_freeList(IntPtr listVar);
		#endregion PHYSFS_freeList

		#region PHYSFS_getBaseDir
		/// <summary>
		/// Get the path where the application resides.
		/// </summary>
		/// <remarks>Helper function.
		/// <p>Get the "base dir". This is the directory where the application was run from, which is probably the installation directory, and may or may not be the process's current working directory.</p>
		/// <p>You should probably use the base dir in your search path.</p></remarks>
		/// <returns>string of base dir in platform-dependent notation.</returns>
		/// <seealso cref="PHYSFS_getUserDir"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getBaseDir();
		#endregion PHYSFS_getBaseDir

		#region PHYSFS_getCdRomDirsInternal
		/// <summary>
		/// Get an array of paths to available CD-ROM drives.
		/// </summary>
		/// <remarks>The dirs returned are platform-dependent ("D:\" on Win32, "/cdrom" or whatnot on Unix). Dirs are only returned if there is a disc ready and accessible in the drive. So if you've got two drives (D: and E:), and only E: has a disc in it, then that's all you get. If the user inserts a disc in D: and you call this function again, you get both drives. If, on a Unix box, the user unmounts a disc and remounts it elsewhere, the next call to this function will reflect that change. Fun.
		/// <p>The returned value is an array of strings, with a NULL entry to signify the end of the list:</p>
		/// <p><code>
		/// char **cds = PHYSFS_getCdRomDirs();
		/// char **i;
		/// for (i = cds; *i != NULL; i++)
		///		printf("cdrom dir [%s] is available.\n", *i);
		///	PHYSFS_freeList(cds);</code></p>
		///	<p>This call may block while drives spin up. Be forewarned.</p>
		///	<p>When you are done with the returned information, you may dispose of the resources by calling <see cref="PHYSFS_freeList"/> with the returned pointer.</p></remarks>
		/// <returns>Null-terminated array of null-terminated strings.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="PHYSFS_getCdRomDirs"), SuppressUnmanagedCodeSecurity]
		private extern static IntPtr PHYSFS_getCdRomDirsInternal();
		#endregion PHYSFS_getCdRomDirsInternal

		#region PHYSFS_getCdRomDirs
		/// <summary>
		/// Get an array of paths to available CD-ROM drives.
		/// </summary>
		/// <remarks>The dirs returned are platform-dependent ("D:\" on Win32, "/cdrom" or whatnot on Unix). Dirs are only returned if there is a disc ready and accessible in the drive. So if you've got two drives (D: and E:), and only E: has a disc in it, then that's all you get. If the user inserts a disc in D: and you call this function again, you get both drives. If, on a Unix box, the user unmounts a disc and remounts it elsewhere, the next call to this function will reflect that change. Fun.
		/// <p>The returned value is an array of strings, with a NULL entry to signify the end of the list:</p>
		/// <p><code>
		/// char **cds = PHYSFS_getCdRomDirs();
		/// char **i;
		/// for (i = cds; *i != NULL; i++)
		///		printf("cdrom dir [%s] is available.\n", *i);
		///	PHYSFS_freeList(cds);</code></p>
		///	<p>This call may block while drives spin up. Be forewarned.</p>
		///	<p>When you are done with the returned information, you may dispose of the resources by calling <see cref="PHYSFS_freeList"/> with the returned pointer.</p>
		///	<p>Note that Tao.PhysFs calls <see cref="PHYSFS_freeList"/> for you.</p>
		///	</remarks>
		/// <returns>Null-terminated array of null-terminated strings.</returns>
		public static string[] PHYSFS_getCdRomDirs()
		{
			ArrayList strings = new ArrayList(); // Use System.Collections.Generic.List if you're on .NET 2.0
			IntPtr p = PHYSFS_getCdRomDirsInternal();
			IntPtr original = p;
			unsafe
			{
				int* ptr = (int*)p.ToPointer();
				while( *ptr != 0 ) 
				{
					string s = Marshal.PtrToStringAnsi(new IntPtr(*ptr));
					strings.Add(s);
					p = new IntPtr(ptr + 1);
					ptr++;
				}
			}
			PHYSFS_freeList(original);
			return (string[])strings.ToArray(typeof(string));
		}
		#endregion PHYSFS_getCdRomDirs

		#region PHYSFS_getDirSeparator
		/// <summary>
		/// Get platform-dependent dir separator string.
		/// </summary>
		/// <remarks>This returns "\\\\" on win32, "/" on Unix, and ":" on MacOS. It may be more than one character, depending on the platform, and your code should take that into account. Note that this is only useful for setting up the search/write paths, since access into those dirs always use '/' (platform-independent notation) to separate directories. This is also handy for getting platform-independent access when using stdio calls.</remarks>
		/// <returns>null-terminated string of platform's dir separator.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getDirSeparator();
		#endregion PHYSFS_getDirSeparator

		#region PHYSFS_getLastError
		/// <summary>
		/// Get human-readable error information.
		/// </summary>
		/// <remarks>Get the last PhysicsFS error message as a null-terminated string. This will be NULL if there's been no error since the last call to this function. The pointer returned by this call points to an internal buffer. Each thread has a unique error state associated with it, but each time a new error message is set, it will overwrite the previous one associated with that thread. It is safe to call this function at anytime, even before <see cref="PHYSFS_init"/>.</remarks>
		/// <returns>string of last error message.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getLastError();
		#endregion PHYSFS_getLastError

		#region PHYSFS_getLastModTime
		/// <summary>
		/// Get the last modification time of a file.
		/// </summary>
		/// <remarks>The modtime is returned as a number of seconds since the epoch (Jan 1, 1970). The exact derivation and accuracy of this time depends on the particular archiver. If there is no reasonable way to obtain this information for a particular archiver, or there was some sort of error, this function returns (-1).</remarks>
		/// <param name="filename">filename to check, in platform-independent notation.</param>
		/// <returns>last modified time of the file. -1 if it can't be determined.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_getLastModTime(string filename);
		#endregion PHYSFS_getLastModTime

		#region PHYSFS_getLinkedVersion
		/// <summary>
		/// Get the version of PhysicsFS that is linked against your program.
		/// </summary>
		/// <remarks>This function may be called safely at any time, even before <see cref="PHYSFS_init"/>.</remarks>
		/// <param name="ver">The output PHYSFS_Version structure.</param>
		/// <seealso cref="PHYSFS_VERSION"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void PHYSFS_getLinkedVersion (out PHYSFS_Version ver);
		#endregion PHYSFS_getLinkedVersion

		#region PHYSFS_getRealDir
		/// <summary>
		/// Figure out where in the search path a file resides.
		/// </summary>
		/// <remarks>The file is specified in platform-independent notation. The returned filename will be the element of the search path where the file was found, which may be a directory, or an archive. Even if there are multiple matches in different parts of the search path, only the first one found is used, just like when opening a file.
		/// <p>So, if you look for "maps/level1.map", and C:\mygame is in your search path and C:\mygame\maps\level1.map exists, then "C:\mygame" is returned.</p>
		/// <p>If a any part of a match is a symbolic link, and you've not explicitly permitted symlinks, then it will be ignored, and the search for a match will continue.</p></remarks>
		/// <param name="filename">file to look for.</param>
		/// <returns>string of element of search path containing the the file in question. NULL if not found.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getRealDir(string filename);
		#endregion PHYSFS_getRealDir

		#region PHYSFS_getSearchPath
		/// <summary>
		/// Get the current search path.
		/// </summary>
		/// <remarks>The default search path is an empty list.
		/// <p>The returned value is an array of strings, with a NULL entry to signify the end of the list:</p>
		/// <p>
		/// <code>
		/// char **i;
		/// for (i = PHYSFS_getSearchPath(); *i != NULL; i++)
		///		printf("[%s] is in the search path.\n", *i);
		///	</code></p>
		///	<p>When you are done with the returned information, you may dispose of the resources by calling <see cref="PHYSFS_freeList"/> with the returned pointer.</p>
		///	<p>Please note that Tao.PhysFs calls <see cref="PHYSFS_freeList"/> for you.</p>
		///	</remarks>
		/// <returns>Null-terminated array of null-terminated strings. NULL if there was a problem (read: OUT OF MEMORY).</returns>
		/// <seealso cref="PHYSFS_addToSearchPath"/>
		/// <seealso cref="PHYSFS_removeFromSearchPath"/>
		public static string[] PHYSFS_getSearchPath()
		{
			ArrayList strings = new ArrayList(); // Use System.Collections.Generic.List if you're on .NET 2.0
			IntPtr p = PHYSFS_getSearchPathInternal();
			IntPtr original = p;
			unsafe
			{
				int* ptr = (int*)p.ToPointer();
				while( *ptr != 0 ) 
				{
					string s = Marshal.PtrToStringAnsi(new IntPtr(*ptr));
					strings.Add(s);
					p = new IntPtr(ptr + 1);
					ptr++;
				}
			}
			PHYSFS_freeList(original);
			return (string[])strings.ToArray(typeof(string));
		}
		#endregion PHYSFS_getSearchPath

		#region PHYSFS_getSearchPathInternal
		/// <summary>
		/// Get the current search path.
		/// </summary>
		/// <remarks>The default search path is an empty list.
		/// <p>The returned value is an array of strings, with a NULL entry to signify the end of the list:</p>
		/// <p>
		/// <code>
		/// char **i;
		/// for (i = PHYSFS_getSearchPath(); *i != NULL; i++)
		///		printf("[%s] is in the search path.\n", *i);
		///	</code></p>
		///	<p>When you are done with the returned information, you may dispose of the resources by calling PHYSFS_freeList() with the returned pointer.</p></remarks>
		/// <returns>Null-terminated array of null-terminated strings. NULL if there was a problem (read: OUT OF MEMORY).</returns>
		/// <seealso cref="PHYSFS_addToSearchPath"/>
		/// <seealso cref="PHYSFS_removeFromSearchPath"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="PHYSFS_getSearchPath"), SuppressUnmanagedCodeSecurity]
		private extern static IntPtr PHYSFS_getSearchPathInternal();
		#endregion PHYSFS_getSearchPathInternal

		#region PHYSFS_getUserDir
		/// <summary>
		/// Get the path where user's home directory resides.
		/// </summary>
		/// <remarks>Helper function.
		/// <p>Get the "user dir". This is meant to be a suggestion of where a specific user of the system can store files. On Unix, this is her home directory. On systems with no concept of multiple home directories (MacOS, win95), this will default to something like "C:\mybasedir\users\username" where "username" will either be the login name, or "default" if the platform doesn't support multiple users, either.</p>
		/// <p>You should probably use the user dir as the basis for your write dir, and also put it near the beginning of your search path.</p></remarks>
		/// <returns>string of user dir in platform-dependent notation.</returns>
		/// <seealso cref="PHYSFS_getBaseDir"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getUserDir();
		#endregion PHYSFS_getUserDir

		#region PHYSFS_getWriteDir
		/// <summary>
		/// Get path where PhysicsFS will allow file writing.
		/// </summary>
		/// <remarks>Get the current write dir. The default write dir is NULL.</remarks>
		/// <returns>string of write dir in platform-dependent notation, OR NULL IF NO WRITE PATH IS CURRENTLY SET.</returns>
		/// <seealso cref="PHYSFS_setWriteDir"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static string PHYSFS_getWriteDir();
		#endregion PHYSFS_getWriteDir

		#region PHYSFS_init
		/// <summary>
		/// Initialize the PhysicsFS library.
		/// </summary>
		/// <remarks>This must be called before any other PhysicsFS function.
		/// <p>This should be called prior to any attempts to change your process's current working directory.</p></remarks>
		/// <param name="argv0">the argv[0] string passed to your program's mainline. This may be NULL on most platforms (such as ones without a standard main() function), but you should always try to pass something in here. Unix-like systems such as Linux _need_ to pass argv[0] from main() in here.</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_deinit"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_init(string argv0);
		#endregion PHYSFS_init

		#region PHYSFS_isDirectory
		/// <summary>
		/// Determine if a file in the search path is really a directory.
		/// </summary>
		/// <remarks>Determine if the first occurence of (fname) in the search path is really a directory entry.
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, so you might end up further down in the search path than expected.</p></remarks>
		/// <param name="filename">filename in platform-independent notation.</param>
		/// <returns>non-zero if filename exists and is a directory. zero otherwise.</returns>
		/// <seealso cref="PHYSFS_exists"/>
		/// <seealso cref="PHYSFS_isSymbolicLink"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_isDirectory(string filename);
		#endregion PHYSFS_isDirectory

		#region PHYSFS_isSymbolicLink
		/// <summary>
		/// Determine if a file in the search path is really a symbolic link.
		/// </summary>
		/// <remarks>Determine if the first occurence of (fname) in the search path is really a symbolic link.
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, and as such, this function will always return 0 in that case.</p></remarks>
		/// <param name="filename">filename in platform-independent notation.</param>
		/// <returns>non-zero if filename exists and is a symlink. zero otherwise.</returns>
		/// <seealso cref="PHYSFS_exists"/>
		/// <seealso cref="PHYSFS_isDirectory"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_isSymbolicLink(string filename);
		#endregion PHYSFS_isSymbolicLink

		#region PHYSFS_mkdir
		/// <summary>
		/// Create a directory.
		/// </summary>
		/// <remarks>This is specified in platform-independent notation in relation to the write dir. All missing parent directories are also created if they don't exist.
		/// <p>So if you've got the write dir set to "C:\mygame\writedir" and call PHYSFS_mkdir("downloads/maps") then the directories "C:\mygame\writedir\downloads" and "C:\mygame\writedir\downloads\maps" will be created if possible. If the creation of "maps" fails after we have successfully created "downloads", then the function leaves the created directory behind and reports failure.</p></remarks>
		/// <param name="dirName">New dir to create.</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_mkdir(string dirName);
		#endregion PHYSFS_mkdir

		#region PHYSFS_openAppend
		/// <summary>
		/// Open a file for appending.
		/// </summary>
		/// <remarks>Open a file for writing, in platform-independent notation and in relation to the write dir as the root of the writable filesystem. The specified file is created if it doesn't exist. If it does exist, the writing offset is set to the end of the file, so the first write will be the byte after the end.
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, and opening a symlink with this function will fail in such a case.</p></remarks>
		/// <param name="filename">File to open.</param>
		/// <returns>A valid PhysicsFS filehandle on success, NULL on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_openRead"/>
		/// <seealso cref="PHYSFS_openWrite"/>
		/// <seealso cref="PHYSFS_write"/>
		/// <seealso cref="PHYSFS_close"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr PHYSFS_openAppend(string filename);
		#endregion PHYSFS_openAppend

		#region PHYSFS_openRead
		/// <summary>
		/// Open a file for reading.
		/// </summary>
		/// <remarks>Open a file for reading, in platform-independent notation. The search path is checked one at a time until a matching file is found, in which case an abstract filehandle is associated with it, and reading may be done. The reading offset is set to the first byte of the file.
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, and opening a symlink with this function will fail in such a case.</p></remarks>
		/// <param name="filename">File to open.</param>
		/// <returns>A valid PhysicsFS filehandle on success, NULL on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_openWrite"/>
		/// <seealso cref="PHYSFS_openAppend"/>
        /// <seealso cref="PHYSFS_read(System.IntPtr, System.IntPtr, uint, uint)"/>
		/// <seealso cref="PHYSFS_close"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr PHYSFS_openRead(string filename);
		#endregion PHYSFS_openRead

		#region PHYSFS_openWrite
		/// <summary>
		/// Open a file for writing.
		/// </summary>
		/// <remarks>Open a file for writing, in platform-independent notation and in relation to the write dir as the root of the writable filesystem. The specified file is created if it doesn't exist. If it does exist, it is truncated to zero bytes, and the writing offset is set to the start.
		/// <p>Note that entries that are symlinks are ignored if PHYSFS_permitSymbolicLinks(1) hasn't been called, and opening a symlink with this function will fail in such a case.</p></remarks>
		/// <param name="filename">File to open.</param>
		/// <returns>A valid PhysicsFS filehandle on success, NULL on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_openRead"/>
		/// <seealso cref="PHYSFS_openAppend"/>
		/// <seealso cref="PHYSFS_write"/>
		/// <seealso cref="PHYSFS_close"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr PHYSFS_openWrite(string filename);
		#endregion PHYSFS_openWrite

		#region PHYSFS_permitSymbolicLinks
		/// <summary>
		/// Enable or disable following of symbolic links.
		/// </summary>
		/// <remarks>Some physical filesystems and archives contain files that are just pointers to other files. On the physical filesystem, opening such a link will (transparently) open the file that is pointed to.
		/// <p>By default, PhysicsFS will check if a file is really a symlink during open calls and fail if it is. Otherwise, the link could take you outside the write and search paths, and compromise security.</p>
		/// <p>If you want to take that risk, call this function with a non-zero parameter. Note that this is more for sandboxing a program's scripting language, in case untrusted scripts try to compromise the system. Generally speaking, a user could very well have a legitimate reason to set up a symlink, so unless you feel there's a specific danger in allowing them, you should permit them.</p>
		/// <p>Symlinks are only explicitly checked when dealing with filenames in platform-independent notation. That is, when setting up your search and write paths, etc, symlinks are never checked for.</p>
		/// <p>Symbolic link permission can be enabled or disabled at any time after you've called PHYSFS_init(), and is disabled by default.</p></remarks>
		/// <param name="allow">nonzero to permit symlinks, zero to deny linking.</param>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void PHYSFS_permitSymbolicLinks(int allow);
		#endregion PHYSFS_permitSymbolicLinks

		#region PHYSFS_read
		/// <summary>
		/// Read data from a PhysicsFS filehandle to a buffer location which already has memory allocated to it.
		/// </summary>
		/// <remarks>The file must be opened for reading. Memory must be allocated.</remarks>
		/// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
		/// <param name="buffer">buffer to store read data into.</param>
		/// <param name="objSize">size in bytes of objects being read from (handle).</param>
		/// <param name="objCount">number of (objSize) objects to read from (handle).</param>
		/// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
		/// <seealso cref="PHYSFS_eof"/>
		// PHYSFS_sint64 PHYSFS_read(PHYSFS_file * handle, void * buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount);
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="PHYSFS_read"), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_read(IntPtr handle, IntPtr buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount);

        /// <summary>
		/// Read data from a PhysicsFS filehandle. Buffer memory is allocated for you.
		/// </summary>
        /// <remarks>The file must be opened for reading. Note that this allocates memory and points to it through the buffer. You must then free the memory by using Marshal.FreeHGlobal(buffer)</remarks>
		/// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
		/// <param name="buffer">buffer where memory is stored. Memory is allocated for you.</param>
		/// <param name="objSize">size in bytes of objects being read from (handle).</param>
		/// <param name="objCount">number of (objSize) objects to read from (handle).</param>
		/// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
		/// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
		public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out IntPtr buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
		{
            buffer = Marshal.AllocHGlobal((int)objSize * (int)objCount);
            return PHYSFS_read(handle, buffer, objSize, objCount);
		}

        /// <summary>
		/// Read a byte array from a PhysicsFS filehandle.
		/// </summary>
		/// <remarks>The file must be opened for reading.</remarks>
		/// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
		/// <param name="buffer">byte array to read in</param>
		/// <param name="objSize">size in bytes of objects being read from (handle).</param>
		/// <param name="objCount">number of (objSize) objects to read from (handle).</param>
		/// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
		/// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out byte[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new byte[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a char array from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">char array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out char[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new char[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a double array from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">double array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out double[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new double[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a float array from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">float array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out float[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new float[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a integer array from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">integer array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out int[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new int[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a array of long values from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">byte array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
		[CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out long[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new long[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }

        /// <summary>
        /// Read a array of short values from a PhysicsFS filehandle.
        /// </summary>
        /// <remarks>The file must be opened for reading.</remarks>
        /// <param name="handle">handle returned from <see cref="PHYSFS_openRead"/>.</param>
        /// <param name="buffer">short array to read in</param>
        /// <param name="objSize">size in bytes of objects being read from (handle).</param>
        /// <param name="objCount">number of (objSize) objects to read from (handle).</param>
        /// <returns>number of objects read. <see cref="PHYSFS_getLastError"/> can shed light on the reason this might be less than (objCount), as can <see cref="PHYSFS_eof"/>. -1 if complete failure.</returns>
        /// <seealso cref="PHYSFS_eof"/>
        [CLSCompliant(false)]
        public static PHYSFS_sint64 PHYSFS_read(IntPtr handle, out short[] buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
        {
            IntPtr ptrBuffer;
            PHYSFS_sint64 ret = PHYSFS_read(handle, out ptrBuffer, objSize, objCount);
            buffer = new short[objCount];
            Marshal.Copy(ptrBuffer, buffer, 0, (int)objCount);
            Marshal.FreeHGlobal(ptrBuffer);
            return ret;
        }
		#endregion PHYSFS_read

		#region PHYSFS_readSBE16
		/// <summary>
		/// Read and convert a signed 16-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 16-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSBE16(IntPtr handle, ref PHYSFS_sint16 val);
		#endregion PHYSFS_readSBE16

		#region PHYSFS_readSBE32
		/// <summary>
		/// Read and convert a signed 32-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 32-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSBE32(IntPtr handle, ref PHYSFS_sint32 val);
		#endregion PHYSFS_readSBE32

		#region PHYSFS_readSBE64
		/// <summary>
		/// Read and convert a signed 64-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 64-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSBE64(IntPtr handle, ref PHYSFS_sint64 val);
		#endregion PHYSFS_readSBE64

		#region PHYSFS_readSLE16
		/// <summary>
		/// Read and convert a signed 16-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 16-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSLE16(IntPtr handle, ref PHYSFS_sint16 val);
		#endregion PHYSFS_readSLE16

		#region PHYSFS_readSLE32
		/// <summary>
		/// Read and convert a signed 32-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 32-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSLE32(IntPtr handle, ref PHYSFS_sint32 val);
		#endregion PHYSFS_readSLE32

		#region PHYSFS_readSLE64
		/// <summary>
		/// Read and convert a signed 64-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read a signed 64-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readSLE64(IntPtr handle, ref PHYSFS_sint64 val);
		#endregion PHYSFS_readSLE64

		#region PHYSFS_readUBE16
		/// <summary>
		/// Read and convert an unsigned 16-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 16-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readUBE16(IntPtr handle, ref PHYSFS_uint16 val);
		#endregion PHYSFS_readUBE16

		#region PHYSFS_readUBE32
		/// <summary>
		/// Read and convert an unsigned 32-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 32-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readUBE32(IntPtr handle, ref PHYSFS_uint32 val);
		#endregion PHYSFS_readUBE32

		#region PHYSFS_readUBE64
		/// <summary>
		/// Read and convert an unsigned 64-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 64-bit bigendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readUBE64(IntPtr handle, ref PHYSFS_uint64 val);
		#endregion PHYSFS_readUBE64

		#region PHYSFS_readULE16
		/// <summary>
		/// Read and convert an unsigned 16-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 16-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readULE16(IntPtr handle, ref PHYSFS_uint16 val);
		#endregion PHYSFS_readULE16

		#region PHYSFS_readULE32
		/// <summary>
		/// Read and convert an unsigned 32-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 32-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readULE32(IntPtr handle, ref PHYSFS_uint32 val);
		#endregion PHYSFS_readULE32

		#region PHYSFS_readULE64
		/// <summary>
		/// Read and convert an unsigned 64-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Read an unsigned 64-bit littleendian value from a file and convert it to the platform's native byte order.</remarks>
		/// <param name="handle">PhysicsFS file handle from which to read.</param>
		/// <param name="val">Where value should be stored.</param>
		/// <returns>zero on failure, non-zero on success. If successful, val will store the result. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_readULE64(IntPtr handle, ref PHYSFS_uint32 val);
		#endregion PHYSFS_readULE64

		#region PHYSFS_removeFromSearchPath
		/// <summary>
		/// Remove a directory or archive from the search path.
		/// </summary>
		/// <remarks>This must be a (case-sensitive) match to a dir or archive already in the search path, specified in platform-dependent notation.
		/// <p>This call will fail (and fail to remove from the path) if the element still has files open in it.</p></remarks>
		/// <param name="oldDir">dir/archive to remove.</param>
		/// <returns>nonzero on success, zero on failure. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>().</returns>
		/// <seealso cref="PHYSFS_addToSearchPath"/>
		/// <seealso cref="PHYSFS_getSearchPath"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_removeFromSearchPath(string oldDir);
		#endregion PHYSFS_removeFromSearchPath

		#region PHYSFS_seek
		/// <summary>
		/// Seek to a new position within a PhysicsFS filehandle.
		/// </summary>
		/// <remarks>The next read or write will occur at that place. Seeking past the beginning or end of the file is not allowed, and causes an error.</remarks>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <param name="pos">number of bytes from start of file to seek to.</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>().</returns>
		/// <seealso cref="PHYSFS_tell"/>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_seek(IntPtr handle, PHYSFS_uint64 pos);
		#endregion PHYSFS_seek

		#region PHYSFS_setBuffer
		/// <summary>
		/// Set up buffering for a PhysicsFS file handle.
		/// </summary>
		/// <remarks>Define an i/o buffer for a file handle. A memory block of (bufsize) bytes will be allocated and associated with (handle).
        /// <p>For files opened for reading, up to (bufsize) bytes are read from (handle) and stored in the internal buffer. Calls to <see cref="PHYSFS_read(System.IntPtr, System.IntPtr, uint, uint)"/>() will pull from this buffer until it is empty, and then refill it for more reading. Note that compressed files, like ZIP archives, will decompress while buffering, so this can be handy for offsetting CPU-intensive operations. The buffer isn't filled until you do your next read.</p>
		/// <p>For files opened for writing, data will be buffered to memory until the buffer is full or the buffer is flushed. Closing a handle implicitly causes a flush...check your return values!</p>
		/// <p>Seeking, etc transparently accounts for buffering.</p>
		/// <p>You can resize an existing buffer by calling this function more than once on the same file. Setting the buffer size to zero will free an existing buffer.</p>
		/// <p>PhysicsFS file handles are unbuffered by default.</p>
		/// <p>Please check the return value of this function! Failures can include not being able to seek backwards in a read-only file when removing the buffer, not being able to allocate the buffer, and not being able to flush the buffer to disk, among other unexpected problems.</p></remarks>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <param name="bufsize">size, in bytes, of buffer to allocate.</param>
		/// <returns>nonzero if successful, zero on error.</returns>
		/// <seealso cref="PHYSFS_flush"/>
        /// <seealso cref="PHYSFS_read(System.IntPtr, System.IntPtr, uint, uint)"/>
		/// <seealso cref="PHYSFS_write"/>
		/// <seealso cref="PHYSFS_close"/>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_setBuffer(IntPtr handle, PHYSFS_uint64 bufsize);
		#endregion PHYSFS_setBuffer

		#region PHYSFS_setSaneConfig
		/// <summary>
		/// Set up sane, default paths.
		/// </summary>
		/// <remarks>Helper function.
		/// <p>The write dir will be set to "userdir/.organization/appName", which is created if it doesn't exist.</p>
		/// <p>The above is sufficient to make sure your program's configuration directory is separated from other clutter, and platform-independent. The period before "mygame" even hides the directory on Unix systems.</p>
		/// <p>The search path will be:
		/// * The Write Dir (created if it doesn't exist)
		/// * The Base Dir (PHYSFS_getBaseDir())
		/// * All found CD-ROM dirs (optionally)</p>
		/// <p>These directories are then searched for files ending with the extension (archiveExt), which, if they are valid and supported archives, will also be added to the search path. If you specified "PKG" for (archiveExt), and there's a file named data.PKG in the base dir, it'll be checked. Archives can either be appended or prepended to the search path in alphabetical order, regardless of which directories they were found in.</p>
		/// <p>All of this can be accomplished from the application, but this just does it all for you. Feel free to add more to the search path manually, too.</p></remarks>
		/// <param name="organization">Name of your company/group/etc to be used as a dirname, so keep it small, and no-frills.</param>
		/// <param name="appName">Program-specific name of your program, to separate it from other programs using PhysicsFS.</param>
		/// <param name="archiveExt">File extension used by your program to specify an archive. For example, Quake 3 uses "pk3", even though they are just zipfiles. Specify NULL to not dig out archives automatically. Do not specify the '.' char; If you want to look for ZIP files, specify "ZIP" and not ".ZIP" ... the archive search is case-insensitive.</param>
		/// <param name="includeCdRoms">Non-zero to include CD-ROMs in the search path, and (if (archiveExt) != NULL) search them for archives. This may cause a significant amount of blocking while discs are accessed, and if there are no discs in the drive (or even not mounted on Unix systems), then they may not be made available anyhow. You may want to specify zero and handle the disc setup yourself.</param>
		/// <param name="archivesFirst">Non-zero to prepend the archives to the search path. Zero to append them. Ignored if !(archiveExt).</param>
		/// <returns>nonzero on success, zero on error. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_setSaneConfig(string organization, string appName, string archiveExt, int includeCdRoms, int archivesFirst);
		#endregion PHYSFS_setSaneConfig

		#region PHYSFS_setWriteDir
		/// <summary>
		/// Tell PhysicsFS where it may write files.
		/// </summary>
		/// <remarks>Set a new write dir. This will override the previous setting. If the directory or a parent directory doesn't exist in the physical filesystem, PhysicsFS will attempt to create them as needed.
		/// <p>This call will fail (and fail to change the write dir) if the current write dir still has files open in it.</p></remarks>
		/// <param name="newDir">The new directory to be the root of the write dir, specified in platform-dependent notation. Setting to NULL disables the write dir, so no files can be opened for writing via PhysicsFS.</param>
		/// <returns>non-zero on success, zero on failure. All attempts to open a file for writing via PhysicsFS will fail until this call succeeds. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>().</returns>
		/// <seealso cref="PHYSFS_getWriteDir"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_setWriteDir(string newDir);
		#endregion PHYSFS_setWriteDir

		#region PHYSFS_supportedArchiveTypes
		/// <summary>
		/// Get a list of supported archive types.
		/// </summary>
		/// <remarks>Get a list of archive types supported by this implementation of PhysicFS. These are the file formats usable for search path entries. This is for informational purposes only. Note that the extension listed is merely convention: if we list "ZIP", you can open a PkZip-compatible archive with an extension of "XYZ", if you like.
		/// <p>The returned value is an array of pointers to PHYSFS_ArchiveInfo structures, with a NULL entry to signify the end of the list:</p>
		/// <p>
		/// <code>
		/// PHYSFS_ArchiveInfo **i;
		/// for (i = PHYSFS_supportedArchiveTypes(); *i != NULL; i++)
		/// {
		///		printf("Supported archive: [%s], which is [%s].\n",
		///			i->extension, i->description);
		///	}
		/// </code>
		/// </p>
		/// <p>The return values are pointers to static internal memory, and should be considered READ ONLY, and never freed.</p></remarks>
		/// <returns>Null-terminated array of READ ONLY structures.</returns>
		public static PHYSFS_ArchiveInfo[] PHYSFS_supportedArchiveTypes()
		{
			ArrayList archives = new ArrayList(); // Use System.Collections.Generic.List if you're on .NET 2.0
			IntPtr p = PHYSFS_supportedArchiveTypesInternal();
			unsafe
			{
				int* ptr = (int*)p.ToPointer();
				while( *ptr != 0 ) 
				{
					PHYSFS_ArchiveInfoInternal info = (PHYSFS_ArchiveInfoInternal)Marshal.PtrToStructure(new IntPtr(*ptr),typeof(PHYSFS_ArchiveInfoInternal));
					PHYSFS_ArchiveInfo archiveInfo = new PHYSFS_ArchiveInfo(
						Marshal.PtrToStringAnsi(info.extension),
						Marshal.PtrToStringAnsi(info.description),
						Marshal.PtrToStringAnsi(info.author),
						Marshal.PtrToStringAnsi(info.url));
					archives.Add(archiveInfo);
					p = new IntPtr(ptr + 1);
					ptr++;
				}
			}
			return (PHYSFS_ArchiveInfo[])archives.ToArray(typeof(PHYSFS_ArchiveInfo));
		}
		#endregion PHYSFS_supportedArchiveTypes

		#region PHYSFS_supportedArchiveTypesInternal
		/// <summary>
		/// Private bindings to get a list of supported archive types.
		/// </summary>
		/// <remarks>Get a list of archive types supported by this implementation of PhysicFS. These are the file formats usable for search path entries. This is for informational purposes only. Note that the extension listed is merely convention: if we list "ZIP", you can open a PkZip-compatible archive with an extension of "XYZ", if you like.
		/// <p>The returned value is an array of pointers to PHYSFS_ArchiveInfo structures, with a NULL entry to signify the end of the list:</p>
		/// <p>
		/// <code>
		/// PHYSFS_ArchiveInfo **i;
		/// for (i = PHYSFS_supportedArchiveTypes(); *i != NULL; i++)
		/// {
		///		printf("Supported archive: [%s], which is [%s].\n",
		///			i->extension, i->description);
		///	}
		/// </code>
		/// </p>
		/// <p>The return values are pointers to static internal memory, and should be considered READ ONLY, and never freed.</p></remarks>
		/// <returns>READ ONLY Null-terminated array of READ ONLY structures.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION, EntryPoint="PHYSFS_supportedArchiveTypes"), SuppressUnmanagedCodeSecurity]
		private static extern IntPtr PHYSFS_supportedArchiveTypesInternal();
		#endregion PHYSFS_supportedArchiveTypesInternal

		#region PHYSFS_swapSBE16
		/// <summary>
		/// Swap bigendian signed 16 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 16-bit signed value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint16 PHYSFS_swapSBE16(PHYSFS_sint16 val);
		#endregion PHYSFS_swapSBE16

		#region PHYSFS_swapSBE32
		/// <summary>
		/// Swap bigendian signed 32 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 32-bit signed value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint32 PHYSFS_swapSBE32(PHYSFS_sint32 val);
		#endregion PHYSFS_swapSBE32

		#region PHYSFS_swapSBE64
		/// <summary>
		/// Swap bigendian signed 64 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 64-bit signed value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_swapSBE64(PHYSFS_sint64 val);
		#endregion PHYSFS_swapSBE64

		#region PHYSFS_swapSLE16
		/// <summary>
		/// Swap littleendian signed 16 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 16-bit signed value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint16 PHYSFS_swapSLE16(PHYSFS_sint16 val);
		#endregion PHYSFS_swapSLE16

		#region PHYSFS_swapSLE32
		/// <summary>
		/// Swap littleendian signed 32 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 32-bit signed value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint32 PHYSFS_swapSLE32(PHYSFS_sint32 val);
		#endregion PHYSFS_swapSLE32

		#region PHYSFS_swapSLE64
		/// <summary>
		/// Swap littleendian signed 64 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 64-bit signed value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_swapSLE64(PHYSFS_sint64 val);
		#endregion PHYSFS_swapSLE64

		#region PHYSFS_swapUBE16
		/// <summary>
		/// Swap bigendian unsigned 16 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 16-bit unsigned value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint16 PHYSFS_swapUBE16(PHYSFS_uint16 val);
		#endregion PHYSFS_swapUBE16

		#region PHYSFS_swapUBE32
		/// <summary>
		/// Swap bigendian unsigned 32 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 32-bit unsigned value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint32 PHYSFS_swapUBE32(PHYSFS_uint32 val);
		#endregion PHYSFS_swapUBE32

		#region PHYSFS_swapUBE64
		/// <summary>
		/// Swap bigendian unsigned 64 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 64-bit unsigned value in bigendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint64 PHYSFS_swapUBE64(PHYSFS_uint64 val);
		#endregion PHYSFS_swapUBE64

		#region PHYSFS_swapULE16
		/// <summary>
		/// Swap littleendian unsigned 16 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 16-bit unsigned value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint16 PHYSFS_swapULE16(PHYSFS_uint16 val);
		#endregion PHYSFS_swapULE16

		#region PHYSFS_swapULE32
		/// <summary>
		/// Swap littleendian unsigned 32 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 32-bit unsigned value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint32 PHYSFS_swapULE32(PHYSFS_uint32 val);
		#endregion PHYSFS_swapULE32

		#region PHYSFS_swapULE64
		/// <summary>
		/// Swap littleendian unsigned 64 to platform's native byte order.
		/// </summary>
		/// <remarks>Take a 64-bit unsigned value in littleendian format and convert it to the platform's native byte order.</remarks>
		/// <param name="val">value to convert</param>
		/// <returns>converted value.</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_uint64 PHYSFS_swapULE64(PHYSFS_uint64 val);
		#endregion PHYSFS_swapULE64

		#region PHYSFS_tell
		/// <summary>
		/// Determine current position within a PhysicsFS filehandle.
		/// </summary>
		/// <param name="handle">handle returned from PHYSFS_open*().</param>
		/// <returns>offset in bytes from start of file. -1 if error occurred. Specifics of the error can be gleaned from <see cref="PHYSFS_getLastError"/>.</returns>
		/// <seealso cref="PHYSFS_seek"/>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_tell(IntPtr handle);
		#endregion PHYSFS_tell

		#region PHYSFS_write
		/// <summary>
		/// Write data to a PhysicsFS filehandle.
		/// </summary>
		/// <remarks>The file must be opened for writing.</remarks>
		/// <param name="handle">retval from <see cref="PHYSFS_openWrite"/> or <see cref="PHYSFS_openAppend"/>.</param>
		/// <param name="buffer">buffer to store read data into.</param>
		/// <param name="objSize">size in bytes of objects being read from (handle).</param>
		/// <param name="objCount">number of (objSize) objects to read from (handle).</param>
		/// <returns>number of objects written. <see cref="PHYSFS_getLastError"/>() can shed light on the reason this might be less than (objCount). -1 if complete failure.</returns>
        // PHYSFS_write(PHYSFS_file * handle, const void * buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount)
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static PHYSFS_sint64 PHYSFS_write(IntPtr handle, IntPtr buffer, PHYSFS_uint32 objSize, PHYSFS_uint32 objCount);
		#endregion PHYSFS_write

		#region PHYSFS_writeSBE16
		/// <summary>
		/// Convert and write a signed 16-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 16-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSBE16(IntPtr file, PHYSFS_sint16 val);
		#endregion PHYSFS_writeSBE16

		#region PHYSFS_writeSBE32
		/// <summary>
		/// Convert and write a signed 32-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 32-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSBE32(IntPtr file, PHYSFS_sint32 val);
		#endregion PHYSFS_writeSBE32

		#region PHYSFS_writeSBE64
		/// <summary>
		/// Convert and write a signed 64-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 64-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSBE64 (IntPtr file, PHYSFS_sint64 val);
		#endregion PHYSFS_writeSBE64

		#region PHYSFS_writeSLE16
		/// <summary>
		/// Convert and write a signed 16-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 16-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSLE16(IntPtr file, PHYSFS_sint16 val);
		#endregion PHYSFS_writeSLE16

		#region PHYSFS_writeSLE32
		/// <summary>
		/// Convert and write a signed 32-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 32-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSLE32(IntPtr file, PHYSFS_sint32 val);
		#endregion PHYSFS_writeSLE32

		#region PHYSFS_writeSLE64
		/// <summary>
		/// Convert and write a signed 64-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert a signed 64-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeSLE64(IntPtr file, PHYSFS_sint64 val);
		#endregion PHYSFS_writeSLE64

		#region PHYSFS_writeUBE16
		/// <summary>
		/// Convert and write an unsigned 16-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 16-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeUBE16(IntPtr file, PHYSFS_uint16 val);
		#endregion PHYSFS_writeUBE16

		#region PHYSFS_writeUBE32
		/// <summary>
		/// Convert and write an unsigned 32-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 32-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeUBE32(IntPtr file, PHYSFS_uint32 val);
		#endregion PHYSFS_writeUBE32

		#region PHYSFS_writeUBE64
		/// <summary>
		/// Convert and write an unsigned 64-bit bigendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 64-bit value from the platform's native byte order to bigendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeUBE64(IntPtr file, PHYSFS_uint64 val);
		#endregion PHYSFS_writeUBE64

		#region PHYSFS_writeULE16
		/// <summary>
		/// Convert and write an unsigned 16-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 16-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeULE16(IntPtr file, PHYSFS_uint16 val);
		#endregion PHYSFS_writeULE16

		#region PHYSFS_writeULE32
		/// <summary>
		/// Convert and write an unsigned 32-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 32-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeULE32(IntPtr file, PHYSFS_uint32 val);
		#endregion PHYSFS_writeULE32

		#region PHYSFS_writeULE64
		/// <summary>
		/// Convert and write an unsigned 64-bit littleendian value.
		/// </summary>
		/// <remarks>Convenience function. Convert an unsigned 64-bit value from the platform's native byte order to littleendian and write it to a file.</remarks>
		/// <param name="file">PhysicsFS file handle to which to write.</param>
		/// <param name="val">Value to convert and write.</param>
		/// <returns>zero on failure, non-zero on success. On failure, you can find out what went wrong from <see cref="PHYSFS_getLastError"/>().</returns>
		[CLSCompliant(false)]
		[DllImport(PHYSFS_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int PHYSFS_writeULE64(IntPtr file, PHYSFS_uint64 val);
		#endregion PHYSFS_writeULE64

		#endregion Public Functions

		#endregion physfs.h
	}
}
