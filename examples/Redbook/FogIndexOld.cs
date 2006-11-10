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
/* Copyright (c) Mark J. Kilgard, 1994. */
/*
 * (c) Copyright 1993, Silicon Graphics, Inc.
 * ALL RIGHTS RESERVED 
 * Permission to use, copy, modify, and distribute this software for 
 * any purpose and without fee is hereby granted, provided that the above
 * copyright notice appear in all copies and that both the copyright notice
 * and this permission notice appear in supporting documentation, and that 
 * the name of Silicon Graphics, Inc. not be used in advertising
 * or publicity pertaining to distribution of the software without specific,
 * written prior permission. 
 *
 * THE MATERIAL EMBODIED ON THIS SOFTWARE IS PROVIDED TO YOU "AS-IS"
 * AND WITHOUT WARRANTY OF ANY KIND, EXPRESS, IMPLIED OR OTHERWISE,
 * INCLUDING WITHOUT LIMITATION, ANY WARRANTY OF MERCHANTABILITY OR
 * FITNESS FOR A PARTICULAR PURPOSE.  IN NO EVENT SHALL SILICON
 * GRAPHICS, INC.  BE LIABLE TO YOU OR ANYONE ELSE FOR ANY DIRECT,
 * SPECIAL, INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF ANY
 * KIND, OR ANY DAMAGES WHATSOEVER, INCLUDING WITHOUT LIMITATION,
 * LOSS OF PROFIT, LOSS OF USE, SAVINGS OR REVENUE, OR THE CLAIMS OF
 * THIRD PARTIES, WHETHER OR NOT SILICON GRAPHICS, INC.  HAS BEEN
 * ADVISED OF THE POSSIBILITY OF SUCH LOSS, HOWEVER CAUSED AND ON
 * ANY THEORY OF LIABILITY, ARISING OUT OF OR IN CONNECTION WITH THE
 * POSSESSION, USE OR PERFORMANCE OF THIS SOFTWARE.
 * 
 * US Government Users Restricted Rights 
 * Use, duplication, or disclosure by the Government is subject to
 * restrictions set forth in FAR 52.227.19(c)(2) or subparagraph
 * (c)(1)(ii) of the Rights in Technical Data and Computer Software
 * clause at DFARS 252.227-7013 and/or in similar or successor
 * clauses in the FAR or the DOD or NASA FAR Supplement.
 * Unpublished-- rights reserved under the copyright laws of the
 * United States.  Contractor/manufacturer is Silicon Graphics,
 * Inc., 2011 N.  Shoreline Blvd., Mountain View, CA 94039-7311.
 *
 * OpenGL(TM) is a trademark of Silicon Graphics, Inc.
 */
#endregion Original Credits / License

using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Redbook {
    #region Class Documentation
    /// <summary>
    ///     This program demonstrates fog in color index mode.  Three cones are drawn at
    ///     different z values in a linear fog.  32 contiguous colors (from 16 to 47) are
    ///     loaded with a color ramp.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Original Author:    Mark J. Kilgard
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class FogIndexOld {
        // --- Fields ---
        #region Private Constants
        // Initialize color map and fog.  Set screen clear color to end of ramp.
        private const int NUMCOLORS = 32;
        private const int RAMPSTART = 16;
        #endregion Private Constants

        // --- Entry Point ---
        #region Run()
        /// <summary>
        ///     <para>
        ///         Open window with initial window size, title bar, color index mode, depth
        ///         buffer, and handle input events.
        ///     </para>
        /// </summary>
        [STAThread]
        public static void Run() {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_INDEX | Glut.GLUT_DEPTH);
            Glut.glutCreateWindow("FogIndexOld");
            Init();
            Glut.glutDisplayFunc(new Glut.DisplayCallback(Display));
            Glut.glutKeyboardFunc(new Glut.KeyboardCallback(Keyboard));
            Glut.glutReshapeFunc(new Glut.ReshapeCallback(Reshape));
            Glut.glutMainLoop();
        }
        #endregion Run()

        // --- Application Methods ---
        #region Init()
        private static void Init() {
            int i;

            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LESS);
            for(i = 0; i < NUMCOLORS; i++) {
                float shade;
                shade = (float) (NUMCOLORS - i) / (float) NUMCOLORS;
                Glut.glutSetColor(16 + i, shade, shade, shade);
            }
            Gl.glEnable(Gl.GL_FOG);

            Gl.glFogi(Gl.GL_FOG_MODE, Gl.GL_LINEAR);
            Gl.glFogi(Gl.GL_FOG_INDEX, NUMCOLORS);
            Gl.glFogf(Gl.GL_FOG_START, 0.0f);
            Gl.glFogf(Gl.GL_FOG_END, 4.0f);
            Gl.glHint(Gl.GL_FOG_HINT, Gl.GL_NICEST);
            Gl.glClearIndex((float) (NUMCOLORS + RAMPSTART - 1));
        }
        #endregion Init()

        // --- Callbacks ---
        #region Display()
        /// <summary>
        ///     <para>
        ///         Display() renders 3 cones at different z positions.
        ///     </para>
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                Gl.glTranslatef(-1.0f, -1.0f, -1.0f);
                Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
                Gl.glIndexi(RAMPSTART);
                Glut.glutSolidCone(1.0, 2.0, 10, 10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(0.0f, -1.0f, -2.25f);
                Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
                Gl.glIndexi(RAMPSTART);
                Glut.glutSolidCone(1.0, 2.0, 10, 10);
            Gl.glPopMatrix();

            Gl.glPushMatrix();
                Gl.glTranslatef(1.0f, -1.0f, -3.5f);
                Gl.glRotatef(-90.0f, 1.0f, 0.0f, 0.0f);
                Gl.glIndexi(RAMPSTART);
                Glut.glutSolidCone(1.0, 2.0, 10, 10);
            Gl.glPopMatrix();

            Gl.glFlush();
        }
        #endregion Display()

        #region Keyboard(byte key, int x, int y)
        private static void Keyboard(byte key, int x, int y) {
            switch(key) {
                case 27:
                    Environment.Exit(0);
                    break;
            }
        }
        #endregion Keyboard(byte key, int x, int y)

        #region Reshape(int w, int h)
        private static void Reshape(int w, int h) {
            Gl.glViewport(0, 0, w, h);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            if(w <= h) {
                Gl.glOrtho(-2.0, 2.0, -2.0 * (float) h / (float) w, 2.0 * (float) h / (float) w, 0.0, 10.0);
            }
            else {
                Gl.glOrtho(-2.0 * (float) w / (float) h, 2.0 * (float) w / (float) h, -2.0, 2.0, 0.0, 10.0);
            }
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity ();
        }
        #endregion Reshape(int w, int h)
    }
}
