#region License
/*
MIT License
Copyright (C)2004-2005 Vladimir Vukicevic <vladimir@pobox.com>
Copyright (C)2004-2006 Tao Framework Team
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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyCompany("Vladimir Vukicevic/http://www.vlad1.com/")]
#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCopyright("Copyright �2003-2006 Tao Framework Team.  All rights reserved.")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDefaultAlias("Tao.GlPostProcess")]
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyDescription("S.R.E. post-processor for OpenGL bindings.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0.0")]
#if STRONG
[assembly: AssemblyKeyFile(@"Tao.GlPostProcess.snk")]
#else
[assembly: AssemblyKeyFile("")]
#endif
[assembly: AssemblyKeyName("")]
#if DEBUG
[assembly: AssemblyProduct("Tao.GlPostProcess.exe *** Debug Build ***")]
#else
[assembly: AssemblyProduct("Tao.GlPostProcess.exe")]
#endif
[assembly: AssemblyTitle("Tao.GlPostProcess")]
[assembly: AssemblyTrademark("Tao Framework -- http://www.taoframework.com")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Flags = SecurityPermissionFlag.Execution)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, Flags = SecurityPermissionFlag.SkipVerification)]
