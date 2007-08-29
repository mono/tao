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
using System.Diagnostics;
using System.Reflection;

namespace CgExamples
{
    public sealed class Gl_14_bulge
    {
        static IntPtr myCgContext;
        static int myCgVertexProfile,
                            myCgFragmentProfile;
        static IntPtr myCgVertexProgram,
                            myCgFragmentProgram,
                            myCgLightVertexProgram/*,
                            myCgLightFragmentProgram*/
                                                      ;
        static IntPtr myCgVertexParam_modelViewProj = IntPtr.Zero;
        static IntPtr myCgVertexParam_time = IntPtr.Zero;
        static IntPtr myCgVertexParam_frequency = IntPtr.Zero;
        static IntPtr myCgVertexParam_scaleFactor = IntPtr.Zero;
        static IntPtr myCgVertexParam_Kd = IntPtr.Zero;
        static IntPtr myCgVertexParam_shininess = IntPtr.Zero;
        static IntPtr myCgVertexParam_eyePosition = IntPtr.Zero;
        static IntPtr myCgVertexParam_lightPosition = IntPtr.Zero;
        static IntPtr myCgVertexParam_lightColor = IntPtr.Zero;
        static IntPtr myCgLightVertexParam_modelViewProj = IntPtr.Zero;

        static string myProgramName = "14_bulge",
            //  myVertexProgramFileName = "C6E1v_bulge.cg",
            /* Page 146 */      myVertexProgramName = "C6E1v_bulge";

        static bool animating = false;
        static float lightVelocity = 0.008f;
        static float timeFlow = 0.01f;

        static float[] myProjectionMatrix = new float[16];
        static float[] myLightColor = { 0.95f, 0.95f, 0.95f };  /* White */
        static float myLightAngle = -0.4f;   /* Angle light rotates around scene. */
        static float myTime = 0.0f;  /* Timing of bulge. */

        // Tao Delegates
        static Glut.KeyboardCallback keyboardDelegate;
        static Glut.CreateMenuCallback menuDelegate;
        static Glut.IdleCallback idleDelegate;
        static Glut.ReshapeCallback reshapeDelegate;

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
                Environment.Exit(1);
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
            string vertexFileName = "C6E1v_bulge.cg";
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

            // Callback Delegates
            keyboardDelegate += keyboard;
            menuDelegate += menu;
            idleDelegate += idle;
            reshapeDelegate += reshape;

            Glut.glutInitWindowSize(400, 400);
            Glut.glutInitDisplayMode(Glut.GLUT_RGB | Glut.GLUT_DOUBLE | Glut.GLUT_DEPTH);
            Glut.glutInit();

            Glut.glutCreateWindow(myProgramName);
            Glut.glutDisplayFunc(display);
            Glut.glutKeyboardFunc(keyboardDelegate);
            Glut.glutReshapeFunc(reshapeDelegate);

            Gl.glClearColor(0.1f, 0.1f, 0.5f, 0f);  /* Gray background. */
            Gl.glEnable(Gl.GL_DEPTH_TEST);         /* Hidden surface removal. */

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

            GET_PARAM("modelViewProj");
            GET_PARAM("time");
            GET_PARAM("frequency");
            GET_PARAM("scaleFactor");
            GET_PARAM("Kd");
            GET_PARAM("shininess");
            GET_PARAM("eyePosition");
            GET_PARAM("lightPosition");
            GET_PARAM("lightColor");

            /* Set light source color parameters once. */
            Cg.cgSetParameter3fv(myCgVertexParam_lightColor, out myLightColor[0]);

            Cg.cgSetParameter1f(myCgVertexParam_scaleFactor, 0.3f);
            Cg.cgSetParameter1f(myCgVertexParam_frequency, 2.4f);
            Cg.cgSetParameter1f(myCgVertexParam_shininess, 35f);

            myCgFragmentProfile = CgGl.cgGLGetLatestProfile(CgGl.CG_GL_FRAGMENT);
            CgGl.cgGLSetOptimalOptions(myCgFragmentProfile);
            checkForCgError("selecting fragment profile");

