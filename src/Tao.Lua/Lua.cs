#region License
/*
 MIT License
 Copyright 2003-2007 Tao Framework Team
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

#region Original License

/*
 Copyright (C) 1994-2006 Lua.org, PUC-Rio.  All rights reserved.

 Permission is hereby granted, free of charge, to any person obtaining
 a copy of this software and associated documentation files (the
 "Software"), to deal in the Software without restriction, including
 without limitation the rights to use, copy, modify, merge, publish,
 distribute, sublicense, and/or sell copies of the Software, and to
 permit persons to whom the Software is furnished to do so, subject to
 the following conditions:

 The above copyright notice and this permission notice shall be
 included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
 CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
 TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
 SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

#endregion Original License

using System;
using System.Security;
using System.Runtime.InteropServices;
using System.Text;

namespace Tao.Lua
{
    #region Aliases
    using lua_State = System.IntPtr;
    using size_t = System.UInt32;
    using lua_Number = System.Double;
    using lua_Integer = System.Int32;
    using lua_Debug = System.IntPtr;
    #endregion Aliases

    /// #region Class Documentation
    /// <summary>
    ///     Lua bindings for .NET, implementing Lua 5.1.1 (http://www.lua.org).
    /// </summary>
    /// <remarks>
    ///		Lua is a powerful light-weight programming language designed for
    ///		extending applications. Lua is also frequently used as a
    ///		general-purpose, stand-alone language.
    ///	<p>More information can be found at the official website (http://www.lua.org).</p>
    ///	</remarks>
    /// #endregion Class Documentation
    public static class Lua
    {
        #region Private Constants

        private const string LUA_NATIVE_LIBRARY = "lua5.1.dll";
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;

        #endregion Private Constants

        #region Lua.h

        #region Public Constants

        /// <summary>
        /// 
        /// </summary>
        public const string LUA_VERSION = "Lua 5.1";
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_RELEASE = "Lua 5.1.1";
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_VERSION_NUM = 501;
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_COPYRIGHT = "Copyright (C) 1994-2006 Lua.org, PUC-Rio";
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_AUTHORS = "R. Ierusalimschy, L. H. de Figueiredo & W. Celes";

        // mark for precompiled code (`<esc>Lua')
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_SIGNATURE = "\033Lua";

        //option for multiple returns in `lua_pcall' and `lua_call'
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MULTRET = -1;

        // pseudo-indices
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_REGISTRYINDEX = -10000;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ENVIRONINDEX = -10001;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GLOBALSINDEX = -10002;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static int lua_upvalueindex(int i) { return LUA_GLOBALSINDEX - i; }

        // thread status; 0 is OK 
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_YIELDSTATUS = 1; // LUA_YIELD
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ERRRUN = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ERRSYNTAX = 3;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ERRMEM = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ERRERR = 5;

        #endregion Public Constants

        #region Public Delegates

        //typedef int (*lua_CFunction) (lua_State *L);
        /// <summary>
        ///     Type for C functions.
        /// </summary>
        /// <param name="L"></param>
        /// <remarks>
        ///     In order to communicate properly with Lua, a C function must use the following
        ///     protocol, which defines the way parameters and results are passed: a C function
        ///     receives its arguments from Lua in its stack in direct order (the first argument
        ///     is pushed first). So, when the function starts, lua_gettop(L) returns the number
        ///     of arguments received by the function. The first argument (if any) is at index 1
        ///     and its last argument is at index lua_gettop(L). To return values to Lua, a C
        ///     function just pushes them onto the stack, in direct order (the first result is
        ///     pushed first), and returns the number of results. Any other value in the stack
        ///     below the results will be properly discarded by Lua. Like a Lua function, a C
        ///     function called by Lua can also return many results.
        /// </remarks>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int lua_CFunction(lua_State L);

        //functions that read/write blocks when loading/dumping Lua chunks
        //typedef const char * (*lua_Reader) (lua_State *L, void *ud, size_t *sz);
        /// <summary>
        ///     The reader function used by lua_load.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="sz"></param>
        /// <returns>
        ///     To signal the end of the chunk, the reader must return NULL. The reader
        ///     function may return pieces of any size greater than zero.
        /// </returns>
        /// <remarks>
        ///     Every time it needs another piece of the chunk, lua_load calls the reader,
        ///     passing along its data parameter. The reader must return a pointer to a
        ///     block of memory with a new piece of the chunk and set size to the block size.
        ///     The block must exist until the reader function is called again.
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [CLSCompliant(false)]
        public delegate string lua_Reader(lua_State L, IntPtr ud, ref size_t sz);

        //typedef int (*lua_Writer) (lua_State *L, const void* p, size_t sz, void* ud);
        /// <summary>
        ///     The writer function used by lua_dump. Every time it produces another piece of chunk, lua_dump calls the writer, passing along the buffer to be written (p), its size (sz), and the data parameter supplied to lua_dump.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="p"></param>
        /// <param name="sz"></param>
        /// <param name="ud"></param>
        /// <returns>
        ///     The writer returns an error code: 0 means no errors; any other value means an error and stops lua_dump from calling the writer again.
        /// </returns>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [CLSCompliant(false)]
        public delegate int lua_Writer(lua_State L, IntPtr p, size_t sz, IntPtr ud);

        //typedef void * (*lua_Alloc) (void *ud, void *ptr, size_t osize, size_t nsize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ud"></param>
        /// <param name="ptr"></param>
        /// <param name="osize"></param>
        /// <param name="nsize"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr lua_Alloc(IntPtr ud, IntPtr ptr, size_t osize, size_t nsize);

        #endregion Public Delegates

        #region Basic Types

        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TNONE = -1;

        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TNIL = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TBOOLEAN = 1;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TLIGHTUSERDATA = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TNUMBER = 3;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TSTRING = 4;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TTABLE = 5;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TFUNCTION = 6;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TUSERDATA = 7;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_TTHREAD = 8;

        /// <summary>
        ///     Minimum Lua stack available to a C function
        /// </summary>
        public const int LUA_MINSTACK = 20;

        #endregion Basic Types

        #region Public Functions

        #region Basic State Management

        //LUA_API lua_State *(lua_newstate) (lua_Alloc f, void *ud);
        /// <summary>
        ///     Creates a new, independent state.   
        /// </summary>
        /// <param name="f">The argument f is the allocator function.</param>
        /// <param name="ud">The second argument, ud, is an opaque pointer that Lua simply passes to the allocator in every call.</param>
        /// <returns>Returns NULL if cannot create the state (due to lack of memory).</returns>
        /// <remarks>Lua does all memory allocation for this state through this function.</remarks>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State lua_newstate(lua_Alloc f, IntPtr ud);

        //LUA_API void       (lua_close) (lua_State *L);
        /// <summary>
        ///     Destroys all objects in the given Lua state (calling the corresponding
        ///     garbage-collection metamethods, if any) and frees all dynamic memory used
        ///     by this state. On several platforms, you may not need to call this function,
        ///     because all resources are naturally released when the host program ends. On
        ///     the other hand, long-running programs, such as a daemon or a web server, might
        ///     need to release states as soon as they are not needed, to avoid growing too large.
        /// </summary>
        /// <param name="L"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_close(lua_State L);

        //LUA_API lua_State *(lua_newthread) (lua_State *L);
        /// <summary>
        ///     Creates a new thread, pushes it on the stack, and returns a pointer
        ///     to a lua_State that represents this new thread. The new state returned
        ///     by this function shares with the original state all global objects
        ///     (such as tables), but has an independent execution stack.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        /// <remarks>
        ///     There is no explicit function to close or to destroy a thread. Threads
        ///     are subject to garbage collection, like any Lua object.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State lua_newthread(lua_State L);

        //LUA_API lua_CFunction (lua_atpanic) (lua_State *L, lua_CFunction panicf);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="panicf"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_CFunction lua_atpanic(lua_State L, lua_CFunction panicf);

        //LUA_API int   (lua_gettop) (lua_State *L);
        /// <summary>
        ///     Returns the index of the top element in the stack. Because indices
        ///     start at 1, this result is equal to the number of elements in the
        ///     stack (and so 0 means an empty stack).
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gettop(lua_State L);

        //LUA_API void  (lua_settop) (lua_State *L, int idx);
        /// <summary>
        ///     Accepts any acceptable index, or 0, and sets the stack top to this index. If the new top is larger than the old one, then the new elements are filled with nil. If index is 0, then all stack elements are removed.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_settop(lua_State L, int idx);

        //LUA_API void  (lua_pushvalue) (lua_State *L, int idx);
        /// <summary>
        ///     Pushes a copy of the element at the given valid index onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushvalue(lua_State L, int idx);

        //LUA_API void  (lua_remove) (lua_State *L, int idx);
        /// <summary>
        ///     Removes the element at the given valid index, shifting down
        ///     the elements above this index to fill the gap. Cannot be called
        ///     with a pseudo-index, because a pseudo-index is not an actual
        ///     stack position.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_remove(lua_State L, int idx);

        //LUA_API void  (lua_insert) (lua_State *L, int idx);
        /// <summary>
        ///     Moves the top element into the given valid index, shifting up
        ///     the elements above this index to open space. Cannot be called
        ///     with a pseudo-index, because a pseudo-index is not an actual
        ///     stack position.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_insert(lua_State L, int idx);

        //LUA_API void  (lua_replace) (lua_State *L, int idx);
        /// <summary>
        ///     Moves the top element into the given position (and pops it), without shifting
        ///     any element (therefore replacing the value at the given position).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_replace(lua_State L, int idx);

        //LUA_API int   (lua_checkstack) (lua_State *L, int sz);
        /// <summary>
        ///     Ensures that there are at least extra free stack slots in the stack. It returns
        ///     false if it cannot grow the stack to that size. This function never shrinks the
        ///     stack; if the stack is already larger than the new size, it is left unchanged.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_checkstack(lua_State L, int sz);

        //LUA_API void  (lua_xmove) (lua_State *from, lua_State *to, int n);
        /// <summary>
        ///     Exchange values between different threads of the same global state.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="n"></param>
        /// <remarks>
        ///     This function pops n values from the stack from, and pushes them onto the stack to.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_xmove(lua_State from, lua_State to, int n);

        #endregion Basic Stack Manipulation

        #region Access Functions (stack -> C)

        //LUA_API int             (lua_isnumber) (lua_State *L, int idx);
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a number
        ///     or a string convertible to a number, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isnumber(lua_State L, int idx);

        //LUA_API int             (lua_isstring) (lua_State *L, int idx);
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a
        ///     string or a number (which is always convertible to a string),
        ///     and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isstring(lua_State L, int idx);

        //LUA_API int             (lua_iscfunction) (lua_State *L, int idx);
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is
        ///     a C function, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_iscfunction(lua_State L, int idx);

        //LUA_API int             (lua_isuserdata) (lua_State *L, int idx);
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a
        ///     userdata (either full or light), and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isuserdata(lua_State L, int idx);

        //LUA_API int             (lua_type) (lua_State *L, int idx);
        /// <summary>
        ///     Returns the type of the value in the given acceptable index, or LUA_TNONE for a non-valid index (that is, an index to an "empty" stack position). The types returned by lua_type are coded by the following constants defined in lua.h: LUA_TNIL, LUA_TNUMBER, LUA_TBOOLEAN, LUA_TSTRING, LUA_TTABLE, LUA_TFUNCTION, LUA_TUSERDATA, LUA_TTHREAD, and LUA_TLIGHTUSERDATA.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_type(lua_State L, int idx);

        //LUA_API const char     *(lua_typename) (lua_State *L, int tp);
        /// <summary>
        ///     Returns the name of the type encoded by the value tp, which must be one the values returned by lua_type.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_typename(lua_State L, int tp);

        //LUA_API int            (lua_equal) (lua_State *L, int idx1, int idx2);
        /// <summary>
        ///     Returns 1 if the two values in acceptable indices index1
        ///     and index2 are equal, following the semantics of the Lua == operator
        ///     (that is, may call metamethods). Otherwise returns 0. Also returns
        ///     0 if any of the indices is non valid.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_equal(lua_State L, int idx1, int idx2);

        //LUA_API int            (lua_rawequal) (lua_State *L, int idx1, int idx2);
        /// <summary>
        ///     Returns 1 if the two values in acceptable indices index1 and index2 
        ///     are primitively equal (that is, without calling metamethods). Otherwise
        ///     returns 0. Also returns 0 if any of the indices are non valid.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_rawequal(lua_State L, int idx1, int idx2);

        //LUA_API int            (lua_lessthan) (lua_State *L, int idx1, int idx2);
        /// <summary>
        ///     Returns 1 if the value at acceptable index index1 is smaller
        ///     than the value at acceptable index index2, following the semantics
        ///     of the Lua less then operator (that is, may call metamethods).
        ///     Otherwise returns 0. Also returns 0 if any of the indices is non valid.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_lessthan(lua_State L, int idx1, int idx2);

        //LUA_API lua_Number      (lua_tonumber) (lua_State *L, int idx);
        /// <summary>
        ///     Converts the Lua value at the given acceptable index to a number (see lua_Number). The Lua value must be a number or a string convertible to a number (see §2.2.1); otherwise, lua_tonumber returns 0.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number lua_tonumber(lua_State L, int idx);

        //LUA_API lua_Integer     (lua_tointeger) (lua_State *L, int idx);
        /// <summary>
        ///     Converts the Lua value at the given acceptable index to the signed integral type lua_Integer. The Lua value must be a number or a string convertible to a number (see §2.2.1); otherwise, lua_tointeger returns 0.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        /// <remarks>
        ///     If the number is not an integer, it is truncated in some non-specified way.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer lua_tointeger(lua_State L, int idx);

        //LUA_API int             lua_toboolean (lua_State *L, int idx);
        /// <summary>
        ///     Converts the Lua value at the given acceptable index to a C boolean value (0 or 1). Like all tests in Lua, lua_toboolean returns 1 for any Lua value different from false and nil; otherwise it returns 0. It also returns 0 when called with a non-valid index. (If you want to accept only actual boolean values, use lua_isboolean to test the value's type.)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_toboolean(lua_State L, int idx);

        //LUA_API const char     *(lua_tolstring) (lua_State *L, int idx, size_t *len);
        /// <summary>
        ///     Converts the Lua value at the given acceptable index to a string (const char*). If len is not NULL, it also sets *len with the string length. The Lua value must be a string or a number; otherwise, the function returns NULL. If the value is a number, then lua_tolstring also changes the actual value in the stack to a string. (This change confuses lua_next when lua_tolstring is applied to keys during a table traversal.)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="len"></param>
        /// <returns>
        ///     lua_tolstring returns a fully aligned pointer to a string inside the Lua state. This string always has a zero ('\0') after its last character (as in C), but may contain other zeros in its body. Because Lua has garbage collection, there is no guarantee that the pointer returned by lua_tolstring will be valid after the corresponding value is removed from the stack.
        /// </returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_tolstring(lua_State L, int idx, out int len);

        //LUA_API size_t          (lua_objlen) (lua_State *L, int idx);
        /// <summary>
        ///     Returns the "length" of the value at the given acceptable
        ///     index: for strings, this is the string length; for tables,
        ///     this is the result of the length operator ('#'); for userdata,
        ///     this is the size of the block of memory allocated for the
        ///     userdata; for other values, it is 0.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static size_t lua_objlen(lua_State L, int idx);

        //LUA_API lua_CFunction   (lua_tocfunction) (lua_State *L, int idx);
        /// <summary>
        ///     Converts a value at the given acceptable index to a C function. That value must be a C function; otherwise, returns NULL.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_CFunction lua_tocfunction(lua_State L, int idx);

        //LUA_API void	       *(lua_touserdata) (lua_State *L, int idx);
        /// <summary>
        ///     If the value at the given acceptable index is a full userdata, returns its block address. If the value is a light userdata, returns its pointer. Otherwise, returns NULL.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_touserdata(lua_State L, int idx);

        //LUA_API lua_State      *(lua_tothread) (lua_State *L, int idx);
        /// <summary>
        ///     Converts the value at the given acceptable index to a Lua thread (represented as lua_State*). This value must be a thread; otherwise, the function returns NULL.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State lua_tothread(lua_State L, int idx);

        //LUA_API const void     *(lua_topointer) (lua_State *L, int idx);
        /// <summary>
        ///     Converts the value at the given acceptable index to a generic C pointer (void*). The value may be a userdata, a table, a thread, or a function; otherwise, lua_topointer returns NULL. Different objects will give different pointers. There is no way to convert the pointer back to its original value.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Typically this function is used only for debug information.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_topointer(lua_State L, int idx);

        #endregion Access Functions (stack -> C)

        #region Push Functions (C -> stack)

        //LUA_API void  (lua_pushnil) (lua_State *L);
        /// <summary>
        ///     Pushes a nil value onto the stack.
        /// </summary>
        /// <param name="L"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushnil(lua_State L);

        //LUA_API void  (lua_pushnumber) (lua_State *L, lua_Number n);
        /// <summary>
        ///     Pushes a number with value n onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushnumber(lua_State L, lua_Number n);

        //LUA_API void  (lua_pushinteger) (lua_State *L, lua_Integer n);
        /// <summary>
        ///     Pushes a number with value n onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushinteger(lua_State L, lua_Integer n);

        //LUA_API void  lua_pushlstring (lua_State *L, const char *s, size_t l);
        /// <summary>
        ///     Pushes the string pointed to by s with size len onto the stack. Lua
        ///     makes (or reuses) an internal copy of the given string, so the
        ///     memory at s can be freed or reused immediately after the function
        ///     returns. The string can contain embedded zeros.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushlstring(lua_State L, string s, size_t l);

        //LUA_API void  lua_pushstring (lua_State *L, const char *s);
        /// <summary>
        ///     Pushes the zero-terminated string pointed to by s onto the stack. Lua
        ///     makes (or reuses) an internal copy of the given string, so the memory
        ///     at s can be freed or reused immediately after the function returns. The
        ///     string cannot contain embedded zeros; it is assumed to end at the first zero.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushstring(lua_State L, string s);

        // TODO: Variable argument lists.
        //LUA_API const char *(lua_pushvfstring) (lua_State *L, const char *fmt, va_list argp);
        //LUA_API const char *lua_pushfstring (lua_State *L, const char *fmt, ...);

        //LUA_API void  (lua_pushcclosure) (lua_State *L, lua_CFunction fn, int n);
        /// <summary>
        ///     Pushes a new C closure onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <param name="n"></param>
        /// <remarks>
        ///     When a C function is created, it is possible to associate some values
        ///     with it, thus creating a C closure (see §3.4); these values are then
        ///     accessible to the function whenever it is called. To associate values
        ///     with a C function, first these values should be pushed onto the stack
        ///     (when there are multiple values, the first value is pushed first).
        ///     Then lua_pushcclosure is called to create and push the C function onto
        ///     the stack, with the argument n telling how many values should be
        ///     associated with the function. lua_pushcclosure also pops these values
        ///     from the stack.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushcclosure(lua_State L, lua_CFunction fn, int n);

        //LUA_API void  (lua_pushboolean) (lua_State *L, int b);
        /// <summary>
        ///     Pushes a boolean value with value b onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="b"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushboolean(lua_State L, int b);

        //LUA_API void  (lua_pushlightuserdata) (lua_State *L, void *p);
        /// <summary>
        ///     Pushes a light userdata onto the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="p"></param>
        /// <remarks>
        ///     Userdata represents C values in Lua. A light userdata represents
        ///     a pointer. It is a value (like a number): you do not create it, it has
        ///     no individual metatable, and it is not collected (as it was never
        ///     created). A light userdata is equal to "any" light userdata with
        ///     the same C address.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushlightuserdata(lua_State L, IntPtr p);

        //LUA_API int   (lua_pushthread) (lua_State *L);
        /// <summary>
        ///     Pushes the thread represented by L onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <returns>
        ///     Returns 1 if this thread is the main thread of its state.
        /// </returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_pushthread(lua_State L);

        #endregion Push Functions (C -> stack)

        #region Get Functions (Lua -> stack)

        //LUA_API void  (lua_gettable) (lua_State *L, int idx);
        /// <summary>
        ///     Pushes onto the stack the value t[k], where t is the value at the given
        ///     valid index index and k is the value at the top of the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <remarks>
        ///     This function pops the key from the stack (putting the resulting value in
        ///     its place). As in Lua, this function may trigger a metamethod for the
        ///     "index" event.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_gettable(lua_State L, int idx);

        //LUA_API void  (lua_getfield) (lua_State *L, int idx, const char *k);
        /// <summary>
        ///     Pushes onto the stack the value t[k], where t is the value at the
        ///     given valid index index. As in Lua, this function may trigger a
        ///     metamethod for the "index" event
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_getfield(lua_State L, int idx, string k);

        //LUA_API void  (lua_rawget) (lua_State *L, int idx);
        /// <summary>
        ///     Similar to lua_gettable, but does a raw access (i.e., without
        ///     metamethods).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawget(lua_State L, int idx);

        //LUA_API void  (lua_rawgeti) (lua_State *L, int idx, int n);
        /// <summary>
        ///     Pushes onto the stack the value t[n], where t is the value at the given
        ///     valid index index. The access is raw; that is, it does not invoke metamethods.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawgeti(lua_State L, int idx, int n);

        //LUA_API void  (lua_createtable) (lua_State *L, int narr, int nrec);
        /// <summary>
        ///     Creates a new empty table and pushes it onto the stack. The new table
        ///     has space pre-allocated for narr array elements and nrec non-array elements.
        ///     This pre-allocation is useful when you know exactly how many elements the table
        ///     will have. Otherwise you can use the function lua_newtable.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narr"></param>
        /// <param name="nrec"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_createtable(lua_State L, int narr, int nrec);

        //LUA_API void *(lua_newuserdata) (lua_State *L, size_t sz);
        /// <summary>
        ///     This function allocates a new block of memory with the given
        ///     size, pushes onto the stack a new full userdata with the block
        ///     address, and returns this address.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        /// <remarks>
        ///     Userdata represents C values in Lua. A full userdata represents
        ///     a block of memory. It is an object (like a table): you must create it,
        ///     it can have its own metatable, and you can detect when it is being
        ///     collected. A full userdata is only equal to itself (under raw equality).
        ///     
        ///     When Lua collects a full userdata with a gc metamethod, Lua calls the
        ///     metamethod and marks the userdata as finalized. When this userdata is
        ///     collected again then Lua frees its corresponding memory.
        /// </remarks>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_newuserdata(lua_State L, size_t sz);

        //LUA_API int   (lua_getmetatable) (lua_State *L, int objindex);
        /// <summary>
        ///     Pushes onto the stack the metatable of the value at the given
        ///     acceptable index. If the index is not valid, or if the value
        ///     does not have a metatable, the function returns 0 and pushes
        ///     nothing on the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getmetatable(lua_State L, int objindex);

        //LUA_API void  (lua_getfenv) (lua_State *L, int idx);
        /// <summary>
        ///     Pushes onto the stack the environment table of the value at the given index.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_getfenv(lua_State L, int idx);

        #endregion Get Functions (Lua -> stack)

        #region Set Functions (stack -> Lua)

        //LUA_API void  (lua_settable) (lua_State *L, int idx);
        /// <summary>
        ///     Does the equivalent to t[k] = v, where t is the value at the given valid index index, v is the value at the top of the stack, and k is the value just below the top.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <remarks>
        ///     This function pops both the key and the value from the stack. As in Lua, this function may trigger a metamethod for the "newindex" event
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_settable(lua_State L, int idx);

        //LUA_API void  (lua_setfield) (lua_State *L, int idx, const char *k);
        /// <summary>
        ///     Does the equivalent to t[k] = v, where t is the value at the
        ///     given valid index index and v is the value at the top of the stack,
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        /// <remarks>
        ///     This function pops the value from the stack. As in Lua, this
        ///     function may trigger a metamethod for the "newindex" event
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_setfield(lua_State L, int idx, string k);

        //LUA_API void  (lua_rawset) (lua_State *L, int idx);
        /// <summary>
        ///     Similar to lua_settable, but does a raw assignment (i.e., without
        ///     metamethods).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawset(lua_State L, int idx);

        //LUA_API void  (lua_rawseti) (lua_State *L, int idx, int n);
        /// <summary>
        ///     Does the equivalent of t[n] = v, where t is the value at the given valid index index and v
        ///     is the value at the top of the stack,
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        /// <remarks>
        ///     This function pops the value from the stack. The assignment is
        ///     raw; that is, it does not invoke metamethods.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawseti(lua_State L, int idx, int n);

        //LUA_API int   (lua_setmetatable) (lua_State *L, int objindex);
        /// <summary>
        ///     Pops a table from the stack and sets it as the new metatable for the value at the given acceptable index.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_setmetatable(lua_State L, int objindex);

        //LUA_API int   (lua_setfenv) (lua_State *L, int idx);
        /// <summary>
        ///     Pops a table from the stack and sets it as the new
        ///     environment for the value at the given index.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns>
        ///     If the value at the given index is neither a function nor a
        ///     thread nor a userdata, lua_setfenv returns 0. Otherwise it returns 1.
        /// </returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_setfenv(lua_State L, int idx);

        #endregion Set Functions (stack -> Lua)

        #region Load and Call Functions (Load and Run Lua code)

        //LUA_API void  (lua_call) (lua_State *L, int nargs, int nresults);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_call(lua_State L, int nargs, int nresults);

        //LUA_API int   (lua_pcall) (lua_State *L, int nargs, int nresults, int errfunc);
        /// <summary>
        ///     Calls a function in protected mode.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs">
        ///     Both nargs and nresults have the same meaning as in lua_call. If there are
        ///     no errors during the call, lua_pcall behaves exactly like lua_call. However,
        ///     if there is any error, lua_pcall catches it, pushes a single value on the
        ///     stack (the error message), and returns an error code. Like lua_call,
        ///     lua_pcall always removes the function and its arguments from the stack.
        /// </param>
        /// <param name="nresults">
        ///     Both nargs and nresults have the same meaning as in lua_call. If there are
        ///     no errors during the call, lua_pcall behaves exactly like lua_call. However,
        ///     if there is any error, lua_pcall catches it, pushes a single value on the
        ///     stack (the error message), and returns an error code. Like lua_call,
        ///     lua_pcall always removes the function and its arguments from the stack.
        /// </param>
        /// <param name="errfunc">
        ///     If errfunc is 0, then the error message returned on the stack is exactly
        ///     the original error message. Otherwise, errfunc is the stack index of an error
        ///     handler function. (In the current implementation, this index cannot be a
        ///     pseudo-index.) In case of runtime errors, this function will be called with
        ///     the error message and its return value will be the message returned on the
        ///     stack by lua_pcall.
        /// </param>
        /// <returns>
        ///     The lua_pcall function returns 0 in case of success or one of the following error codes (defined in lua.h):
        ///         LUA_ERRRUN: a runtime error.
        ///         LUA_ERRMEM: memory allocation error. For such errors, Lua does not call the error handler function.
        ///         LUA_ERRERR: error while running the error handler function.
        /// </returns>
        /// <remarks>
        ///     Typically, the error handler function is used to add more debug information
        ///     to the error message, such as a stack traceback. Such information cannot
        ///     be gathered after the return of lua_pcall, since by then the stack has unwound.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_pcall(lua_State L, int nargs, int nresults, int errfunc);

        //LUA_API int (lua_cpcall) (lua_State *L, lua_CFunction func, void *ud);
        /// <summary>
        ///     Calls the C function func in protected mode. func starts with only one
        ///     element in its stack, a light userdata containing ud. In case of errors,
        ///     lua_cpcall returns the same error codes as lua_pcall, plus the error object
        ///     on the top of the stack; otherwise, it returns zero, and does not change
        ///     the stack. All values returned by func are discarded.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_cpcall(lua_State L, lua_CFunction func, IntPtr ud);

        //LUA_API int   (lua_load) (lua_State *L, lua_Reader reader, void *dt, const char *chunkname);
        /// <summary>
        ///     Loads a Lua chunk. If there are no errors, lua_load pushes the compiled
        ///     chunk as a Lua function on top of the stack. Otherwise, it pushes an
        ///     error message.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="reader"></param>
        /// <param name="data">The data argument is an opaque value passed to the reader function.</param>
        /// <param name="chunkname">The chunkname argument gives a name to the chunk, which is used for error messages and in debug information.</param>
        /// <returns>0: no errors.  LUA_ERRSYNTAX: syntax error during pre-compilation. LUA_ERRMEM: memory allocation error.</returns>
        /// <remarks>This function only loads a chunk; it does not run it. lua_load automatically detects whether the chunk is text or binary, and loads it accordingly (see program luac). lua_load uses a user-supplied reader function to read the chunk (see lua_Reader).</remarks>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_load(lua_State L, lua_Reader reader, IntPtr data, string chunkname);

        //LUA_API int (lua_dump) (lua_State *L, lua_Writer writer, void *data);
        /// <summary>
        ///     Dumps a function as a binary chunk. Receives a Lua function on the
        ///     top of the stack and produces a binary chunk that, if loaded again,
        ///     results in a function equivalent to the one dumped. As it produces
        ///     parts of the chunk, lua_dump calls function writer (see lua_Writer)
        ///     with the given data to write them.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="writer"></param>
        /// <param name="data"></param>
        /// <returns>
        ///     The value returned is the error code returned by the last call to
        ///     the writer; 0 means no errors.
        /// </returns>
        /// <remarks>
        ///     This function does not pop the Lua function from the stack.
        /// </remarks>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_dump(lua_State L, lua_Writer writer, IntPtr data);

        #endregion Load and Call Functions (Load and Run Lua code)

        #region Coroutine Functions

        //LUA_API int  (lua_yield) (lua_State *L, int nresults);
        /// <summary>
        ///     Yields a coroutine.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nresults"></param>
        /// <returns></returns>
        /// <remarks>
        ///     When a C function calls lua_yield in that way, the running coroutine suspends its execution, and the call to lua_resume that started this coroutine returns. The parameter nresults is the number of values from the stack that are passed as results to lua_resume.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_yield(lua_State L, int nresults);

        //LUA_API int  (lua_resume) (lua_State *L, int narg);
        /// <summary>
        ///     Starts and resumes a coroutine in a given thread.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <returns>
        ///     When it returns, the stack contains all values passed to lua_yield, or
        ///     all values returned by the body function. lua_resume returns LUA_YIELD
        ///     if the coroutine yields, 0 if the coroutine finishes its execution without
        ///     errors, or an error code in case of errors (see lua_pcall). In case of 
        ///     errors, the stack is not unwound, so you can use the debug API over it. The
        ///     error message is on the top of the stack.
        /// </returns>
        /// <remarks>
        ///     To start a coroutine, you first create a new thread (see lua_newthread);
        ///     then you push onto its stack the main function plus any arguments;
        ///     then you call lua_resume, with narg being the number of arguments.
        ///     This call returns when the coroutine suspends or finishes its execution.
        ///     To restart a coroutine, you put on its stack only the values to be passed
        ///     as results from yield, and then call lua_resume.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_resume(lua_State L, int narg);

        //LUA_API int  (lua_status) (lua_State *L);
        /// <summary>
        ///     Returns the status of the thread L.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        /// <remarks>
        ///     The status can be 0 for a normal thread, an error code if the thread finished its execution with an error, or LUA_YIELD if the thread is suspended.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_status(lua_State L);

        #endregion Coroutine Functions

        #region Garbage-Collection Function and Options

        //#define LUA_GCSTOP		0
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCSTOP = 0;

        //#define LUA_GCRESTART		1
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCRESTART = 1;

        //#define LUA_GCCOLLECT		2
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCCOLLECT = 2;

        //#define LUA_GCCOUNT		3
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCCOUNT = 3;

        //#define LUA_GCCOUNTB		4
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCCOUNTB = 4;

        //#define LUA_GCSTEP		5
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCSTEP = 5;

        //#define LUA_GCSETPAUSE		6
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCSETPAUSE = 6;

        //#define LUA_GCSETSTEPMUL	7
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_GCSETSTEPMUL = 7;

        //LUA_API int (lua_gc) (lua_State *L, int what, int data);
        /// <summary>
        ///     Controls the garbage collector.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <remarks>
        ///     This function performs several tasks, according to the value of the parameter what:
        ///         LUA_GCSTOP: stops the garbage collector.
        ///         LUA_GCRESTART: restarts the garbage collector.
        ///         LUA_GCCOLLECT: performs a full garbage-collection cycle.
        ///         LUA_GCCOUNT: returns the current amount of memory (in Kbytes) in use by Lua.
        ///         LUA_GCCOUNTB: returns the remainder of dividing the current amount of bytes of memory in use by Lua by 1024.
        ///         LUA_GCSTEP: performs an incremental step of garbage collection. The step "size" is controlled by data (larger values mean more steps) in a non-specified way. If you want to control the step size you must experimentally tune the value of data. The function returns 1 if the step finished a garbage-collection cycle.
        ///         LUA_GCSETPAUSE: sets data/100 as the new value for the pause of the collector (see §2.10). The function returns the previous value of the pause.
        ///         LUA_GCSETSTEPMUL: sets arg/100 as the new value for the step multiplier of the collector (see §2.10). The function returns the previous value of the step multiplier.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gc(lua_State L, int what, int data);

        #endregion Garbage-Collection Functions

        #region Miscellaneous Functions

        //LUA_API int   (lua_error) (lua_State *L);
        /// <summary>
        ///     Generates a Lua error. The error message (which can actually
        ///     be a Lua value of any type) must be on the stack top. This function
        ///     does a long jump, and therefore never returns. (see luaL_error).
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_error(lua_State L);

        //LUA_API int   (lua_next) (lua_State *L, int idx);
        /// <summary>
        ///     Pops a key from the stack, and pushes a key-value pair from the
        ///     table at the given index (the "next" pair after the given key).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns>
        ///     If there are no more elements in the table, then lua_next
        ///     returns 0 (and pushes nothing).
        /// </returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_next(lua_State L, int idx);

        //LUA_API void  (lua_concat) (lua_State *L, int n);
        /// <summary>
        ///     Concatenates the n values at the top of the stack, pops them, and leaves
        ///     the result at the top. If n is 1, the result is the single string on
        ///     the stack (that is, the function does nothing); if n is 0, the result
        ///     is the empty string. Concatenation is done following the usual semantics
        ///     of Lua.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_concat(lua_State L, int n);

        //LUA_API lua_Alloc (lua_getallocf) (lua_State *L, void **ud);
        /// <summary>
        ///     Returns the memory-allocation function of a given state.
        ///     If ud is not NULL, Lua stores in *ud the opaque pointer
        ///     passed to lua_newstate.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Alloc lua_getallocf(lua_State L, IntPtr ud);

        //LUA_API void lua_setallocf (lua_State *L, lua_Alloc f, void *ud);
        /// <summary>
        ///     Changes the allocator function of a given state to f with
        ///     user data ud.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Alloc lua_setallocf(lua_State L, lua_Alloc f, IntPtr ud);

        #endregion Miscellaneous Functions

        #region Some Useful Macros

        //#define lua_pop(L,n)		lua_settop(L, -(n)-1)
        /// <summary>
        ///     Pops n elements from the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void lua_pop(lua_State L, int n)
        {
            lua_settop(L, -(n) - 1);
        }

        //#define lua_newtable(L)		lua_createtable(L, 0, 0)
        /// <summary>
        ///     Creates a new empty table and pushes it onto the stack. 
        /// </summary>
        /// <param name="L"></param>
        /// <remarks>It is equivalent to lua_createtable(L, 0, 0).</remarks>
        public static void lua_newtable(lua_State L)
        {
            lua_createtable(L, 0, 0);
        }

        //#define lua_register(L,n,f) (lua_pushcfunction(L, (f)), lua_setglobal(L, (n)))
        /// <summary>
        ///     Sets the C function f as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="f"></param>
        public static void lua_register(lua_State L, string n, lua_CFunction f)
        {
            lua_pushcfunction(L, f);
            lua_setglobal(L, n);
        }

        //#define lua_pushcfunction(L,f)	lua_pushcclosure(L, (f), 0)
        /// <summary>
        ///     Pushes a C function onto the stack. This function receives a pointer
        ///     to a C function and pushes onto the stack a Lua value of type function
        ///     that, when called, invokes the corresponding C function.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        /// <remarks>
        ///     Any function to be registered in Lua must follow the correct protocol
        ///     to receive its parameters and return its results
        /// </remarks>
        public static void lua_pushcfunction(lua_State L, lua_CFunction f)
        {
            lua_pushcclosure(L, f, 0);
        }

        //#define lua_strlen(L,i)		lua_objlen(L, (i))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        public static size_t lua_strlen(lua_State L, int i)
        {
            return lua_objlen(L, i);
        }

        //#define lua_isfunction(L,n)	(lua_type(L,n) == LUA_TFUNCTION)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a
        ///     function (either C or Lua), and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isfunction(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TFUNCTION;
        }

        //#define lua_istable(L,n)	(lua_type(L,n) == LUA_TTABLE)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a
        ///     table, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_istable(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TLIGHTUSERDATA;
        }

        //#define lua_islightuserdata(L,n)	(lua_type(L,n) == LUA_TLIGHTUSERDATA)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a light
        ///     userdata, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_islightuserdata(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TLIGHTUSERDATA;
        }

        //#define lua_isnil(L,n)		(lua_type(L,n) == LUA_TNIL)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is nil,
        ///     and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isnil(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TNIL;
        }

        //#define lua_isboolean(L,n)	(lua_type(L,n) == LUA_TBOOLEAN)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index has type boolean, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isboolean(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TBOOLEAN;
        }

        //#define lua_isthread(L,n)	(lua_type(L, (n)) == LUA_TTHREAD)
        /// <summary>
        ///     Returns 1 if the value at the given acceptable index is a
        ///     thread, and 0 otherwise.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isthread(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TTHREAD;
        }

        //#define lua_isnone(L,n)		(lua_type(L,n) == LUA_TNONE)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isnone(lua_State L, int n)
        {
            return lua_type(L, n) == LUA_TNONE;
        }

        //#define lua_isnoneornil(L, n)	(lua_type(L,n) <= 0)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool lua_isnoneornil(lua_State L, int n)
        {
            return lua_type(L, n) <= 0;
        }

        //#define lua_pushliteral(L, s)	 lua_pushlstring(L, "" s, (sizeof(s)/sizeof(char))-1)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void lua_pushliteral(lua_State L, string s)
        {
            //TODO: Implement use using lua_pushlstring instead of lua_pushstring
            //lua_pushlstring(L, "" s, (sizeof(s)/sizeof(char))-1)
            lua_pushstring(L, s);
        }

        //#define lua_setglobal(L,s)	lua_setfield(L, LUA_GLOBALSINDEX, (s))
        /// <summary>
        ///     Pops a value from the stack and sets it as the new value of global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void lua_setglobal(lua_State L, string s)
        {
            lua_setfield(L, LUA_GLOBALSINDEX, s);
        }

        //#define lua_getglobal(L,s)	lua_getfield(L, LUA_GLOBALSINDEX, (s))
        /// <summary>
        ///     Pushes onto the stack the value of the global name.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void lua_getglobal(lua_State L, string s)
        {
            lua_getfield(L, LUA_GLOBALSINDEX, s);
        }

        //#define lua_tostring(L,i)	lua_tolstring(L, (i), NULL)
        /// <summary>
        ///     Equivalent to lua_tolstring with len equal to NULL.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string lua_tostring(lua_State L, int i)
        {
            int strlen;
            IntPtr str = lua_tolstring(L, i, out strlen);
            if (str != IntPtr.Zero)
                return Marshal.PtrToStringAnsi(str, strlen);
            else
                return null;
        }

        #endregion Some Useful Macros

        #region Compatibility Macros and Functions

        //#define lua_open()	luaL_newstate()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static lua_State lua_open()
        {
            return luaL_newstate();
        }

        //#define lua_getregistry(L)	lua_pushvalue(L, LUA_REGISTRYINDEX)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        public static void lua_getregistry(lua_State L)
        {
            lua_pushvalue(L, LUA_REGISTRYINDEX);
        }

        //#define lua_getgccount(L)	lua_gc(L, LUA_GCCOUNT, 0)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        public static int lua_getgccount(lua_State L)
        {
            return lua_gc(L, LUA_GCCOUNT, 0);
        }

        #endregion Compatibility Macros and Functions

        #region Debug API

        #region Event Codes
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_HOOKCALL = 0;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_HOOKRET = 1;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_HOOKLINE = 2;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_HOOKCOUNT = 3;
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_HOOKTAILRET = 4;

        #endregion Event Codes

        #region Event Masks

        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MASKCALL = (1 << LUA_HOOKCALL);
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MASKRET = (1 << LUA_HOOKRET);
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MASKLINE = (1 << LUA_HOOKLINE);
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MASKCOUNT = (1 << LUA_HOOKCOUNT);

        //typedef void (*lua_Hook) (lua_State *L, lua_Debug *ar);
        /// <summary>
        ///     Type for debugging hook functions.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        /// <remarks>
        ///     Whenever a hook is called, its ar argument has its field event set to the specific event that triggered the hook. Lua identifies these events with the following constants: LUA_HOOKCALL, LUA_HOOKRET, LUA_HOOKTAILRET, LUA_HOOKLINE, and LUA_HOOKCOUNT. Moreover, for line events, the field currentline is also set. To get the value of any other field in ar, the hook must call lua_getinfo. For return events, event may be LUA_HOOKRET, the normal value, or LUA_HOOKTAILRET. In the latter case, Lua is simulating a return from a function that did a tail call; in this case, it is useless to call lua_getinfo.
        ///     While Lua is running a hook, it disables other calls to hooks. Therefore, if a hook calls back Lua to execute a function or a chunk, this execution occurs without any calls to hooks.
        /// </remarks>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void lua_Hook(lua_State L, ref lua_Debug ar);

        //LUA_API int lua_getstack (lua_State *L, int level, lua_Debug *ar);
        /// <summary>
        ///     Get information about the interpreter runtime stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="level"></param>
        /// <param name="ar"></param>
        /// <returns>When there are no errors, lua_getstack returns 1; when called with a level greater than the stack depth, it returns 0.</returns>
        /// <remarks>This function fills parts of a lua_Debug structure with an identification of the activation record of the function executing at a given level. Level 0 is the current running function, whereas level n+1 is the function that has called level n.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getstack(lua_State L, int level, ref lua_Debug ar);

        //LUA_API int lua_getinfo (lua_State *L, const char *what, lua_Debug *ar);
        /// <summary>
        ///     Returns information about a specific function or function invocation.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        /// <remarks>
        ///     To get information about a function invocation, the parameter ar must be a valid activation record that was filled by a previous call to lua_getstack or given as argument to a hook (see lua_Hook).
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getinfo(lua_State L, string what, ref lua_Debug ar);

        //LUA_API const char *lua_getlocal (lua_State *L, const lua_Debug *ar, int n);
        /// <summary>
        ///     Gets information about a local variable of a given activation record.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar">The parameter ar must be a valid activation record that was filled by a previous call to lua_getstack or given as argument to a hook (see lua_Hook).</param>
        /// <param name="n">The index n selects which local variable to inspect (1 is the first parameter or active local variable, and so on, until the last active local variable). lua_getlocal pushes the variable's value onto the stack and returns its name.</param>
        /// <returns>Returns NULL (and pushes nothing) when the index is greater than the number of active local variables.</returns>
        /// <remarks>
        ///     Variable names starting with '(' (open parentheses) represent internal variables (loop control variables, temporaries, and C function locals).
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_getlocal(lua_State L, ref lua_Debug ar, int n);

        //LUA_API const char *lua_setlocal (lua_State *L, const lua_Debug *ar, int n);
        /// <summary>
        ///     Sets the value of a local variable of a given activation record
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar">Parameters ar and n are as in lua_getlocal (see lua_getlocal). lua_setlocal assigns the value at the top of the stack to the variable and returns its name. It also pops the value from the stack.</param>
        /// <param name="n">Parameters ar and n are as in lua_getlocal (see lua_getlocal). lua_setlocal assigns the value at the top of the stack to the variable and returns its name. It also pops the value from the stack.</param>
        /// <returns>Returns NULL (and pops nothing) when the index is greater than the number of active local variables.</returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_setlocal(lua_State L, ref lua_Debug ar, int n);

        //LUA_API const char *lua_getupvalue (lua_State *L, int funcindex, int n);
        /// <summary>
        ///     Gets information about a closure's upvalue. (For Lua functions, upvalues are the external local variables that the function uses, and that are consequently included in its closure.) lua_getupvalue gets the index n of an upvalue, pushes the upvalue's value onto the stack, and returns its name. funcindex points to the closure in the stack. (Upvalues have no particular order, as they are active through the whole function. So, they are numbered in an arbitrary order.)
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns>Returns NULL (and pushes nothing) when the index is greater than the number of upvalues. For C functions, this function uses the empty string "" as a name for all upvalues.</returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_getupvalue(lua_State L, int funcindex, int n);

        //LUA_API const char *lua_setupvalue (lua_State *L, int funcindex, int n);
        /// <summary>
        ///     Sets the value of a closure's upvalue. Parameters funcindex and n are as in lua_getupvalue (see lua_getupvalue). It assigns the value at the top of the stack to the upvalue and returns its name. It also pops the value from the stack.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns>Returns NULL (and pops nothing) when the index is greater than the number of upvalues.</returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_setupvalue(lua_State L, int funcindex, int n);

        //LUA_API int lua_sethook (lua_State *L, lua_Hook func, int mask, int count);
        /// <summary>
        ///     Sets the debugging hook function.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func">func is the hook function.</param>
        /// <param name="mask">mask specifies on which events the hook will be called: it is formed by a bitwise or of the constants LUA_MASKCALL, LUA_MASKRET, LUA_MASKLINE, and LUA_MASKCOUNT.</param>
        /// <param name="count">The count argument is only meaningful when the mask includes LUA_MASKCOUNT.</param>
        /// <returns></returns>
        /// <remarks>
        ///     For each event, the hook is called as explained below:
        ///     * The call hook: is called when the interpreter calls a function. The hook is called just after Lua enters the new function, before the function gets its arguments.
        ///     * The return hook: is called when the interpreter returns from a function. The hook is called just before Lua leaves the function. You have no access to the values to be returned by the function.
        ///     * The line hook: is called when the interpreter is about to start the execution of a new line of code, or when it jumps back in the code (even to the same line). (This event only happens while Lua is executing a Lua function.)
        ///     * The count hook: is called after the interpreter executes every count instructions. (This event only happens while Lua is executing a Lua function.)
        ///     A hook is disabled by setting mask to zero. 
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_sethook(lua_State L, lua_Hook func, int mask, int count);

        //LUA_API lua_Hook lua_gethook (lua_State *L);
        /// <summary>
        ///     Returns the current hook function.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Hook lua_gethook(lua_State L);

        //LUA_API int lua_gethookmask (lua_State *L);
        /// <summary>
        ///     Returns the current hook mask.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gethookmask(lua_State L);

        //LUA_API int lua_gethookcount (lua_State *L);
        /// <summary>
        ///     Returns the current hook count.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gethookcount(lua_State L);

        //struct lua_Debug {
        //  int event;
        //  const char *name;	/* (n) */
        //  const char *namewhat;	/* (n) `global', `local', `field', `method' */
        //  const char *what;	/* (S) `Lua', `C', `main', `tail' */
        //  const char *source;	/* (S) */
        //  int currentline;	/* (l) */
        //  int nups;		/* (u) number of upvalues */
        //  int linedefined;	/* (S) */
        //  char short_src[LUA_IDSIZE]; /* (S) */
        //  /* private part */
        //  int i_ci;  /* active function */
        //};
        /// <summary>
        ///     A structure used to carry different pieces of information about an active function. lua_getstack fills only the private part of this structure, for later use. To fill the other fields of lua_Debug with useful information, call lua_getinfo.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct lua_Debug
        {
            /// <summary>
            /// 
            /// </summary>
            public int Event;
            /// <summary>
            ///     a reasonable name for the given function. Because functions in Lua are first-class values, they do not have a fixed name: some functions may be the value of multiple global variables, while others may be stored only in a table field. The lua_getinfo function checks how the function was called to find a suitable name. If it cannot find a name, then name is set to NULL.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string name;
            /// <summary>
            ///     explains the name field. The value of namewhat can be "global", "local", "method", "field", "upvalue", or "" (the empty string), according to how the function was called. (Lua uses the empty string when no other option seems to apply.)
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string namewhat;
            /// <summary>
            /// the string "Lua" if the function is a Lua function, "C" if it is a C function, "main" if it is the main part of a chunk, and "tail" if it was a function that did a tail call. In the latter case, Lua has no other information about the function.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string what;
            /// <summary>
            /// If the function was defined in a string, then source is that string. If the function was defined in a file, then source starts with a '@' followed by the file name.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string source;
            /// <summary>
            /// the current line where the given function is executing. When no line information is available, currentline is set to -1.
            /// </summary>
            public int currentline;
            /// <summary>
            ///     the number of upvalues of the function.
            /// </summary>
            public int nups;
            /// <summary>
            /// the line number where the definition of the function starts.
            /// </summary>
            public int linedefined;
            /// <summary>
            /// a "printable" version of source, to be used in error messages.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string short_src;
            /// <summary>
            /// 
            /// </summary>
            public int i_ci;
        };

        #endregion Event Masks

        #endregion Debug API

        #endregion Public Functions

        #endregion Lua.h

        #region LuaLib.h

        //#define LUA_FILEHANDLE		"FILE*"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_FILEHANDLE = "FILE*";

        //#define LUA_COLIBNAME	"coroutine"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_COLIBNAME = "coroutine";

        //LUALIB_API int (luaopen_base) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_base(lua_State L);

        //#define LUA_TABLIBNAME	"table"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_TABLIBNAME = "table";

        //LUALIB_API int (luaopen_table) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_table(lua_State L);

        //#define LUA_IOLIBNAME	"io"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_IOLIBNAME = "io";

        //LUALIB_API int (luaopen_io) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_io(lua_State L);

        //#define LUA_OSLIBNAME	"os"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_OSLIBNAME = "os";

        //LUALIB_API int (luaopen_os) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_os(lua_State L);

        //#define LUA_STRLIBNAME	"string"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_STRLIBNAME = "string";

        //LUALIB_API int (luaopen_string) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_string(lua_State L);

        //#define LUA_MATHLIBNAME	"math"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_MATHLIBNAME = "math";

        //LUALIB_API int (luaopen_math) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_math(lua_State L);

        //#define LUA_DBLIBNAME	"debug"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_DBLIBNAME = "debug";

        //LUALIB_API int (luaopen_debug) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_debug(lua_State L);

        //#define LUA_LOADLIBNAME	"package"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_LOADLIBNAME = "package";

        //LUALIB_API int (luaopen_package) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaopen_package(lua_State L);

        //LUALIB_API void (luaL_openlibs) (lua_State *L); 
        /// <summary>
        /// Opens all standard Lua libraries into the given state.
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_openlibs(lua_State L);

        //#define lua_assert(x)	((void)0)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int lua_asset(object x)
        {
            return 0;
        }

        #endregion LuaLib.h

        #region LauxLib.h

        //LUALIB_API int (luaL_getn) (lua_State *L, int t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_getn(lua_State L, int t);

        //LUALIB_API void (luaL_setn) (lua_State *L, int t, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_setn(lua_State L, int t, int n);

        //#define LUA_ERRFILE     (LUA_ERRERR+1)
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_ERRFILE = Lua.LUA_ERRERR + 1;

        /// <summary>
        /// Type for arrays of functions to be registered by luaL_register. name is the function name and func is a pointer to the function. Any array of luaL_Reg must end with an sentinel entry in which both name and func are NULL.
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct luaL_Reg
        {
            /// <summary>
            /// 
            /// </summary>
            public string name;
            /// <summary>
            /// 
            /// </summary>
            public Lua.lua_CFunction func;
        }

        //LUALIB_API void (luaI_openlib) (lua_State *L, const char *libname, const luaL_Reg *l, int nup);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="libname"></param>
        /// <param name="l"></param>
        /// <param name="nup"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaI_openlib(lua_State L, string libname, ref luaL_Reg l, int nup);

        //LUALIB_API void (luaL_register) (lua_State *L, const char *libname, const luaL_Reg *l);
        /// <summary>
        /// Opens a library.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="libname"></param>
        /// <param name="l"></param>
        /// <remarks>When called with libname equal to NULL, it simply registers all functions in the list l (see luaL_Reg) into the table on the top of the stack.
        /// When called with a non-null libname, creates a new table t, sets it as the value of the global variable libname, sets it as the value of package.loaded[libname], and registers on it all functions in the list l. If there is a table in package.loaded[libname] or in variable libname, reuses this table instead of creating a new one.
        /// In any case the function leaves the table on the top of the stack. </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_register(lua_State L, string libname, ref luaL_Reg l);

        //LUALIB_API int (luaL_getmetafield) (lua_State *L, int obj, const char *e);
        /// <summary>
        /// Pushes onto the stack the field e from the metatable of the object at index obj. If the object does not have a metatable, or if the metatable does not have this field, returns 0 and pushes nothing.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_getmetafield(lua_State L, int obj, string e);

        //LUALIB_API int (luaL_callmeta) (lua_State *L, int obj, const char *e);
        /// <summary>
        /// Calls a metamethod.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        /// <remarks>
        /// If the object at index obj has a metatable and this metatable has a field e, this function calls this field and passes the object as its only argument. In this case this function returns 1 and pushes onto the stack the value returned by the call. If there is no metatable or no metamethod, this function returns 0 (without pushing any value on the stack).
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_callmeta(lua_State L, int obj, string e);

        //LUALIB_API int (luaL_typerror) (lua_State *L, int narg, const char *tname);
        /// <summary>
        /// Generates an error with a message.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        /// <remarks>Generates an error with a message like:
        /// [location]: bad argument [narg] to [function] ([tname] expected, got [realt])
        /// where [location] is produced by luaL_where, [function] is the name of the current function, and [realt] is the type name of the actual argument. </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_typerror(lua_State L, int narg, string tname);

        //LUALIB_API int (luaL_argerror) (lua_State *L, int numarg, const char *extramsg);
        /// <summary>
        /// Raises an error with the following message, where func is retrieved from the call stack:
        /// <code>bad argument #[numarg] to [func] ([extramsg])</code>
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numarg"></param>
        /// <param name="extramsg"></param>
        /// <returns>This function never returns, but it is an idiom to use it in C functions as return luaL_argerror(args).</returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_argerror(lua_State L, int numarg, string extramsg);

        //LUALIB_API const char *(luaL_checklstring) (lua_State *L, int numArg, size_t *l);
        /// <summary>
        /// Checks whether the function argument narg is a string and returns this string; if l is not NULL fills *l with the string's length.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_checklstring(lua_State L, int numArg, ref size_t l);

        //LUALIB_API const char *(luaL_optlstring) (lua_State *L, int numArg, const char *def, size_t *l);
        /// <summary>
        /// If the function argument narg is a string, returns this string. If this argument is absent or is nil, returns d. Otherwise, raises an error. If l is not NULL, fills the position *l with the results's length. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <param name="def"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_optlstring(lua_State L, int numArg, string def, ref size_t l);

        //LUALIB_API lua_Number (luaL_checknumber) (lua_State *L, int numArg);
        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number luaL_checknumber(lua_State L, int numArg);

        //LUALIB_API lua_Number (luaL_optnumber) (lua_State *L, int nArg, lua_Number def);
        /// <summary>
        /// If the function argument narg is a number, returns this number. If this argument is absent or is nil, returns d. Otherwise, raises an error.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number luaL_optnumber(lua_State L, int nArg, lua_Number def);

        //LUALIB_API lua_Integer (luaL_checkinteger) (lua_State *L, int numArg);
        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to a lua_Integer.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer luaL_checkinteger(lua_State L, int numArg);

        //LUALIB_API lua_Integer (luaL_optinteger) (lua_State *L, int nArg, lua_Integer def);
        /// <summary>
        /// If the function argument narg is a number, returns this number cast to a lua_Integer. If this argument is absent or is nil, returns d. Otherwise, raises an error.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer luaL_optinteger(lua_State L, int nArg, lua_Integer def);

        //LUALIB_API void (luaL_checkstack) (lua_State *L, int sz, const char *msg);
        /// <summary>
        /// Grows the stack size to top + sz elements, raising an error if the stack cannot grow to that size. msg is an additional text to go into the error message.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <param name="msg"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checkstack(lua_State L, int sz, string msg);

        //LUALIB_API void (luaL_checktype) (lua_State *L, int narg, int t);
        /// <summary>
        /// Checks whether the function argument narg has type t.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="t"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checktype(lua_State L, int narg, int t);

        //LUALIB_API void (luaL_checkany) (lua_State *L, int narg);
        /// <summary>
        /// Checks whether the function has an argument of any type (including nil) at position narg.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checkany(lua_State L, int narg);

        //LUALIB_API int   (luaL_newmetatable) (lua_State *L, const char *tname);
        /// <summary>
        /// If the registry already has the key tname, returns 0. Otherwise, creates a new table to be used as a metatable for userdata, adds it to the registry with key tname, and returns 1.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        /// <remarks>In both cases pushes onto the stack the final value associated with tname in the registry.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_newmetatable(lua_State L, string tname);

        //LUALIB_API void *(luaL_checkudata) (lua_State *L, int ud, const char *tname);
        /// <summary>
        /// Checks whether the function argument narg is a userdata of the type tname (see luaL_newmetatable).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr luaL_checkudata(lua_State L, int ud, string tname);

        //LUALIB_API void (luaL_where) (lua_State *L, int lvl);
        /// <summary>
        /// Pushes onto the stack a string identifying the current position of the control at level lvl in the call stack. Typically this string has the format {chunkname}:{currentline}:. Level 0 is the running function, level 1 is the function that called the running function, etc.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="lvl"></param>
        /// <remarks>This function is used to build a prefix for error messages.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_where(lua_State L, int lvl);

        //LUALIB_API int (luaL_error) (lua_State *L, const char *fmt, ...);
        // TODO: Implement parameter list for luaL_error

        //LUALIB_API int (luaL_checkoption) (lua_State *L, int narg, const char *def, const char *const lst[]);
        // TODO: Check if string array lst works correctly
        /// <summary>
        /// Checks whether the function argument narg is a string and searches for this string in the array lst (which must be NULL-terminated). Returns the index in the array where the string was found. Raises an error if the argument is not a string or if the string cannot be found.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="def"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        /// <remarks>
        /// If def is not NULL, the function uses def as a default value when there is no argument narg or if this argument is nil.
        /// This is a useful function for mapping strings to C enums. (The usual convention in Lua libraries is to use strings instead of numbers to select options.) 
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_checkoption(lua_State L, int narg, string def, string[] lst);

        //LUALIB_API int (luaL_ref) (lua_State *L, int t);
        /// <summary>
        /// Creates and returns a reference, in the table at index t, for the object at the top of the stack (and pops the object).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        /// <remarks>A reference is a unique integer key. As long as you do not manually add integer keys into table t, luaL_ref ensures the uniqueness of the key it returns. You can retrieve an object referred by reference r by calling lua_rawgeti(L, t, r). Function luaL_unref frees a reference and its associated object.
        /// If the object at the top of the stack is nil, luaL_ref returns the constant LUA_REFNIL. The constant LUA_NOREF is guaranteed to be different from any reference returned by luaL_ref.
        /// </remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_ref(lua_State L, int t);

        //LUALIB_API void (luaL_unref) (lua_State *L, int t, int ref);
        /// <summary>
        /// Releases reference ref from the table at index t (see luaL_ref). The entry is removed from the table, so that the referred object can be collected. The reference ref is also freed to be used again.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <param name="rf">If rf is LUA_NOREF or LUA_REFNIL, luaL_unref does nothing.</param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_unref(lua_State L, int t, int rf);

        //LUALIB_API int (luaL_loadfile) (lua_State *L, const char *filename);
        /// <summary>
        /// Loads a file as a Lua chunk. This function uses lua_load to load the chunk in the file named filename. If filename is NULL, then it loads from the standard input. The first line in the file is ignored if it starts with a #.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        /// <remarks>This function returns the same results as lua_load, but it has an extra error code LUA_ERRFILE if it cannot open/read the file. As lua_load, this function only loads the chunk; it does not run it.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadfile(lua_State L, string filename);

        //LUALIB_API int (luaL_loadbuffer) (lua_State *L, const char *buff, size_t sz, const char *name);
        /// <summary>
        /// Loads a buffer as a Lua chunk. This function uses lua_load to load the chunk in the buffer pointed to by buff with size sz.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="buff"></param>
        /// <param name="sz"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>This function returns the same results as lua_load. name is the chunk name, used for debug information and error messages.</remarks>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadbuffer(lua_State L, string buff, size_t sz, string name);

        //LUALIB_API int (luaL_loadstring) (lua_State *L, const char *s);
        /// <summary>
        /// Loads a string as a Lua chunk. This function uses lua_load to load the chunk in the zero-terminated string s.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <remarks>This function returns the same results as lua_load. Also as lua_load, this function only loads the chunk; it does not run it.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadstring(lua_State L, string s);

        //LUALIB_API lua_State *(luaL_newstate) (void);
        /// <summary>
        /// Creates a new Lua state, calling lua_newstate with an allocation function based on the standard C realloc function and setting a panic function (see lua_atpanic) that prints an error message to the standard error output in case of fatal errors.
        /// </summary>
        /// <returns>Returns the new state, or NULL if there is a memory allocation error.</returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State luaL_newstate();

        //LUALIB_API const char *(luaL_gsub) (lua_State *L, const char *s, const char *p, const char *r);
        /// <summary>
        /// Creates a copy of string s by replacing any occurrence of the string p with the string r. Pushes the resulting string on the stack and returns it.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_gsub(lua_State L, string s, string p, string r);

        //LUALIB_API const char *(luaL_findtable) (lua_State *L, int idx, const char *fname, int szhint);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="fname"></param>
        /// <param name="szhint"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_findtable(lua_State L, int idx, string fname, int szhint);

        #region Some Useful Macros

        //#define luaL_argcheck(L, cond,numarg,extramsg) ((void)((cond) || luaL_argerror(L, (numarg), (extramsg))))
        /// <summary>
        /// Checks whether cond is true. If not, raises an error with the following message, where func is retrieved from the call stack:
        /// <code>bad argument #[numarg] to [func] ([extramsg])</code>
        /// </summary>
        /// <param name="L"></param>
        /// <param name="cond"></param>
        /// <param name="numarg"></param>
        /// <param name="extramsg"></param>
        /// <returns></returns>
        public static bool luaL_argcheck(lua_State L, int cond, int numarg, string extramsg)
        {
            return cond > 0 || luaL_argerror(L, numarg, extramsg) > 0;
        }

        //#define luaL_checkstring(L,n)	(luaL_checklstring(L, (n), NULL))
        /// <summary>
        /// Checks whether the function argument narg is a string and returns this string.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static string luaL_checkstring(lua_State L, int n)
        {
            uint nullValue = 0;
            return luaL_checklstring(L, n, ref nullValue);
        }

        //#define luaL_optstring(L,n,d)	(luaL_optlstring(L, (n), (d), NULL))
        /// <summary>
        /// If the function argument narg is a string, returns this string. If this argument is absent or is nil, returns d. Otherwise, raises an error.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string luaL_optstring(lua_State L, int n, string d)
        {
            uint nullValue = 0;
            return luaL_optlstring(L, n, d, ref nullValue);
        }

        //#define luaL_checkint(L,n)	((int)luaL_checkinteger(L, (n)))
        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to an int.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int luaL_checkint(lua_State L, int n)
        {
            return luaL_checkinteger(L, n);
        }

        //#define luaL_optint(L,n,d)	((int)luaL_optinteger(L, (n), (d)))
        /// <summary>
        /// If the function argument narg is a number, returns this number cast to an int. 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns>If this argument is absent or is nil, returns d. Otherwise, raises an error.</returns>
        public static int luaL_optint(lua_State L, int n, int d)
        {
            return luaL_optinteger(L, n, d);
        }

        //#define luaL_checklong(L,n)	((long)luaL_checkinteger(L, (n)))
        /// <summary>
        /// Checks whether the function argument narg is a number and returns this number cast to a long.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int luaL_checklong(lua_State L, int n)
        {
            return luaL_checkinteger(L, n);
        }

        //#define luaL_optlong(L,n,d)	((long)luaL_optinteger(L, (n), (d)))
        /// <summary>
        /// If the function argument narg is a number, returns this number cast to a long. If this argument is absent or is nil, returns d. Otherwise, raises an error.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int luaL_optlong(lua_State L, int n, int d)
        {
            return luaL_optinteger(L, n, d);
        }

        //#define luaL_typename(L,i)	lua_typename(L, lua_type(L,(i)))
        /// <summary>
        /// Returns the name of the type of the value at index idx.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string luaL_typename(lua_State L, int i)
        {
            return lua_typename(L, Lua.lua_type(L, i));
        }

        //#define luaL_dofile(L, fn)	(luaL_loadfile(L, fn) || lua_pcall(L, 0, 0, 0))
        /// <summary>
        /// Loads and runs the given file.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <returns>It returns 0 if there are no errors or 1 in case of errors.</returns>
        public static int luaL_dofile(lua_State L, string fn)
        {
            return luaL_loadfile(L, fn) | lua_pcall(L, LUA_MULTRET, 0, 0);
        }

        //#define luaL_dostring(L, s)	(luaL_loadstring(L, s) || lua_pcall(L, 0, 0, 0))
        /// <summary>
        /// Loads and runs the given string.
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns>It returns 0 if there are no errors or 1 in case of errors.</returns>
        public static int luaL_dostring(lua_State L, string s)
        {
            return luaL_loadstring(L, s) | lua_pcall(L, LUA_MULTRET, 0, 0);
        }

        //#define luaL_getmetatable(L,n)	(lua_getfield(L, LUA_REGISTRYINDEX, (n)))
        /// <summary>
        /// Pushes onto the stack the metatable associated with name tname in the registry (see luaL_newmetatable).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void luaL_getmetatable(lua_State L, string n)
        {
            lua_getfield(L, LUA_REGISTRYINDEX, n);
        }

        //#define luaL_opt(L,f,n,d)	(lua_isnoneornil(L,(n)) ? (d) : f(L,(n)))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        public static void luaL_opt(lua_State L, int f, int n, int d)
        {
            // TODO: Implement luaL_opt
            throw new NotImplementedException("The function you have called, luaL_opt, is not yet implemented.");
        }

        #endregion Some Useful Macros

        #region Generic Buffer Manipulation

        /// <summary>
        /// Type for a string buffer.
        /// </summary>
        /// <remarks>
        /// A string buffer allows C code to build Lua strings piecemeal. Its pattern of use is as follows:
        ///     * First you declare a variable b of type luaL_Buffer.
        ///     * Then you initialize it with a call luaL_buffinit(L, &amp;b).
        ///     * Then you add string pieces to the buffer calling any of the luaL_add* functions.
        ///     * You finish by calling luaL_pushresult(&amp;b). This call leaves the final string on the top of the stack.
        /// During its normal operation, a string buffer uses a variable number of stack slots. So, while using a buffer, you cannot assume that you know where the top of the stack is. You can use the stack between successive calls to buffer operations as long as that use is balanced; that is, when you call a buffer operation, the stack is at the same level it was immediately after the previous buffer operation. (The only exception to this rule is luaL_addvalue.) After calling luaL_pushresult the stack is back to its level when the buffer was initialized, plus the final string on its top.
        /// </remarks>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct luaL_Buffer
        {
            /// <summary>
            /// 
            /// </summary>
            public string p;			/* current position in buffer */
            /// <summary>
            /// 
            /// </summary>
            public int lvl;  /* number of strings in the stack (level) */
            /// <summary>
            /// 
            /// </summary>
            public lua_State L;
            /// <summary>
            /// 
            /// </summary>
            public string buffer; // TODO: char buffer[BUFFERSIZE] ;
        }

        //#define luaL_addchar(B,c) \
        // ((void)((B)->p < ((B)->buffer+LUAL_BUFFERSIZE) || luaL_prepbuffer(B)), \
        // (*(B)->p++ = (char)(c)))
        /// <summary>
        ///     Adds the character c to the buffer B (see luaL_Buffer).
        /// </summary>
        /// <param name="B"></param>
        /// <param name="c"></param>
        public static void luaL_addchar(ref luaL_Buffer B, char c)
        {
            // TODO: Implement luaL_addchar
            throw new NotImplementedException("The function you have called, luaL_addchar, is not yet implemented.");
        }

        #region Compatibility Only

        //#define luaL_putchar(B,c)	luaL_addchar(B,c)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="c"></param>
        public static void luaL_putchar(ref luaL_Buffer B, char c)
        {
            luaL_addchar(ref B, c);
        }

        //#define luaL_addsize(B,n)	((B)->p += (n))
        /// <summary>
        ///     Adds a string of length n previously copied to the buffer area (see luaL_prepbuffer) to the buffer B (see luaL_Buffer).
        /// </summary>
        /// <param name="B"></param>
        /// <param name="n"></param>
        public static void luaL_addsize(luaL_Buffer B, int n)
        {
            // TODO: Implement luaL_addsize
            throw new NotImplementedException("The function you have called, luaL_addsize, is not yet implemented.");
        }

        #endregion Compatibility Only

        //LUALIB_API void (luaL_buffinit) (lua_State *L, luaL_Buffer *B);
        /// <summary>
        /// Initializes a buffer B. This function does not allocate any space; the buffer must be declared as a variable (see luaL_Buffer).
        /// </summary>
        /// <param name="L"></param>
        /// <param name="B"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_buffinit(lua_State L, ref luaL_Buffer B);

        //LUALIB_API char *(luaL_prepbuffer) (luaL_Buffer *B);
        /// <summary>
        /// Returns an address to a space of size LUAL_BUFFERSIZE where you can copy a string to be added to buffer B (see luaL_Buffer). After copying the string into this space you must call luaL_addsize with the size of the string to actually add it to the buffer.
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_prepbuffer(ref luaL_Buffer B);

        //LUALIB_API void (luaL_addlstring) (luaL_Buffer *B, const char *s, size_t l);
        /// <summary>
        /// Adds the string pointed to by s with length l to the buffer B (see luaL_Buffer). The string may contain embedded zeros.
        /// </summary>
        /// <param name="B"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addlstring(ref luaL_Buffer B, string s, size_t l);

        //LUALIB_API void (luaL_addstring) (luaL_Buffer *B, const char *s);
        /// <summary>
        ///     Adds the zero-terminated string pointed to by s to the buffer B (see luaL_Buffer). The string may not contain embedded zeros.
        /// </summary>
        /// <param name="B"></param>
        /// <param name="s"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addstring(ref luaL_Buffer B, string s);

        //LUALIB_API void (luaL_addvalue) (luaL_Buffer *B);
        /// <summary>
        /// Adds the value at the top of the stack to the buffer B (see luaL_Buffer). Pops the value.
        /// </summary>
        /// <param name="B"></param>
        /// <remarks>This is the only function on string buffers that can (and must) be called with an extra element on the stack, which is the value to be added to the buffer.</remarks>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addvalue(ref luaL_Buffer B);

        //LUALIB_API void (luaL_pushresult) (luaL_Buffer *B);
        /// <summary>
        /// Finishes the use of buffer B leaving the final string on the top of the stack.
        /// </summary>
        /// <param name="B"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_pushresult(ref luaL_Buffer B);

        #endregion Generic Buffer Manipulation

        #region Compatibility With Ref System

        //#define LUA_NOREF       (-2)
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_NOREF = -2;

        //#define LUA_REFNIL      (-1)
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_RENIL = -1;

        //#define lua_ref(L,lock) ((lock) ? luaL_ref(L, LUA_REGISTRYINDEX) : \
        // (lua_pushstring(L, "unlocked references are obsolete"), lua_error(L), 0))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="lockit"></param>
        /// <returns></returns>
        public static int lua_ref(lua_State L, bool lockit)
        {
            if (lockit)
                return luaL_ref(L, LUA_REGISTRYINDEX);
            lua_pushstring(L, "unlocked references are obsolete");
            lua_error(L);
            return 0;
        }

        //#define lua_unref(L,ref)        luaL_unref(L, LUA_REGISTRYINDEX, (ref))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="reference"></param>
        public static void lua_unref(lua_State L, int reference)
        {
            luaL_unref(L, LUA_REGISTRYINDEX, reference);
        }

        //#define lua_getref(L,ref)       lua_rawgeti(L, LUA_REGISTRYINDEX, (ref))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="reference"></param>
        public static void lua_getref(lua_State L, int reference)
        {
            lua_rawgeti(L, LUA_REGISTRYINDEX, reference);
        }

        #endregion Compatibility With Ref System

        #endregion LauxLib.h

        #region LuaConf.h

        //#define LUA_IDSIZE	60
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_IDSIZE = 60;

        //#define LUA_PROMPT		"> "
        /// <summary>
        /// 
        /// </summary>
        public const string UA_PROMPT = "> ";

        //#define LUA_PROMPT2		">> "
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_PROMT2 = ">> ";

        //#define LUA_PROGNAME		"lua"
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_PROGNAME = "lua";

        //#define LUA_MAXINPUT	512
        /// <summary>
        /// 
        /// </summary>
        public const int LUA_MAXINPUT = 512;

        //#define LUAI_GCPAUSE	200  /* 200% (wait memory to double before next GC) */
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_GCPAUSE = 200;

        //#define LUAI_GCMUL	200
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_GCMUL = 200;

        //#define LUA_COMPAT_LSTR		1
        /// <summary>
        /// 
        /// </summary>
        public const byte LUA_COMPAT_LSTR = 1;

        //#define LUAI_MAXCALLS	20000
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_MAXCALLS = 20000;

        //#define LUAI_MAXCSTACK	2048
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_MAXCSTACK = 2048;

        //#define LUAI_MAXCCALLS		200
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_MAXCCALLS = 200;

        //#define LUAI_MAXVARS		200
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_MAXVARS = 200;

        //#define LUAI_MAXUPVALUES	60
        /// <summary>
        /// 
        /// </summary>
        public const int LUAI_MAXUPVALUES = 60;

        //#define LUAL_BUFFERSIZE		BUFSIZ
        /// <summary>
        /// 
        /// </summary>
        public const int LUAL_BUFFERSIZE = 1028;

        //#define LUA_MAXCAPTURES		32
        /// <summary>
        /// 
        /// </summary>
        public const byte LUA_MAXCAPTURES = 32;

        //#define LUAI_EXTRASPACE		0
        /// <summary>
        /// 
        /// </summary>
        public const byte LUAI_EXTRASPACE = 0;

        #endregion LuaConf.h
    }
}
