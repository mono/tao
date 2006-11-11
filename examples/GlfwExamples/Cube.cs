#region License
/*
MIT License
Copyright ©2003-2006 Tao Framework Team
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
using System.Collections.Generic;
using System.Text;
using Tao.Glfw;
using Tao.OpenGl;

namespace GlfwExamples
{
    class Cube : IDisposable
    {
        #region Shaders

        string[] vertex_shader =
        {
            "void main() { ",
            "gl_FrontColor = gl_Color;",
            "gl_Position = ftransform();",
            "}"
        };
            
        string[] fragment_shader =
        {
            "void main() { gl_FragColor = gl_Color; }"
        };

        #endregion

        bool exit = false;
        int vs_object, fs_object, program;

        #region Constructor

        public Cube()
        {
            Glfw.glfwInit();
            Glfw.glfwOpenWindow(640, 480, 8, 8, 8, 8, 16, 0, Glfw.GLFW_WINDOW);
            Glfw.glfwSetWindowTitle(
                Gl.glGetString(Gl.GL_VENDOR) + " " +
                Gl.glGetString(Gl.GL_RENDERER) + " " +
                Gl.glGetString(Gl.GL_VERSION)
            );

            Gl.glClearColor(0.1f, 0.1f, 0.5f, 0.0f);
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            vs_object = Gl.glCreateShader(Gl.GL_VERTEX_SHADER);
            fs_object = Gl.glCreateShader(Gl.GL_FRAGMENT_SHADER);

            int[] status = new int[1];

            Gl.glShaderSource(vs_object, 1, vertex_shader, null);
            Gl.glCompileShader(vs_object);
            Gl.glGetShaderiv(vs_object, Gl.GL_COMPILE_STATUS, status);
            //if (status[0] != Gl.GL_TRUE)
            //    throw new Exception("Could not compile vertex shader");

            Gl.glShaderSource(fs_object, 1, fragment_shader, null);
            Gl.glCompileShader(fs_object);
            Gl.glGetShaderiv(fs_object, Gl.GL_COMPILE_STATUS, status);
            //if (status[0] != Gl.GL_TRUE)
            //    throw new Exception("Could not compile fragment shader");

            program = Gl.glCreateProgram();
            Gl.glAttachShader(program, fs_object);
            Gl.glAttachShader(program, vs_object);

            Gl.glLinkProgram(program);
            Gl.glUseProgram(program);

            Glfw.GLFWwindowsizefun ResizeCallback = new Glfw.GLFWwindowsizefun(Resize);
            Glfw.GLFWwindowclosefun CloseCallback = new Glfw.GLFWwindowclosefun(Close);
            Glfw.glfwSetWindowSizeCallback(ResizeCallback);
            Glfw.glfwSetWindowCloseCallback(CloseCallback);
        }

        #endregion

        #region Resize

        void Resize(int w, int h)
        {
            // Prevent a divide by zero, when window is too short
            // (you cant make a window of zero width).
            if (h == 0)
                h = 1;

            double ratio = 1.0 * w / h;

            // Reset the coordinate system before modifying
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();

            // Set the viewport to be the entire window
            Gl.glViewport(0, 0, w, h);

            // Set the correct perspective.
            Glu.gluPerspective(45.0, ratio, 1.0, 64.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        #endregion

        #region Close

        int Close()
        {
            exit = true;
            return 0;
        }

        #endregion

        #region Render

        public void Render()
        {
            Gl.glBegin(Gl.GL_QUADS);

            Gl.glColor3f(1, 0, 0);
            Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
            Gl.glVertex3f(-1.0f, 1.0f, -1.0f);
            Gl.glVertex3f(1.0f, 1.0f, -1.0f);
            Gl.glVertex3f(1.0f, -1.0f, -1.0f);

            Gl.glColor3f(1, 1, 0);
            Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
            Gl.glVertex3f(1.0f, -1.0f, -1.0f);
            Gl.glVertex3f(1.0f, -1.0f, 1.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 1.0f);

            Gl.glColor3f(1, 0, 1);
            Gl.glVertex3f(-1.0f, -1.0f, -1.0f);
            Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(-1.0f, 1.0f, -1.0f);

            Gl.glColor3f(0, 1, 0);
            Gl.glVertex3f(-1.0f, -1.0f, 1.0f);
            Gl.glVertex3f(1.0f, -1.0f, 1.0f);
            Gl.glVertex3f(1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 1.0f);

            Gl.glColor3f(0, 0, 1);
            Gl.glVertex3f(-1.0f, 1.0f, -1.0f);
            Gl.glVertex3f(-1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(1.0f, 1.0f, -1.0f);

            Gl.glColor3f(0, 1, 1);
            Gl.glVertex3f(1.0f, -1.0f, -1.0f);
            Gl.glVertex3f(1.0f, 1.0f, -1.0f);
            Gl.glVertex3f(1.0f, 1.0f, 1.0f);
            Gl.glVertex3f(1.0f, -1.0f, 1.0f);

            Gl.glEnd();
        }

        #endregion

        public void MainLoop()
        {
            float angle = 0.0f;

            while (!exit)
            {
                Glfw.glfwPollEvents();

                if (Glfw.glfwGetKey(Glfw.GLFW_KEY_ESC) == Glfw.GLFW_KEY_DOWN)
                    exit = true;

                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
                
                Gl.glLoadIdentity();
                Glu.gluLookAt(0.0f, 5.0f, 5.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f);
                Gl.glRotatef(angle, 0.0f, 1.0f, 0.0f);
                angle += 0.01f;
                
                Render();
                                
                Glfw.glfwSwapBuffers();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Glfw.glfwCloseWindow();
            Glfw.glfwTerminate();
        }

        #endregion
    }
}
