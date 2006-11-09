#region License
/*
MIT License
Copyright ©2003-2004 Randy Ridge
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

#region Original Credits/License
/*
Copyright (c) 2002-2004 Marcus Geelnard

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would
   be appreciated but is not required.

2. Altered source versions must be plainly marked as such, and must not
   be misrepresented as being the original software.

3. This notice may not be removed or altered from any source
   distribution.

Marcus Geelnard
marcus.geelnard at home.se
*/

/*****************************************************************************
 * Title:   GLBoing
 * Desc:    Tribute to Amiga Boing.
 * Author:  Jim Brooks  <gfx@jimbrooks.org>
 *          Original Amiga authors were R.J. Mical and Dale Luck.
 *          GLFW conversion by Marcus Geelnard
 * Notes:   - 360' = 2*PI [radian]
 *
 *          - Distances between objects are created by doing a relative
 *            Z translations.
 *
 *          - Although OpenGL enticingly supports alpha-blending,
 *            the shadow of the original Boing didn't affect the color
 *            of the grid.
 *
 *          - [Marcus] Changed timing scheme from interval driven to frame-
 *            time based animation steps (which results in much smoother
 *            movement)
 *
 * History of Amiga Boing:
 *
 * Boing was demonstrated on the prototype Amiga (codenamed "Lorraine") in
 * 1985. According to legend, it was written ad-hoc in one night by
 * R. J. Mical and Dale Luck. Because the bouncing ball animation was so fast
 * and smooth, attendees did not believe the Amiga prototype was really doing
 * the rendering. Suspecting a trick, they began looking around the booth for
 * a hidden computer or VCR.
 *****************************************************************************/
#endregion Original Credits/License

using System;
using Tao.Glfw;
using Tao.OpenGl;

namespace GlfwExamples {
    #region Class Documentation
    /// <summary>
    ///     This is a small test application for GLFW.
    /// </summary>
    /// <remarks>
    ///     Tribute to Amiga's Boing.
    /// </remarks>
    #endregion Class Documentation
    public sealed class Boing {
        // --- Fields ---
        #region Private Constants
        private const float PI = 3.1415926535897932384626433832795f;
        private const int RAND_MAX = 4095;
        private const float RADIUS = 70;
        // 22.5 makes 8 bands like original Boing
        private const float STEP_LONGITUDE = 22.5f;
        private const float STEP_LATITUDE = 22.5f;
        private const float DISTANCE_BALL = RADIUS * 2 + RADIUS * 0.1f;
        // Distance from viewer to middle of buing area
        private const float VIEW_SCENE_DISTANCE = DISTANCE_BALL * 3 + 200;
        // Length (width) of grid
        private const float GRID_SIZE = (RADIUS * 4.5f);
        private const float BOUNCE_HEIGHT = (RADIUS * 2.1f);
        private const float BOUNCE_WIDTH = (RADIUS * 2.1f);
        // Maximum allowed delta time per physics iteration
        private const float MAX_DELTA_TIME = 0.02f;
        // Animation speed (50.0 mimics the original GLUT demo speed)
        private const float ANIMATION_SPEED = 50;
        private const float SHADOW_OFFSET_X = -20;
        private const float SHADOW_OFFSET_Y = 10;
        private const float SHADOW_OFFSET_Z = 0;
        private const float WALL_LEFT_OFFSET = 0;
        private const float WALL_RIGHT_OFFSET = 5f;
        #endregion Private Constants

        #region Private Enums
        #region DrawType
        /// <summary>
        ///     Draw type.
        /// </summary>
        private enum DrawType {
            /// <summary>
            ///     Draw ball.
            /// </summary>
            DrawBall,
            /// <summary>
            ///     Draw ball's shadow.
            /// </summary>
            DrawBallShadow
        }
        #endregion DrawType
        #endregion Private Enums