            /* Specify fragment program with a string. */
            myCgFragmentProgram =
              Cg.cgCreateProgram(
                myCgContext,              /* Cg runtime context */
                Cg.CG_SOURCE,                /* Program in human-readable form */
                "float4 main(float4 c : COLOR) : COLOR { return c; }",
                myCgFragmentProfile,      /* Profile: latest fragment profile */
                "main",                   /* Entry function name */
                null); /* No extra commyPiler options */
            checkForCgError("creating fragment program from string");
            CgGl.cgGLLoadProgram(myCgFragmentProgram);
            checkForCgError("loading fragment program");

            /* Specify vertex program for rendering the light source with a
               string. */
            myCgLightVertexProgram =
              Cg.cgCreateProgram(
                myCgContext,              /* Cg runtime context */
                Cg.CG_SOURCE,                /* Program in human-readable form */
                "void main(inout float4 p : POSITION, " +
                "uniform float4x4 modelViewProj, " +
                "out float4 c : COLOR) " +
                "{ p = mul(modelViewProj, p); c = float4(1,1,0,1); }",
                myCgVertexProfile,        /* Profile: latest fragment profile */
                "main",                   /* Entry function name */
                null); /* No extra commyPiler options */
            checkForCgError("creating light vertex program from string");
            CgGl.cgGLLoadProgram(myCgLightVertexProgram);
            checkForCgError("loading light vertex program");

            myCgLightVertexParam_modelViewProj =
              Cg.cgGetNamedParameter(myCgLightVertexProgram, "modelViewProj");
            checkForCgError("could not get modelViewProj parameter");

            Glut.glutCreateMenu(menu);
            Glut.glutAddMenuEntry("[ ] Animate", ' ');
            Glut.glutAttachMenu(Glut.GLUT_RIGHT_BUTTON);

            // Change Animation to true, so that it starts with action ;-)
            keyboard((byte)' ', 0, 0);

            Glut.glutMainLoop();
        }
        #endregion Run())

        private static void GET_PARAM(string name)
        {
            FieldInfo fieldInfo = typeof(Gl_14_bulge).GetField("myCgVertexParam_" + name
                , BindingFlags.Static | BindingFlags.NonPublic);
            fieldInfo.SetValue(null, Cg.cgGetNamedParameter(myCgVertexProgram, name));
            checkForCgError("could not get " + name + " parameter");
        }

        static void reshape(int width, int height)
        {
            double aspectRatio = (float)width / (float)height;
            double fieldOfView = 40.0; /* Degrees */

            /* Build projection matrix once. */
            buildPerspectiveMatrix(fieldOfView, aspectRatio,
                                   1.0, 20.0,  /* Znear and Zfar */
                                   ref myProjectionMatrix);
            Gl.glViewport(0, 0, width, height);
        }

        static void buildPerspectiveMatrix(double fieldOfView,
                                   double aspectRatio,
                                   double zNear, double zFar,
                                   ref float[] m)
        {
            double sine, cotangent, deltaZ;
            double radians = fieldOfView / 2.0 * Math.PI / 180.0;

            deltaZ = zFar - zNear;
            sine = Math.Sin(radians);
            /* Should be non-zero to avoid division by zero. */
            Debug.Assert(deltaZ != 0);
            Debug.Assert(sine != 0);
            Debug.Assert(aspectRatio != 0);
            cotangent = Math.Cos(radians) / sine;

            m[0 * 4 + 0] = (float)(cotangent / aspectRatio);
            m[1 * 4 + 0] = 0.0f;
            m[2 * 4 + 0] = 0.0f;
            m[3 * 4 + 0] = 0.0f;

            m[0 * 4 + 1] = 0.0f;
            m[1 * 4 + 1] = (float)cotangent;
            m[2 * 4 + 1] = 0.0f;
            m[3 * 4 + 1] = 0.0f;

            m[0 * 4 + 2] = 0.0f;
            m[1 * 4 + 2] = 0.0f;
            m[2 * 4 + 2] = (float)(-(zFar + zNear) / deltaZ);
            m[3 * 4 + 2] = (float)(-2 * zNear * zFar / deltaZ);

            m[0 * 4 + 3] = 0.0f;
            m[1 * 4 + 3] = 0.0f;
            m[2 * 4 + 3] = -1f;
            m[3 * 4 + 3] = 0f;
        }

