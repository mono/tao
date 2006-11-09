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
    ///     Keyboard input test.
    /// </remarks>
    #endregion Class Documentation
    public sealed class KeyTest {
        // --- Fields ---
        #region Private Static Fields
        private static bool isRunning = true;
        private static bool isKeyRepeat = false;
        private static bool isSystemKeys = true;
        #endregion Private Static Fields

        // --- Application Entry Point ---
        #region Run()
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Run() {
            int windowWidth, windowHeight;
            double currentTime;

            // Initialise GLFW
            Glfw.glfwInit();

            // Open OpenGL window
            if(Glfw.glfwOpenWindow(250, 100, 0, 0, 0, 0, 0, 0, Glfw.GLFW_WINDOW) == Gl.GL_FALSE) {
                Glfw.glfwTerminate();
                return;
            }

            // Set key callback function
            Glfw.glfwSetKeyCallback(new Glfw.GLFWkeyfun(Key));

            // Set title
            Glfw.glfwSetWindowTitle("Press some keys!");

            // Main loop
            while(isRunning) {
                // Get time
                currentTime = Glfw.glfwGetTime();

                // Get window size (may be different than the requested size)
                Glfw.glfwGetWindowSize(out windowWidth, out windowHeight);
                windowHeight = windowHeight > 0 ? windowHeight : 1;

                // Set viewport
                Gl.glViewport(0, 0, windowWidth, windowHeight);

                // Clear color buffer
                Gl.glClearColor((float) (0.5f + 0.5f * (float) Math.Sin(3.0 * currentTime)),
                    0, 0, 0);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

                // Swap buffers
                Glfw.glfwSwapBuffers();

                // Check if the window was closed
                if(Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_FALSE) {
                    isRunning = false;
                }
            }

            // Close OpenGL window and terminate GLFW
            Glfw.glfwTerminate();
        }
        #endregion Run()

        // --- Private GLFW Callback Methods ---
        #region Key(int key, int action)
        /// <summary>
        ///     Handles GLFW key callback.
        /// </summary>
        /// <param name="key">
        ///     The key.
        /// </param>
        /// <param name="action">
        ///     The key action.
        /// </param>
        private static void Key(int key, int action) {
            if(action != Glfw.GLFW_PRESS) {
                return;
            }

            switch(key) {
                case Glfw.GLFW_KEY_ESC:
                    Console.WriteLine("ESC => quit program");
                    isRunning = false;
                    break;
                case Glfw.GLFW_KEY_F1:
                case Glfw.GLFW_KEY_F2:
                case Glfw.GLFW_KEY_F3:
                case Glfw.GLFW_KEY_F4:
                case Glfw.GLFW_KEY_F5:
                case Glfw.GLFW_KEY_F6:
                case Glfw.GLFW_KEY_F7:
                case Glfw.GLFW_KEY_F8:
                case Glfw.GLFW_KEY_F9:
                case Glfw.GLFW_KEY_F10:
                case Glfw.GLFW_KEY_F11:
                case Glfw.GLFW_KEY_F12:
                case Glfw.GLFW_KEY_F13:
                case Glfw.GLFW_KEY_F14:
                case Glfw.GLFW_KEY_F15:
                case Glfw.GLFW_KEY_F16:
                case Glfw.GLFW_KEY_F17:
                case Glfw.GLFW_KEY_F18:
                case Glfw.GLFW_KEY_F19:
                case Glfw.GLFW_KEY_F20:
                case Glfw.GLFW_KEY_F21:
                case Glfw.GLFW_KEY_F22:
                case Glfw.GLFW_KEY_F23:
                case Glfw.GLFW_KEY_F24:
                case Glfw.GLFW_KEY_F25:
                    Console.WriteLine("F{0}", 1 + key - Glfw.GLFW_KEY_F1);
                    break;
                case Glfw.GLFW_KEY_UP:
                    Console.WriteLine("UP");
                    break;
                case Glfw.GLFW_KEY_DOWN:
                    Console.WriteLine("DOWN");
                    break;
                case Glfw.GLFW_KEY_LEFT:
                    Console.WriteLine("LEFT");
                    break;
                case Glfw.GLFW_KEY_RIGHT:
                    Console.WriteLine("RIGHT");
                    break;
                case Glfw.GLFW_KEY_LSHIFT:
                    Console.WriteLine("LSHIFT");
                    break;
                case Glfw.GLFW_KEY_RSHIFT:
                    Console.WriteLine("RSHIFT");
                    break;
                case Glfw.GLFW_KEY_LCTRL:
                    Console.WriteLine("LCTRL");
                    break;
                case Glfw.GLFW_KEY_RCTRL:
                    Console.WriteLine("RCTRL");
                    break;
                case Glfw.GLFW_KEY_LALT:
                    Console.WriteLine("LALT");
                    break;
                case Glfw.GLFW_KEY_RALT:
                    Console.WriteLine("RALT");
                    break;
                case Glfw.GLFW_KEY_TAB:
                    Console.WriteLine("TAB");
                    break;
                case Glfw.GLFW_KEY_ENTER:
                    Console.WriteLine("ENTER");
                    break;
                case Glfw.GLFW_KEY_BACKSPACE:
                    Console.WriteLine("BACKSPACE");
                    break;
                case Glfw.GLFW_KEY_INSERT:
                    Console.WriteLine("INSERT");
                    break;
                case Glfw.GLFW_KEY_DEL:
                    Console.WriteLine("DEL");
                    break;
                case Glfw.GLFW_KEY_PAGEUP:
                    Console.WriteLine("PAGEUP");
                    break;
                case Glfw.GLFW_KEY_PAGEDOWN:
                    Console.WriteLine("PAGEDOWN");
                    break;
                case Glfw.GLFW_KEY_HOME:
                    Console.WriteLine("HOME");
                    break;
                case Glfw.GLFW_KEY_END:
                    Console.WriteLine("END");
                    break;
                case Glfw.GLFW_KEY_KP_0:
                    Console.WriteLine("KEYPAD 0");
                    break;
                case Glfw.GLFW_KEY_KP_1:
                    Console.WriteLine("KEYPAD 1");
                    break;
                case Glfw.GLFW_KEY_KP_2:
                    Console.WriteLine("KEYPAD 2");
                    break;
                case Glfw.GLFW_KEY_KP_3:
                    Console.WriteLine("KEYPAD 3");
                    break;
                case Glfw.GLFW_KEY_KP_4:
                    Console.WriteLine("KEYPAD 4");
                    break;
                case Glfw.GLFW_KEY_KP_5:
                    Console.WriteLine("KEYPAD 5");
                    break;
                case Glfw.GLFW_KEY_KP_6:
                    Console.WriteLine("KEYPAD 6");
                    break;
                case Glfw.GLFW_KEY_KP_7:
                    Console.WriteLine("KEYPAD 7");
                    break;
                case Glfw.GLFW_KEY_KP_8:
                    Console.WriteLine("KEYPAD 8");
                    break;
                case Glfw.GLFW_KEY_KP_9:
                    Console.WriteLine("KEYPAD 9");
                    break;
                case Glfw.GLFW_KEY_KP_DIVIDE:
                    Console.WriteLine("KEYPAD DIVIDE");
                    break;
                case Glfw.GLFW_KEY_KP_MULTIPLY:
                    Console.WriteLine("KEYPAD MULTIPLY");
                    break;
                case Glfw.GLFW_KEY_KP_SUBTRACT:
                    Console.WriteLine("KEYPAD SUBTRACT");
                    break;
                case Glfw.GLFW_KEY_KP_ADD:
                    Console.WriteLine("KEYPAD ADD");
                    break;
                case Glfw.GLFW_KEY_KP_DECIMAL:
                    Console.WriteLine("KEYPAD DECIMAL");
                    break;
                case Glfw.GLFW_KEY_KP_EQUAL:
                    Console.WriteLine("KEYPAD =");
                    break;
                case Glfw.GLFW_KEY_KP_ENTER:
                    Console.WriteLine("KEYPAD ENTER");
                    break;
                case Glfw.GLFW_KEY_SPACE:
                    Console.WriteLine("SPACE");
                    break;
                case (int) 'R':
                    isKeyRepeat = !isKeyRepeat;
                    if(isKeyRepeat) {
                        Glfw.glfwEnable(Glfw.GLFW_KEY_REPEAT);
                    }
                    else {
                        Glfw.glfwDisable(Glfw.GLFW_KEY_REPEAT);
                    }
                    Console.WriteLine("R => Key repeat: {0}", isKeyRepeat ? "ON" : "OFF");
                    break;
                case (int) 'S':
                    isSystemKeys = !isSystemKeys;
                    if(isSystemKeys) {
                        Glfw.glfwEnable(Glfw.GLFW_SYSTEM_KEYS);
                    }
                    else {
                        Glfw.glfwDisable(Glfw.GLFW_SYSTEM_KEYS);
                    }
                    Console.WriteLine("S => System keys: {0}", isSystemKeys ? "ON" : "OFF");
                    break;
                default:
                    if(key > 0 && key < 256) {
                        Console.WriteLine("{0}", (char) key);
                    }
                    else {
                        Console.WriteLine("???");
                    }
                    break;
            }
        }
        #endregion Key(int key, int action)
    }
}
