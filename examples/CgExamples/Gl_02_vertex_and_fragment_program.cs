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
/* 02_vertex_and_fragment_program.c - OpenGL-based example using a Cg
   vertex and a Cg fragment programs from Chapter 2 of "The Cg Tutorial"
   (Addison-Wesley, ISBN 0321194969). */

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
    ///     Displays some stars
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Gl_02_vertex_and_fragment_program
    {
        static string myProgramName = "02_vertex_and_fragment_program";
        static string myVertexProgramName = "C2E1v_green";
        static string myFragmentProgramName = "C2E2f_passthru";

        static IntPtr myCgContext;
        static int myCgVertexProfile;
        static int myCgFragmentProfile;
        static IntPtr myCgVertexProgram;
        static IntPtr myCgFragmentProgram;
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
            string fragmentFileName = "C2E2f_passthru.cg";
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
            string myFragmentProgramFileName = Path.Combine(Path.Combine(filePath, fileDirectory), fragmentFileName);

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

            myCgFragmentProfile = CgGl.cgGLGetLatestProfile(CgGl.CG_GL_FRAGMENT);
            CgGl.cgGLSetOptimalOptions(myCgFragmentProfile);
            checkForCgError("selecting fragment profile");

            myCgFragmentProgram =
              Cg.cgCreateProgramFromFile(
                myCgContext,                /* Cg runtime context */
                Cg.CG_SOURCE,                  /* Program in human-readable form */
                myFragmentProgramFileName,  /* Name of file containing program */
                myCgFragmentProfile,        /* Profile: OpenGL ARB vertex program */
                myFragmentProgramName,      /* Entry function name */
                null);                      /* No extra compiler options */
            checkForCgError("creating fragment program from file");
            CgGl.cgGLLoadProgram(myCgFragmentProgram);
            checkForCgError("loading fragment program");

            Glut.glutMainLoop();
        }

        #endregion Run())

        static void DrawStar(float x, float y,
                             int starPoints, float R, float r)
        {
            int i;
            double piOverStarPoints = Math.PI / starPoints,
                   angle = 0.0;

            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(x, y);  /* Center of star */
            /* Emit exterior vertices for star's points. */
            for (i = 0; i < starPoints; i++)
            {
                Gl.glVertex2f((float)(x + R * Math.Cos(angle)), (float)(y + R * Math.Sin(angle)));
                angle += piOverStarPoints;
                Gl.glVertex2f((float)(x + r * Math.Cos(angle)), (float)(y + r * Math.Sin(angle)));
                angle += piOverStarPoints;
            }
            /* End by repeating first exterior vertex of star. */
            angle = 0;
            Gl.glVertex2f((float)(x + R * Math.Cos(angle)), (float)(y + R * Math.Sin(angle)));
            Gl.glEnd();
        }

        static void DrawStars()
        {
            /*                     star    outer   inner  */
            /*        x      y     Points  radius  radius */
            /*       =====  =====  ======  ======  ====== */
            DrawStar(-0.1f, 0f, 5, 0.5f, 0.2f);
            DrawStar(-0.84f, 0.1f, 5, 0.3f, 0.12f);
            DrawStar(0.92f, -0.5f, 5, 0.25f, 0.11f);
            DrawStar(0.3f, 0.97f, 5, 0.3f, 0.1f);
            DrawStar(0.94f, 0.3f, 5, 0.5f, 0.2f);
            DrawStar(-0.97f, -0.8f, 5, 0.6f, 0.2f);
        }

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

            CgGl.cgGLBindProgram(myCgFragmentProgram);
            checkForCgError("binding fragment program");

            CgGl.cgGLEnableProfile(myCgFragmentProfile);
            checkForCgError("enabling fragment profile");

            DrawStars();

            CgGl.cgGLDisableProfile(myCgVertexProfile);
            checkForCgError("disabling vertex profile");

            CgGl.cgGLDisableProfile(myCgFragmentProfile);
            checkForCgError("disabling fragment profile");

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
                    Cg.cgDestroyProgram(myCgFragmentProgram);
                    Cg.cgDestroyContext(myCgContext);
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion Exit()
    }
}
