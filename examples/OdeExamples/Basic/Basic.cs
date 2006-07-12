#region License
/*
MIT License
Copyright �2003-2006 Tao Framework Team
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
/*
 *  This code is roughly a port of:
 *  http://pyode.sourceforge.net/tutorials/tutorial1.html
 *  by Matthias Baas
*/
#endregion Original Credits / License

using System;
using Tao.Ode;

namespace OdeExamples {
    #region Class Documentation
    /// <summary>
    ///     Basic: A basic ODE example.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This tutorial shows you the very basics of ODE: creating a world including
    ///         a rigid body and doing a simulation loop. The example program does without
    ///         any fancy graphics output, but just displays the bare numbers. Adding eye
    ///         catchy 3D graphics is left as an exercise for the reader.
    ///     </para>
    ///     <para>
    ///         Original Author:    Matthias Baas
    ///         http://pyode.sourceforge.net/tutorials/tutorial1.html
    ///     </para>
    ///     <para>
    ///         C# Implementation:  Randy Ridge
    ///         http://www.taoframework.com
    ///     </para>
    /// </remarks>
    #endregion Class Documentation
    public sealed class Basic {
        #region Main()
        /// <summary>
        ///     Application's entry point.
        /// </summary>
        public static void Main() {
            // Create a world
            IntPtr world = Ode.dWorldCreate();

            // Add gravity to the world (pull down on the Y axis 9.81 meters/second
            Ode.dWorldSetGravity(world, 0, -9.81f, 0);

            // Create a rigid body (in the world)
            IntPtr body = Ode.dBodyCreate(world);

            // Create some mass, we're creating a sphere with a radius of 0.05 centimeters
            // and a constant density of 2500 (about that of glass)
            Ode.dMass mass = new Ode.dMass();
            Ode.dMassSetSphere(ref mass, 2500, 0.05f);

            // If you printed the values of mass now, you'd see the mass would be about 1.3 kilograms
            // We'll change that to 1 kilogram here
            mass.mass = 1;
            // If you printed the values of mass now, you'd notice that the inertia tensions values
            // were also updated

            // We'll set the body's mass to the mass we just created
            Ode.dBodySetMass(body, ref mass);

            // Set the body's position (in the world) to 2 meters above the 'ground'
            Ode.dBodySetPosition(body, 0, 2, 0);

            // Apply a force to the body, we're sending it vertical, up the Y axis
            // This force is only applied for the first step, forces will be reset to zero
            // at the end of each step
            Ode.dBodyAddForce(body, 0, 200, 0);

            // The simulation loop's 'time', in seconds
            float time = 0;

            // The 'time' increment, in seconds
            float deltaTime = 0.04f;

            // Run the simulation loop for 2 seconds
            while(time < 2) {
                // Get the body's current position
                Ode.dVector3 position = Ode.dBodyGetPosition(body);

                // Get the body's current linear velocity
				Ode.dVector3 velocity = Ode.dBodyGetLinearVel(body);
				
                // Print out the 'time', the body's position, and its velocity
                Console.WriteLine("{0:0.00} sec: pos=({1:0.00}, {2:0.00}, {3:0.00})  vel={4:0.00}, {5:0.00}, {6:0.00})",
                    time, position[0], position[1], position[2], velocity[0], velocity[1], velocity[2]);

                // Move the bodies in the world
                Ode.dWorldStep(world, deltaTime);

                // Increment the time
                time += deltaTime;
            }

            Console.WriteLine();
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        #endregion Main()
    }
}
