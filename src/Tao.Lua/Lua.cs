#region License
/*
 MIT License
 Copyright 2003-2005 Tao Framework Team
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

/******************************************************************************
* Copyright (C) 1994-2006 Lua.org, PUC-Rio.  All rights reserved.
*
* Permission is hereby granted, free of charge, to any person obtaining
* a copy of this software and associated documentation files (the
* "Software"), to deal in the Software without restriction, including
* without limitation the rights to use, copy, modify, merge, publish,
* distribute, sublicense, and/or sell copies of the Software, and to
* permit persons to whom the Software is furnished to do so, subject to
* the following conditions:
*
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
* MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
* IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
* CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
* TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
* SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
******************************************************************************/

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
	
	#region Class Documentation
	/// <summary>
	///     Lua bindings for .NET, implementing Lua 5.1 (http://www.lua.org).
	/// </summary>
	/// <remarks>
	///		Lua is a powerful light-weight programming language designed for
	///		extending applications. Lua is also frequently used as a
	///		general-purpose, stand-alone language.
	///	<p>More information can be found at the official website (http://www.lua.org).</p>
	///	</remarks>
	#endregion Class Documentation
    public class Lua
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
        public const int LUA_VERSION_NUM = 501;
        /// <summary>
        /// 
        /// </summary>
        public const string LUA_COPYRIGHT = "Copyright (C) 1994-2004 Tecgraf, PUC-Rio";
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
        public int lua_upvalueindex(int i) { return LUA_GLOBALSINDEX - i; }

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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CALLING_CONVENTION)]
        public delegate int lua_CFunction(lua_State L);

        //functions that read/write blocks when loading/dumping Lua chunks
        //typedef const char * (*lua_Reader) (lua_State *L, void *ud, size_t *sz);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CALLING_CONVENTION)]
		[CLSCompliant(false)]
        public delegate string lua_Reader(lua_State L, IntPtr ud, ref size_t sz);

        //typedef int (*lua_Writer) (lua_State *L, const void* p, size_t sz, void* ud);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="p"></param>
        /// <param name="sz"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [UnmanagedFunctionPointer(CALLING_CONVENTION)]
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
        [UnmanagedFunctionPointer(CALLING_CONVENTION)]
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
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State lua_newstate(lua_Alloc f, IntPtr ud);

        //LUA_API void       (lua_close) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_close(lua_State L);

        //LUA_API lua_State *(lua_newthread) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gettop(lua_State L);

        //LUA_API void  (lua_settop) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_settop(lua_State L, int idx);

        //LUA_API void  (lua_pushvalue) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushvalue(lua_State L, int idx);

        //LUA_API void  (lua_remove) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_remove(lua_State L, int idx);

        //LUA_API void  (lua_insert) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_insert(lua_State L, int idx);

        //LUA_API void  (lua_replace) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_replace(lua_State L, int idx);

        //LUA_API int   (lua_checkstack) (lua_State *L, int sz);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_checkstack(lua_State L, int sz);

        //LUA_API void  (lua_xmove) (lua_State *from, lua_State *to, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_xmove(lua_State from, lua_State to, int n);

        #endregion Basic Stack Manipulation

        #region Access Functions (stack -> C)

        //LUA_API int             (lua_isnumber) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isnumber(lua_State L, int idx);

        //LUA_API int             (lua_isstring) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isstring(lua_State L, int idx);

        //LUA_API int             (lua_iscfunction) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_iscfunction(lua_State L, int idx);

        //LUA_API int             (lua_isuserdata) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_isuserdata(lua_State L, int idx);

        //LUA_API int             (lua_type) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_type(lua_State L, int idx);

        //LUA_API const char     *(lua_typename) (lua_State *L, int tp);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tp"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_typename(lua_State L, int tp);

        //LUA_API int            (lua_equal) (lua_State *L, int idx1, int idx2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_equal(lua_State L, int idx1, int idx2);

        //LUA_API int            (lua_rawequal) (lua_State *L, int idx1, int idx2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_rawequal(lua_State L, int idx1, int idx2);

        //LUA_API int            (lua_lessthan) (lua_State *L, int idx1, int idx2);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx1"></param>
        /// <param name="idx2"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_lessthan(lua_State L, int idx1, int idx2);

        //LUA_API lua_Number      (lua_tonumber) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number lua_tonumber(lua_State L, int idx);

        //LUA_API lua_Integer     (lua_tointeger) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer lua_tointeger(lua_State L, int idx);

        //LUA_API int             lua_toboolean (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_toboolean(lua_State L, int idx);

        //LUA_API const char     *(lua_tolstring) (lua_State *L, int idx, size_t *len);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_tolstring(lua_State L, int idx, ref size_t len);

        //LUA_API size_t          (lua_objlen) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static size_t lua_objlen(lua_State L, int idx);

        //LUA_API lua_CFunction   (lua_tocfunction) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_CFunction lua_tocfunction(lua_State L, int idx);

        //LUA_API void	       *(lua_touserdata) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_touserdata(lua_State L, int idx);

        //LUA_API lua_State      *(lua_tothread) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State lua_tothread(lua_State L, int idx);

        //LUA_API const void     *(lua_topointer) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_topointer(lua_State L, int idx);

        #endregion Access Functions (stack -> C)

        #region Push Functions (C -> stack)

        //LUA_API void  (lua_pushnil) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushnil(lua_State L);

        //LUA_API void  (lua_pushnumber) (lua_State *L, lua_Number n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushnumber(lua_State L, lua_Number n);

        //LUA_API void  (lua_pushinteger) (lua_State *L, lua_Integer n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushnumber(lua_State L, lua_Integer n);

        //LUA_API void  lua_pushlstring (lua_State *L, const char *s, size_t l);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushlstring(lua_State L, string s, size_t l);

        //LUA_API void  lua_pushstring (lua_State *L, const char *s);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushcclosure(lua_State L, lua_CFunction fn, int n);

        //LUA_API void  (lua_pushboolean) (lua_State *L, int b);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="b"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushboolean(lua_State L, int b);

        //LUA_API void  (lua_pushlightuserdata) (lua_State *L, void *p);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="p"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_pushlightuserdata(lua_State L, IntPtr p);

        //LUA_API int   (lua_pushthread) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_pushthread(lua_State L);

        #endregion Push Functions (C -> stack)

        #region Get Functions (Lua -> stack)

        //LUA_API void  (lua_gettable) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_gettable(lua_State L, int idx);

        //LUA_API void  (lua_getfield) (lua_State *L, int idx, const char *k);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_getfield(lua_State L, int idx, string k);

        //LUA_API void  (lua_rawget) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawget(lua_State L, int idx);

        //LUA_API void  (lua_rawgeti) (lua_State *L, int idx, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawgeti(lua_State L, int idx, int n);

        //LUA_API void  (lua_createtable) (lua_State *L, int narr, int nrec);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narr"></param>
        /// <param name="nrec"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_createtable(lua_State L, int narr, int nrec);

        //LUA_API void *(lua_newuserdata) (lua_State *L, size_t sz);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <returns></returns>
		[CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr lua_newuserdata(lua_State L, size_t sz);

        //LUA_API int   (lua_getmetatable) (lua_State *L, int objindex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getmetatable(lua_State L, int objindex);

        //LUA_API void  (lua_getfenv) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_getfenv(lua_State L, int idx);

        #endregion Get Functions (Lua -> stack)

        #region Set Functions (stack -> Lua)

        //LUA_API void  (lua_settable) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_settable(lua_State L, int idx);

        //LUA_API void  (lua_setfield) (lua_State *L, int idx, const char *k);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="k"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_setfield(lua_State L, int idx, string k);

        //LUA_API void  (lua_rawset) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawset(lua_State L, int idx);

        //LUA_API void  (lua_rawseti) (lua_State *L, int idx, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_rawseti(lua_State L, int idx, int n);

        //LUA_API int   (lua_setmetatable) (lua_State *L, int objindex);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="objindex"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_setmetatable(lua_State L, int objindex);

        //LUA_API int   (lua_setfenv) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nargs"></param>
        /// <param name="nresults"></param>
        /// <param name="errfunc"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_pcall(lua_State L, int nargs, int nresults, int errfunc);

        //LUA_API int (lua_cpcall) (lua_State *L, lua_CFunction func, void *ud);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_cpcall(lua_State L, lua_CFunction func, IntPtr ud);

		//LUA_API int   (lua_load) (lua_State *L, lua_Reader reader, void *dt, const char *chunkname);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="L"></param>
		/// <param name="reader"></param>
		/// <param name="dt"></param>
		/// <param name="chunkname"></param>
		/// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_load(lua_State L, lua_Reader reader, IntPtr dt, string chunkname);

		//LUA_API int (lua_dump) (lua_State *L, lua_Writer writer, void *data);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="writer"></param>
        /// <param name="data"></param>
        /// <returns></returns>
		[CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_dump(lua_State L, lua_Writer writer, IntPtr data);

        #endregion Load and Call Functions (Load and Run Lua code)

        #region Coroutine Functions

        //LUA_API int  (lua_yield) (lua_State *L, int nresults);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nresults"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_yield(lua_State L, int nresults);

        //LUA_API int  (lua_resume) (lua_State *L, int narg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_resume(lua_State L, int narg);

        //LUA_API int  (lua_status) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gc(lua_State L, int what, int data);

        #endregion Garbage-Collection Functions

        #region Miscellaneous Functions

        //LUA_API int   (lua_error) (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_error(lua_State L);

        //LUA_API int   (lua_next) (lua_State *L, int idx);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_next(lua_State L, int idx);

        //LUA_API void  (lua_concat) (lua_State *L, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void lua_concat(lua_State L, int n);

        //LUA_API lua_Alloc (lua_getallocf) (lua_State *L, void **ud);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Alloc lua_getallocf(lua_State L, IntPtr ud);

        //LUA_API void lua_setallocf (lua_State *L, lua_Alloc f, void *ud);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        public static void lua_pop(lua_State L, int n)
        {
            lua_settop(L, -(n) - 1);
        }

        //#define lua_newtable(L)		lua_createtable(L, 0, 0)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        public static void lua_newtable(lua_State L)
        {
            lua_createtable(L, 0, 0);
        }

        //#define lua_register(L,n,f) (lua_pushcfunction(L, (f)), lua_setglobal(L, (n)))
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="f"></param>
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void lua_setglobal(lua_State L, string s)
        {
            lua_setfield(L, LUA_GLOBALSINDEX, s);
        }

        //#define lua_getglobal(L,s)	lua_getfield(L, LUA_GLOBALSINDEX, (s))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        public static void lua_getglobal(lua_State L, string s)
        {
            lua_getfield(L, LUA_GLOBALSINDEX, s);
        }

        //#define lua_tostring(L,i)	lua_tolstring(L, (i), NULL)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string lua_tostring(lua_State L, int i)
        {
            uint blah = 0;
            return lua_tolstring(L, i, ref blah);
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        [UnmanagedFunctionPointer(CALLING_CONVENTION)]
        public delegate void lua_Hook(lua_State L, lua_Debug ar);

        //LUA_API int lua_getstack (lua_State *L, int level, lua_Debug *ar);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="level"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getstack(lua_State L, int level, lua_Debug ar);

        //LUA_API int lua_getinfo (lua_State *L, const char *what, lua_Debug *ar);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="what"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_getinfo(lua_State L, string what, lua_Debug ar);

        //LUA_API const char *lua_getlocal (lua_State *L, const lua_Debug *ar, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_getlocal(lua_State L, lua_Debug ar, int n);

        //LUA_API const char *lua_setlocal (lua_State *L, const lua_Debug *ar, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ar"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_setlocal(lua_State L, lua_Debug ar, int n);

        //LUA_API const char *lua_getupvalue (lua_State *L, int funcindex, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_getupvalue(lua_State L, int funcindex, int n);

        //LUA_API const char *lua_setupvalue (lua_State *L, int funcindex, int n);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="funcindex"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string lua_setupvalue(lua_State L, int funcindex, int n);

        //LUA_API int lua_sethook (lua_State *L, lua_Hook func, int mask, int count);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="func"></param>
        /// <param name="mask"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_sethook(lua_State L, lua_Hook func, int mask, int count);

        //LUA_API lua_Hook lua_gethook (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Hook lua_gethook(lua_State L);

        //LUA_API int lua_gethookmask (lua_State *L);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int lua_gethookmask(lua_State L);

        //LUA_API int lua_gethookcount (lua_State *L);
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct lua_Debug
        {
            /// <summary>
            /// 
            /// </summary>
            public int Event;
            /// <summary>
            /// 
            /// </summary>
			[CLSCompliant(false)]
			public sbyte name;
            /// <summary>
            /// 
            /// </summary>
			[CLSCompliant(false)]
			public sbyte namewhat;
            /// <summary>
            /// 
            /// </summary>
			[CLSCompliant(false)]
			public sbyte what;
            /// <summary>
            /// 
            /// </summary>
			[CLSCompliant(false)]
            public sbyte source;
            /// <summary>
            /// 
            /// </summary>
            public int currentline;
            /// <summary>
            /// 
            /// </summary>
            public int nups;
            /// <summary>
            /// 
            /// </summary>
            public int linedefined;
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = LUA_IDSIZE)]
            public char[] short_src;
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
        public const string LUA_TABLIBNAME = "coroutine";

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
        /// 
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
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
        public struct luaL_Reg
        {
            /// <summary>
            /// 
            /// </summary>
            string name;
            /// <summary>
            /// 
            /// </summary>
            Lua.lua_CFunction func;
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="libname"></param>
        /// <param name="l"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_register(lua_State L, string libname, ref luaL_Reg l);

        //LUALIB_API int (luaL_getmetafield) (lua_State *L, int obj, const char *e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_getmetafield(lua_State L, int obj, string e);

        //LUALIB_API int (luaL_callmeta) (lua_State *L, int obj, const char *e);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_callmeta(lua_State L, int obj, string e);

        //LUALIB_API int (luaL_typerror) (lua_State *L, int narg, const char *tname);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_typerror(lua_State L, int narg, string tname);

        //LUALIB_API int (luaL_argerror) (lua_State *L, int numarg, const char *extramsg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numarg"></param>
        /// <param name="extramsg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_argerror(lua_State L, int numarg, string extramsg);

        //LUALIB_API const char *(luaL_checklstring) (lua_State *L, int numArg, size_t *l);
        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number luaL_checknumber(lua_State L, int numArg);

        //LUALIB_API lua_Number (luaL_optnumber) (lua_State *L, int nArg, lua_Number def);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Number luaL_optnumber(lua_State L, int nArg, lua_Number def);

        //LUALIB_API lua_Integer (luaL_checkinteger) (lua_State *L, int numArg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="numArg"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer luaL_checkinteger(lua_State L, int numArg);

        //LUALIB_API lua_Integer (luaL_optinteger) (lua_State *L, int nArg, lua_Integer def);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="nArg"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_Integer luaL_optinteger(lua_State L, int nArg, lua_Integer def);

        //LUALIB_API void (luaL_checkstack) (lua_State *L, int sz, const char *msg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="sz"></param>
        /// <param name="msg"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checkstack(lua_State L, int sz, string msg);

        //LUALIB_API void (luaL_checktype) (lua_State *L, int narg, int t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="t"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checktype(lua_State L, int narg, int t);

        //LUALIB_API void (luaL_checkany) (lua_State *L, int narg);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_checkany(lua_State L, int narg);

        //LUALIB_API int   (luaL_newmetatable) (lua_State *L, const char *tname);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_newmetatable(lua_State L, string tname);

        //LUALIB_API void *(luaL_checkudata) (lua_State *L, int ud, const char *tname);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="ud"></param>
        /// <param name="tname"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static IntPtr luaL_checkudata(lua_State L, int ud, string tname);

        //LUALIB_API void (luaL_where) (lua_State *L, int lvl);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="lvl"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_where(lua_State L, int lvl);

        //LUALIB_API int (luaL_error) (lua_State *L, const char *fmt, ...);
        // TODO: Implement parameter list for luaL_error

        //LUALIB_API int (luaL_checkoption) (lua_State *L, int narg, const char *def, const char *const lst[]);
        // TODO: Check if string array lst works correctly
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="narg"></param>
        /// <param name="def"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_checkoption(lua_State L, int narg, string def, string[] lst);

        //LUALIB_API int (luaL_ref) (lua_State *L, int t);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_ref(lua_State L, int t);

        //LUALIB_API void (luaL_unref) (lua_State *L, int t, int ref);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="t"></param>
        /// <param name="rf"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_unref(lua_State L, int t, int rf);

        //LUALIB_API int (luaL_loadfile) (lua_State *L, const char *filename);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadfile(lua_State L, string filename);

        //LUALIB_API int (luaL_loadbuffer) (lua_State *L, const char *buff, size_t sz, const char *name);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="buff"></param>
        /// <param name="sz"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadbuffer(lua_State L, string buff, size_t sz, string name);

        //LUALIB_API int (luaL_loadstring) (lua_State *L, const char *s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static int luaL_loadstring(lua_State L, string s);

        //LUALIB_API lua_State *(luaL_newstate) (void);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static lua_State luaL_newstate();

        //LUALIB_API const char *(luaL_gsub) (lua_State *L, const char *s, const char *p, const char *r);
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static int luaL_optint(lua_State L, int n, int d)
        {
            return luaL_optinteger(L, n, d);
        }

        //#define luaL_checklong(L,n)	((long)luaL_checkinteger(L, (n)))
        /// <summary>
        /// 
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
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static int luaL_dofile(lua_State L, string fn)
        {
            return luaL_loadfile(L, fn) | lua_pcall(L, 0, 0, 0);
        }

        //#define luaL_dostring(L, s)	(luaL_loadstring(L, s) || lua_pcall(L, 0, 0, 0))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int luaL_dostring(lua_State L, string s)
        {
            return luaL_loadstring(L, s) | lua_pcall(L, 0, 0, 0);
        }

        //#define luaL_getmetatable(L,n)	(lua_getfield(L, LUA_REGISTRYINDEX, (n)))
        /// <summary>
        /// 
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
        /// 
        /// </summary>
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
        /// 
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
            // TODO: Implement luaL_putchar
            throw new NotImplementedException("The function you have called, luaL_putchar, is not yet implemented.");
        }

        //#define luaL_addsize(B,n)	((B)->p += (n))
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="n"></param>
        public static void luaL_addsize(luaL_Buffer B, int n)
        {
            B.p += n;
        }

        #endregion Compatibility Only

        //LUALIB_API void (luaL_buffinit) (lua_State *L, luaL_Buffer *B);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="L"></param>
        /// <param name="B"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_buffinit(lua_State L, ref luaL_Buffer B);

        //LUALIB_API char *(luaL_prepbuffer) (luaL_Buffer *B);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <returns></returns>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static string luaL_prepbuffer(ref luaL_Buffer B);

        //LUALIB_API void (luaL_addlstring) (luaL_Buffer *B, const char *s, size_t l);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        [CLSCompliant(false)]
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addlstring(ref luaL_Buffer B, string s, size_t l);

        //LUALIB_API void (luaL_addstring) (luaL_Buffer *B, const char *s);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        /// <param name="s"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addstring(ref luaL_Buffer B, string s);

        //LUALIB_API void (luaL_addvalue) (luaL_Buffer *B);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="B"></param>
        [DllImport(LUA_NATIVE_LIBRARY, CallingConvention = CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public extern static void luaL_addvalue(ref luaL_Buffer B);

        //LUALIB_API void (luaL_pushresult) (luaL_Buffer *B);
        /// <summary>
        /// 
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

        #endregion LuaConf.h
    }
}
