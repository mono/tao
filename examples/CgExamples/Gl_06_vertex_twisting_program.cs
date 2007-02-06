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

#region Porting Credits
//-----------------------------------------------------------------------------
/*  Ported from C to C# by Marek Wyborski for the Tao Framework.
    02/05/07
*/
//-----------------------------------------------------------------------------
#endregion Porting Credits

using System;
using System.IO;
using Tao.FreeGlut;
using Tao.OpenGl;
using Tao.Cg;

namespace CgExamples
{
    #region Class Documentation
    /// <summary>
    ///     Displays an animated Triangle
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Gl_06_vertex_twisting
    {
        static IntPtr   myCgContext;
        static int      myCgVertexProfile,
                        myCgFragmentProfile;
        static IntPtr   myCgVertexProgram,
                        myCgFragmentProgram;
        static IntPtr   myCgVertexParam_twisting;

        static string myProgramName = "06_vertex_twisting",
            /* Page 79 */   myVertexProgramName = "C3E4v_twist",
            /* Page 53 */   myFragmentProgramName = "C2E2f_passthru";

        static float myTwisting = 2.9f, /* Twisting angle in radians. */
                     myTwistDirection = 0.1f; /* Animation delta for twist. */

        // Tao Delegates
        static Glut.KeyboardCallback keyboardDelegate;
        static Glut.CreateMenuCallback menuDelegate;
        static Glut.IdleCallback idleDelegate;

        //
        static bool animating = false,
            wireframe = false;


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
            string vertexFileName = "C3E4v_twist.cg";
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

            // Callback Delegates
            keyboardDelegate += keyboard;
            menuDelegate += menu;
            idleDelegate += idle;

            Glut.glutInitWindowSize(400, 400);
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH );
            Glut.glutInit();

            Glut.glutCreateWindow(myProgramName);
            Glut.glutDisplayFunc(display);
            Glut.glutKeyboardFunc(keyboardDelegate);

            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);  /* White background */

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

            myCgVertexParam_twisting =
              Cg.cgGetNamedParameter(myCgVertexProgram, "twisting");
            checkForCgError("could not get twisting parameter");

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

            /* No uniform fragment program parameters expected. */

            Glut.glutCreateMenu(menuDelegate);
            Glut.glutAddMenuEntry("[ ] Animate", ' ');
            Glut.glutAddMenuEntry("[w] Wireframe", 'w');
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);

            // Change Animation to true, so that it starts with action ;-)
            keyboard((byte)' ', 0, 0);

            Glut.glutMainLoop();
        }
        #endregion Run())

        /// <summary>
        /// Apply an inefficient but simple-to-implement subdivision scheme for a triangle.
        /// </summary>
        static void triangleDivide(int depth,
                                   float[] a, float[] b, float[] c,
                                   float[] ca, float[] cb, float[] cc)
        {
            if (depth == 0)
            {
                Gl.glColor3fv(ca);
                Gl.glVertex2fv(a);
                Gl.glColor3fv(cb);
                Gl.glVertex2fv(b);
                Gl.glColor3fv(cc);
                Gl.glVertex2fv(c);
            }
            else
            {
                float[] d = { (a[0] + b[0]) / 2, (a[1] + b[1]) / 2 },
                            e = { (b[0] + c[0]) / 2, (b[1] + c[1]) / 2 },
                            f = { (c[0] + a[0]) / 2, (c[1] + a[1]) / 2 };
                float[] cd = { (ca[0] + cb[0]) / 2, (ca[1] + cb[1]) / 2, (ca[2] + cb[2]) / 2 },
                            ce = { (cb[0] + cc[0]) / 2, (cb[1] + cc[1]) / 2, (cb[2] + cc[2]) / 2 },
                            cf = { (cc[0] + ca[0]) / 2, (cc[1] + ca[1]) / 2, (cc[2] + ca[2]) / 2 };

                depth -= 1;
                triangleDivide(depth, a, d, f, ca, cd, cf);
                triangleDivide(depth, d, b, e, cd, cb, ce);
                triangleDivide(depth, f, e, c, cf, ce, cc);
                triangleDivide(depth, d, e, f, cd, ce, cf);
            }
        }


        /// <summary>
        /// Large vertex displacements such as are possible with C3E4v_twist
        /// require a high degree of tessellation.  This routine draws a
        /// triangle recursively subdivided to provide sufficient tessellation.
        /// </summary>
        static void drawSubDividedTriangle(int subdivisions)
        {
            float[] a = { -0.8f, 0.8f },
                        b = { 0.8f, 0.8f },
                        c = { 0.0f, -0.8f },
                        ca = { 0f, 0f, 1f },
                        cb = { 0f, 0f, 1f },
                        cc = { 0.7f, 0.7f, 1f };

            Gl.glBegin(Gl.GL_TRIANGLES);
            triangleDivide(subdivisions, a, b, c, ca, cb, cc);
            Gl.glEnd();
        }

        static void display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Cg.cgSetParameter1f(myCgVertexParam_twisting, myTwisting);

            CgGl.cgGLBindProgram(myCgVertexProgram);
            checkForCgError("binding vertex program");

            CgGl.cgGLEnableProfile(myCgVertexProfile);
            checkForCgError("enabling vertex profile");

            CgGl.cgGLBindProgram(myCgFragmentProgram);
            checkForCgError("binding fragment program");

            CgGl.cgGLEnableProfile(myCgFragmentProfile);
            checkForCgError("enabling fragment profile");

            drawSubDividedTriangle(5);

            CgGl.cgGLDisableProfile(myCgVertexProfile);
            checkForCgError("disabling vertex profile");

            CgGl.cgGLDisableProfile(myCgFragmentProfile);
            checkForCgError("disabling fragment profile");

            Glut.glutSwapBuffers();
        }

        static void idle()
        {
            if (myTwisting > 3f)
            {
                myTwistDirection = -0.05f;
            }
            else if (myTwisting < -3f)
            {
                myTwistDirection = 0.05f;
            }
            myTwisting += myTwistDirection;
            Glut.glutPostRedisplay();
        }

        private static void keyboard(byte key, int x, int y)
        {
            //static int animating = 0,
            //  wireframe = 0;

            switch (key)
            {
                case (byte)' ':
                    animating = !animating; /* Toggle */
                    if (animating)
                    {
                        Glut.glutIdleFunc(idleDelegate);
                    }
                    else
                    {
                        Glut.glutIdleFunc(null);
                    }
                    break;
                case (byte)'w':
                case (byte)'W':
                    wireframe = !wireframe;
                    if (wireframe)
                    {
                        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_LINE);
                    }
                    else
                    {
                        Gl.glPolygonMode(Gl.GL_FRONT_AND_BACK, Gl.GL_FILL);
                    }
                    Glut.glutPostRedisplay();
                    break;
                case 27:  /* Esc key */
                    /* Demonstrate proper deallocation of Cg runtime data structures.
                       Not strictly necessary if we are simply going to exit. */
                    Cg.cgDestroyProgram(myCgVertexProgram);
                    Cg.cgDestroyProgram(myCgFragmentProgram);
                    Cg.cgDestroyContext(myCgContext);
                    Environment.Exit(0);
                    break;
            }
        }

        private static void menu(int item)
        {
            /* Pass menu item character code to keyboard callback. */
            keyboard((byte)item, 0, 0);
        }
    }
}