        #region Private Structs
        #region Vertex
        /// <summary>
        ///     Vertex structure.
        /// </summary>
        private struct Vertex {
            /// <summary>
            ///     X coordinate.
            /// </summary>
            public float X;
            /// <summary>
            ///     Y coordinate.
            /// </summary>
            public float Y;
            /// <summary>
            ///     Z coordinate.
            /// </summary>
            public float Z;
        }
        #endregion Vertex
        #endregion Private Structs

        #region Private Static Fields
        private static Random rand = new Random();
        private static double currentTime, oldTime, timeDifference;
        private static float yRotationDegree = 0;
        private static float yRotationDegreeIncrement = 2;
        private static float ballX = -RADIUS;
        private static float ballY = -RADIUS;
        private static float ballXIncrement = 1;
        private static float ballYIncrement = 2;
        private static DrawType drawType;
        private static bool isColor;
        #endregion Private Static Fields

        // --- Application Entry Point ---
        #region Run()
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Run() {
            bool isRunning = true;

            // Initialise GLFW
            Glfw.glfwInit();
            if(Glfw.glfwOpenWindow(400, 400, 0, 0, 0, 0, 16, 0, Glfw.GLFW_WINDOW) == Gl.GL_FALSE) {
                Glfw.glfwTerminate();
                return;
            }
            Glfw.glfwSetWindowTitle("Boing (classic Amiga demo)");
            Glfw.glfwSetWindowSizeCallback(new Glfw.GLFWwindowsizefun(Reshape));
            Glfw.glfwEnable(Glfw.GLFW_STICKY_KEYS);
            Glfw.glfwSwapInterval(1);
            // TODO: Glfw.glfwSetTime(0.0);

            Init();

            // Main loop
            while(isRunning) {
                // Timing
                currentTime = Glfw.glfwGetTime();
                timeDifference = currentTime - oldTime;
                oldTime = currentTime;

                // Draw one frame
                Display();

                // Swap buffers
                Glfw.glfwSwapBuffers();

                // Check if we are still running
                isRunning = ((Glfw.glfwGetKey(Glfw.GLFW_KEY_ESC) == Glfw.GLFW_RELEASE) &&
                    Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_TRUE);
            }

            // Close OpenGL window and terminate GLFW
            Glfw.glfwTerminate();
        }
        #endregion Run()

        // --- Private Static Methods ---
        #region BounceBall(double timeDifference)
        /// <summary>
        ///     Bounces the ball.
        /// </summary>
        /// <param name="timeDifference">
        ///     The time difference.
        /// </param>
        private static void BounceBall(double timeDifference) {
            float sign;
            float degree;

            // Bounce on walls
            if(ballX > (BOUNCE_WIDTH / 2 + WALL_RIGHT_OFFSET)) {
                ballXIncrement = -0.5f - 0.75f * (float) rand.NextDouble() / (float) RAND_MAX;
                yRotationDegreeIncrement = -yRotationDegreeIncrement;
            }

            if(ballX < -(BOUNCE_HEIGHT / 2 + WALL_LEFT_OFFSET)) {
                ballXIncrement = 0.5f + 0.75f * (float) rand.NextDouble() / (float) RAND_MAX;
                yRotationDegreeIncrement = -yRotationDegreeIncrement;
            }

            // Bounce on floor / ceiling
            if(ballY > BOUNCE_HEIGHT / 2) {
                ballYIncrement = -0.75f - 1.0f * (float) rand.NextDouble() / (float) RAND_MAX;
            }

            if(ballY < -BOUNCE_HEIGHT / 2 * 0.85f) {
                ballYIncrement = 0.75f + 1 * (float) rand.NextDouble() / (float) RAND_MAX;
            }

            // Update ball position
            ballX += (float) (ballXIncrement * (timeDifference * ANIMATION_SPEED));
            ballY += (float) (ballYIncrement * (timeDifference * ANIMATION_SPEED));

            // Simulate the effects of gravity on Y movement
            if(ballYIncrement < 0) {
                sign = -1;
            }
            else {
                sign = 1;
            }

            degree = (ballY + BOUNCE_HEIGHT / 2) * 90 / BOUNCE_HEIGHT;

            if(degree > 80) {
                degree = 80;
            }
            else if(degree < 10) {
                degree = 10;
            }

            ballYIncrement = sign * 4 * (float) SinDegree(degree);
        }
        #endregion BounceBall(double timeDifference)

