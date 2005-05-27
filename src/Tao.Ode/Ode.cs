/* -*- Mode: csharp; tab-width: 50; indent-tabs-mode: nil; c-basic-offset:4 -*- */
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

using System;
using System.Runtime.InteropServices;
using System.Security;

using real = System.Single;

namespace Tao.Ode {
    #region Class Documentation
    /// <summary>
    ///     ODE (Open Dynamics Engine) binding for .NET.
    /// </summary>
    #endregion Class Documentation
    public sealed class Ode {
        // --- Fields ---
        #region Private Constants
        #region CallingConvention CALLING_CONVENTION
        /// <summary>
        ///     Specifies the calling convention.
        /// </summary>
        /// <remarks>
        ///     Specifies <see cref="CallingConvention.Winapi" />.
        /// </remarks>
        private const CallingConvention CALLING_CONVENTION = CallingConvention.Winapi;
        #endregion CallingConvention CALLING_CONVENTION
        #endregion Private Constants

        #region Public Constants
        #endregion Public Constants

        // --- Constructors & Destructors ---
        #region Ode()
        /// <summary>
        ///     Prevents instantiation.
        /// </summary>
        private Ode() {
        }
        #endregion Ode()



/*
typedef dReal dVector3[4];
typedef dReal dVector4[4];
typedef dReal dMatrix3[4*3];
typedef dReal dMatrix4[4*4];
typedef dReal dMatrix6[8*6];
typedef dReal dQuaternion[4];
*/


        // --- Public Structs ---
        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct dMass {
            /// <summary>
            /// 
            /// </summary>
            public real mass;
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public real[] c;
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
            public real[] I;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct dContactGeom {
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public real[] pos;
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public real[] normal;
            /// <summary>
            /// 
            /// </summary>
            public real depth;
            /// <summary>
            /// 
            /// </summary>
            public IntPtr g1,g2;
        }
        
        /// <summary>
        /// 
        /// </summary>
        [FlagsAttribute]
        public enum dContactFlags : int {
            /// <summary>
            /// 
            /// </summary>
            dContactMu2 = 0x001,
            /// <summary>
            /// 
            /// </summary>
            dContactFDir1       = 0x002,
            /// <summary>
            /// 
            /// </summary>
            dContactBounce      = 0x004,
            /// <summary>
            /// 
            /// </summary>
            dContactSoftERP     = 0x008,
            /// <summary>
            /// 
            /// </summary>
            dContactSoftCFM     = 0x010,
            /// <summary>
            /// 
            /// </summary>
            dContactMotion1     = 0x020,
            /// <summary>
            /// 
            /// </summary>
            dContactMotion2     = 0x040,
            /// <summary>
            /// 
            /// </summary>
            dContactSlip1       = 0x080,
            /// <summary>
            /// 
            /// </summary>
            dContactSlip2       = 0x100,
            
            /// <summary>
            /// 
            /// </summary>
            dContactApprox0     = 0x0000,
            /// <summary>
            /// 
            /// </summary>
            dContactApprox1_1   = 0x1000,
            /// <summary>
            /// 
            /// </summary>
            dContactApprox1_2   = 0x2000,
            /// <summary>
            /// 
            /// </summary>
            dContactApprox1     = 0x3000
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct dSurfaceParameters {
            /// <summary>
            /// 
            /// </summary>
            public dContactFlags mode;
            /// <summary>
            /// 
            /// </summary>
            public real mu;
            /// <summary>
            /// 
            /// </summary>
            public real mu2;
            /// <summary>
            /// 
            /// </summary>
            public real bounce;
            /// <summary>
            /// 
            /// </summary>
            public real bounce_vel;
            /// <summary>
            /// 
            /// </summary>
            public real soft_erp;
            /// <summary>
            /// 
            /// </summary>
            public real soft_cfm;
            /// <summary>
            /// 
            /// </summary>
            public real motion1, motion2;
            /// <summary>
            /// 
            /// </summary>
            public real slip1, slip2;
        }

        /// <summary>
        /// 
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct dContact {
            /// <summary>
            /// 
            /// </summary>
            public dSurfaceParameters surface;
            /// <summary>
            /// 
            /// </summary>
            public dContactGeom geom;
            /// <summary>
            /// 
            /// </summary>
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=4)]
            public real[] fdir1;
        }

        // --- Public Externs ---
        // dWorldID dWorldCreate();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dWorldCreate();

        // dWorldID dWorldDestroy();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dWorldDestroy(IntPtr world);

        // dSpaceID dHashSpaceCreate(dSpaceID space);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dHashSpaceCreate(IntPtr space);

        // dJointGroupID dJointGroupCreate(int max_size);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="max_size"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dJointGroupCreate(int max_size);

        // void dWorldSetGravity(dWorldID, dReal x, dReal y, dReal z);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dWorldSetGravity(IntPtr world, real x, real y, real z);

        // dGeomID dCreatePlane(dSpaceID space, dReal a, dReal b, dReal c, dReal d);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dCreatePlane(IntPtr space, real a, real b, real c, real d);

