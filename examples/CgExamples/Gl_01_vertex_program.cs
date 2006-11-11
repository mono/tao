#region License
/*
MIT License
Copyright ©2003-2005 Tao Framework Team
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

#region Original Credits / License
//-----------------------------------------------------------------------------
/* 01_vertex_program.c - OpenGL-based very simple vertex program example
   using Cg program from Chapter 2 of "The Cg Tutorial" (Addison-Wesley,
   ISBN 0321194969). */

/* Requires the OpenGL Utility Toolkit (GLUT) and Cg runtime (version
   1.0 or higher). */
//-----------------------------------------------------------------------------
#endregion Original Credits / License

using System;
using System.IO;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Cg;

namespace CgExamples
{
    #region Class Documentation
    /// <summary>
    ///     Displays a triangle
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         OpenGL-based very simple vertex program example
    ///         using Cg program from Chapter 2 of "The Cg Tutorial" (Addison-Wesley,
    ///         ISBN 0321194969)
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Gl_01_vertex_program
    {
        static string myProgramName = "01_vertex_program";
        static string myVertexProgramName = "C2E1v_green";

        static IntPtr myCgContext;
        static int myCgVertexProfile;
        static IntPtr myCgVertexProgram;
        static Glut.KeyboardCallback KeyboardDelegate;

        // --- Entry Point ---
        #region Run())
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        [STAThread]
        public static void Run()
        {
            string filePath = Path.Combine("..", "..");
            string fileDirectory = "Data";
            string vertexFileName = "C2E1v_green.cg";
            if (File.Exists(vertexFileName))
            {
                filePath = "";
                fileDirectory = "";
            }
            else if (File.Exists(Path.Combine(fileDirectory, vertexFileName)))
            {
                filePath = "";
            }

            string myVertexProgramFileName = Path.Combine(Path.Combine(filePath, fileDirectory), vertexFileName);

            KeyboardDelegate += Keyboard;
            Glut.glutInitWindowSize(400, 400);
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInit();

            Glut.glutCreateWindow(myProgramName);
            Glut.glutDisplayFunc(Display);
            Glut.glutKeyboardFunc(KeyboardDelegate);

            Gl.glClearColor(0.1f, 0.3f, 0.6f, 0.0f);  /* Blue background */

            myCgContext = Cg.cgCreateContext();
            checkForCgError("creating context");

            myCgVertexProfile = CgGl.cgGLGetLatestProfile(CgGl.CG_GL_VERTEX);
            CgGl.cgGLSetOptimalOptions(myCgVertexProfile);
            checkForCgError("selecting vertex profile");

            myCgVertexProgram =
              Cg.cgCreateProgramFromFile(
                myCgContext,              /* Cg runtime context */
                Cg.CG_SOURCE,                /* Program in human-readable form */
                myVertexProgramFileName,  /* Name of file containing program */
                myCgVertexProfile,        /* Profile: OpenGL ARB vertex program */
                myVertexProgramName,      /* Entry function name */
                null);                    /* No extra compiler options */
            checkForCgError("creating vertex program from file");
            CgGl.cgGLLoadProgram(myCgVertexProgram);
            checkForCgError("loading vertex program");

            Glut.glutMainLoop();
        }

        #endregion Run())

        static void checkForCgError(string situation)
        {
            int error;
            string errorString = Cg.cgGetLastErrorString(out error);

            if (error != Cg.CG_NO_ERROR)
            {
                Console.WriteLine("{0}- {1}- {2}",
                  myProgramName, situation, errorString);
                if (error == Cg.CG_COMPILER_ERROR)
                {
                    Console.WriteLine("{0}", Cg.cgGetLastListing(myCgContext));
                }
                Environment.Exit(0);
            }
        }

        static void Display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            CgGl.cgGLBindProgram(myCgVertexProgram);
            checkForCgError("binding vertex program");

            CgGl.cgGLEnableProfile(myCgVertexProfile);
            checkForCgError("enabling vertex profile");

            /* Rendering code verbatim from Chapter 1, Section 2.4.1 "Rendering
               a Triangle with OpenGL" (page 57). */
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glVertex2f(-0.8f, 0.8f);
            Gl.glVertex2f(0.8f, 0.8f);
            Gl.glVertex2f(0.0f, -0.8f);
            Gl.glEnd();

            CgGl.cgGLDisableProfile(myCgVertexProfile);
            checkForCgError("disabling vertex profile");

            Glut.glutSwapBuffers();
        }

        #region Keyboard()
        /// <summary>
        ///     Exits application.
        /// </summary>
        private static void Keyboard(byte key, int x, int y)
        {
            switch (key)
            {
                case 27:
                    Cg.cgDestroyProgram(myCgVertexProgram);
                    Cg.cgDestroyContext(myCgContext);
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion Exit()
    }
}