        #region double CosDegree(double degree)
        /// <summary>
        ///     360' Cos().
        /// </summary>
        /// <param name="degree">
        ///     The degree.
        /// </param>
        /// <returns>
        ///     The Cos.
        /// </returns>
        private static double CosDegree(double degree) {
            return Math.Cos(DegreeToRadian(degree));
        }
        #endregion double CosDegree(double degree)

        #region CrossProduct(Vertex a, Vertex b, Vertex c, out Vertex normal)
        /// <summary>
        ///     Computes a cross product for a vector normal.
        /// </summary>
        /// <param name="a">
        ///     First vector.
        /// </param>
        /// <param name="b">
        ///     Second vector.
        /// </param>
        /// <param name="c">
        ///     Third vector.
        /// </param>
        /// <param name="normal">
        ///     The normalized vector.
        /// </param>
        private static void CrossProduct(Vertex a, Vertex b, Vertex c, out Vertex normal) {
            float u1, u2, u3;
            float v1, v2, v3;

            u1 = b.X - a.X;
            u2 = b.Y - a.Y;
            u3 = b.Y - a.Z;

            v1 = c.X - a.X;
            v2 = c.Y - a.Y;
            v3 = c.Z - a.Z;

            normal.X = u2 * v3 - v2 * v3;
            normal.Y = u3 * v1 - v3 * u1;
            normal.Z = u1 * v2 - v1 * u2;
        }
        #endregion CrossProduct(Vertex a, Vertex b, Vertex c, out Vertex normal)

        #region double DegreeToRadian(double degree)
        /// <summary>
        ///     Converts a degree to a radian.
        /// </summary>
        /// <param name="degree">
        ///     The degree.
        /// </param>
        /// <returns>
        ///     The radian.
        /// </returns>
        private static double DegreeToRadian(double degree) {
            return degree / 360 * (2 * PI);
        }
        #endregion double DegreeToRadian(double degree)

        #region Display()
        /// <summary>
        ///     Draws a frame.
        /// </summary>
        private static void Display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glPushMatrix();
                drawType = DrawType.DrawBallShadow;
                DrawBoingBall();
                DrawGrid();
                drawType = DrawType.DrawBall;
                DrawBoingBall();
            Gl.glPopMatrix();
            Gl.glFlush();
        }
        #endregion Display()

        #region DrawBoingBall()
        /// <summary>
        ///     Draws the Boing ball.
        /// </summary>
        /// <remarks>
        ///     The Boing ball is sphere in which each facet is a rectangle.  Facet colors
        ///     alternate between red and white.  The ball is built by stacking latitudinal
        ///     circles.  Each circle is composed of a widely-separated set of points, so
        ///     that each facet is noticably large.
        /// </remarks>
        private static void DrawBoingBall() {
            float degreeOfLongitude;
            double timeDifferenceTotal, timeDifferenceTemp;

            Gl.glPushMatrix();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);

                // Another relative Z translation to separate objects
                Gl.glTranslatef(0, 0, (float) DISTANCE_BALL);

                // Update ball position and rotation (iterate if necessary)
                timeDifferenceTotal = timeDifference;
                while(timeDifferenceTotal > 0.0) {
                    timeDifferenceTemp = timeDifferenceTotal > MAX_DELTA_TIME ? MAX_DELTA_TIME :
                        timeDifferenceTotal;
                    timeDifferenceTotal -= timeDifferenceTemp;
                    BounceBall(timeDifferenceTemp);
                    yRotationDegree = TruncateDegree((float) (yRotationDegree + yRotationDegreeIncrement *
                        (timeDifferenceTemp * ANIMATION_SPEED)));
                }