        // dSpaceID dSimpleSpaceCreate(dSpaceID space);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dSimpleSpaceCreate(IntPtr space);

        // void dSpaceAdd(dSpaceID, dGeomID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="geom"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dSpaceAdd(IntPtr space, IntPtr geom);

        // dBodyID dBodyCreate(dWorldID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dBodyCreate(IntPtr world);

        // void dMassSetSphere(dMass *, dReal density, dReal radius);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="density"></param>
        /// <param name="radius"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dMassSetSphere(ref dMass mass, real density, real radius);

        // void dBodySetMass(dBodyID, const dMass *mass);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="mass"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dBodySetMass(IntPtr body, ref dMass mass);

        // void dBodySetPosition(dBodyID, dReal x, dReal y, dReal z);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dBodySetPosition(IntPtr body, real x, real y, real z);

        // void dBodyAddForce(dBodyID, dReal fx, dReal fy, dReal fz);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="fz"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dBodyAddForce(IntPtr body, real fx, real fy, real fz);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <param name="fx"></param>
        /// <param name="fy"></param>
        /// <param name="fz"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dBodyAddTorque(IntPtr body, real fx, real fy, real fz);

        // const dReal * dBodyGetPosition(dBodyID);
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="dBodyGetPosition"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr __dBodyGetPosition(IntPtr body);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static real[] dBodyGetPosition(IntPtr body) {
            real[] positionArray = new real[3];

            unsafe {
                IntPtr position = __dBodyGetPosition(body);
                real* positionPointer = (real*) position.ToPointer();

                for(int i = 0; i < positionArray.Length; i++) {
                    positionArray[i] = positionPointer[i];
                }
            }

            return positionArray;
        }

        // const dReal * dBodyGetLinearVel(dBodyID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="dBodyGetLinearVel"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr __dBodyGetLinearVel(IntPtr body);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static real[] dBodyGetLinearVel(IntPtr body) {
            real[] velocityArray = new real[3];

            unsafe {
                IntPtr velocity = __dBodyGetLinearVel(body);
                real* velocityPointer = (real*) velocity.ToPointer();

                for(int i = 0; i < velocityArray.Length; i++) {
                    velocityArray[i] = velocityPointer[i];
                }
            }

            return velocityArray;
        }

        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="dBodyGetAngularVel"), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr __dBodyGetAngularVel(IntPtr body);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static real[] dBodyGetAngularVel(IntPtr body) {
            real[] velocityArray = new real[3];

            unsafe {
                IntPtr velocity = __dBodyGetAngularVel(body);
                real* velocityPointer = (real*) velocity.ToPointer();

                for(int i = 0; i < velocityArray.Length; i++) {
                    velocityArray[i] = velocityPointer[i];
                }
            }

            return velocityArray;
        }

        // void dWorldStep (dWorldID, dReal stepsize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="stepsize"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dWorldStep(IntPtr world, real stepsize);

        // void dWorldSetQuickStepNumIterations (dWorldID, dReal stepsize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="num"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dWorldSetQuickStepNumIterations(IntPtr world, int num);

        // void dWorldQuickStep (dWorldID, dReal stepsize);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="stepsize"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dWorldQuickStep(IntPtr world, real stepsize);

        // void dWorldSetCFM (dWorldID, dReal cfm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="crm"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dWorldSetCFM(IntPtr world, real crm);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dCreateSphere(IntPtr space, real radius);

        // dGeomID dCreateBox (dSpaceID space, dReal lx, dReal ly, dReal lz);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="space"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dCreateBox(IntPtr space, real x, real y, real z);


        // void dGeomSetBody (dGeomID, dBodyID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="geom"></param>
        /// <param name="body"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dGeomSetBody(IntPtr geom, IntPtr body);

        // void dJointGroupEmpty (dJointGroupID);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jointGroup"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dJointGroupEmpty(IntPtr jointGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jointGroup"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dJointGroupDestroy(IntPtr jointGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="jointGroup"></param>
        /// <param name="contact"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dJointCreateContact(IntPtr world, IntPtr jointGroup, ref dContact contact);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joint"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dJointDestroy(IntPtr joint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joint"></param>
        /// <param name="body1"></param>
        /// <param name="body2"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dJointAttach(IntPtr joint, IntPtr body1, IntPtr body2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joint"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dJointGetBody(IntPtr joint, int index);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="jointGroup"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern IntPtr dJointCreateFixed(IntPtr world, IntPtr jointGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="joint"></param>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
        public static extern void dJointSetFixed(IntPtr joint);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o1"></param>
        /// <param name="o2"></param>
        /// <param name="flags"></param>
        /// <param name="contactGeoms"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [DllImport("ode.dll", CallingConvention=CALLING_CONVENTION, EntryPoint="dCollide"), SuppressUnmanagedCodeSecurity]
        public static extern int dCollide(IntPtr o1, IntPtr o2, int flags, [In,Out] dContactGeom[] contactGeoms, int skip);
    }
}