        /// <summary>
        /// Build a row-major (C-style) 4x4 matrix transform based on the
        /// parameters for gluLookAt.
        /// </summary>
        static void buildLookAtMatrix(double eyex, double eyey, double eyez,
                              double centerx, double centery, double centerz,
                              double upx, double upy, double upz,
                              ref float[] m)
        {
            double[] x = new double[3], y = new double[3], z = new double[3];
            double mag;

            /* Difference eye and center vectors to make Z vector. */
            z[0] = eyex - centerx;
            z[1] = eyey - centery;
            z[2] = eyez - centerz;
            /* Normalize Z. */
            mag = Math.Sqrt(z[0] * z[0] + z[1] * z[1] + z[2] * z[2]);
            if (mag != 0)
            {
                z[0] /= mag;
                z[1] /= mag;
                z[2] /= mag;
            }

            /* Up vector makes Y vector. */
            y[0] = upx;
            y[1] = upy;
            y[2] = upz;

            /* X vector = Y cross Z. */
            x[0] = y[1] * z[2] - y[2] * z[1];
            x[1] = -y[0] * z[2] + y[2] * z[0];
            x[2] = y[0] * z[1] - y[1] * z[0];

            /* Recompute Y = Z cross X. */
            y[0] = z[1] * x[2] - z[2] * x[1];
            y[1] = -z[0] * x[2] + z[2] * x[0];
            y[2] = z[0] * x[1] - z[1] * x[0];

            /* Normalize X. */
            mag = Math.Sqrt(x[0] * x[0] + x[1] * x[1] + x[2] * x[2]);
            if (mag != 0)
            {
                x[0] /= mag;
                x[1] /= mag;
                x[2] /= mag;
            }

            /* Normalize Y. */
            mag = Math.Sqrt(y[0] * y[0] + y[1] * y[1] + y[2] * y[2]);
            if (mag != 0)
            {
                y[0] /= mag;
                y[1] /= mag;
                y[2] /= mag;
            }

            /* Build resulting view matrix. */
            m[0 * 4 + 0] = (float)x[0]; m[0 * 4 + 1] = (float)x[1];
            m[0 * 4 + 2] = (float)x[2]; m[0 * 4 + 3] = (float)(-x[0] * eyex + -x[1] * eyey + -x[2] * eyez);

            m[1 * 4 + 0] = (float)y[0]; m[1 * 4 + 1] = (float)y[1];
            m[1 * 4 + 2] = (float)y[2]; m[1 * 4 + 3] = (float)(-y[0] * eyex + -y[1] * eyey + -y[2] * eyez);

            m[2 * 4 + 0] = (float)z[0]; m[2 * 4 + 1] = (float)z[1];
            m[2 * 4 + 2] = (float)z[2]; m[2 * 4 + 3] = (float)(-z[0] * eyex + -z[1] * eyey + -z[2] * eyez);

            m[3 * 4 + 0] = (float)0.0; m[3 * 4 + 1] = (float)0.0; m[3 * 4 + 2] = 0.0f; m[3 * 4 + 3] = 1.0f;
        }

        static void makeRotateMatrix(float angle,
                             float ax, float ay, float az,
                             ref float[] m)
        {
            float radians, sine, cosine, ab, bc, ca, tx, ty, tz;
            float[] axis = new float[3];
            float mag;

            axis[0] = ax;
            axis[1] = ay;
            axis[2] = az;
            mag = (float)Math.Sqrt(axis[0] * axis[0] + axis[1] * axis[1] + axis[2] * axis[2]);
            if (mag != 0)
            {
                axis[0] /= mag;
                axis[1] /= mag;
                axis[2] /= mag;
            }

            radians = angle * (float)(Math.PI / 180.0);
            sine = (float)Math.Sin(radians);
            cosine = (float)Math.Cos(radians);
            ab = axis[0] * axis[1] * (1 - cosine);
            bc = axis[1] * axis[2] * (1 - cosine);
            ca = axis[2] * axis[0] * (1 - cosine);
            tx = axis[0] * axis[0];
            ty = axis[1] * axis[1];
            tz = axis[2] * axis[2];

            m[0] = tx + cosine * (1 - tx);
            m[1] = ab + axis[2] * sine;
            m[2] = ca - axis[1] * sine;
            m[3] = 0.0f;
            m[4] = ab - axis[2] * sine;
            m[5] = ty + cosine * (1 - ty);
            m[6] = bc + axis[0] * sine;
            m[7] = 0.0f;
            m[8] = ca + axis[1] * sine;
            m[9] = bc - axis[0] * sine;
            m[10] = tz + cosine * (1 - tz);
            m[11] = 0;
            m[12] = 0;
            m[13] = 0;
            m[14] = 0;
            m[15] = 1;
        }