                // Set ball position
                Gl.glTranslatef(ballX, ballY, 0);

                // Offset the shadow
                if(drawType == DrawType.DrawBallShadow) {
                    Gl.glTranslatef(SHADOW_OFFSET_X, SHADOW_OFFSET_Y, SHADOW_OFFSET_Z);
                }

                // Tilt the ball
                Gl.glRotatef(-20, 0, 0, 1);

                // Continually rotate ball around Y axis
                Gl.glRotatef(yRotationDegree, 0, 1, 0);

                // Set OpenGL state for Boing ball
                Gl.glCullFace(Gl.GL_FRONT);
                Gl.glEnable(Gl.GL_CULL_FACE);
                Gl.glEnable(Gl.GL_NORMALIZE);

                // Build a faceted latitude slice of the Boing ball,  stepping same-sized vertical
                // bands of the sphere
                for(degreeOfLongitude = 0; degreeOfLongitude < 180;
                    degreeOfLongitude += STEP_LONGITUDE) {
                    // Draw a latitude circle at this longitude
                    DrawBoingBallBand(degreeOfLongitude, degreeOfLongitude + STEP_LONGITUDE);
                }
            Gl.glPopMatrix();
        }
        #endregion DrawBoingBall()

        #region DrawBoingBallBand(float low, float high)
        /// <summary>
        ///     Drawa a faceted latitude band of the Boing ball.
        /// </summary>
        /// <param name="low">
        ///     The low longitude of the slice.
        /// </param>
        /// <param name="high">
        ///     The high longitude of the slice.
        /// </param>
        private static void DrawBoingBallBand(float low, float high) {
            // "ne" means north-east, so on
            Vertex neVertex;
            Vertex nwVertex;
            Vertex seVertex;
            Vertex swVertex;
            Vertex normalVertex;
            float degreeLatitude;

            // Iterate thru the points of a latitude circle.  A latitude circle is a 2D set of
            // X, Z points
            for(degreeLatitude = 0; degreeLatitude <= (360 - STEP_LATITUDE);
                degreeLatitude += STEP_LATITUDE) {
            // Color this polygon with red or white
                if(isColor) {
                    Gl.glColor3f(0.8f, 0.1f, 0.1f);
                }
                else {
                    Gl.glColor3f(0.95f, 0.95f, 0.95f);
                }

                #if BOING_DEBUG
                if(degreeLatitude >= 180) {
                    if(isColor) {
                        Gl.glColor3f(0.1f, 0.8f, 0.1f);
                    }
                    else {
                        Gl.glColor3f(0.5f, 0.5f, 0.95f);
                    }
                }
                #endif

                isColor = !isColor;

                // Change color if drawing shadow
                if(drawType == DrawType.DrawBallShadow) {
                    Gl.glColor3f(0.35f, 0.35f, 0.35f);
                }

                // Assign each Y
                neVertex.Y = nwVertex.Y = (float) CosDegree(high) * RADIUS;
                swVertex.Y = seVertex.Y = (float) CosDegree(low) * RADIUS;

                // Assign each X, Z with Sin, Cos values scaled by latitude radius indexed by
                // longitude.  E.G. longitude = 0 and longitude = 180 are at the poles, so zero
                // scale is Sin(longitude), while longitude = 90 (Sin(90) = 1) is at equator
                neVertex.X = (float) CosDegree(degreeLatitude) * (float) (RADIUS * SinDegree(low + STEP_LONGITUDE));
                seVertex.X = (float) CosDegree(degreeLatitude) * (float) (RADIUS * SinDegree(low));
                nwVertex.X = (float) CosDegree(degreeLatitude + STEP_LATITUDE) * (float) (RADIUS * SinDegree(low + STEP_LONGITUDE));
                swVertex.X = (float) CosDegree(degreeLatitude + STEP_LATITUDE) * (float) (RADIUS * SinDegree(low));

                neVertex.Z = (float) SinDegree(degreeLatitude) * (float) (RADIUS * SinDegree(low + STEP_LONGITUDE));
                seVertex.Z = (float) SinDegree(degreeLatitude) * (float) (RADIUS * SinDegree(low));
                nwVertex.Z = (float) SinDegree(degreeLatitude + STEP_LATITUDE) * (float) (RADIUS * SinDegree(low + STEP_LONGITUDE));
                swVertex.Z = (float) SinDegree(degreeLatitude + STEP_LATITUDE) * (float) (RADIUS * SinDegree(low));

                //  Draw the facet
                Gl.glBegin(Gl.GL_POLYGON);
                    CrossProduct(neVertex, nwVertex, swVertex, out normalVertex);
                    Gl.glNormal3f(normalVertex.X, normalVertex.Y, normalVertex.Z);
                    Gl.glVertex3f(neVertex.X, neVertex.Y, neVertex.Z);
                    Gl.glVertex3f(nwVertex.X, nwVertex.Y, nwVertex.Z);
                    Gl.glVertex3f(swVertex.X, swVertex.Y, swVertex.Z);
                    Gl.glVertex3f(seVertex.X, seVertex.Y, seVertex.Z);
                Gl.glEnd();

                #if BOING_DEBUG
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("lat = {0}  low = {1}  high = {2}", degreeLatitude, low, high);
                Console.WriteLine( "vert_ne  x = %.8f  y = %.8f  z = %.8f \n", vert_ne.x, vert_ne.y, vert_ne.z );
                Console.WriteLine( "vert_nw  x = %.8f  y = %.8f  z = %.8f \n", vert_nw.x, vert_nw.y, vert_nw.z );
                Console.WriteLine( "vert_se  x = %.8f  y = %.8f  z = %.8f \n", vert_se.x, vert_se.y, vert_se.z );
                Console.WriteLine( "vert_sw  x = %.8f  y = %.8f  z = %.8f \n", vert_sw.x, vert_sw.y, vert_sw.z );
                #endif
            }

            // Toggle color so that next band will opposite red/white colors than this one
            isColor = !isColor;
        }
        #endregion DrawBoingBallBand(float low, float high)

        #region DrawGrid()
        /// <summary>
        ///     Draws the purple grid of lines behind the Boing ball.
        /// </summary>
        private static void DrawGrid() {
            int row, column;
            int rowTotal = 12;              // must be divisible by 2
            int columnTotal = rowTotal;     // must be same as rowTotal
            float widthLine = 2;            // should be divisible by 2
            float sizeCell = (float) GRID_SIZE / rowTotal;
            float z_offset = -40;
            float xl, xr;
            float yt, yb;

            Gl.glPushMatrix();
                Gl.glDisable(Gl.GL_CULL_FACE);

                // Another relative Z translation to separate objects
                Gl.glTranslatef(0, 0, DISTANCE_BALL);

                // Draw vertical lines (as skinny 3D rectangles)
                for(column = 0; column <= columnTotal; column++) {
                    // Compute coordinatess of line
                    xl = (float) -GRID_SIZE / 2 + column * sizeCell;
                    xr = xl + widthLine;

                    yt =  (float) GRID_SIZE / 2;
                    yb = (float) -GRID_SIZE / 2 - widthLine;

                    Gl.glBegin(Gl.GL_POLYGON);
                        Gl.glColor3f(0.6f, 0.1f, 0.6f);     // purple
                        Gl.glVertex3f(xr, yt, z_offset);    // NE
                        Gl.glVertex3f(xl, yt, z_offset);    // NW
                        Gl.glVertex3f(xl, yb, z_offset);    // SW
                        Gl.glVertex3f(xr, yb, z_offset);    // SE
                    Gl.glEnd();
                }

                // Draw horizontal lines (as skinny 3D rectangles)
                for(row = 0; row <= rowTotal; row++) {
                    // Compute coordinates of line
                    yt = (float) GRID_SIZE / 2 - row * sizeCell;
                    yb = yt - widthLine;

                    xl = (float) -GRID_SIZE / 2;
                    xr = (float) GRID_SIZE / 2 + widthLine;

                    Gl.glBegin(Gl.GL_POLYGON);
                        Gl.glColor3f(0.6f, 0.1f, 0.6f);     // purple
                        Gl.glVertex3f(xr, yt, z_offset);    // NE
                        Gl.glVertex3f(xl, yt, z_offset);    // NW
                        Gl.glVertex3f(xl, yb, z_offset);    // SW
                        Gl.glVertex3f(xr, yb, z_offset);    // SE
                    Gl.glEnd();
                }
            Gl.glPopMatrix();
        }
        #endregion DrawGrid()

        #region Init()
        /// <summary>
        ///     Initializes some GL settings.
        /// </summary>
        private static void Init() {
            // Clear background
            Gl.glClearColor(0.55f, 0.55f, 0.55f, 0.0f);
            // Flat shading
            Gl.glShadeModel(Gl.GL_FLAT);
        }
        #endregion Init()

        #region double PerspectiveAngle(double size, double distance)
        /// <summary>
        ///     Calculates the angle to be passed to <see cref="Glu.gluPerspective" /> so that
        ///     a scene is visible.
        /// </summary>
        /// <param name="size">
        ///     The size of the segment when the angle is intersected at
        ///     <paramref name="distance" />.
        /// </param>
        /// <param name="distance">
        ///     The distance from viewpoint to the scene.
        /// </param>
        /// <returns></returns>
        private static double PerspectiveAngle(double size, double distance) {
            double radianTheta = 2 * Math.Atan2(size / 2, distance);
            return (double) (180 * radianTheta) / PI;
        }
        #endregion double PerspectiveAngle(double size, double distance)

        #region double SinDegree(double degree)
        /// <summary>
        ///     360' Sin().
        /// </summary>
        /// <param name="degree">
        ///     The degree.
        /// </param>
        /// <returns>
        ///     The Sin.
        /// </returns>
        private static double SinDegree(double degree) {
            return Math.Sin(DegreeToRadian(degree));
        }
        #endregion double SinDegree(double degree)

        #region float TruncateDegree(float degree)
        /// <summary>
        ///     Truncates a degree.
        /// </summary>
        /// <param name="degree">
        ///     The degree to truncate.
        /// </param>
        /// <returns>
        ///     The truncated degree value.
        /// </returns>
        private static float TruncateDegree(float degree) {
            if(degree >= 360.0f) {
                return (degree - 360.0f);
            }
            else {
                return degree;
            }
        }
        #endregion float TruncateDegree(float degree)

        // --- Private GLFW Callback Methods ---
        #region Reshape(int width, int height)
        /// <summary>
        ///     Handles GLFW's window reshape callback.
        /// </summary>
        /// <param name="width">
        ///     New window width.
        /// </param>
        /// <param name="height">
        ///     New window height.
        /// </param>
        private static void Reshape(int width, int height) {
            Gl.glViewport(0, 0, width, height);

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            Glu.gluPerspective(PerspectiveAngle(RADIUS * 2, 200),
                (double) width / (double) height,
                1,
                VIEW_SCENE_DISTANCE);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            Glu.gluLookAt(0, 0, VIEW_SCENE_DISTANCE,    // eye
                0, 0, 0,                                // center of vision
                0, -1, 0);                              // up vector
        }
        #endregion Reshape(int width, int height)
    }
}