        static void makeTranslateMatrix(float x, float y, float z, ref float[] m)
        {
            m[0] = 1; m[1] = 0; m[2] = 0; m[3] = x;
            m[4] = 0; m[5] = 1; m[6] = 0; m[7] = y;
            m[8] = 0; m[9] = 0; m[10] = 1; m[11] = z;
            m[12] = 0; m[13] = 0; m[14] = 0; m[15] = 1;
        }

        /// <summary>
        /// Simple 4x4 matrix by 4x4 matrix multiply.
        /// </summary>
        static void multMatrix(ref float[] dst, float[] src1, float[] src2)
        {
            float[] tmp = new float[16];
            int i, j;

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    tmp[i * 4 + j] = src1[i * 4 + 0] * src2[0 * 4 + j] +
                                 src1[i * 4 + 1] * src2[1 * 4 + j] +
                                 src1[i * 4 + 2] * src2[2 * 4 + j] +
                                 src1[i * 4 + 3] * src2[3 * 4 + j];
                }
            }
            /* Copy result to dst (so dst can also be src1 or src2). */
            for (i = 0; i < 16; i++)
                dst[i] = tmp[i];
        }

        /// <summary>
        /// Invert a row-major (C-style) 4x4 matrix.
        /// </summary>
        static void invertMatrix(ref float[] output, ref float[] m)
        {
            double m0, m1, m2, m3, s;
            double[] r0 = new double[8], r1 = new double[8], r2 = new double[8], r3 = new double[8];

            r0[0] = MAT_Get(m, 0, 0); r0[1] = MAT_Get(m, 0, 1);
            r0[2] = MAT_Get(m, 0, 2); r0[3] = MAT_Get(m, 0, 3);
            r0[4] = 1.0; r0[5] = r0[6] = r0[7] = 0.0;

            r1[0] = MAT_Get(m, 1, 0); r1[1] = MAT_Get(m, 1, 1);
            r1[2] = MAT_Get(m, 1, 2); r1[3] = MAT_Get(m, 1, 3);
            r1[5] = 1.0; r1[4] = r1[6] = r1[7] = 0.0;

            r2[0] = MAT_Get(m, 2, 0); r2[1] = MAT_Get(m, 2, 1);
            r2[2] = MAT_Get(m, 2, 2); r2[3] = MAT_Get(m, 2, 3);
            r2[6] = 1.0; r2[4] = r2[5] = r2[7] = 0.0;

            r3[0] = MAT_Get(m, 3, 0); r3[1] = MAT_Get(m, 3, 1);
            r3[2] = MAT_Get(m, 3, 2); r3[3] = MAT_Get(m, 3, 3);
            r3[7] = 1.0; r3[4] = r3[5] = r3[6] = 0.0;

            /* Choose myPivot, or die. */
            if (Math.Abs(r3[0]) > Math.Abs(r2[0])) SWAP_ROWS(ref r3, ref r2);
            if (Math.Abs(r2[0]) > Math.Abs(r1[0])) SWAP_ROWS(ref r2, ref r1);
            if (Math.Abs(r1[0]) > Math.Abs(r0[0])) SWAP_ROWS(ref r1, ref r0);
            if (0.0 == r0[0])
            {
                Debug.Assert(false, "could not invert matrix");
            }

            /* Eliminate first variable. */
            m1 = r1[0] / r0[0]; m2 = r2[0] / r0[0]; m3 = r3[0] / r0[0];
            s = r0[1]; r1[1] -= m1 * s; r2[1] -= m2 * s; r3[1] -= m3 * s;
            s = r0[2]; r1[2] -= m1 * s; r2[2] -= m2 * s; r3[2] -= m3 * s;
            s = r0[3]; r1[3] -= m1 * s; r2[3] -= m2 * s; r3[3] -= m3 * s;
            s = r0[4];
            if (s != 0.0) { r1[4] -= m1 * s; r2[4] -= m2 * s; r3[4] -= m3 * s; }
            s = r0[5];
            if (s != 0.0) { r1[5] -= m1 * s; r2[5] -= m2 * s; r3[5] -= m3 * s; }
            s = r0[6];
            if (s != 0.0) { r1[6] -= m1 * s; r2[6] -= m2 * s; r3[6] -= m3 * s; }
            s = r0[7];
            if (s != 0.0) { r1[7] -= m1 * s; r2[7] -= m2 * s; r3[7] -= m3 * s; }

            /* Choose myPivot, or die. */
            if (Math.Abs(r3[1]) > Math.Abs(r2[1])) SWAP_ROWS(ref r3, ref r2);
            if (Math.Abs(r2[1]) > Math.Abs(r1[1])) SWAP_ROWS(ref r2, ref r1);
            if (0.0 == r1[1])
            {
                Debug.Assert(false, "could not invert matrix");
            }

            /* Eliminate second variable. */
            m2 = r2[1] / r1[1]; m3 = r3[1] / r1[1];
            r2[2] -= m2 * r1[2]; r3[2] -= m3 * r1[2];
            r2[3] -= m2 * r1[3]; r3[3] -= m3 * r1[3];
            s = r1[4]; if (0.0 != s) { r2[4] -= m2 * s; r3[4] -= m3 * s; }
            s = r1[5]; if (0.0 != s) { r2[5] -= m2 * s; r3[5] -= m3 * s; }
            s = r1[6]; if (0.0 != s) { r2[6] -= m2 * s; r3[6] -= m3 * s; }
            s = r1[7]; if (0.0 != s) { r2[7] -= m2 * s; r3[7] -= m3 * s; }

            /* Choose myPivot, or die. */
            if (Math.Abs(r3[2]) > Math.Abs(r2[2])) SWAP_ROWS(ref r3, ref r2);
            if (0.0 == r2[2])
            {
                Debug.Assert(false, "could not invert matrix");
            }

            /* Eliminate third variable. */
            m3 = r3[2] / r2[2];
            r3[3] -= m3 * r2[3]; r3[4] -= m3 * r2[4];
            r3[5] -= m3 * r2[5]; r3[6] -= m3 * r2[6];
            r3[7] -= m3 * r2[7];

            /* Last check. */
            if (0.0 == r3[3])
            {
                Debug.Assert(false, "could not invert matrix");
            }

            s = 1.0 / r3[3];              /* Now back substitute row 3. */
            r3[4] *= s; r3[5] *= s; r3[6] *= s; r3[7] *= s;

            m2 = r2[3];                 /* Now back substitute row 2. */
            s = 1.0 / r2[2];
            r2[4] = s * (r2[4] - r3[4] * m2); r2[5] = s * (r2[5] - r3[5] * m2);
            r2[6] = s * (r2[6] - r3[6] * m2); r2[7] = s * (r2[7] - r3[7] * m2);
            m1 = r1[3];
            r1[4] -= r3[4] * m1; r1[5] -= r3[5] * m1;
            r1[6] -= r3[6] * m1; r1[7] -= r3[7] * m1;
            m0 = r0[3];
            r0[4] -= r3[4] * m0; r0[5] -= r3[5] * m0;
            r0[6] -= r3[6] * m0; r0[7] -= r3[7] * m0;

            m1 = r1[2];                 /* Now back substitute row 1. */
            s = 1.0 / r1[1];
            r1[4] = s * (r1[4] - r2[4] * m1); r1[5] = s * (r1[5] - r2[5] * m1);
            r1[6] = s * (r1[6] - r2[6] * m1); r1[7] = s * (r1[7] - r2[7] * m1);
            m0 = r0[2];
            r0[4] -= r2[4] * m0; r0[5] -= r2[5] * m0;
            r0[6] -= r2[6] * m0; r0[7] -= r2[7] * m0;

            m0 = r0[1];                 /* Now back substitute row 0. */
            s = 1.0 / r0[0];
            r0[4] = s * (r0[4] - r1[4] * m0); r0[5] = s * (r0[5] - r1[5] * m0);
            r0[6] = s * (r0[6] - r1[6] * m0); r0[7] = s * (r0[7] - r1[7] * m0);

            MAT_Set(ref output, 0, 0, r0[4]); MAT_Set(ref output, 0, 1, r0[5]);
            MAT_Set(ref output, 0, 2, r0[6]); MAT_Set(ref output, 0, 3, r0[7]);
            MAT_Set(ref output, 1, 0, r1[4]); MAT_Set(ref output, 1, 1, r1[5]);
            MAT_Set(ref output, 1, 2, r1[6]); MAT_Set(ref output, 1, 3, r1[7]);
            MAT_Set(ref output, 2, 0, r2[4]); MAT_Set(ref output, 2, 1, r2[5]);
            MAT_Set(ref output, 2, 2, r2[6]); MAT_Set(ref output, 2, 3, r2[7]);
            MAT_Set(ref output, 3, 0, r3[4]); MAT_Set(ref output, 3, 1, r3[5]);
            MAT_Set(ref output, 3, 2, r3[6]); MAT_Set(ref output, 3, 3, r3[7]);
        }

        /// <summary>
        /// Change Rows means in this case just change the Refrences
        /// to the Arrays
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        static void SWAP_ROWS(ref double[] a, ref double[] b)
        {
            double[] temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Get Element of Matrix
        /// </summary>
        /// <param name="m">Matrix</param>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <returns>Value</returns>
        static float MAT_Get(float[] m, int r, int c)
        {
            return m[r * 4 + c];
        }

        /// <summary>
        /// Set Element in Matrix
        /// </summary>
        /// <param name="m">Matrix</param>
        /// <param name="r">Row</param>
        /// <param name="c">Column</param>
        /// <param name="value">Value</param>
        static void MAT_Set(ref float[] m, int r, int c, double value)
        {
            m[r * 4 + c] = (float)value;
        }

        /// <summary>
        /// Simple 4x4 matrix by 4-component column vector multiply.
        /// </summary>
        /// <param name="dst"></param>
        /// <param name="mat"></param>
        /// <param name="vec"></param>
        static void transform(ref float[] dst, float[] mat, float[] vec)
        {
            double[] tmp = new double[4];
            double invW;
            int i;

            for (i = 0; i < 4; i++)
            {
                tmp[i] = mat[i * 4 + 0] * vec[0] +
                         mat[i * 4 + 1] * vec[1] +
                         mat[i * 4 + 2] * vec[2] +
                         mat[i * 4 + 3] * vec[3];
            }
            invW = 1 / tmp[3];
            /* Apply perspective divide and copy to dst (so dst can vec). */
            for (i = 0; i < 3; i++)
                dst[i] = (float)(tmp[i] * tmp[3]);
            dst[3] = 1;
        }

        static void display()
        {
            /* World-space positions for light and eye. */
            float[] eyePosition = { 0, 0, 8, 1 };
            float[] lightPosition = { 5*(float) Math.Sin(myLightAngle), 
                                   1.5f,
                                   5*(float) Math.Cos(myLightAngle), 1 };

            float[] translateMatrix = new float[16], rotateMatrix = new float[16],
                    modelMatrix = new float[16], invModelMatrix = new float[16], viewMatrix = new float[16],
                    modelViewMatrix = new float[16], modelViewProjMatrix = new float[16];
            float[] objSpaceEyePosition = new float[4], objSpaceLightPosition = new float[4];

            Cg.cgSetParameter1f(myCgVertexParam_time, myTime);

            buildLookAtMatrix(eyePosition[0], eyePosition[1], eyePosition[2],
                    0, 0, 0,
                    0, 1, 0,
                    ref viewMatrix);

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            CgGl.cgGLEnableProfile(myCgVertexProfile);
            checkForCgError("enabling vertex profile");

            CgGl.cgGLEnableProfile(myCgFragmentProfile);
            checkForCgError("enabling fragment profile");

            CgGl.cgGLBindProgram(myCgVertexProgram);
            checkForCgError("binding vertex program");

            CgGl.cgGLBindProgram(myCgFragmentProgram);
            checkForCgError("binding fragment program");

            /*** Render green solid bulging sphere ***/

            /* modelView = rotateMatrix * translateMatrix */
            makeRotateMatrix(70f, 1f, 1f, 1f, ref rotateMatrix);
            makeTranslateMatrix(2.2f, 1f, 0.2f, ref translateMatrix);
            multMatrix(ref modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            invertMatrix(ref invModelMatrix, ref modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            transform(ref objSpaceEyePosition, invModelMatrix, eyePosition);
            Cg.cgSetParameter3fv(myCgVertexParam_eyePosition, out objSpaceEyePosition[0]);
            transform(ref objSpaceLightPosition, invModelMatrix, lightPosition);
            Cg.cgSetParameter3fv(myCgVertexParam_lightPosition, out objSpaceLightPosition[0]);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            multMatrix(ref modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            multMatrix(ref modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.cgSetMatrixParameterfr(myCgVertexParam_modelViewProj, out modelViewProjMatrix[0]);
            Cg.cgSetParameter4f(myCgVertexParam_Kd, 0.1f, 0.7f, 0.1f, 1f);  /* Green */
            Glut.glutSolidSphere(1.0, 40, 40);

            /*** Render red solid bulging torus ***/

            /* modelView = viewMatrix * translateMatrix */
            makeTranslateMatrix(-2f, -1.5f, 0f, ref translateMatrix);
            makeRotateMatrix(55, 1, 0, 0, ref rotateMatrix);
            multMatrix(ref modelMatrix, translateMatrix, rotateMatrix);

            /* invModelMatrix = inverse(modelMatrix) */
            invertMatrix(ref invModelMatrix, ref modelMatrix);

            /* Transform world-space eye and light positions to sphere's object-space. */
            transform(ref objSpaceEyePosition, invModelMatrix, eyePosition);
            Cg.cgSetParameter3fv(myCgVertexParam_eyePosition, out objSpaceEyePosition[0]);
            transform(ref objSpaceLightPosition, invModelMatrix, lightPosition);
            Cg.cgSetParameter3fv(myCgVertexParam_lightPosition, out objSpaceLightPosition[0]);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            multMatrix(ref modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            multMatrix(ref modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.cgSetMatrixParameterfr(myCgVertexParam_modelViewProj, out modelViewProjMatrix[0]);
            Cg.cgSetParameter4f(myCgVertexParam_Kd, 0.8f, 0.1f, 0.1f, 1f);  /* Red */
            Glut.glutSolidTorus(0.15, 1.7, 40, 40);

            /*** Render light as emissive yellow ball ***/

            CgGl.cgGLBindProgram(myCgLightVertexProgram);
            checkForCgError("binding light vertex program");

            /* modelView = translateMatrix */
            makeTranslateMatrix(lightPosition[0], lightPosition[1], lightPosition[2],
              ref modelMatrix);

            /* modelViewMatrix = viewMatrix * modelMatrix */
            multMatrix(ref modelViewMatrix, viewMatrix, modelMatrix);

            /* modelViewProj = projectionMatrix * modelViewMatrix */
            multMatrix(ref modelViewProjMatrix, myProjectionMatrix, modelViewMatrix);

            /* Set matrix parameter with row-major matrix. */
            Cg.cgSetMatrixParameterfr(myCgLightVertexParam_modelViewProj,
              out modelViewProjMatrix[0]);
            Glut.glutSolidSphere(0.1, 12, 12);

            CgGl.cgGLDisableProfile(myCgVertexProfile);
            checkForCgError("disabling vertex profile");

            CgGl.cgGLDisableProfile(myCgFragmentProfile);
            checkForCgError("disabling fragment profile");

            Glut.glutSwapBuffers();
        }

        static void idle()
        {
            // static float lightVelocity = 0.008;
            // static float timeFlow = 0.01;

            /* Repeat rotating light around front 180 degrees. */
            if (myLightAngle > Math.PI / 2)
            {
                myLightAngle = (float)Math.PI / 2;
                lightVelocity = -lightVelocity;
            }
            else if (myLightAngle < -Math.PI / 2)
            {
                myLightAngle = (float)-Math.PI / 2;
                lightVelocity = -lightVelocity;
            }
            myLightAngle += lightVelocity;  /* Add a small angle (in radians). */

            /* Repeatedly advance and rewind time. */
            if (myTime > 10)
            {
                myTime = 10;
                timeFlow = -timeFlow;
            }
            else if (myTime < 0)
            {
                myTime = 0;
                timeFlow = -timeFlow;
            }
            myTime += timeFlow;  /* Add time delta. */

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
                case 27:  /* Esc key */
                    /* Demonstrate proper deallocation of Cg runtime data structures.
                       Not strictly necessary if we are simply going to exit. */
                    Cg.cgDestroyProgram(myCgVertexProgram);
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
