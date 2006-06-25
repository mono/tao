#region License
/*
 MIT License
 Copyright 2003-2005 Tao Framework Team
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

namespace Tao.Ode 
{
	#region Aliases
	// TODO: Make dReal precision controllable at compile time - the ode lib can be compiled with either single or double precision
	using dReal=System.Single;
	using dWorldID=System.IntPtr;
	using dBodyID=System.IntPtr;
	using dJointID=System.IntPtr;
	using dJointGroupID=System.IntPtr;
	using dGeomID=System.IntPtr;
	using dSpaceID=System.IntPtr;
	using dTriMeshDataID=System.IntPtr;
	
	#endregion Aliases
	
	#region Class Documentation
	/// <summary>
	///     Open Dynamics Engine (ODE - http://ode.org) bindings for .NET
	/// 	ODE Version: 0.6
	/// </summary>
	#endregion Class Documentation
	public sealed class Ode 
	{
		#region Private Constants
		#region string ODE_NATIVE_LIBRARY
		/// <summary>
		/// Specifies the ODE native library used in the bindings
		/// </summary>
		/// <remarks>
		/// The Windows dll is specified here universally - note that
		/// under Mono the non-windows native library can be mapped using
		/// the ".config" file mechanism.  Kudos to the Mono team for this
		/// simple yet elegant solution.
		/// </remarks>
		private const string ODE_NATIVE_LIBRARY="ode.dll";
		#endregion string ODE_NATIVE_LIBRARY
		
		#region CallingConvention CALLING_CONVENTION
		/// <summary>
		///     Specifies the calling convention used for the binding.
		/// </summary>
		/// <remarks>
		///     Specifies <see cref="CallingConvention.Cdecl" />
		///     for the bindings.
		/// </remarks>
		private const CallingConvention CALLING_CONVENTION = CallingConvention.Cdecl;
		#endregion CallingConvention CALLING_CONVENTION
		#endregion Private Constants
		
		#region Public Constants
		#region Error Numbers
		/// <summary>
		/// 
		/// </summary>
		public enum dError : int 
		{
			/// <summary>
			/// 
			/// </summary>
			d_ERR_UNKNOWN = 0,		/* unknown error */
			/// <summary>
			/// 
			/// </summary>
			d_ERR_IASSERT=1,		/* internal assertion failed */
			/// <summary>
			/// 
			/// </summary>
			d_ERR_UASSERT=2,		/* user assertion failed */
			/// <summary>
			/// 
			/// </summary>
			d_ERR_LCP=3				/* user assertion failed */
		};
		#endregion Error Numbers
		
		/// <summary>
		/// Infinity.
		/// 
		/// The maximum value of the current data type for dReal.
		/// 
		/// </summary>
		/// <remarks>
		/// dReal can be System.Single or System.Double, based on the
		/// multiple precision levels possible with the ODE library.
		/// </remarks>
		public const dReal dInfinity=dReal.MaxValue;
		
		#region Joint Type Numbers
		/// <summary>
		/// 
		/// </summary>
		public enum dJointTypes : int 
		{
			/// <summary>
			/// 
			/// </summary>
			dJointTypeNone = 0,		/* or "unknown" */
			/// <summary>
			/// 
			/// </summary>
			dJointTypeBall=1,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeHinge=2,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeSlider=3,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeContact=4,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeUniversal=5,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeHinge2=6,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeFixed=7,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeNull=8,
			/// <summary>
			/// 
			/// </summary>
			dJointTypeAMotor=9
		}
		#endregion Joint Type Numbers
		
		#region Joint Parameter Names
		/// <summary>
		/// Definition of Joint limit and motor parameter names
		/// If a particular parameter is not implemented by a given joint, setting it will have no effect.
		/// 
		/// These parameter names can be optionally followed by a digit (2 or 3) to indicate the second or third set of parameters, e.g. for the second axis in a hinge-2 joint, or the third axis in an AMotor joint. A constant dParamGroup is also defined such that: dParamXi = dParamX + dParamGroup * (i-1)
		/// </summary>
		/// <remarks>
		/// Implemented via a macro in Ode's common.h
		/// Translated into actual constants here following inspection of common.h
		/// A change in the Ode macro could require these values to be updated
		/// </remarks>
		public enum dJointParams : int
		{

			#region Parameters for first axis
			/// <summary>
			/// Low stop angle or position. Setting this to -dInfinity (the default value) turns off the low stop. For rotational joints, this stop must be greater than - pi to be effective.
			/// </summary>
			dParamLoStop = 0,
			
			/// <summary>
			/// High stop angle or position. Setting this to dInfinity (the default value) turns off the high stop. For rotational joints, this stop must be less than pi to be effective. If the high stop is less than the low stop then both stops will be ineffective.
			/// </summary>
			dParamHiStop = 1,
			
			/// <summary>
			/// Desired motor velocity (this will be an angular or linear velocity).
			/// </summary>
			dParamVel = 2,
			
			/// <summary>
			/// The maximum force or torque that the motor will use to achieve the desired velocity. This must always be greater than or equal to zero. Setting this to zero (the default value) turns off the motor.
			/// </summary>
			dParamFMax = 3,
			
			/// <summary>
			/// The current joint stop/motor implementation has a small problem: when the joint is at one stop and the motor is set to move it away from the stop, too much force may be applied for one time step, causing a ``jumping'' motion. This fudge factor is used to scale this excess force. It should have a value between zero and one (the default value). If the jumping motion is too visible in a joint, the value can be reduced. Making this value too small can prevent the motor from being able to move the joint away from a stop.
			/// </summary>
			dParamFudgeFactor = 4,
			
			/// <summary>
			/// The bouncyness of the stops. This is a restitution parameter in the range 0..1. 0 means the stops are not bouncy at all, 1 means maximum bouncyness.
			/// </summary>
			dParamBounce = 5,
			
			/// <summary>
			/// The constraint force mixing (CFM) value used when not at a stop.
			/// </summary>
			dParamCFM = 6,
			
			/// <summary>
			/// The error reduction parameter (ERP) used by the stops.
			/// </summary>
			dParamStopERP = 7,
			
			/// <summary>
			/// The constraint force mixing (CFM) value used by the stops. Together with the ERP value this can be used to get spongy or soft stops. Note that this is intended for unpowered joints, it does not really work as expected when a powered joint reaches its limit.
			/// </summary>
			dParamStopCFM = 8,

			/// <summary>
			/// Suspension error reduction parameter (ERP). Currently this is only implemented on the hinge-2 joint.
			/// </summary>
			dParamSuspensionERP = 9,
			
			/// <summary>
			/// Suspension constraint force mixing (CFM) value. Currently this is only implemented on the hinge-2 joint.
			/// </summary>
			dParamSuspensionCFM = 10,
			#endregion Parameters for first axis
			
			#region Parameters for second axis
			dParamLoStop2 = 0x100 + 0,
			dParamHiStop2 = 0x100 + 1,
			dParamVel2 = 0x100 + 2,
			dParamFMax2 = 0x100 + 3,
			dParamFudgeFactor2 = 0x100 + 4,
			dParamBounce2 = 0x100 + 5,
			dParamCFM2 = 0x100 + 6,
			dParamStopERP2 = 0x100 + 7,
			dParamStopCFM2 = 0x100 + 8,
			dParamSuspensionERP2 = 0x100 + 9,
			dParamSuspensionCFM2 = 0x100 + 10,
			#endregion Parameters for second axis
			
			#region Parameters for third axis
			dParamLoStop3 = 0x200 + 0,
			dParamHiStop3 = 0x200 + 1,
			dParamVel3 = 0x200 + 2,
			dParamFMax3 = 0x200 + 3,
			dParamFudgeFactor3 = 0x200 + 4,
			dParamBounce3 = 0x200 + 5,
			dParamCFM3 = 0x200 + 6,
			dParamStopERP3 = 0x200 + 7,
			dParamStopCFM3 = 0x200 + 8,
			dParamSuspensionERP3 = 0x200 + 9,
			dParamSuspensionCFM3 = 0x200 + 10,
			#endregion Parameters for third axis
		}
		#endregion Joint Parameter Names
		
		#region Angular Motor Mode Numbers
		/// <summary>
		/// 
		/// </summary>
		public enum dAMotorMode : int 
		{
			/// <summary>
			/// 
			/// </summary>
			dAMotorUser = 0,
			/// <summary>
			/// 
			/// </summary>
			dAMotorEuler = 1
		}
		#endregion Angular Motor Mode Numbers
		
		#region Class Numbers
		/// <summary>the maximum number of user classes that are supported</summary>
		public const int dMaxUserClasses = 4;
		
		/// <summary>
		/// class numbers - each geometry object needs a unique number 
		/// </summary>
		public enum dClassNumbers : int 
		{
			/// <summary>
			/// 
			/// </summary>
			dSphereClass = 0,
			/// <summary>
			/// 
			/// </summary>
			dBoxClass = 1,
			/// <summary>
			/// 
			/// </summary>
			dCapsuleClass = 2,
			/// <summary>
			/// 
			/// </summary>
			dCylinderClass = 3,
			/// <summary>
			/// 
			/// </summary>
			dPlaneClass = 4,
			/// <summary>
			/// 
			/// </summary>
			dRayClass = 5,
			/// <summary>
			/// 
			/// </summary>
			dGeomTransformClass = 6,
			/// <summary>
			/// 
			/// </summary>
			dTriMeshClass = 7,
			/// <summary>
			/// 
			/// </summary>
			dFirstSpaceClass = 8,
			/// <summary>
			/// 
			/// </summary>
			dSimpleSpaceClass = dFirstSpaceClass,
			/// <summary>
			/// 
			/// </summary>
			dHashSpaceClass = 9,
			/// <summary>
			/// 
			/// </summary>
			dQuadTreeSpaceClass = 10,
			/// <summary>
			/// 
			/// </summary>
			dLastSpaceClass = dQuadTreeSpaceClass,
			/// <summary>
			/// 
			/// </summary>
			dFirstUserClass = 11,
			/// <summary>
			/// 
			/// </summary>
			dLastUserClass = dFirstUserClass + dMaxUserClasses - 1,
			/// <summary>
			/// 
			/// </summary>
			dGeomNumClasses=dLastUserClass + 1
		}
		#endregion Class Numbers
		
		#region Contact Flags
		/// <summary>
		/// 
		/// </summary>
		[FlagsAttribute]
			public enum dContactFlags : int 
		{
			/// <summary>
			/// 
			/// </summary>
			dContactMu2			= 0x001,
			/// <summary>
			/// 
			/// </summary>
			dContactFDir1		= 0x002,
			/// <summary>
			/// 
			/// </summary>
			dContactBounce		= 0x004,
			/// <summary>
			/// 
			/// </summary>
			dContactSoftERP		= 0x008,
			/// <summary>
			/// 
			/// </summary>
			dContactSoftCFM		= 0x010,
			/// <summary>
			/// 
			/// </summary>
			dContactMotion1		= 0x020,
			/// <summary>
			/// 
			/// </summary>
			dContactMotion2		= 0x040,
			/// <summary>
			/// 
			/// </summary>
			dContactSlip1		= 0x080,
			/// <summary>
			/// 
			/// </summary>
			dContactSlip2		= 0x100,
			
			/// <summary>
			/// 
			/// </summary>
			dContactApprox0		= 0x0000,
			/// <summary>
			/// 
			/// </summary>
			dContactApprox1_1	= 0x1000,
			/// <summary>
			/// 
			/// </summary>
			dContactApprox1_2	= 0x2000,
			/// <summary>
			/// 
			/// </summary>
			dContactApprox1		= 0x3000
		}
		#endregion Contact Flags
		#endregion Public Constants
		
		#region Ode()
		/// <summary>
		///     Empty constructor - prevents instantiation.
		/// </summary>
		private Ode() 
		{
		}
		#endregion Ode()
		
		#region Public Structs
		/// <summary>
		/// Describes the mass parameters of a rigid body
		/// </summary>
		/// <remarks>
		/// mass - the total mass of the rigid body
		/// c - center of gravity position in body frame (x,y,z)
		/// I - 3x3 inertia tensor in body frame, about POR
		/// </remarks>
		[StructLayout(LayoutKind.Sequential)]
			public struct dMass 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="_mass"></param>
			/// <param name="_c"></param>
			/// <param name="_I"></param>
			public dMass(dReal _mass, dVector4 _c, dMatrix3 _I) 
			{
				mass = _mass;
				c = _c;
				I = _I;
			}
			/// <summary>
			/// 
			/// </summary>
			public dReal mass;
			/// <summary>
			/// 
			/// </summary>
			public dVector4 c;
			/// <summary>
			/// 
			/// </summary>
			public dMatrix3 I;
		};
		
		/// <summary>
		/// Contact info set by collision functions
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dContactGeom 
		{
			/// <summary>
			/// The contact position in global coordinates.
			/// </summary>
			public dVector3 pos;
			
			/// <summary>
			/// A unit length vector that is, generally speaking, perpendicular to the contact surface.
			/// </summary>
			public dVector3 normal;
			
			/// <summary>
			/// The depth to which the two bodies inter-penetrate each other. 
			/// If the depth is zero then the two bodies have a grazing contact, 
			/// i.e. they "only just" touch. However, this is rare - the simulation is 
			/// not perfectly accurate and will often step the bodies too far so that 
			/// the depth is nonzero.
			/// </summary>
			public dReal depth;
			
			/// <summary>
			/// The geometry objects that collided.
			/// </summary>
			public dGeomID g1,g2;
		};
		
		/// <summary>
		/// Defines the properties of the colliding surfaces
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dSurfaceParameters 
		{
			/// <summary>
			/// 
			/// </summary>
			public dSurfaceParameters(int _mode, dReal _mu, dReal _mu2, dReal _bounce, dReal _bounce_vel, dReal _soft_erp, dReal _soft_cfm, dReal _motion1, dReal _motion2, dReal _slip1, dReal _slip2) 
			{
				mode = _mode;
				mu = _mu;
				mu2 = _mu2;
				bounce = _bounce;
				bounce_vel = _bounce_vel;
				soft_erp = _soft_erp;
				soft_cfm = _soft_cfm;
				motion1 = _motion1;
				motion2 = _motion2;
				slip1 = _slip1;
				slip2 = _slip2;
			}
			
			/// <summary>
			/// Contact flags. This must always be set. This is a combination of one or more of the following flags:
			///
			/// dContactMu2			If not set, use mu for both friction directions. 
			/// 					If set, use mu for friction direction 1, use mu2 for friction direction 2.
			/// dContactFDir1		If set, take fdir1 as friction direction 1, otherwise automatically compute 
			/// 					friction direction 1 to be perpendicular to the contact normal (in which 
			/// 					case its resulting orientation is unpredictable).
			/// dContactBounce		If set, the contact surface is bouncy, in other words the bodies will 
			/// 					bounce off each other. The exact amount of bouncyness is controlled by 
			/// 					the bounce parameter.
			///	dContactSoftERP		If set, the error reduction parameter of the contact normal can be set 
			/// 					with the soft_erp parameter. This is useful to make surfaces soft.
			///	dContactSoftCFM		If set, the constraint force mixing parameter of the contact normal 
			/// 					can be set with the soft_cfm parameter. This is useful to make surfaces soft.
			///	dContactMotion1		If set, the contact surface is assumed to be moving independently of the 
			/// 					motion of the bodies. This is kind of like a conveyor belt running over 
			/// 					the surface. When this flag is set, motion1 defines the surface velocity 
			/// 					in friction direction 1.
			///	dContactMotion2		The same thing as above, but for friction direction 2.
			/// dContactSlip1		Force-dependent-slip (FDS) in friction direction 1.
			///	dContactSlip2		Force-dependent-slip (FDS) in friction direction 2.
			///	dContactApprox1_1	Use the friction pyramid approximation for friction direction 1. If this is 
			/// 					not specified then the constant-force-limit approximation is used (and mu is 
			/// 					a force limit).
			/// dContactApprox1_2	Use the friction pyramid approximation for friction direction 2. If this is 
			/// 					not specified then the constant-force-limit approximation is used (and mu is 
			/// 					a force limit).
			/// dContactApprox1		Equivalent to both dContactApprox1_1 and dContactApprox1_2.
			/// </summary>
			public int mode;
			
			/// <summary>
			/// Coulomb friction coefficient. 
			/// This must be in the range 0 to dInfinity. 
			/// 0 results in a frictionless contact, and dInfinity results in a contact that never slips. 
			/// Note that frictionless contacts are less time consuming to compute than ones with friction, 
			/// and infinite friction contacts can be cheaper than contacts with finite friction. 
			/// 
			/// This must always be set.
			/// </summary>
			public dReal mu;
			
			/// <summary>
			/// Optional Coulomb friction coefficient for friction direction 2 (0..dInfinity). 
			/// 
			/// This is only set if the corresponding flag is set in mode.
			/// </summary>
			public dReal mu2;
			
			/// <summary>
			/// Restitution parameter (0..1). 
			/// 0 means the surfaces are not bouncy at all, 1 is maximum bouncyness. 
			/// 
			/// This is only set if the corresponding flag is set in mode.
			/// </summary>
			public dReal bounce;
			
			/// <summary>
			/// Restitution parameter (0..1). 
			/// 0 means the surfaces are not bouncy at all, 1 is maximum bouncyness. 
			/// 
			/// This is only set if the corresponding flag is set in mode.
			/// </summary>
			public dReal bounce_vel;
			
			/// <summary>
			/// Contact normal ``softness'' parameter. 
			/// 
			/// This is only set if the corresponding flag is set in mode.
			/// </summary>
			public dReal soft_erp;
			
			/// <summary>
			/// Contact normal ``softness'' parameter. 
			/// 
			/// This is only set if the corresponding flag is set in mode.
			/// </summary>
			public dReal soft_cfm;
			
			/// <summary>
			/// Surface velocity in friction directions 1 (in m/s). 
			/// 
			/// Only set if the corresponding flags are set in mode.
			/// </summary>
			public dReal motion1;
			
			/// <summary>
			/// Surface velocity in friction directions 1 (in m/s). 
			/// 
			/// Only set if the corresponding flags are set in mode.
			/// </summary>
			public dReal motion2;
			
			/// <summary>
			/// The coefficients of force-dependent-slip (FDS) for friction directions 1 and 2. 
			/// 
			/// These are only set if the corresponding flags are set in mode.
			/// 
			/// FDS is an effect that causes the contacting surfaces to side past each other with a 
			/// velocity that is proportional to the force that is being applied tangentially to that surface.
			///	
			///	Consider a contact point where the coefficient of friction mu is infinite. Normally, if a 
			/// force f is applied to the two contacting surfaces, to try and get them to slide past each 
			/// other, they will not move. However, if the FDS coefficient is set to a positive value k 
			/// then the surfaces will slide past each other, building up to a steady velocity of k*f 
			/// relative to each other.
			/// 
			/// Note that this is quite different from normal frictional effects: the force does not 
			/// cause a constant acceleration of the surfaces relative to each other - it causes a 
			/// brief acceleration to achieve the steady velocity.
			///	
			///	This is useful for modeling some situations, in particular tires. For example consider 
			/// a car at rest on a road. Pushing the car in its direction of travel will cause it to 
			/// start moving (i.e. the tires will start rolling). Pushing the car in the perpendicular 
			/// direction will have no effect, as the tires do not roll in that direction. However - if 
			/// the car is moving at a velocity v, applying a force f in the perpendicular direction will 
			/// cause the tires to slip on the road with a velocity proportional to f*v (Yes, this really 
			/// happens).
			///
			///	To model this in ODE set the tire-road contact parameters as follows: set friction direction 1 
			/// in the direction that the tire is rolling in, and set the FDS slip coefficient in friction 
			/// direction 2 to k*v, where v is the tire rolling velocity and k is a tire parameter that you can 
			/// choose based on experimentation.
			///	
			///	Note that FDS is quite separate from the sticking/slipping effects of Coulomb friction - both 
			/// modes can be used together at a single contact point. 
			/// </summary>
			public dReal slip1,slip2;
		};
		
		
		/// <summary>
		/// Contact structure used by contact joint
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dContact 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="_surface"></param>
			/// <param name="_geom"></param>
			/// <param name="_fdir1"></param>
			public dContact(dSurfaceParameters _surface, dContactGeom _geom, dVector3 _fdir1) 
			{
				surface = _surface;
				geom = _geom;
				fdir1 = _fdir1;
			}
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
			public dVector3 fdir1;
		};
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dVector3 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="z"></param>
			public dVector3(dReal x, dReal y, dReal z) 
			{
				X = x;
				Y = y;
				Z = z;
			}
			/// <summary>
			/// 
			/// </summary>
			public dReal X,Y,Z;
			/// <summary>
			/// Indexer to support use of array syntax as found in ODE examples
			/// X = 0, Y = 1, Z = 2
			/// </summary>
			public dReal this[int index] 
			{
				get
				{
					if ( index < 0 || index > 2 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					dReal retVal = 0;
					switch ( index ) 
					{
						case 0:
							retVal = X;
							break;
						case 1:
							retVal = Y;
							break;
						case 2:
							retVal = Z;
							break;
					}
					return retVal;
				}
				set
				{
					if ( index < 0 || index > 2 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					switch ( index ) 
					{
						case 0:
							X = value;
							break;
						case 1:
							Y = value;
							break;
						case 2:
							Z = value;
							break;
					}
				}
			}
		};
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dVector4 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="z"></param>
			/// <param name="w"></param>
			public dVector4(dReal x, dReal y, dReal z, dReal w) 
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}
			/// <summary>
			/// 
			/// </summary>
			public dReal X,Y,Z,W;
			/// <summary>
			/// Indexer to support use of array syntax as found in ODE examples
			/// X = 0, Y = 1, Z = 2, W = 3
			/// </summary>
			public dReal this[int index] 
			{
				get
				{
					if ( index < 0 || index > 3 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					dReal retVal = 0;
					switch ( index ) 
					{
						case 0:
							retVal = X;
							break;
						case 1:
							retVal = Y;
							break;
						case 2:
							retVal = Z;
							break;
						case 3:
							retVal = W;
							break;
					}
					return retVal;
				}
				set
				{
					if ( index < 0 || index > 3 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					switch ( index ) 
					{
						case 0:
							X = value;
							break;
						case 1:
							Y = value;
							break;
						case 2:
							Z = value;
							break;
						case 3:
							W = value;
							break;
					}
					
				}
			}
		};
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dQuaternion 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="x"></param>
			/// <param name="y"></param>
			/// <param name="z"></param>
			/// <param name="w"></param>
			public dQuaternion(dReal x, dReal y, dReal z, dReal w) 
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}
			/// <summary>
			/// 
			/// </summary>
			public dReal W,X,Y,Z;

			/// <summary>
			/// Indexer to support use of array syntax as found in ODE examples
			/// X = 0, Y = 1, Z = 2, W = 3
			/// </summary>
			public dReal this[int index] 
			{
				get
				{
					if ( index < 0 || index > 3 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					dReal retVal = 0;
					switch ( index ) 
					{
						case 0:
							retVal = X;
							break;
						case 1:
							retVal = Y;
							break;
						case 2:
							retVal = Z;
							break;
						case 3:
							retVal = W;
							break;
					}
					return retVal;
				}
				set
				{
					if ( index < 0 || index > 3 ) 
					{
						throw new ArgumentOutOfRangeException("Index out of range");
					}
					switch ( index ) 
					{
						case 0:
							X = value;
							break;
						case 1:
							Y = value;
							break;
						case 2:
							Z = value;
							break;
						case 3:
							W = value;
							break;
					}
				}
			}
		};
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct Aabb 
		{
			/// <summary>
			/// 
			/// </summary>
			/// <param name="_minx"></param>
			/// <param name="_maxx"></param>
			/// <param name="_miny"></param>
			/// <param name="_maxy"></param>
			/// <param name="_minz"></param>
			/// <param name="_maxz"></param>
			public Aabb(dReal _minx, dReal _maxx, dReal _miny, dReal _maxy, dReal _minz, dReal _maxz) 
			{
				minx = _minx;
				maxx = _maxx;
				miny = _miny;
				maxy = _maxy;
				minz = _minz;
				maxz = _maxz;
			}
			/// <summary>
			/// 
			/// </summary>
			public dReal minx, maxx, miny, maxy, minz, maxz;
		}
		
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct dMatrix3 
		{
			
			public dMatrix3(dReal[] values)
			{
				M00 = values[0];
				M01 = values[1];
				M02 = values[2];
				M03 = values[3];
				M10 = values[4];
				M11 = values[5];
				M12 = values[6];
				M13 = values[7];
				M20 = values[8];
				M21 = values[9];
				M22 = values[10];
				M23 = values[11];
			}
			
			public dReal M00,M01,M02,M03;
			public dReal M10,M11,M12,M13;
			public dReal M20,M21,M22,M23;
			
			public dReal this[int index]
			{
				get
				{
					switch(index)
					{
						case  0: return M00;
						case  1: return M01;
						case  2: return M02;
						case  3: return M03;
						case  4: return M10;
						case  5: return M11;
						case  6: return M12;
						case  7: return M13;
						case  8: return M20;
						case  9: return M21;
						case 10: return M22;
						case 11: return M23;
						default: throw new ArgumentOutOfRangeException("index", index, "Must be between 0 and 11");
					}
				}
				set
				{
					switch(index)
					{
						case  0: M00 = value;
							break;
						case  1: M01 = value; 
							break;
						case  2: M02 = value; 
							break;
						case  3: M03 = value; 
							break;
						case  4: M10 = value; 
							break;
						case  5: M11 = value; 
							break;
						case  6: M12 = value; 
							break;
						case  7: M13 = value; 
							break;
						case  8: M20 = value; 
							break;
						case  9: M21 = value; 
							break;
						case 10: M22 = value; 
							break;
						case 11: M23 = value; 
							break;
						default: throw new ArgumentOutOfRangeException("index", index, "Must be between 0 and 11");
					}
				}
			}				
			public dReal this[int x, int y]
			{
				get
				{
					switch(x)
					{
						case 0:
							switch(y)
							{
								case 0: return M00;
								case 1: return M01;
								case 2: return M02;
								case 3: return M03;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						case 1:
							switch(y)
							{
								case 0: return M10;
								case 1: return M11;
								case 2: return M12;
								case 3: return M13;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						case 2:
							switch(y)
							{
								case 0: return M20;
								case 1: return M21;
								case 2: return M22;
								case 3: return M23;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						default: throw new ArgumentOutOfRangeException("x", x, "X value must be between 0 and 2");
					}
				}
				set
				{
					switch(x)
					{
						case 0:
							switch(y)
							{
								case 0: M00 = value; break;
								case 1: M01 = value; break;
								case 2: M02 = value; break;
								case 3: M03 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						case 1:
							switch(y)
							{
								case 0: M10 = value; break;
								case 1: M11 = value; break;
								case 2: M12 = value; break;
								case 3: M13 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						case 2:
							switch(y)
							{
								case 0: M20 = value; break;
								case 1: M21 = value; break;
								case 2: M22 = value; break;
								case 3: M23 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						default: throw new ArgumentOutOfRangeException("x", x, "X value must be between 0 and 2");
					}
				}
			}
			
			public dReal[] ToArray() {
			  return new dReal[] {
			    M00, M01, M02, M03, M10, M11, M12, M13, M20, M21, M22, M23
			  };
			}
	};
	
		/// <summary>
		/// 
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dMatrix4 
		{
			public dMatrix4(dReal[] values) 
			{
				M00 = values[0];
				M01 = values[1];
				M02 = values[2];
				M03 = values[3];
				M10 = values[4];
				M11 = values[5];
				M12 = values[6];
				M13 = values[7];
				M20 = values[8];
				M21 = values[9];
				M22 = values[10];
				M23 = values[11];
				M30 = values[12];
				M31 = values[13];
				M32 = values[14];
				M33 = values[15];
			}

			public dReal M00,M01,M02,M03;
			public dReal M10,M11,M12,M13;
			public dReal M20,M21,M22,M23;
			public dReal M30,M31,M32,M33;
			
			public dReal this[int index]
			{
				get
				{
					switch(index)
					{
						case  0: return M00;
						case  1: return M01;
						case  2: return M02;
						case  3: return M03;
						case  4: return M10;
						case  5: return M11;
						case  6: return M12;
						case  7: return M13;
						case  8: return M20;
						case  9: return M21;
						case 10: return M22;
						case 11: return M23;
						case 12: return M30;
						case 13: return M31;
						case 14: return M32;
						case 15: return M33;
						default: throw new ArgumentOutOfRangeException("index", index, "Must be between 0 and 15");
					}
				}
				set
				{
					switch(index)
					{
						case  0: M00 = value;
							break;
						case  1: M01 = value; 
							break;
						case  2: M02 = value; 
							break;
						case  3: M03 = value; 
							break;
						case  4: M10 = value; 
							break;
						case  5: M11 = value; 
							break;
						case  6: M12 = value; 
							break;
						case  7: M13 = value; 
							break;
						case  8: M20 = value; 
							break;
						case  9: M21 = value; 
							break;
						case 10: M22 = value; 
							break;
						case 11: M23 = value; 
							break;
						case 12: M30 = value; 
							break;
						case 13: M31 = value; 
							break;
						case 14: M32 = value; 
							break;
						case 15: M33 = value; 
							break;
						default: throw new ArgumentOutOfRangeException("index", index, "Must be between 0 and 15");
					}
				}
			}				
			public dReal this[int x, int y]
			{
				get
				{
					switch(x)
					{
						case 0:
							switch(y)
							{
								case 0: return M00;
								case 1: return M01;
								case 2: return M02;
								case 3: return M03;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						case 1:
							switch(y)
							{
								case 0: return M10;
								case 1: return M11;
								case 2: return M12;
								case 3: return M13;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						case 2:
							switch(y)
							{
								case 0: return M20;
								case 1: return M21;
								case 2: return M22;
								case 3: return M23;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						case 3:
							switch(y)
							{
								case 0: return M30;
								case 1: return M31;
								case 2: return M32;
								case 3: return M33;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");									
							}
						default: throw new ArgumentOutOfRangeException("x", x, "X value must be between 0 and 3");
					}
				}
				set
				{
					switch(x)
					{
						case 0:
							switch(y)
							{
								case 0: M00 = value; break;
								case 1: M01 = value; break;
								case 2: M02 = value; break;
								case 3: M03 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						case 1:
							switch(y)
							{
								case 0: M10 = value; break;
								case 1: M11 = value; break;
								case 2: M12 = value; break;
								case 3: M13 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						case 2:
							switch(y)
							{
								case 0: M20 = value; break;
								case 1: M21 = value; break;
								case 2: M22 = value; break;
								case 3: M23 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						case 3:
							switch(y)
							{
								case 0: M30 = value; break;
								case 1: M31 = value; break;
								case 2: M32 = value; break;
								case 3: M33 = value; break;
								default: throw new ArgumentOutOfRangeException("y", y, "Y value must be between 0 and 3");
							}
							break;
						default: throw new ArgumentOutOfRangeException("x", x, "X value must be between 0 and 3");
					}
				}
			}
		};
		
		// TODO: Should there be a dMatrix6 here to complete the set of arrays found in ODE's common.h?
		// public struct dMatrix6 {}
		
		/// <summary>
		/// During the world time step, the forces that are applied by each joint are computed. 
		/// These forces are added directly to the joined bodies, and the user normally has no 
		/// way of telling which joint contributed how much force.
		///
		///	If this information is desired then the user can allocate a dJointFeedback structure 
		/// and pass its pointer to the dJointSetFeedback() function. 
		/// 
		/// The feedback information structure is defined as follows:
		///	
		///	typedef struct dJointFeedback {
		///		dVector3 f1;       // force that joint applies to body 1
		///		dVector3 t1;       // torque that joint applies to body 1
		///		dVector3 f2;       // force that joint applies to body 2
		///		dVector3 t2;       // torque that joint applies to body 2
		///	} dJointFeedback;
		///	
		///	During the time step any feedback structures that are attached to joints will be filled in with the 
		/// joint's force and torque information. The dJointGetFeedback() function returns the current feedback 
		/// structure pointer, or 0 if none is used (this is the default). dJointSetFeedback() can be passed 0 
		/// to disable feedback for that joint.
		///	
		///	Now for some API design notes. It might seem strange to require that users perform the allocation 
		/// of these structures. Why not just store the data statically in each joint? The reason is that not 
		/// all users will use the feedback information, and even when it is used not all joints will need it. 
		/// It will waste memory to store it statically, especially as this structure could grow to store a 
		/// lot of extra information in the future.
		///	
		///	Why not have ODE allocate the structure itself, at the user's request? The reason is that contact 
		/// joints (which are created and destroyed every time step) would require a lot of time to be spent 
		/// in memory allocation if feedback is required. Letting the user do the allocation means that a 
		/// better allocation strategy can be provided, e.g simply allocating them out of a fixed array.
		///	
		///	The alternative to this API is to have a joint-force callback. This would work of course, but 
		/// it has a few problems. First, callbacks tend to pollute APIs and sometimes require the user 
		/// to go through unnatural contortions to get the data to the right place. Second, this would 
		/// expose ODE to being changed in the middle of a step (which would have bad consequences), and 
		/// there would have to be some kind of guard against this or a debugging check for it - which 
		/// would complicate things.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
			public struct dJointFeedback 
		{
			/// <summary>
			/// 
			/// </summary>
			public dJointFeedback(dVector3 _f1, dVector3 _t1, dVector3 _f2, dVector3 _t2) 
			{
				f1 = _f1;
				t1 = _t1;
				f2 = _f2;
				t2 = _t2;
			}
			
			/// <summary>Force applied to body 1</summary>
			public dVector3 f1;
			/// <summary>Torque applied to body 1</summary>
			public dVector3 t1;
			/// <summary>Force applied to body 2</summary>
			public dVector3 f2;
			/// <summary>Torque applied to body 2</summary>
			public dVector3 t2;
		};
		#endregion Public Structs
		
		#region Public Delegates
		/// <summary>
		/// Callback function for dSpaceCollide and dSpaceCollide2
		/// </summary>
		[DelegateCallingConventionCdecl]
		public delegate void dNearCallback (IntPtr data, dGeomID o1, dGeomID o2);
		#endregion Public Delegates
		
		#region Public Externs
		#region World Functions
		#region World create and destroy functions
		/// <summary>
		/// Create a new, empty world and return its ID number.
		/// </summary>
		/// <remarks>
		/// The world object is a container for rigid bodies and joints.
		/// Objects in different worlds can not interact, for example rigid bodies from two different worlds can not collide.
		/// All the objects in a world exist at the same point in time, thus one reason to use separate worlds is to simulate
		/// systems at different rates.
		///
		/// Most applications will only need one world.
		/// </remarks>
		/// <returns>A dWorldID</returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dWorldID dWorldCreate();
		
		/// <summary>
		/// Destroy a world and everything in it.
		/// This includes all bodies, and all joints that are not part of a joint group.
		/// Joints that are part of a joint group will be deactivated, and can be destroyed by calling, for example,
		/// dJointGroupEmpty.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldDestroy(dWorldID world);
		#endregion World create and destroy functions
		#region World gravity functions
		/// <summary>
		/// Set the world's global gravity vector.
		/// The units are m/s/s, so Earth's gravity vector would be (0,0,-9.81), assuming that +z is up.
		/// The default is no gravity, i.e. (0,0,0).
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetGravity(dWorldID world, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the world's global gravity vector.
		/// The units are m/s/s.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="gravity">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldGetGravity(dWorldID world, ref dVector3 gravity);
		
		#endregion World gravity functions
		#region World CFM and ERP functions
		/// <summary>
		/// Set the global ERP value, which controls how much error correction is performed in each time step.
		/// Typical values are in the range 0.1--0.8. The default is 0.2.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="erp">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetERP(dWorldID world, dReal erp);
		
		/// <summary>
		/// Get the global ERP value, which controls how much error correction is performed in each time step.
		/// Typical values are in the range 0.1--0.8. The default is 0.2.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetERP(dWorldID world);
		
		/// <summary>
		/// Set the global CFM (constraint force mixing) value.
		/// Typical values are in the range 10-9 -- 1.
		/// The default is 10-5 if single precision is being used, or 10-10 if double precision is being used.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="cfm">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetCFM(dWorldID world, dReal cfm);
		
		/// <summary>
		/// Get the global CFM (constraint force mixing) value.
		/// Typical values are in the range 10-9 -- 1.
		/// The default is 10-5 if single precision is being used, or 10-10 if double precision is being used.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetCFM(dWorldID world);
		
		#endregion World CFM and ERP functions
		#region World impulse to force conversion function
		/// <summary>
		/// Convert linear/angular impulse to a rigid body to a force/torque vector.
		///
		/// If you want to apply a linear or angular impulse to a rigid body, instead of a force or a torque,
		/// then you can use this function to convert the desired impulse into a force/torque vector before
		/// calling the dBodyAdd... function.
		///
		/// This function is given the desired impulse as (ix,iy,iz) and puts the force vector in force.
		///
		/// The current algorithm simply scales the impulse by 1/stepsize, where stepsize is the step size for
		/// the next step that will be taken.
		/// </summary>
		/// <remarks>
		/// This function is given a dWorldID because, in the future, the force computation may depend on integrator
		/// parameters that are set as properties of the world.
		/// </remarks>
		/// <param name="world">A  dWorldID</param>
		/// <param name="stepsize">A  dReal</param>
		/// <param name="ix">A  dReal</param>
		/// <param name="iy">A  dReal</param>
		/// <param name="iz">A  dReal</param>
		/// <param name="force">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldImpulseToForce(dWorldID world, dReal stepsize, dReal ix, dReal iy, dReal iz, ref dVector3 force);
		
		#endregion World impulse to force conversion function
		#region World Stepping Functions
		/// <summary>
		/// Step the world.
		/// This uses a "big matrix" method that takes time on the order of m3 and memory on the order of m2,
		/// where m is the total number of constraint rows.
		///
		/// For large systems this will use a lot of memory and can be very slow, but this is currently the
		/// most accurate method.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="stepsize">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldStep(dWorldID world, dReal stepsize);
		#endregion World Stepping Functions
		#region World QuickStep functions
		/// <summary>
		/// Step the world.
		/// This uses an iterative method that takes time on the order of m*N and memory on the order of m, where
		/// m is the total number of constraint rows and N is the number of iterations.
		///
		/// For large systems this is a lot faster than dWorldStep, but it is less accurate.
		/// </summary>
		/// <remarks>
		/// QuickStep is great for stacks of objects especially when the auto-disable feature is used as well.
		/// However, it has poor accuracy for near-singular systems. Near-singular systems can occur when using
		/// high-friction contacts, motors, or certain articulated structures.
		/// For example, a robot with multiple legs sitting on the ground may be near-singular.
		///
		/// There are ways to help overcome QuickStep's inaccuracy problems:
		/// 	- 	Increase CFM.
		/// 	-	Reduce the number of contacts in your system (e.g. use the minimum number of contacts for
		///     	the feet of a robot or creature).
		///		-	Don't use excessive friction in the contacts.
		///		-	Use contact slip if appropriate
		///		-	Avoid kinematic loops (however, kinematic loops are inevitable in legged creatures).
		///		-	Don't use excessive motor strength.
		///		-	Use force-based motors instead of velocity-based motors.
		///
		/// Increasing the number of QuickStep iterations may help a little bit, but it is not going to help much
		/// if your system is really near singular.
		/// </remarks>
		/// <param name="world">A  dWorldID</param>
		/// <param name="stepsize">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldQuickStep(dWorldID world, dReal stepsize);
		
		/// <summary>
		/// Set the number of iterations that the QuickStep method performs per step.
		///
		/// More iterations will give a more accurate solution, but will take longer to compute.
		///
		/// The default is 20 iterations.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="num">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetQuickStepNumIterations(dWorldID world, int num);
		
		/// <summary>
		/// Get the number of iterations that the QuickStep method performs per step.
		///
		/// The default is 20 iterations.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dWorldGetQuickStepNumIterations(dWorldID world);
		
		/// <summary>
		/// Set the QuickStep SOR over-relaxation parameter
		/// </summary>
		/// <remarks>
		/// Summary obtained from code - otherwise undocumented
		/// </remarks>
		/// <param name="world">A  dWorldID</param>
		/// <param name="param">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetQuickStepW(dWorldID world, dReal param);
		
		/// <summary>
		/// Get the QuickStep SOR over-relaxation parameter
		/// </summary>
		/// <remarks>
		/// Summary obtained from code - otherwise undocumented
		/// </remarks>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetQuickStepW(dWorldID world);
		#endregion World QuickStep functions
		#region World contact parameter functions
		/// <summary>
		/// Set maximum correcting velocity that contacts are allowed to generate.
		///
		/// The default value is infinity (i.e. no limit).
		///
		/// Reducing this value can help prevent "popping" of deeply embedded objects.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="vel">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetContactMaxCorrectingVel(dWorldID world, dReal vel);
		
		/// <summary>
		/// Get the maximum correcting velocity that contacts are allowed to generate.
		///
		/// The default value is infinity (i.e. no limit).
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetContactMaxCorrectingVel(dWorldID world);
		
		/// <summary>
		/// Set the depth of the surface layer around all geometry objects.
		///
		/// Contacts are allowed to sink into the surface layer up to the given depth before coming to rest.
		///
		/// The default value is zero.
		///
		/// Increasing this to some small value (e.g. 0.001) can help prevent jittering problems due to contacts
		/// being repeatedly made and broken.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="depth">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetContactSurfaceLayer(dWorldID world, dReal depth);
		
		/// <summary>
		/// Get the depth of the surface layer around all geometry objects.
		///
		/// The default value is zero.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetContactSurfaceLayer(dWorldID world);
		#endregion World contact parameter functions
		#region World StepFast1 functions
		/// <summary>
		/// Step the world by stepsize seconds using the StepFast1 algorithm.
		/// The number of iterations to perform is given by maxiterations.
		///
		/// NOTE: The StepFast algorithm has been superseded by the QuickStep algorithm: see the dWorldQuickStep function.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="stepsize">A  dReal</param>
		/// <param name="maxiterations">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldStepFast1(dWorldID world, dReal stepsize, int maxiterations);
		
		/// <summary>
		/// Set the AutoEnableDepth parameter used by the StepFast1 algorithm.
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="autoEnableDepth">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWorldSetAutoEnableDepthSF1(dWorldID world, int autoEnableDepth);
		
		/// <summary>
		/// Get the AutoEnableDepth parameter used by the StepFast1 algorithm.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dWorldGetAutoEnableDepthSF1(dWorldID world);
		#endregion World StepFast1 functions
		#region World Auto-disable functions
		/// <summary>
		/// Set the default auto-disable flag for newly created bodies.
		///
		/// The default parameter is:  AutoDisableFlag = disabled
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="do_auto_disable">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dWorldSetAutoDisableFlag(dWorldID world, int do_auto_disable);
		
		/// <summary>
		/// Get the current auto-disable flag for newly created bodies.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int   dWorldGetAutoDisableFlag(dWorldID world);
		
		/// <summary>
		/// Set the default auto-disable linear threshold for newly created bodies.
		///
		/// The default parameter is:  AutoDisableLinearThreshold = 0.01
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="linear_threshold">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dWorldSetAutoDisableLinearThreshold(dWorldID world, dReal linear_threshold);
		
		/// <summary>
		/// Get the current auto-disable linear threshold for newly created bodies.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetAutoDisableLinearThreshold(dWorldID world);
		
		/// <summary>
		/// Set the default auto-disable angular threshold for newly created bodies.
		///
		/// The default parameter is:  AutoDisableAngularThreshold = 0.01
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="angular_threshold">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dWorldSetAutoDisableAngularThreshold(dWorldID world, dReal angular_threshold);
		
		/// <summary>
		/// Get the current auto-disable angular threshold for newly created objects
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetAutoDisableAngularThreshold(dWorldID world);
		
		/// <summary>
		/// Set the default auto-disable steps for newly created bodies.
		///
		/// The default parameter is:  AutoDisableSteps = 10
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="steps">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dWorldSetAutoDisableSteps(dWorldID world, int steps);
		
		/// <summary>
		/// Get the current auto-disable steps for newly created bodies
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int   dWorldGetAutoDisableSteps(dWorldID world);
		
		/// <summary>
		/// Set the default auto-disable time for newly created bodies.
		///
		/// The default parameter is:  AutoDisableTime = 0
		/// </summary>
		/// <param name="world">A  dWorldID</param>
		/// <param name="time">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dWorldSetAutoDisableTime(dWorldID world, dReal time);
		
		/// <summary>
		/// Get the current auto-disable time for newly created bodies.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dWorldGetAutoDisableTime(dWorldID world);
		#endregion World Auto-disable functions
		#endregion World Functions
		
		#region Body functions
		#region Body create and destroy functions
		/// <summary>
		/// Create a body in the given world with default mass parameters at position (0,0,0).
		/// Return its ID (really a handle to the body).
		/// </summary>
		/// <returns>A dBodyID</returns>
		/// <param name="world">A  dWorldID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dBodyID dBodyCreate(dWorldID world);
		
		/// <summary>
		/// Destroy a body.
		///
		/// All joints that are attached to this body will be put into limbo (i.e. unattached and
		/// not affecting the simulation, but they will NOT be deleted)
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyDestroy(dBodyID body);
		#endregion Body create and destroy functions
		#region Body position and orientation functions
		/// <summary>
		/// Set the position of the body.
		///
		/// After setting a group of bodies, the outcome of the simulation is undefined if the new configuration
		/// is inconsistent with the joints/constraints that are present.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetPosition(dBodyID body, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set the rotation of the body.
		///
		/// After setting a group of bodies, the outcome of the simulation is undefined if the new configuration
		/// is inconsistent with the joints/constraints that are present.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="R">A  dMatrix3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetRotation(dBodyID body, ref dMatrix3 R);
		
		/// <summary>
		/// Set the orientation on of the body.
		///
		/// Orientation is represented by a quaternion (qs,qx,qy,qz)
		///
		/// After setting a group of bodies, the outcome of the simulation is undefined if the new configuration
		/// is inconsistent with the joints/constraints that are present.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="q">A  dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetQuaternion(dBodyID body, [In] ref dQuaternion q);
		
		/// <summary>
		/// Set the linear velocity of the body.
		///
		/// After setting a group of bodies, the outcome of the simulation is undefined if the new configuration
		/// is inconsistent with the joints/constraints that are present.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetLinearVel(dBodyID body, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set the angular velocity of the body.
		///
		/// After setting a group of bodies, the outcome of the simulation is undefined if the new configuration
		/// is inconsistent with the joints/constraints that are present.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetAngularVel(dBodyID body, dReal x, dReal y, dReal z);
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetPosition")]
		private extern unsafe static dReal *dBodyGetPosition_(dBodyID body);
		/// <summary>
		/// Get the position of the body
		///
		/// The vector is valid until any changes are made to the rigid body system structure.
		/// </summary>
		/// <returns>A dVector3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dVector3 dBodyGetPosition(dBodyID body) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dBodyGetPosition_(body);
				return *v;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetRotation")]
		private extern unsafe static dReal * dBodyGetRotation_(dBodyID body);	// ptr to 4x3 rot matrix
		/// <summary>
		/// Get the rotation of the body.
		///
		/// The returned value is a 4x3 rotation matrix.
		/// The matrix is valid until any changes are made to the rigid body system structure.
		/// </summary>
		/// <returns>A dMatrix3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dMatrix3 dBodyGetRotation(dBodyID body) 
		{
			unsafe
			{
				dMatrix3 *m=(dMatrix3*)dBodyGetRotation_(body);
				return *m;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetQuaternion")]
		private extern unsafe static dReal* dBodyGetQuaternion_(dBodyID body);
		/// <summary>
		/// Get the orientation of a body.
		///
		/// Orientation is represented by a quaternion (qs,qx,qy,qz)
		/// </summary>
		/// <returns>A dQuaternion</returns>
		/// <param name="body">A  dBodyID</param>
		/// TODO: This seems to be unfinished.  Need completion and testing.
		public static dQuaternion dBodyGetQuaternion(dBodyID body) 
		{
			unsafe
			{
				dQuaternion *q=(dQuaternion*)dBodyGetQuaternion_(body);
				//dQuaternion q2=new dQuaternion(q->X,q->Y,q->Z,q->W);
				return *q;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetLinearVel")]
		private extern unsafe static dReal *dBodyGetLinearVel_(dBodyID body);
		/// <summary>
		/// Get the linear velocity of a body
		///
		/// The vector is valid until any changes are made to the rigid body system structure.
		/// </summary>
		/// <returns>A dVector3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dVector3 dBodyGetLinearVel(dBodyID body) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dBodyGetLinearVel_(body);
				return *v;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetAngularVel")]
		private extern unsafe static dReal *dBodyGetAngularVel_(dBodyID body);
		/// <summary>
		/// Get the angular velocity of a body
		///
		/// The vector is valid until any changes are made to the rigid body system structure.
		/// </summary>
		/// <returns>A dVector3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dVector3 dBodyGetAngularVel(dBodyID body) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dBodyGetAngularVel_(body);
				return *v;
			}
		}
		#endregion Body position and orientation functions
		#region Body mass and force functions
		/// <summary>
		/// Set the mass of the body (see the mass functions)
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="mass">A  dMass</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetMass(dBodyID body, ref dMass mass);
		
		/// <summary>
		/// Get the mass of the body (see the mass functions)
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="mass">A  dMass</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetMass(dBodyID body, ref dMass mass);
		
		/// <summary>
		/// Add force to a body using absolute coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at body's center of mass
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddForce(dBodyID body, dReal fx, dReal fy, dReal fz);
		
		/// <summary>
		/// Add torque to a body using absolute coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at body's center of mass
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddTorque(dBodyID body, dReal fx, dReal fy, dReal fz);
		
		/// <summary>
		/// Add force to a body using relative coordinates.
		///
		/// This function takes a force vector that is relative to the body's own frame of reference.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at body's center of mass
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddRelForce(dBodyID body, dReal fx, dReal fy, dReal fz);
		
		/// <summary>
		/// Add torque to a body using relative coordinates.
		///
		/// This function takes a force vector that is relative to the body's own frame of reference.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at body's center of mass
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddRelTorque(dBodyID body, dReal fx, dReal fy, dReal fz);
		
		/// <summary>
		/// Add force to a body using absolute coordinates at specified absolute position.
		///
		/// The supplied position vector specifies the point at which the force is supplied in global coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at specified point.
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddForceAtPos(dBodyID body, dReal fx, dReal fy, dReal fz,
			dReal px, dReal py, dReal pz);
		/// <summary>
		/// Add force to a body using absolute coordinates at specified relative position.
		///
		/// The supplied position vector specifies the point at which the force is supplied in body-relative coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at specified point.
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddForceAtRelPos(dBodyID body, dReal fx, dReal fy, dReal fz,
			dReal px, dReal py, dReal pz);
		
		/// <summary>
		/// Add force to a body using body-relative coordinates at specified absolute position.
		///
		/// The supplied position vector specifies the point at which the force is supplied in global coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at specified point.
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddRelForceAtPos(dBodyID body, dReal fx, dReal fy, dReal fz,
			dReal px, dReal py, dReal pz);
		
		/// <summary>
		/// Add force to a body using body-relative coordinates at specified relative position.
		///
		/// The supplied position vector specifies the point at which the force is supplied in body-relative coordinates.
		/// </summary>
		/// <remarks>
		/// Forces are accumulated on to each body, and the accumulators are zeroed after each time step.
		///
		/// Force is applied at specified point.
		/// </remarks>
		/// <param name="body">A  dBodyID</param>
		/// <param name="fx">A  dReal</param>
		/// <param name="fy">A  dReal</param>
		/// <param name="fz">A  dReal</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyAddRelForceAtRelPos(dBodyID body, dReal fx, dReal fy, dReal fz,
			dReal px, dReal py, dReal pz);
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetForce")]
		private extern unsafe static dReal *dBodyGetForce_(dBodyID body);
		/// <summary>
		/// Return the current accumulated force on the body.
		/// </summary>
		/// <remarks>
		/// In ODE, the returned values are pointers to internal data structures, so the vectors are only valid until any
		/// changes are made to the rigid body system.
		/// </remarks>
		/// <returns>A dVector3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dVector3 dBodyGetForce(dBodyID body) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dBodyGetForce_(body);
				return *v;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dBodyGetTorque")]
		private extern unsafe static dReal *dBodyGetTorque_(dBodyID body);
		/// <summary>
		/// Return the current accumulated torque on the body.
		/// </summary>
		/// <remarks>
		/// In ODE, the returned values are pointers to internal data structures, so the vectors are only valid until any
		/// changes are made to the rigid body system.
		/// </remarks>
		/// <returns>A dVector3</returns>
		/// <param name="body">A  dBodyID</param>
		public static dVector3 dBodyGetTorque(dBodyID body) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dBodyGetTorque_(body);
				return *v;
			}
		}
		
		/// <summary>
		/// Set the body force accumulation vector.
		/// This is mostly useful to zero the force and torque for deactivated bodies before they are reactivated,
		/// in the case where the force-adding functions were called on them while they were deactivated.
		/// </summary>
		/// <param name="b">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetForce(dBodyID b, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set the body torque accumulation vector.
		/// This is mostly useful to zero the force and torque for deactivated bodies before they are reactivated,
		/// in the case where the force-adding functions were called on them while they were deactivated.
		/// </summary>
		/// <param name="b">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetTorque(dBodyID b, dReal x, dReal y, dReal z);
		#endregion Body mass and force functions
		#region Body utility functions
		/// <summary>
		/// Take a point on a body (px,py,pz) and return that point's position in body-relative coordinates (in result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetRelPointPos(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3 result);
		
		/// <summary>
		/// Take a point on a body (px,py,pz) and return that point's velocity in body-relative coordinates (in result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetRelPointVel(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3  result);
		
		/// <summary>
		/// Take a point on a body (px,py,pz) and return that point's position in absolute coordinates (in result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetPointVel(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3  result);
		
		/// <summary>
		/// This is the inverse of dBodyGetRelPointPos.
		/// It takes a point in global coordinates (x,y,z) and returns the point's position in body-relative
		/// coordinates (result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetPosRelPoint(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3  result);
		
		/// <summary>
		/// Given a vector expressed in the body coordinate system (x,y,z), rotate it to the world coordinate system (result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyVectorToWorld(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3  result);
		
		/// <summary>
		/// Given a vector expressed in the world coordinate system (x,y,z), rotate it to the body coordinate system (result).
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyVectorFromWorld(dBodyID body, dReal px, dReal py, dReal pz,
			ref dVector3  result);
		#endregion Body utility functions
		#region Miscellaneous Body Functions
		/// <summary>
		/// Set the body's user-data pointer.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="data">An IntPtr</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetData(dBodyID body, /*void **/ IntPtr data);
		
		/// <summary>
		/// Get the body's user-data pointer.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <returns>An IntPtr</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr dBodyGetData(dBodyID body);
		
		/// <summary>
		/// This function controls the way a body's orientation is updated at each time step. The mode argument can be:
		///
		/// 	-	0: An ``infinitesimal'' orientation update is used. This is fast to compute, but it can occasionally
		/// 		cause inaccuracies for bodies that are rotating at high speed, especially when those bodies are
		/// 		joined to other bodies.
		/// 		This is the default for every new body that is created.
		///
		/// 	-	1: A ``finite'' orientation update is used. This is more costly to compute, but will be more
		/// 		accurate for high speed rotations. Note however that high speed rotations can result in many
		/// 		types of error in a simulation, and this mode will only fix one of those sources of error.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetFiniteRotationMode(dBodyID body, int mode);
		
		/// <summary>
		/// Return the current finite rotation mode of a body (0 or 1).
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dBodyGetFiniteRotationMode(dBodyID body);
		
		/// <summary>
		/// This sets the finite rotation axis for a body.
		/// This axis only has meaning when the finite rotation mode is set (see dBodySetFiniteRotationMode).
		///
		/// If this axis is zero (0,0,0), full finite rotations are performed on the body.
		///
		/// If this axis is nonzero, the body is rotated by performing a partial finite rotation along the axis direction
		/// followed by an infinitesimal rotation along an orthogonal direction.
		///
		/// This can be useful to alleviate certain sources of error caused by quickly spinning bodies. For example, if a
		/// car wheel is rotating at high speed you can call this function with the wheel's hinge axis as the argument to
		/// try and improve its behavior.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetFiniteRotationAxis(dBodyID body, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Return the current finite rotation axis of a body.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyGetFiniteRotationAxis(dBodyID body, ref dVector3 result);
		
		/// <summary>
		/// Return the number of joints that are attached to this body.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="b">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dBodyGetNumJoints(dBodyID b);
		
		/// <summary>
		/// Return a joint attached to this body, given by index.
		///
		/// Valid indexes are 0 to n-1 where n is the value returned by dBodyGetNumJoints.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="body">A  dBodyID</param>
		/// <param name="index">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dBodyGetJoint(dBodyID body, int index);
		
		/// <summary>
		/// Set whether the body is influenced by the world's gravity or not.
		///
		/// If mode is nonzero it is, if mode is zero, it isn't.
		///
		/// Newly created bodies are always influenced by the world's gravity.
		/// </summary>
		/// <param name="b">A  dBodyID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodySetGravityMode(dBodyID b, int mode);
		
		/// <summary>
		/// Get whether the body is influenced by the world's gravity or not.
		///
		/// If mode is nonzero it is, if mode is zero, it isn't.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="b">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dBodyGetGravityMode(dBodyID b);
		#endregion Miscellaneous Body Functions
		#region Body automatic enabling and disabling functions
		// Every body can be enabled or disabled.
		// Enabled bodies participate in the simulation, while disabled bodies are
		// turned off and do not get updated during a simulation step.
		// New bodies are always created in the enabled state.
		// A disabled body that is connected through a joint to an enabled body will
		// be automatically re-enabled at the next simulation step.
		// Disabled bodies do not consume CPU time, therefore to speed up the
		// simulation bodies should be disabled when they come to rest.
		// This can be done automatically with the auto-disable feature.
		// If a body has its auto-disable flag turned on, it will automatically
		// disable itself when
		// 	1. 	it has been idle for a given number of simulation steps.
		// 	2. 	it has also been idle for a given amount of simulation time.
		//
		// A body is considered to be idle when the magnitudes of both its linear
		// velocity and angular velocity are below given thresholds.
		// Thus, every body has five auto-disable parameters:
		// 	an enabled flag, a idle step count, an idle time, and linear/angular velocity thresholds.
		// Newly created bodies get these parameters from world.
		// The following functions set and get the enable/disable parameters of a body.
		
		/// <summary>
		/// Manually enable a body.
		/// Note that a disabled body that is connected through a joint to an enabled body
		/// will be automatically re-enabled at the next simulation step.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyEnable(dBodyID body);
		
		/// <summary>
		/// Manually disable a body.
		/// Note that a disabled body that is connected through a joint to an enabled body
		/// will be automatically re-enabled at the next simulation step.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dBodyDisable(dBodyID body);
		
		/// <summary>
		/// Method dBodyIsEnabled
		/// Return 1 if a body is currently enabled or 0 if it is disabled.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dBodyIsEnabled(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableFlag
		/// Set the auto-disable flag of a body.
		///
		/// If the do_auto_disable is nonzero the body will be automatically disabled when it has been idle for long enough.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="do_auto_disable">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableFlag(dBodyID body, int do_auto_disable);
		
		/// <summary>
		/// Method dBodyGetAutoDisableFlag
		/// Get the auto-disable flag of a body.
		///
		/// If the do_auto_disable is nonzero the body will be automatically disabled when it has been idle for long enough.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int   dBodyGetAutoDisableFlag(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableLinearThreshold
		/// Set a body's linear velocity threshold for automatic disabling.
		///
		/// The body's linear velocity magnitude must be less than this threshold for
		/// it to be considered idle.
		///
		/// Set the threshold to dInfinity to prevent the linear velocity from being considered.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="linear_threshold">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableLinearThreshold(dBodyID body, dReal linear_threshold);
		
		/// <summary>
		/// Method dBodyGetAutoDisableLinearThreshold
		/// Get a body's linear velocity threshold for automatic disabling.
		///
		/// The body's linear velocity magnitude must be less than this threshold for
		/// it to be considered idle.
		///
		/// Set the threshold to dInfinity to prevent the linear velocity from being considered.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dBodyGetAutoDisableLinearThreshold(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableAngularThreshold
		/// Set a body's angular velocity threshold for automatic disabling.
		///
		/// The body's linear angular magnitude must be less than this threshold for
		/// it to be considered idle.
		///
		/// Set the threshold to dInfinity to prevent the angular velocity from being considered.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="angular_threshold">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableAngularThreshold(dBodyID body, dReal angular_threshold);
		
		/// <summary>
		/// Method dBodyGetAutoDisableAngularThreshold
		/// Get a body's angular velocity threshold for automatic disabling.
		///
		/// The body's linear angular magnitude must be less than this threshold for
		/// it to be considered idle.
		///
		/// Set the threshold to dInfinity to prevent the angular velocity from being considered.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dBodyGetAutoDisableAngularThreshold(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableSteps
		/// Set the number of simulation steps that a body must be idle before
		/// it is automatically disabled.
		///
		/// Set this to zero to disable consideration of the number of steps.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="steps">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableSteps(dBodyID body, int steps);
		
		/// <summary>
		/// Method dBodyGetAutoDisableSteps
		/// Get the number of simulation steps that a body must be idle before
		/// it is automatically disabled.
		///
		///  If zero, consideration of the number of steps is disabled.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int   dBodyGetAutoDisableSteps(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableTime
		/// Set the amount of simulation time that a body must be idle before
		/// it is automatically disabled.
		///
		/// Set this to zero to disable consideration of the amount of simulation time.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		/// <param name="time">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableTime(dBodyID body, dReal time);
		
		/// <summary>
		/// Method dBodyGetAutoDisableTime
		/// Get the amount of simulation time that a body must be idle before
		/// it is automatically disabled.
		///
		/// If zero, consideration of the amount of simulation time is disabled.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dBodyGetAutoDisableTime(dBodyID body);
		
		/// <summary>
		/// Method dBodySetAutoDisableDefaults
		/// Set the auto-disable parameters of the body to the default parameters
		/// that have been set on the world.
		/// </summary>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void  dBodySetAutoDisableDefaults(dBodyID body);
		#endregion Body automatic enabling and disabling functions
		#endregion Body functions
		
		#region Joint functions
		#region Joint create and destroy functions
		/// <summary>
		/// Create a new ball joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateBall(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new hinge joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateHinge(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new slider joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateSlider(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new contact joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		///
		/// The contact joint will be initialized with the given dContact structure.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		/// <param name="contact"></param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateContact(dWorldID world, dJointGroupID group, ref dContact contact);
		
		/// <summary>
		/// Create a new hinge-2 joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateHinge2(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new universal joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateUniversal(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new fixed joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateFixed(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new angular motor joint.
		///
		/// The joint is initially in "limbo" (i.e. it has no effect on the simulation)
		/// because it does not connect to any bodies.
		///
		/// The joint group ID is 0 to allocate the joint normally.
		/// If it is nonzero the joint is allocated in the given joint group.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateAMotor(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Create a new "null" joint.
		///
		/// There's no discussion of this in the docs or sourcecode.
		/// The only mention is the following entry in the ODE Changelog:
		///
		/// 	10/11/01 russ
		///
		/// 	* joints can now return m=0 to be "inactive". added a "null" joint
		/// 	to test this.
		///
		/// This suggests a null joint is mainly useful for testing and should probably
		/// be ignored by users of the bindings.
		/// </summary>
		/// <returns>A dJointID</returns>
		/// <param name="world">A  dWorldID</param>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointID dJointCreateNull(dWorldID world, dJointGroupID group);
		
		/// <summary>
		/// Destroy a joint, disconnecting it from its attached bodies and removing it from the world.
		/// However, if the joint is a member of a group then this function has no effect - to destroy
		/// that joint the group must be emptied or destroyed.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointDestroy(dJointID joint);
		
		/// <summary>
		/// Create a joint group.
		///
		/// NOTE: 	The max_size argument is no longer used and should be set to 0.
		/// 		It is kept for backwards compatibility.
		/// </summary>
		/// <returns>A dJointGroupID</returns>
		/// <param name="max_size">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dJointGroupID dJointGroupCreate(int max_size);
		
		/// <summary>
		/// Destroy a joint group. All joints in the joint group will be destroyed.
		/// </summary>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGroupDestroy(dJointGroupID group);
		
		/// <summary>
		/// Empty a joint group.
		/// All joints in the joint group will be destroyed, but the joint group itself will not be destroyed.
		/// </summary>
		/// <param name="group">A  dJointGroupID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGroupEmpty(dJointGroupID group);
		#endregion Joint create and destroy functions
		#region Joint miscellaneous functions
		/// <summary>
		/// Attach the joint to some new bodies.
		///
		/// If the joint is already attached, it will be detached from the old bodies first.
		/// To attach this joint to only one body, set body1 or body2 to zero - a zero body
		/// refers to the static environment.
		/// Setting both bodies to zero puts the joint into "limbo", i.e. it will have no
		/// effect on the simulation.
		/// Some joints, like hinge-2 need to be attached to two bodies to work.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="body1">A  dBodyID</param>
		/// <param name="body2">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAttach(dJointID joint, dBodyID body1, dBodyID body2);
		
		/// <summary>
		/// Set the joint's user-data pointer.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="data">An IntPtr</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetData(dJointID joint, IntPtr data);
		
		/// <summary>
		/// Get the joint's user-data pointer.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <returns>An IntPtr</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr dJointGetData(dJointID joint);
		
		/// <summary>
		/// Get the joint's type.
		///
		/// The available joint types are:
		/// 	dJointTypeBall:  		A ball-and-socket joint.
		/// 	dJointTypeHinge:  		A hinge joint.
		/// 	dJointTypeSlider:  		A slider joint.
		/// 	dJointTypeContact:		A contact joint.
		/// 	dJointTypeUniversal:	A universal joint.
		/// 	dJointTypeHinge2:		A hinge-2 joint.
		/// 	dJointTypeFixed:		A fixed joint.
		/// 	dJointTypeAMotor:		An angular motor joint.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dJointGetType(dJointID joint);
		
		/// <summary>
		/// Return the bodies that this joint connects.
		///
		/// If index is 0 the ``first'' body will be returned,
		/// corresponding to the body1 argument of dJointAttach.
		/// If index is 1 the ``second'' body will be returned,
		/// corresponding to the body2 argument of dJointAttach.
		///
		/// If one of these returned body IDs is zero, the joint
		/// connects the other body to the static environment.
		///
		/// If both body IDs are zero, the joint is in ``limbo'' and has no effect on the simulation.
		/// </summary>
		/// <returns>A dBodyID</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="index">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dBodyID dJointGetBody(dJointID joint, int index);
		
		/// <summary>
		/// Pass a dJointFeedback structure to the joint to collect information about
		/// the forces applied by each joint.
		///
		/// Notes from the ODE docs:
		/// 	During the world time step, the forces that are applied by each joint are computed.
		/// 	These forces are added directly to the joined bodies, and the user normally has no
		/// 	way of telling which joint contributed how much force.
		///		If this information is desired then the user can allocate a dJointFeedback structure
		/// 	and pass its pointer to the dJointSetFeedback() function.
		///
		/// 	The feedback information structure is defined as follows (NOTE: C# version listed here):
		/// 			public struct dJointFeedback {
		///					public dVector3 f1;		/* force that joint applies to body 1  */
		///					public dVector3 t1;		/* torque that joint applies to body 1 */
		///					public dVector3 f2;		/* force that joint applies to body 2  */
		///					public dVector3 t2;		/* torque that joint applies to body 2 */
		///				};
		///		During the time step any feedback structures that are attached to joints will be
		/// 	filled in with the joint's force and torque information.
		///
		/// 	The dJointGetFeedback() function returns the current feedback structure pointer,
		/// 	or 0 if none is used (this is the default).
		///
		/// 	dJointSetFeedback() can be passed 0 to disable feedback for that joint.
		///
		/// 	TODO: Will passing 0 work?  Seems as if something else needs to be passed here
		///
		///		Now for some API design notes. It might seem strange to require that users perform the
		/// 	allocation of these structures. Why not just store the data statically in each joint?
		/// 	The reason is that not all users will use the feedback information, and even when it
		/// 	is used not all joints will need it. It will waste memory to store it statically,
		/// 	especially as this structure could grow to store a lot of extra information in the future.
		///		Why not have ODE allocate the structure itself, at the user's request? The reason is
		/// 	that contact joints (which are created and destroyed every time step) would require a
		/// 	lot of time to be spent in memory allocation if feedback is required. Letting the user
		/// 	do the allocation means that a better allocation strategy can be provided, e.g simply
		/// 	allocating them out of a fixed array.
		///
		///		The alternative to this API is to have a joint-force callback. This would work of course,
		/// 	but it has a few problems. First, callbacks tend to pollute APIs and sometimes require
		/// 	the user to go through unnatural contortions to get the data to the right place.
		/// 	Second, this would expose ODE to being changed in the middle of a step (which would have
		/// 	bad consequences), and there would have to be some kind of guard against this or a debugging
		/// 	check for it - which would complicate things.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="feedback">A  dJointFeedback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetFeedback(dJointID joint, ref dJointFeedback feedback);
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dJointGetFeedback")]
		private extern unsafe static dJointFeedback *dJointGetFeedback_(dJointID joint);
		/// <summary>
		/// Get the jointfeedback structure from the joint to get information about
		/// the forces applied by each joint.
		///
		/// 	The feedback information structure is defined as follows (NOTE: C# version listed here):
		/// 			public struct dJointFeedback {
		///					public dVector3 f1;		/* force that joint applies to body 1  */
		///					public dVector3 t1;		/* torque that joint applies to body 1 */
		///					public dVector3 f2;		/* force that joint applies to body 2  */
		///					public dVector3 t2;		/* torque that joint applies to body 2 */
		///				};
		///
		/// 	The dJointGetFeedback() function returns the current feedback structure pointer,
		/// 	or 0 if none is used (this is the default).
		/// 	TODO: Will passing 0 work or does something special have to be done?
		/// </summary>
		/// <returns>A dJointFeedback</returns>
		/// <param name="body">A  dBodyID</param>
		public static dJointFeedback dJointGetFeedback(dBodyID body) 
		{
			unsafe
			{
				dJointFeedback *v=(dJointFeedback*)dJointGetFeedback_(body);
				return *v;
			}
		}
		
		/// <summary>
		/// Test if the two specified bodies are connected by a joint.
		///
		/// Return 1 if yes, otherwise return 0
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body1">A  dBodyID</param>
		/// <param name="body2">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dAreConnected(dBodyID body1, dBodyID body2);
		
		/// <summary>
		/// Return 1 if the two bodies are connected together by a joint that does not
		/// have type joint_type, otherwise return 0.
		/// joint_type is a dJointTypeXXX constant.
		/// This is useful for deciding whether to add contact joints between two bodies:
		/// if they are already connected by non-contact joints then it may not be
		/// appropriate to add contacts, however it is okay to add more contact between
		/// bodies that already have contacts.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="body1">A  dBodyID</param>
		/// <param name="body2">A  dBodyID</param>
		/// <param name="joint_type">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dAreConnectedExcluding(dBodyID body1, dBodyID body2, int joint_type);
		#endregion Joint miscellaneous functions
		#region Joint parameter setting functions
		#region Ball Joint functions
		/// <summary>
		/// Method dJointSetBallAnchor
		/// Set the joint anchor point.
		/// The joint will try to keep this point on each body together.
		/// The input is specified in world coordinates.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetBallAnchor(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Method dJointGetBallAnchor
		/// Get the joint anchor point on body 1, in world coordinates.
		/// If the joint is perfectly satisfied, this will be the same as the point on body 2.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetBallAnchor(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Method dJointGetBallAnchor2
		/// Get the joint anchor point on body 2, in world coordinates.
		/// You can think of a ball and socket joint as trying to keep the
		/// result of dJointGetBallAnchor() and dJointGetBallAnchor2() the same.
		/// If the joint is perfectly satisfied, this function will return the
		/// same value as dJointGetBallAnchor to within roundoff errors.
		/// dJointGetBallAnchor2 can be used, along with dJointGetBallAnchor,
		/// to see how far the joint has come apart.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetBallAnchor2(dJointID joint, ref dVector3 result);
		#endregion Ball Joint functions
		#region Hinge Joint functions
		/// <summary>
		/// Set hinge anchor parameters
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHingeAnchor(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set hinge axis parameters
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHingeAxis(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 1.
		/// If the joint is perfectly satisfied, this will be the same as the point on body 2.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHingeAnchor(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 2.
		/// If the joint is perfectly satisfied, this will return the same value as dJointGetHingeAnchor.
		/// If not, this value will be slightly different.
		/// This can be used, for example, to see how far the joint has come apart.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHingeAnchor2(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the hinge axis parameter for the joint.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHingeAxis(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the hinge angle of the joint.
		/// The angle is measured between the two bodies, or between the body
		/// and the static environment.
		/// The angle will be between -pi..pi.
		/// When the hinge anchor or axis is set, the current position of the
		/// attached bodies is examined and that position will be the zero angle.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHingeAngle(dJointID joint);
		
		/// <summary>
		/// Get the time derivative of the hinge angle of the joint
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHingeAngleRate(dJointID joint);
		
		/// <summary>
		/// Set limit/motor parameters for a hinge joint
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		/// <param name="value">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHingeParam(dJointID joint, dJointParams parameter, dReal value);
		
		/// <summary>
		/// Get limit/motor parameters for a hinge joint
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHingeParam(dJointID joint, dJointParams parameter);
		
		/// <summary>
		/// Applies the torque about the hinge axis.
		///
		/// That is, it applies a torque with magnitude torque, in the direction of
		/// the hinge axis, to body 1, and with the same magnitude but in opposite
		/// direction to body 2.
		/// </summary>
		/// <remarks>
		/// This function is just a wrapper for dBodyAddTorque
		/// </remarks>
		/// <param name="joint">A  dJointID</param>
		/// <param name="torque">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAddHingeTorque(dJointID joint, dReal torque);
		#endregion Hinge Joint functions
		#region Slider Joint functions
		/// <summary>
		/// Set the slider axis parameter.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetSliderAxis(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the slider axis parameter
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetSliderAxis(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the slider linear position (i.e. the slider's ``extension'')
		///
		/// When the axis is set, the current position of the attached bodies
		/// is examined and that position will be the zero position.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetSliderPosition(dJointID joint);
		
		/// <summary>
		/// Get the time derivative of the slider linear position.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetSliderPositionRate(dJointID joint);
		
		/// <summary>
		/// Set limit/motor parameters for a slider joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		/// <param name="value">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetSliderParam(dJointID joint, dJointParams parameter, dReal value);
		
		/// <summary>
		/// Get limit/motor parameters for a slider joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetSliderParam(dJointID joint, dJointParams parameter);
		
		/// <summary>
		/// Applies the given force in the slider's direction.
		/// That is, it applies a force with magnitude force, in the direction
		/// slider's axis, to body1, and with the same magnitude but opposite
		/// direction to body2.
		/// </summary>
		/// <remarks>
		/// This function is just a wrapper for dBodyAddForce.
		/// </remarks>
		/// <param name="joint">A  dJointID</param>
		/// <param name="force">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAddSliderForce(dJointID joint, dReal force);
		#endregion Slider Joint functions
		#region Hinge-2 Joint functions
		/// <summary>
		/// Set hinge-2 anchor parameters
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHinge2Anchor(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set hinge-2 axis 1 parameters
		///
		/// Axis 1 and axis 2 must not lie on the same line
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHinge2Axis1(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set hinge-2 axis 2 parameters
		///
		/// Axis 1 and axis 2 must not lie on the same line
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHinge2Axis2(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 1.
		/// If the joint is perfectly satisfied, this will be the same as the point on body 2.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHinge2Anchor(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 2.
		/// If the joint is perfectly satisfied, this will return the same value as dJointGetHinge2Anchor.
		/// If not, this value will be slightly different.
		/// This can be used, for example, to see how far the joint has come apart.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHinge2Anchor2(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get hinge-2 axis 1 parameters.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHinge2Axis1(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get hinge-2 axis 2 parameters.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetHinge2Axis2(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the hinge-2 angles (around axis 1 and axis 2)
		///
		/// When the anchor or axis is set, the current position of the attached bodies
		/// is examined and that position will be the zero angle.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHinge2Angle1(dJointID joint);
		
		/// <summary>
		/// Get the time derivative of hinge-2 angle 1
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHinge2Angle1Rate(dJointID joint);
		
		/// <summary>
		/// Get the time derivative of hinge-2 angle 2
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHinge2Angle2Rate(dJointID joint);
		
		/// <summary>
		/// Set limit/motor parameters for a hinge-2 joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		/// <param name="value">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetHinge2Param(dJointID joint, dJointParams parameter, dReal value);
		
		/// <summary>
		/// Get limit/motor parameters for a hinge-2 joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetHinge2Param(dJointID joint, dJointParams parameter);
		
		/// <summary>
		/// Applies torque1 about the hinge2's axis 1, and torque2 about the hinge2's axis 2.
		/// This function is just a wrapper for dBodyAddTorque.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="torque1">A  dReal</param>
		/// <param name="torque2">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAddHinge2Torques(dJointID joint, dReal torque1, dReal torque2);
		#endregion Hinge-2 Joint functions
		#region Universal Joint functions
		/// <summary>
		/// Set universal joint anchor parameters.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetUniversalAnchor(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set universal joint axis 1 parameters
		///
		/// Axis 1 and axis 2 should be perpendicular to each other.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetUniversalAxis1(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set universal joint axis 2 parameters
		///
		/// Axis 1 and axis 2 should be perpendicular to each other.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetUniversalAxis2(dJointID joint, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 1.
		/// If the joint is perfectly satisfied, this will be the same as the point on body 2.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetUniversalAnchor(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get the joint anchor point, in world coordinates.
		/// This returns the point on body 2.
		/// You can think of the ball and socket part of a universal joint as trying
		/// to keep the result of dJointGetBallAnchor() and dJointGetBallAnchor2() the same.
		/// If the joint is perfectly satisfied, this function will return the same value as
		/// dJointGetUniversalAnchor to within roundoff errors.
		/// dJointGetUniversalAnchor2 can be used, along with dJointGetUniversalAnchor, to
		/// see how far the joint has come apart.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetUniversalAnchor2(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get parameters for universal joint axis 1
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetUniversalAxis1(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Get parameters for universal joint axis 2
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetUniversalAxis2(dJointID joint, ref dVector3 result);
		
		/// <summary>
		/// Set limit/motor parameters for a universal joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		/// <param name="value">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetUniversalParam(dJointID joint, dJointParams parameter, dReal value);
		
		/// <summary>
		/// Get limit/motor parameters for a universal joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetUniversalParam(dJointID joint, dJointParams parameter);
		
		/// <summary>
		/// Applies torque1 about the universal's axis 1, and torque2 about the universal's axis 2.
		/// </summary>
		/// <remarks>
		/// This function is just a wrapper for dBodyAddTorque.
		/// </remarks>
		/// <param name="joint">A  dJointID</param>
		/// <param name="torque1">A  dReal</param>
		/// <param name="torque2">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAddUniversalTorques(dJointID joint, dReal torque1, dReal torque2);
		
		// TODO: Document this - not found in ode docs
		/// <summary>
		/// 
		/// </summary>
		/// <param name="joint"></param>
		/// <returns></returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetUniversalAngle1(dJointID joint);
		
		// TODO: Document this - not found in ode docs
		/// <summary>
		/// 
		/// </summary>
		/// <param name="joint"></param>
		/// <returns></returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetUniversalAngle2(dJointID joint);
		
		// TODO: Document this - not found in ode docs
		/// <summary>
		/// 
		/// </summary>
		/// <param name="joint"></param>
		/// <returns></returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetUniversalAngle1Rate(dJointID joint);
		
		// TODO: Document this - not found in ode docs
		/// <summary>
		/// 
		/// </summary>
		/// <param name="joint"></param>
		/// <returns></returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetUniversalAngle2Rate(dJointID joint);
		#endregion Universal Joint functions
		#region Fixed Joint functions
		/// <summary>
		/// Call this on the fixed joint after it has been attached to remember the current desired
		/// relative offset and desired relative rotation between the bodies.
		/// </summary>
		/// <remarks>
		/// The fixed joint maintains a fixed relative position and orientation between two bodies,
		/// or between a body and the static environment.
		/// Using this joint is almost never a good idea in practice, except when debugging.
		/// If you need two bodies to be glued together it is better to represent that as a single body.
		/// </remarks>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetFixed(dJointID joint);
		#endregion Fixed Joint functions
		#region Angular Motor Joint functions
		/// <summary>
		/// Set the angular motor mode.
		/// The mode parameter must be one of the following constants:
		/// 	dAMotorUser:	The AMotor axes and joint angle settings are entirely controlled by the user.
		/// 					This is the default mode.
		///		dAMotorEuler:	Euler angles are automatically computed.
		/// 					The axis a1 is also automatically computed.
		/// 					The AMotor axes must be set correctly when in this mode, as described below.
		/// 					When this mode is initially set the current relative orientations of the
		/// 					bodies will correspond to all euler angles at zero.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetAMotorMode(dJointID joint, int mode);
		
		/// <summary>
		/// Get the angular motor mode.
		/// The mode parameter will be one of the following constants:
		/// 	dAMotorUser:	The AMotor axes and joint angle settings are entirely controlled by the user.
		/// 					This is the default mode.
		///		dAMotorEuler:	Euler angles are automatically computed.
		/// 					The axis a1 is also automatically computed.
		/// 					The AMotor axes must be set correctly when in this mode, as described below.
		/// 					When this mode is initially set the current relative orientations of the
		/// 					bodies will correspond to all euler angles at zero.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dJointGetAMotorMode(dJointID joint);
		
		/// <summary>
		/// Set the number of angular axes that will be controlled by the AMotor.
		/// The argument num can range from 0 (which effectively deactivates the joint) to 3.
		/// This is automatically set to 3 in dAMotorEuler mode.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="num">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetAMotorNumAxes(dJointID joint, int num);
		
		/// <summary>
		/// Get the number of angular axes controlled by the AMotor.
		/// The number of axes can range from 0 (which effectively deactivates the joint) to 3.
		/// This is automatically set to 3 in dAMotorEuler mode.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="joint">A  dJointID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dJointGetAMotorNumAxes(dJointID joint);
		
		/// <summary>
		/// Set the AMotor axes.
		/// The anum argument selects the axis to change (0,1 or 2).
		/// Each axis can have one of three ``relative orientation'' modes, selected by rel:
		/// 	*	0: The axis is anchored to the global frame.
		///		*	1: The axis is anchored to the first body.
		///		*	2: The axis is anchored to the second body.
		///
		/// The axis vector (x,y,z) is always specified in global coordinates regardless of the setting of rel.
		///
		/// For dAMotorEuler mode:
		/// 	* Only axes 0 and 2 need to be set. Axis 1 will be determined automatically at each time step.
		///		* Axes 0 and 2 must be perpendicular to each other.
		///		* Axis 0 must be anchored to the first body, axis 2 must be anchored to the second body.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		/// <param name="rel">An int</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetAMotorAxis(dJointID joint, int anum, int rel,
			dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Get the specified AMotor axis.
		/// The anum argument selects the axis to get (0,1 or 2).
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointGetAMotorAxis(dJointID joint, int anum, ref dVector3 result);
		
		/// <summary>
		/// Get the relative orientation mode for the specified axis
		/// The anum argument selects the axis to get (0,1 or 2).
		/// The return value will represent one of three ``relative orientation'' modes:
		/// 	*	0: The axis is anchored to the global frame.
		///		*	1: The axis is anchored to the first body.
		///		*	2: The axis is anchored to the second body.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dJointGetAMotorAxisRel(dJointID joint, int anum);
		
		/// <summary>
		/// Tell the AMotor what the current angle is along axis anum.
		/// This function should only be called in dAMotorUser mode, because in this mode
		/// the AMotor has no other way of knowing the joint angles.
		/// The angle information is needed if stops have been set along the axis,
		/// but it is not needed for axis motors.
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		/// <param name="angle">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetAMotorAngle(dJointID joint, int anum, dReal angle);
		
		/// <summary>
		/// Return the current angle for axis anum.
		/// In dAMotorUser mode this is simply the value that was set with dJointSetAMotorAngle.
		/// In dAMotorEuler mode this is the corresponding euler angle.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetAMotorAngle(dJointID joint, int anum);
		
		/// <summary>
		/// Return the current angle rate for axis anum.
		/// In dAMotorUser mode this is always zero, as not enough information is available.
		/// In dAMotorEuler mode this is the corresponding euler angle rate.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="anum">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetAMotorAngleRate(dJointID joint, int anum);
		
		/// <summary>
		/// Set limit/motor parameters for a an angular motor joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		/// <param name="value">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointSetAMotorParam(dJointID joint, dJointParams parameter, dReal value);
		
		/// <summary>
		/// Get limit/motor parameters for a an angular motor joint
		///
		/// See http://ode.org/ode-latest-userguide.html#sec_7_5_1 for details
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="joint">A  dJointID</param>
		/// <param name="parameter">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dJointGetAMotorParam(dJointID joint, dJointParams parameter);
		
		/// <summary>
		/// Applies torque0 about the AMotor's axis 0,
		/// torque1 about the AMotor's axis 1,
		/// and torque2 about the AMotor's axis 2.
		/// If the motor has fewer than three axes, the higher torques are ignored.
		/// </summary>
		/// <remarks>
		/// This function is just a wrapper for dBodyAddTorque.
		/// </remarks>
		/// <param name="joint">A  dJointID</param>
		/// <param name="torque1">A  dReal</param>
		/// <param name="torque2">A  dReal</param>
		/// <param name="torque3">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dJointAddAMotorTorques(dJointID joint, dReal torque1, dReal torque2, dReal torque3);
		#endregion Angular Motor Joint functions
		#endregion Joint parameter setting functions
		#endregion Joint functions
		
		#region Mass functions
		/// <summary>
		/// Set all the mass parameters to zero
		/// </summary>
		/// <param name="mass">A reference to a dMass</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetZero(ref dMass mass);
		
		/// <summary>
		/// Set the mass parameters to the given values.
		/// </summary>
		/// <remarks>
		/// The inertia matrix looks like this:
		///     [ I11 I12 I13 ]
		///     [ I12 I22 I23 ]
		///     [ I13 I23 I33 ]
		/// </remarks>
		/// <param name="mass">A reference to a dMass</param>
		/// <param name="themass">the mass of the body</param>
		/// <param name="cgx">the x coordinate for the center of gravity position in the body frame</param>
		/// <param name="cgy">the y coordinate for the center of gravity position in the body frame</param>
		/// <param name="cgz">the z coordinate for the center of gravity position in the body frame</param>
		/// <param name="I11">An element of the inertia matrix</param>
		/// <param name="I22">An element of the inertia matrix</param>
		/// <param name="I33">An element of the inertia matrix</param>
		/// <param name="I12">An element of the inertia matrix</param>
		/// <param name="I13">An element of the inertia matrix</param>
		/// <param name="I23">An element of the inertia matrix</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetParameters(ref dMass mass, dReal themass,
			dReal cgx, dReal cgy, dReal cgz,
			dReal I11, dReal I22, dReal I33,
			dReal I12, dReal I13, dReal I23);
		
		/// <summary>
		/// Set the mass parameters to represent a sphere of the given radius and density, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="density">A  dReal</param>
		/// <param name="radius">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetSphere(ref dMass mass, dReal density, dReal radius);
		
		/// <summary>
		/// Set the mass parameters to represent a sphere of the given total mass and radius, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="total_mass">A  dReal</param>
		/// <param name="radius">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetSphereTotal(ref dMass mass, dReal total_mass, dReal radius);
		
		/// <summary>
		/// Set the mass parameters to represent a capped cylinder of the given parameters and density, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <remarks>
		/// The cylinder's long axis is oriented along the body's x, y or z axis according to the value of direction (1=x, 2=y, 3=z).
		/// </remarks>
		/// <param name="mass">A  dMass</param>
		/// <param name="density">The density of the cylinder</param>
		/// <param name="direction">The orientation of the cylinder's long axis (1=x, 2=y, 3=z)</param>
		/// <param name="radius">The radius of the cylinder (and the spherical cap)</param>
		/// <param name="length">The length of the cylinder (not counting the spherical cap)</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetCapsule(ref dMass mass, dReal density, int direction,
			dReal radius, dReal length);
		
		/* TLT comment:
		 Calls dMassSetCapsule and dMassAdjust internally.
		 parameter a = radius, parameter b = length - should probably name them this, but
		 for now am following the Ode code.
		 */
		/// <summary>
		/// Set the mass parameters to represent a capped cylinder of the given parameters and total mass, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <remarks>
		/// The cylinder's long axis is oriented along the body's x, y or z axis according to the value of direction (1=x, 2=y, 3=z).
		/// </remarks>
		/// <param name="mass">A  dMass</param>
		/// <param name="total_mass">The total mass of the cylinder</param>
		/// <param name="direction">The orientation of the cylinder's long axis (1=x, 2=y, 3=z)</param>
		/// <param name="radius">The radius of the cylinder (and the spherical cap)</param>
		/// <param name="length">The length of the cylinder (not counting the spherical cap)</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetCapsuleTotal(ref dMass mass, dReal total_mass, int direction,
			dReal radius, dReal length);
		
		/// <summary>
		/// Set the mass parameters to represent a flat-ended cylinder of the given parameters and density, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <remarks>
		/// The cylinder's long axis is oriented along the body's x, y or z axis according to the value of direction (1=x, 2=y, 3=z).
		/// </remarks>
		/// <param name="mass">A  dMass</param>
		/// <param name="density">A  dReal</param>
		/// <param name="direction">An int</param>
		/// <param name="radius">The radius of the cylinder</param>
		/// <param name="length">The length of the cylinder</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetCylinder(ref dMass mass, dReal density, int direction,
			dReal radius, dReal length);
		
		/// <summary>
		/// Set the mass parameters to represent a flat-ended cylinder of the given parameters and total mass, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <remarks>
		/// The cylinder's long axis is oriented along the body's x, y or z axis according to the value of direction (1=x, 2=y, 3=z).
		/// </remarks>
		/// <param name="mass">A  dMass</param>
		/// <param name="total_mass">A  dReal</param>
		/// <param name="direction">An int</param>
		/// <param name="radius">The radius of the cylinder</param>
		/// <param name="length">The length of the cylinder</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetCylinderTotal(ref dMass mass, dReal total_mass, int direction,
			dReal radius, dReal length);
		
		/// <summary>
		/// Set the mass parameters to represent a box of the given dimensions and density, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="density">The density of the box</param>
		/// <param name="lx">The side length of the box along the x axis</param>
		/// <param name="ly">The side length of the box along the y axis</param>
		/// <param name="lz">The side length of the box along the z axis</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetBox(ref dMass mass, dReal density,
			dReal lx, dReal ly, dReal lz);
		
		/// <summary>
		/// Set the mass parameters to represent a box of the given dimensions and total mass, with
		/// the center of mass at (0,0,0) relative to the body.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="total_mass">The total mass of the box</param>
		/// <param name="lx">The side length of the box along the x axis</param>
		/// <param name="ly">The side length of the box along the y axis</param>
		/// <param name="lz">The side length of the box along the z axis</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassSetBoxTotal(ref dMass mass, dReal total_mass,
			dReal lx, dReal ly, dReal lz);
		
		/// <summary>
		/// Given mass parameters for some object, adjust them so the total mass is now newmass
		/// </summary>
		/// <remarks>
		/// This is useful when using the "mass set" functions to set the mass parameters for
		/// certain objects - they take the object density, not the total mass.
		/// </remarks>
		/// <param name="mass">A  dMass</param>
		/// <param name="newmass">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassAdjust(ref dMass mass, dReal newmass);
		
		/// <summary>
		/// Given mass parameters for some object, adjust them to represent the object displaced
		/// by (x,y,z) relative to the body frame.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="x">The displacement along the x axis</param>
		/// <param name="y">The displacement along the y axis</param>
		/// <param name="z">The displacement along the z axis</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassTranslate(ref dMass mass, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Given mass parameters for some object, adjust them to represent the object rotated by R relative to the body frame.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="R">An  array of 12 elements containing a 3x4 rotation matrix</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassRotate(ref dMass mass, dReal[] R);
		
		/// <summary>
		/// Given mass parameters for some object, adjust them to represent the object rotated by R relative to the body frame.
		/// </summary>
		/// <param name="mass">A  dMass</param>
		/// <param name="R">A  dMatrix3</param>
		public static void dMassRotate(ref dMass mass, dMatrix3 R) { // for compatibility
		  dMassRotate(ref mass, R.ToArray());
		}
		
		/// <summary>
		/// Add the mass b to the mass a.
		/// </summary>
		/// <remarks>
		/// Should mass b be a reference as well?
		/// </remarks>
		/// <param name="a">A  dMass</param>
		/// <param name="b">A  dMass</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dMassAdd(ref dMass a, dMass b);
		#endregion Mass functions
		
		#region Collision functions
		/// <summary>
		/// Destroy a geom, removing it from any space it is in first. 
		/// This one function destroys a geom of any type, but to create a geom you 
		/// must call a creation function for that type.
		/// When a space is destroyed, if its cleanup mode is 1 (the default) then 
		/// all the geoms in that space are automatically destroyed as well.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomDestroy(dGeomID geom);
		
		/// <summary>
		/// Set the user-defined data pointer stored in the geom.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="data">An IntPtr</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetData(dGeomID geom, IntPtr data);
		
		/// <summary>
		/// Get the user-defined data pointer stored in the geom.
		///
		/// WARNING: It is unclear from the ODE source and the documentation what the nature of
		/// user-data is.
		/// This function is here for the sake of completeness because it is part of ODE's public API, but
		/// has NOT been tested in any way.
		///
		/// Use at own risk.
		/// </summary>
		/// <returns>A void*</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static IntPtr dGeomGetData(dGeomID geom);
		
		/// <summary>
		/// Set the body associated with a placeable geom. 
		/// 
		/// Setting a body on a geom automatically combines the position vector and 
		/// rotation matrix of the body and geom, so that setting the position or 
		/// orientation of one will set the value for both objects.
		/// Setting a body ID of zero gives the geom its own position and rotation, 
		/// independent from any body. 
		/// If the geom was previously connected to a body then its new independent 
		/// position/rotation is set to the current position/rotation of the body.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="body">A  dBodyID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetBody(dGeomID geom, dBodyID body);
		
		/// <summary>
		/// Get the body associated with at placeable geom.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <returns>A dBodyID</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dBodyID dGeomGetBody(dGeomID geom);
		
		/// <summary>
		/// Set the position vector of a placeable geom. 
		/// 
		/// This function is analogous to dBodySetPosition.
		///  
		/// If the geom is attached to a body, the body's position will also be changed.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetPosition(dGeomID geom, dReal x, dReal y, dReal z);
		
		/// <summary>
		/// Set the rotation matrix of a placeable geom. 
		/// 
		/// This function is analogous to dBodySetRotation.
		///  
		/// If the geom is attached to a body, the body's rotation will also be changed.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="R">An  array of 12 elements containing a 3x4 rotation matrix</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetRotation(dGeomID geom, dReal[] R);

		/// <summary>
		/// Set the rotation matrix of a placeable geom. 
		/// 
		/// This function is analogous to dBodySetRotation.
		///  
		/// If the geom is attached to a body, the body's rotation will also be changed.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="R">A  dMatrix3</param>
		public static void dGeomSetRotation(dGeomID geom, dMatrix3 R) { // for compatibility
		  dGeomSetRotation(geom, R.ToArray());
		}
		
		/// <summary>
		/// Set the quaternion of a placeable geom. 
		/// 
		/// This function is analogous to dBodySetQuaternion. 
		/// 
		/// If the geom is attached to a body, the body's quaternion will also be changed.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="q">A  dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetQuaternion(dGeomID geom, dQuaternion q);
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dGeomGetPosition")]
		private extern unsafe static dReal *dGeomGetPosition_(dGeomID geom);
		/// <summary>
		/// Return the geom's position vector. 
		/// 
		/// In native ODE, the returned values are pointers to internal data 
		/// structures, so the vectors are valid until any changes are made to the 
		/// geom. 
		/// 
		/// If the geom is attached to a body, the body's position vector will be 
		/// returned, i.e. the result will be identical to calling dBodyGetPosition
		/// 
		/// dGeomGetQuaternion copies the geom's quaternion into the space provided. 
		/// If the geom is attached to a body, the body's quaternion will be returned, 
		/// i.e. the resulting quaternion will be the same as the result of calling dBodyGetQuaternion.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <returns>A dVector3</returns>
		/// <param name="geom">A  dGeomID</param>
		public static dVector3 dGeomGetPosition(dGeomID geom) 
		{
			unsafe
			{
				dVector3 *v=(dVector3*)dGeomGetPosition_(geom);
				return *v;
			}
		}
		
		[DllImport(ODE_NATIVE_LIBRARY,EntryPoint="dGeomGetRotation")]
		private extern unsafe static dReal *dGeomGetRotation_(dGeomID geom);
		/// <summary>
		/// Return the geom's rotation matrix.
		/// 
		/// In native ODE, the returned values are pointers to internal data 
		/// structures, so the matrices are valid until any changes are made to the 
		/// geom. 
		/// 
		/// If the geom is attached to a body, the body's rotation matrix will be 
		/// returned, i.e. the result will be identical to calling dBodyGetRotation.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <returns>A dMatrix3</returns>
		/// <param name="geom">A  dGeomID</param>
		public static dMatrix3 dGeomGetRotation(dGeomID geom) 
		{
			unsafe
			{
				dMatrix3 *m=(dMatrix3*)dGeomGetRotation_(geom);
				return *m;
			}
		}
		
		/// <summary>
		/// Get the geom's quaternion.
		/// 
		/// dGeomGetQuaternion copies the geom's quaternion into the structure provided. 
		/// 
		/// If the geom is attached to a body, the body's quaternion will be returned, 
		/// i.e. the resulting quaternion will be the same as the result of calling dBodyGetQuaternion.
		/// 
		/// Calling this function on a non-placeable geom results in a runtime error in the debug build of ODE.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="result">A  dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomGetQuaternion(dGeomID geom, ref dQuaternion result);
		
		/// <summary>
		/// Return in aabb an axis aligned bounding box that surrounds the given geom. 
		/// 
		/// The aabb array has elements (minx, maxx, miny, maxy, minz, maxz).
		///  
		/// If the geom is a space, a bounding box that surrounds all contained geoms is returned.
		/// 
		/// This function may return a pre-computed cached bounding box, if it can 
		/// determine that the geom has not moved since the last time the bounding box was computed.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="aabb">An Aabb</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomGetAABB(dGeomID geom, Aabb aabb);
		
		/// <summary>
		/// Return 1 if the given geom is a space, or 0 if not.		
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomIsSpace(dGeomID geom);
		
		/// <summary>
		/// Return the space that the given geometry is contained in, or return 0 if it is not contained in any space.
		/// </summary>
		/// <returns>A dSpaceID</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dSpaceID dGeomGetSpace(dGeomID geom);
		
		/// <summary>
		/// Given a geom, this returns its class number. The standard class numbers are:
		///		dSphereClass  			Sphere
		///		dBoxClass  				Box
		///		dCapsuleClass			Capped cylinder
		///		dCylinderClass  		Regular flat-ended cylinder
		///		dPlaneClass  			Infinite plane (non-placeable)
		///		dGeomTransformClass 	Geometry transform
		///		dRayClass  				Ray
		///		dTriMeshClass  			Triangle mesh
		///		dSimpleSpaceClass  		Simple space
		///		dHashSpaceClass  		Hash table based space
		/// 
		/// User defined classes will return their own numbers.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomGetClass(dGeomID geom);
		
		/// <summary>
		/// Set the ``category'' bitfield for the given geom. 
		/// This bitfield is used by spaces to govern which geoms will interact 
		/// with each other. 
		/// 
		/// The bit fields are guaranteed to be at least 32 bits wide. 
		/// 
		/// The default category and collide values for newly created geoms have all bits set.
		///
		/// Note this is NOT CLS-compliant (due to the use of ulong to hold the 32-bit bitfield)
		/// TODO: Implement a CLS-compliant work-around or justify why not
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="bits">An ulong</param>
		[CLSCompliant(false)]
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetCategoryBits(dGeomID geom, ulong bits);
		
		/// <summary>
		/// Set the ``collide'' bitfield for the given geom. 
		/// 
		/// This bitfield is used by spaces to govern which geoms will interact 
		/// with each other. 
		/// 
		/// The bit fields are guaranteed to be at least 32 bits wide. 
		/// 
		/// The default category and collide values for newly created geoms have all bits set.
		///
		/// Note this is NOT CLS-compliant (due to the use of ulong to hold the 32-bit bitfield)
		/// TODO: Implement a CLS-compliant work-around or justify why not
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="bits">An ulong</param>
		[CLSCompliant(false)]
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSetCollideBits(dGeomID geom, ulong bits);
		
		/// <summary>
		/// Get the ``category'' bitfield for the given geom. 
		/// This bitfield is used by spaces to govern which geoms will interact 
		/// with each other. 
		/// 
		/// The bit fields are guaranteed to be at least 32 bits wide. 
		/// 
		/// The default category and collide values for newly created geoms have all bits set.
		///
		/// Note this is NOT CLS-compliant (due to the use of ulong to hold the 32-bit bitfield)
		/// TODO: Implement a CLS-compliant work-around or justify why not
		/// </summary>
		/// <returns>An ulong</returns>
		/// <param name="geom">A  dGeomID</param>
		[CLSCompliant(false)]
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static ulong dGeomGetCategoryBits(dGeomID geom);
		
		/// <summary>
		/// Get the ``collide'' bitfield for the given geom. 
		/// This bitfield is used by spaces to govern which geoms will interact 
		/// with each other. 
		/// 
		/// The bit fields are guaranteed to be at least 32 bits wide. 
		/// 
		/// The default category and collide values for newly created geoms have all bits set.
		///
		/// Note this is NOT CLS-compliant (due to the use of ulong to hold the 32-bit bitfield)
		/// TODO: Implement a CLS-compliant work-around or justify why not
		/// </summary>
		/// <returns>An ulong</returns>
		/// <param name="geom">A  dGeomID</param>
		[CLSCompliant(false)]
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static ulong dGeomGetCollideBits(dGeomID geom);
		
		/// <summary>
		/// Enable a geom. 
		/// 
		/// Disabled geoms are completely ignored by dSpaceCollide and dSpaceCollide2,
		/// although they can still be members of a space.
		/// 
		/// New geoms are created in the enabled state.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomEnable(dGeomID geom);
		
		/// <summary>
		/// Disable a geom. 
		/// 
		/// Disabled geoms are completely ignored by dSpaceCollide and dSpaceCollide2,
		/// although they can still be members of a space.
		/// 
		/// New geoms are created in the enabled state.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomDisable(dGeomID geom);
		
		/// <summary>
		/// Returns 1 if a geom is enabled or 0 if it is disabled. 
		/// 
		/// New geoms are created in the enabled state.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomIsEnabled(dGeomID geom);
		#endregion Collision functions
		
		#region Collision Detection
		/// <summary>
		/// Given two geoms o1 and o2 that potentially intersect, generate contact 
		/// information for them. 
		/// 
		/// Internally, this just calls the correct class-specific collision functions
		/// for o1 and o2.
		/// 
		/// "flags" specifies how contacts should be generated if the geoms touch. The 
		/// lower 16 bits of flags is an integer that specifies the maximum number 
		/// of contact points to generate. Note that if this number is zero, this 
		/// function just pretends that it is one - in other words you can not ask 
		/// for zero contacts. All other bits in flags must be zero. 
		/// In the future the other bits may be used to select from different contact 
		/// generation strategies.
		/// 
		/// "contacts" points to an array of dContactGeom structures. The array must 
		/// be able to hold at least the maximum number of contacts. These 
		/// dContactGeom structures may be embedded within larger structures in the 
		/// array - the skip parameter is the byte offset from one dContactGeom to 
		/// the next in the array. If skip is sizeof(dContactGeom) then contact 
		/// points to a normal (C-style) array. It is an error for skip to be smaller
		/// than sizeof(dContactGeom).
		/// 
		/// If the geoms intersect, this function returns the number of contact points
		/// generated (and updates the contact array), otherwise it returns 0 (and the
		///  contact array is not touched).
		/// 
		/// If a space is passed as o1 or o2 then this function will collide all 
		/// objects contained in o1 with all objects contained in o2, and return 
		/// the resulting contact points. This method for colliding spaces with 
		/// geoms (or spaces with spaces) provides no user control over the 
		/// individual collisions. To get that control, use dSpaceCollide or 
		/// dSpaceCollide2 instead.
		/// 
		/// If o1 and o2 are the same geom then this function will do nothing and 
		/// return 0. Technically speaking an object intersects with itself, but 
		/// it is not useful to find contact points in this case.
		/// 
		/// This function does not care if o1 and o2 are in the same space or not 
		/// (or indeed if they are in any space at all).
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="o1">A  dGeomID</param>
		/// <param name="o2">A  dGeomID</param>
		/// <param name="flags">An int</param>
		/// <param name="contacts">A  dContactGeom[]</param>
		/// <param name="skip">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dCollide(dGeomID o1, dGeomID o2, int flags, [In,Out]dContactGeom[] contacts,
			int skip);
		
		/// <summary>
		/// This determines which pairs of geoms in a space may potentially intersect,
		/// and calls the callback function with each candidate pair. 
		/// 
		/// The callback function is of type dNearCallback, which is defined as: 
		///		typedef void dNearCallback (void *data, dGeomID o1, dGeomID o2);
		/// 
		/// The data argument is passed from dSpaceCollide directly to the callback 
		/// function. Its meaning is user defined. 
		/// The o1 and o2 arguments are the geoms that may be near each other.
		/// The callback function can call dCollide on o1 and o2 to generate contact 
		/// points between each pair. Then these contact points may be added to the 
		/// simulation as contact joints. The user's callback function can of course 
		/// chose not to call dCollide for any pair, e.g. if the user decides that 
		/// those pairs should not interact.
		/// 
		/// Other spaces that are contained within the colliding space are not treated 
		/// specially, i.e. they are not recursed into. The callback function may be 
		/// passed these contained spaces as one or both geom arguments.
		/// 
		/// dSpaceCollide() is guaranteed to pass all intersecting geom pairs to the 
		/// callback function, but it may also make mistakes and pass non-intersecting 
		/// pairs. The number of mistaken calls depends on the internal algorithms 
		/// used by the space. Thus you should not expect that dCollide will return 
		/// contacts for every pair passed to the callback.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="data">An IntPtr</param>
		/// <param name="callback">A  dNearCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceCollide(dSpaceID space, IntPtr data, dNearCallback callback);
		
		/// <summary>
		/// This function is similar to dSpaceCollide, except that it is passed two 
		/// geoms (or spaces) as arguments. It calls the callback for all 
		/// potentially intersecting pairs that contain one geom from o1 and one geom 
		/// from o2.
		/// 
		/// The exact behavior depends on the types of o1 and o2: 
		///		If one argument is a non-space geom and the other is a space, the 
		/// 	callback is called with all potential intersections between the geom and 
		/// 	the objects in the space.
		/// 	If both o1 and o2 are spaces then this calls the callback for all potentially 
		/// 	intersecting pairs that contain one geom from o1 and one geom from o2. The 
		/// 	algorithm that is used depends on what kinds of spaces are being collided. 
		/// 	If no optimized algorithm can be selected then this function will resort 
		/// 	to one of the following two strategies: 
		/// 		1. 	All the geoms in o1 are tested one-by-one against o2. 
		/// 		2. 	All the geoms in o2 are tested one-by-one against o1. 
		/// 	The strategy used may depend on a number of rules, but in general the 
		/// 	space with less objects has its geoms examined one-by-one. 
		/// 		-	If both arguments are the same space, this is equivalent to calling 
		/// 			dSpaceCollide on that space. 
		/// 		-	If both arguments are non-space geoms, this simply calls the callback 
		/// 			once with these arguments. 
		/// 
		/// If this function is given a space and an geom X in that same space, this 
		/// case is not treated specially. In this case the callback will always be 
		/// called with the pair (X,X), because an objects always intersects with 
		/// itself. The user may either test for this case and ignore it, or just 
		/// pass the pair (X,X) to dCollide (which will be guaranteed to return 0).
		/// </summary>
		/// <param name="o1">A  dGeomID</param>
		/// <param name="o2">A  dGeomID</param>
		/// <param name="data">An IntPtr</param>
		/// <param name="callback">A  dNearCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceCollide2(dGeomID o1, dGeomID o2, IntPtr data,
			dNearCallback callback);
		#endregion Collision Detection
		
		#region Sphere class
		/// <summary>
		/// Create a sphere geom of the given radius, and return its ID. If space is 
		/// nonzero, insert it into that space. The point of reference for a sphere 
		/// is its center.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="radius">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateSphere(dSpaceID space, dReal radius);
		
		/// <summary>
		/// Set the radius of the given sphere.
		/// </summary>
		/// <param name="sphere">A  dGeomID</param>
		/// <param name="radius">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomSphereSetRadius(dGeomID sphere, dReal radius);
		
		/// <summary>
		/// Return the radius of the given sphere.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="sphere">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomSphereGetRadius(dGeomID sphere);
		
		/// <summary>
		/// Return the depth of the point (x,y,z) in the given sphere. 
		/// 
		/// Points inside the geom will have positive depth, points outside it will 
		/// have negative depth, and points on the surface will have zero depth.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="sphere">A  dGeomID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomSpherePointDepth(dGeomID sphere, dReal x, dReal y, dReal z);
		#endregion Sphere class
		#region Box class
		/// <summary>
		/// Create a box geom of the given x/y/z side lengths (lx,ly,lz), and return 
		/// its ID. 
		/// 
		/// If space is nonzero, insert it into that space. The point of reference 
		/// for a box is its center.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="lx">A  dReal</param>
		/// <param name="ly">A  dReal</param>
		/// <param name="lz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateBox(dSpaceID space, dReal lx, dReal ly, dReal lz);
		
		/// <summary>
		/// Set the side lengths of the given box.
		/// </summary>
		/// <param name="box">A  dGeomID</param>
		/// <param name="lx">A  dReal</param>
		/// <param name="ly">A  dReal</param>
		/// <param name="lz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomBoxSetLengths(dGeomID box, dReal lx, dReal ly, dReal lz);
		
		/// <summary>
		/// Return in result the side lengths of the given box.
		/// </summary>
		/// <param name="box">A  dGeomID</param>
		/// <param name="result">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomBoxGetLengths(dGeomID box, ref dVector3 result);
		
		/// <summary>
		/// Return the depth of the point (x,y,z) in the given box. 
		/// 
		/// Points inside the geom will have positive depth, points outside it will 
		/// have negative depth, and points on the surface will have zero depth.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="box">A  dGeomID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomBoxPointDepth(dGeomID box, dReal x, dReal y, dReal z);
		#endregion Box class
		#region Plane class
		/// <summary>
		/// Create a plane geom of the given parameters, and return its ID. 
		/// 
		/// If space is nonzero, insert it into that space. The plane equation is 
		///		a*x+b*y+c*z = d
		/// 
		/// The plane's normal vector is (a,b,c), and it must have length 1. 
		/// 
		/// Planes are non-placeable geoms. This means that, unlike placeable geoms, 
		/// planes do not have an assigned position and rotation. This means that 
		/// the parameters (a,b,c,d) are always in global coordinates. In other words 
		/// it is assumed that the plane is always part of the static environment and 
		/// not tied to any movable object.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="a">A  dReal</param>
		/// <param name="b">A  dReal</param>
		/// <param name="c">A  dReal</param>
		/// <param name="d">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreatePlane(dSpaceID space, dReal a, dReal b, dReal c, dReal d);
		
		/// <summary>
		/// Set the parameters of the given plane.
		/// </summary>
		/// <param name="plane">A  dGeomID</param>
		/// <param name="a">A  dReal</param>
		/// <param name="b">A  dReal</param>
		/// <param name="c">A  dReal</param>
		/// <param name="d">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomPlaneSetParams(dGeomID plane, dReal a, dReal b, dReal c, dReal d);
		
		/// <summary>
		/// Return in result the parameters of the given plane.
		/// </summary>
		/// <param name="plane">A  dGeomID</param>
		/// <param name="result">A  dVector4</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomPlaneGetParams(dGeomID plane, ref dVector4 result);
		
		/// <summary>
		/// Return the depth of the point (x,y,z) in the given plane. 
		/// 
		/// Points inside the geom will have positive depth, points outside it will 
		/// have negative depth, and points on the surface will have zero depth.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="plane">A  dGeomID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomPlanePointDepth(dGeomID plane, dReal x, dReal y, dReal z);
		#endregion Plane class
		#region Capped cylinder class
		/// <summary>
		/// Create a capped cylinder geom of the given parameters, and return its ID. 
		/// If space is nonzero, insert it into that space.
		/// 
		/// A capped cylinder is like a normal cylinder except it has half-sphere 
		/// caps at its ends. This feature makes the internal collision detection 
		/// code particularly fast and accurate. The cylinder's length, not counting 
		/// the caps, is given by length. The cylinder is aligned along the geom's 
		/// local Z axis. The radius of the caps, and of the cylinder itself, is 
		/// given by radius.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="radius">A  dReal</param>
		/// <param name="length">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateCapsule(dSpaceID space, dReal radius, dReal length);
		
		/// <summary>
		/// Set the parameters of the given capped cylinder.
		/// </summary>
		/// <param name="ccylinder">A  dGeomID</param>
		/// <param name="radius">A  dReal</param>
		/// <param name="length">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomCapsuleSetParams(dGeomID ccylinder, dReal radius, dReal length);
		
		/// <summary>
		/// Return in radius and length the parameters of the given capped cylinder.
		/// </summary>
		/// <param name="ccylinder">A  dGeomID</param>
		/// <param name="radius">A  dReal</param>
		/// <param name="length">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomCapsuleGetParams(dGeomID ccylinder, ref dReal radius, ref dReal length);
		
		/// <summary>
		/// Return the depth of the point (x,y,z) in the given capped cylinder. 
		/// 
		/// Points inside the geom will have positive depth, points outside it will 
		/// have negative depth, and points on the surface will have zero depth.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="ccylinder">A  dGeomID</param>
		/// <param name="x">A  dReal</param>
		/// <param name="y">A  dReal</param>
		/// <param name="z">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomCapsulePointDepth(dGeomID ccylinder, dReal x, dReal y, dReal z);
		#endregion Capped cylinder class
		#region Ray class
		/// <summary>
		/// Create a ray geom of the given length, and return its ID. 
		/// 
		/// If space is nonzero, insert it into that space.
		/// </summary>
		/// <remarks>
		/// A ray is different from all the other geom classes in that it does not 
		/// represent a solid object. It is an infinitely thin line that starts from 
		/// the geom's position and extends in the direction of the geom's local Z-axis.
		/// 
		/// Calling dCollide between a ray and another geom will result in at most one 
		/// contact point. Rays have their own conventions for the contact information 
		/// in the dContactGeom structure (thus it is not useful to create contact 
		/// joints from this information):
		/// 
		/// 	pos - 		This is the point at which the ray intersects the surface of the 
		/// 				other geom, regardless of whether the ray starts from inside or 
		/// 				outside the geom.
		/// 	normal - 	This is the surface normal of the other geom at the contact point. 
		/// 				if dCollide is passed the ray as its first geom then the normal 
		/// 				will be oriented correctly for ray reflection from that surface 
		/// 				(otherwise it will have the opposite sign).
		/// 	depth - 	This is the distance from the start of the ray to the contact point. 
		/// 
		/// Rays are useful for things like visibility testing, determining the path of 
		/// projectiles or light rays, and for object placement.
		/// </remarks>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="length">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateRay(dSpaceID space, dReal length);
		
		/// <summary>
		/// Set the length of the given ray.
		/// </summary>
		/// <param name="ray">A  dGeomID</param>
		/// <param name="length">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRaySetLength(dGeomID ray, dReal length);
		
		/// <summary>
		/// Get the length of the given ray.
		/// </summary>
		/// <returns>A dReal</returns>
		/// <param name="ray">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dReal dGeomRayGetLength(dGeomID ray);
		
		/// <summary>
		/// Set the starting position (px,py,pz) and direction (dx,dy,dz) of the given ray. 
		/// The ray's rotation matrix will be adjusted so that the local Z-axis is aligned 
		/// with the direction. 
		/// 
		/// Note that this does not adjust the ray's length.
		/// </summary>
		/// <param name="ray">A  dGeomID</param>
		/// <param name="px">A  dReal</param>
		/// <param name="py">A  dReal</param>
		/// <param name="pz">A  dReal</param>
		/// <param name="dx">A  dReal</param>
		/// <param name="dy">A  dReal</param>
		/// <param name="dz">A  dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRaySet(dGeomID ray, dReal px, dReal py, dReal pz,
			dReal dx, dReal dy, dReal dz);
		
		/// <summary>
		/// Get the starting position (start) and direction (dir) of the ray. 
		/// The returned direction will be a unit length vector.
		/// </summary>
		/// <param name="ray">A  dGeomID</param>
		/// <param name="start">A  dVector3</param>
		/// <param name="dir">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRayGet(dGeomID ray, dVector3 start, dVector3 dir);
		
		
		/*
		 * Set/get ray flags that influence ray collision detection.
		 * These flags are currently only noticed by the trimesh collider, because
		 * they can make a major differences there.
		 */
		/// <summary>
		/// Method dGeomRaySetParams
		/// TODO: Document me
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="FirstContact">An int</param>
		/// <param name="BackfaceCull">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRaySetParams(dGeomID g, int FirstContact, int BackfaceCull);
		
		/// <summary>
		/// Method dGeomRayGetParams
		/// TODO: Document me
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="FirstContact">An int</param>
		/// <param name="BackfaceCull">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRayGetParams(dGeomID g, ref int FirstContact, ref int BackfaceCull);
		
		/// <summary>
		/// Method dGeomRayGetParams
		/// TODO: Document me
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="FirstContact">An int[]</param>
		/// <param name="BackfaceCull">An int[]</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRayGetParams(dGeomID g, [Out]int[] FirstContact, [Out]int[] BackfaceCull);
		
		/// <summary>
		/// Method dGeomRaySetClosestHit
		/// TODO: Document me
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="closestHit">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomRaySetClosestHit(dGeomID g, int closestHit);
		
		/// <summary>
		/// Method dGeomRayGetClosestHit
		/// TODO: Document me
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomRayGetClosestHit(dGeomID g);
		#endregion Ray class
		#region Geometry transform class
		/// <summary>
		/// Create a new geometry transform object, and return its ID. 
		/// If space is nonzero, insert it into that space. 
		/// On creation the encapsulated geometry is set to 0.
		/// </summary>
		/// <remarks>
		/// A geometry transform `T' is a geom that encapsulates another geom `E', 
		/// allowing E to be positioned and rotated arbitrarily with respect to 
		/// its point of reference.
		/// Most placeable geoms (like the sphere and box) have their point of 
		/// reference corresponding to their center of mass, allowing them to be 
		/// easily connected to dynamics objects. Transform objects give you more 
		/// flexibility - for example, you can offset the center of a sphere, or 
		/// rotate a cylinder so that its axis is something other than the default.
		/// T mimics the object E that it encapsulates: T is inserted into a space 
		/// and attached to a body as though it was E. E itself must not be inserted 
		/// into a space or attached to a body. E's position and rotation are set to 
		/// constant values that say how it is transformed relative to T. If E's 
		/// position and rotation are left at their default values, T will behave 
		/// exactly like E would have if you had used it directly.
		/// </remarks>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateGeomTransform(dSpaceID space);
		
		/// <summary>
		/// Set the geom that the geometry transform g encapsulates. The object obj 
		/// must not be inserted into any space, and must not be associated with any body.
		/// 
		/// If g has its clean-up mode turned on, and it already encapsulates an object, 
		/// the old object will be destroyed before it is replaced with the new one.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="obj">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTransformSetGeom(dGeomID g, dGeomID obj);
		
		/// <summary>
		/// Get the geom that the geometry transform g encapsulates.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dGeomTransformGetGeom(dGeomID g);
		
		/// <summary>
		/// Set the clean-up mode of geometry transform g. 
		/// 
		/// If the clean-up mode is 1, then the encapsulated object will be destroyed 
		/// when the geometry transform is destroyed. 
		/// If the clean-up mode is 0 this does not happen. 
		/// 
		/// The default clean-up mode is 0.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTransformSetCleanup(dGeomID g, int mode);
		
		/// <summary>
		/// Get the clean-up mode of geometry transform g. 
		/// 
		/// If the clean-up mode is 1, then the encapsulated object will be destroyed 
		/// when the geometry transform is destroyed. 
		/// If the clean-up mode is 0 this does not happen. 
		/// 
		/// The default clean-up mode is 0.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomTransformGetCleanup(dGeomID g);
		
		/// <summary>
		/// Set and get the "information" mode of geometry transform g. 
		/// 
		/// The mode can be 0 or 1. The default mode is 0.
		/// With mode 0, when a transform object is collided with another object 
		/// (using dCollide (tx_geom,other_geom,...)), the g1 field of the 
		/// dContactGeom structure is set to the geom that is encapsulated by the 
		/// transform object. This value of g1 allows the caller to interrogate the 
		/// type of the geom that is transformed, but it does not allow the caller 
		/// to determine the position in global coordinates or the associated body, 
		/// as both of these properties are used differently for encapsulated geoms.
		/// With mode 1, the g1 field of the dContactGeom structure is set to the 
		/// transform object itself. This makes the object appear just like any other 
		/// kind of geom, as dGeomGetBody will return the attached body, and 
		/// dGeomGetPosition will return the global position. 
		/// To get the actual type of the encapsulated geom in this case, 
		/// dGeomTransformGetGeom must be used.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTransformSetInfo(dGeomID g, int mode);
		
		/// <summary>
		/// Set and get the "information" mode of geometry transform g. 
		/// 
		/// The mode can be 0 or 1. The default mode is 0.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomTransformGetInfo(dGeomID g);
		#endregion Geometry transform class
		
		#region Utility Functions
		/// <summary>
		/// Given two line segments A and B with endpoints a1-a2 and b1-b2, return 
		/// the points on A and B that are closest to each other (in cp1 and cp2). 
		/// 
		/// In the case of parallel lines where there are multiple solutions, a 
		/// solution involving the endpoint of at least one line will be returned. 
		/// This will work correctly for zero length lines, e.g. if a1==a2 and/or b1==b2.
		/// </summary>
		/// <param name="a1">A  dVector3</param>
		/// <param name="a2">A  dVector3</param>
		/// <param name="b1">A  dVector3</param>
		/// <param name="b2">A  dVector3</param>
		/// <param name="cp1">A  dVector3</param>
		/// <param name="cp2">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dClosestLineSegmentPoints(ref dVector3 a1, ref dVector3 a2,
			ref dVector3 b1, ref dVector3 b2,
			ref dVector3 cp1, ref dVector3 cp2);
		
		/// <summary>
		/// Given boxes (p1,R1,side1) and (p2,R2,side2), return 1 if they intersect 
		/// or 0 if not. p is the center of the box, R is the rotation matrix for 
		/// the box, and side is a vector of x/y/z side lengths.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="_p1">A  dVector3</param>
		/// <param name="R1">A  dMatrix3</param>
		/// <param name="side1">A  dVector3</param>
		/// <param name="_p2">A  dVector3</param>
		/// <param name="R2">A  dMatrix3</param>
		/// <param name="side2">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dBoxTouchesBox(ref dVector3 _p1, ref dMatrix3 R1,
			ref dVector3 side1, ref dVector3 _p2,
			ref dMatrix3 R2, ref dVector3 side2);
		
		/// <summary>
		/// This function can be used as the AABB-getting function in a geometry class, 
		/// if you don't want to compute tight bounds for the AABB. 
		/// It returns +/- infinity in each direction.
		/// </summary>
		/// <param name="geom">A  dGeomID</param>
		/// <param name="aabb">An Aabb</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dInfiniteAABB(dGeomID geom, Aabb aabb);
		
		/// <summary>
		/// This deallocates some extra memory used by ODE that can not be deallocated using the normal destroy functions,
		/// e.g. dWorldDestroy.
		/// You can use this function at the end of your application to prevent memory leak checkers from complaining about ODE.
		/// </summary>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dCloseODE();
		#endregion Utility Functions
		
		#region Space functions
		/// <summary>
		/// Create a simple space. 
		/// 
		/// If space is nonzero, insert the new space into that space.
		/// </summary>
		/// <returns>A dSpaceID</returns>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dSpaceID dSimpleSpaceCreate(dSpaceID space);
		
		/// <summary>
		/// Create a multi-resolution hash table space. 
		/// 
		/// If space is nonzero, insert the new space into that space.
		/// </summary>
		/// <returns>A dSpaceID</returns>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dSpaceID dHashSpaceCreate(dSpaceID space);
		
		/// <summary>
		/// Creates a quadtree space. 
		/// 
		/// Center and Extents define the size of the root block. 
		/// Depth sets the depth of the tree - the number of blocks that are created is 4^Depth
		/// </summary>
		/// <returns>A dSpaceID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="Center">A  dVector3</param>
		/// <param name="Extents">A  dVector3</param>
		/// <param name="Depth">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dSpaceID dQuadTreeSpaceCreate(dSpaceID space, dVector3 Center, dVector3 Extents, int Depth);
		
		/// <summary>
		/// This destroys a space. 
		/// It functions exactly like dGeomDestroy except that it takes a dSpaceID argument. 
		/// When a space is destroyed, if its cleanup mode is 1 (the default) then all the 
		/// geoms in that space are automatically destroyed as well.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceDestroy(dSpaceID space);
		
		/// <summary>
		/// Sets some parameters for a multi-resolution hash table space. 
		/// 
		/// The smallest and largest cell sizes used in the hash table will be 
		/// 2^minlevel and 2^maxlevel respectively. 
		/// 
		/// minlevel must be less than or equal to maxlevel.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="minlevel">An int</param>
		/// <param name="maxlevel">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dHashSpaceSetLevels(dSpaceID space, int minlevel, int maxlevel);
		
		/// <summary>
		/// Get some parameters for a multi-resolution hash table space. 
		/// 
		/// The smallest and largest cell sizes used in the hash table will be 
		/// 2^minlevel and 2^maxlevel respectively. 
		/// 
		/// minlevel must be less than or equal to maxlevel.
		/// 
		/// The minimum and maximum levels are returned through pointers. 
		/// If a pointer is zero then it is ignored and no argument is returned.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="minlevel">An int</param>
		/// <param name="maxlevel">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dHashSpaceGetLevels(dSpaceID space, ref int minlevel, ref int maxlevel);
		
		/// <summary>
		/// Set the clean-up mode of the space. 
		/// 
		/// If the clean-up mode is 1, then the contained geoms will be destroyed 
		/// when the space is destroyed. 
		/// If the clean-up mode is 0 this does not happen. 
		/// 
		/// The default clean-up mode for new spaces is 1.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="mode">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceSetCleanup(dSpaceID space, int mode);
		
		/// <summary>
		/// Get the clean-up mode of the space.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dSpaceGetCleanup(dSpaceID space);
		
		/// <summary>
		/// Add a geom to a space. 
		/// 
		/// This does nothing if the geom is already in the space. 
		/// 
		/// This function can be called automatically if a space argument is given to 
		/// a geom creation function.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceAdd(dSpaceID space, dGeomID geom);
		
		/// <summary>
		/// Remove a geom from a space. 
		/// 
		/// This does nothing if the geom is not actually in the space. 
		/// 
		/// This function is called automatically by dGeomDestroy if the geom is in a space.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceRemove(dSpaceID space, dGeomID geom);
		
		/// <summary>
		/// Return 1 if the given geom is in the given space, or return 0 if it is not.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="geom">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dSpaceQuery(dSpaceID space, dGeomID geom);
		
		/// <summary>
		/// Method dSpaceClean
		/// Not sure what this does exactly - no documentation.
		/// TODO: Find out what this function does and document it here.
		/// </summary>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dSpaceClean(dSpaceID space);
		
		/// <summary>
		/// Return the number of geoms contained within a space.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="space">A  dSpaceID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dSpaceGetNumGeoms(dSpaceID space);
		
		/// <summary>
		/// Return the i'th geom contained within the space. 
		/// 
		/// i must range from 0 to dSpaceGetNumGeoms()-1.
		/// 
		/// If any change is made to the space (including adding and deleting geoms) 
		/// then no guarantee can be made about how the index number of any 
		/// particular geom will change. Thus no space changes should be made while 
		/// enumerating the geoms.
		/// This function is guaranteed to be fastest when the geoms are accessed in 
		/// the order 0,1,2,etc. Other non-sequential orders may result in slower 
		/// access, depending on the internal implementation.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="i">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dSpaceGetGeom(dSpaceID space, int i);
		#endregion Space functions
		
		#region TriMesh functions
		/// <summary>
		/// 
		/// </summary>
		public const int TRIMESH_FACE_NORMALS=1;
		/// <summary>
		/// 
		/// </summary>
		public const int TRIMESH_LAST_TRANSFORMATION=2;
		
		/// <summary>
		/// Create a dTriMeshData object which is used to store mesh data.
		/// </summary>
		/// <returns>A dTriMeshDataID</returns>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dTriMeshDataID dGeomTriMeshDataCreate();
		
		/// <summary>
		/// Destroy a dTriMeshData object.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataDestroy(dTriMeshDataID g);
		
		/// <summary>
		/// In order to efficiently resolve collisions, dCollideTTL needs the 
		/// positions of the colliding trimeshes in the previous timestep. This is 
		/// used to calculate an estimated velocity of each colliding triangle, which 
		/// is used to find the direction of impact, contact normals, etc. This 
		/// requires the user to update these variables at every timestep. This update 
		/// is performed outside of ODE, so it is not included in ODE itself. 
		/// The code to do this looks something like this: 
		///		const double *DoubleArrayPtr =
		///			Bodies[BodyIndex].TransformationMatrix->GetArray();
		///		dGeomTriMeshDataSet( TriMeshData,
		///			TRIMESH_LAST_TRANSFORMATION,
		///			(void *) DoubleArrayPtr );
		/// 
		/// The transformation matrix is the standard 4x4 homogeneous transform matrix, 
		/// and the "DoubleArray" is the standard flattened array of the 16 matrix values.
		/// </summary>
		/// <remarks>
		/// Not really used or documented in the ODE 0.5 code that I have other than the 
		/// description above.  This looks like part of work in progress, since the 
		/// Trimesh stuff is still in development.  
		/// 
		/// I leave this here for completeness, but this function should probably only be
		/// uses if you know what you are doing.
		/// </remarks>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="data_id">An int</param>
		/// <param name="data">An IntPtr</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataSet(dTriMeshDataID g, int data_id, IntPtr data);
		
		#region Trimesh data filling functions
		// Note: this section of the ODE api seems a bit rougher than the rest
		// Not surprising since it is still in flux according to the docs.
		// The code below is a best attempt to work with what is there currently.
		
		/// <summary>
		/// Build Trimesh data with single precision used in vertex data.
		/// </summary>
		/// <remarks>
		/// Applies to all the dGeomTriMeshDataBuild single and double versions.
		/// 
		/// (From http://ode.org/ode-latest-userguide.html#sec_10_7_6)
		/// 
		/// Used for filling a dTriMeshData object with data.
		///  
		/// No data is copied here, so the pointers passed into this function must 
		/// remain valid. 
		/// This is how the strided data works:
		///		struct StridedVertex {
		///			dVector3 Vertex;  // 4th component can be left out, reducing memory usage
		///			// Userdata
		///		};
		///		int VertexStride = sizeof (StridedVertex);
		///
		///		struct StridedTri {
		///			int Indices[3];
		///			// Userdata
		///		};
		///		int TriStride = sizeof (StridedTri);
		/// 
		///	The Normals argument is optional: the normals of the faces of each 
		/// trimesh object. For example,
		///		dTriMeshDataID TriMeshData;
		///		TriMeshData = dGeomTriMeshGetTriMeshDataID (
		///			Bodies[BodyIndex].GeomID);
		///
		///		// as long as dReal == floats
		///		dGeomTriMeshDataBuildSingle (TriMeshData,
		///			// Vertices
		///			Bodies[BodyIndex].VertexPositions,
		///			3*sizeof(dReal), (int) numVertices,
		///			// Faces
		///			Bodies[BodyIndex].TriangleIndices,
		///			(int) NumTriangles, 3*sizeof(unsigned int),
		///			// Normals
		///			Bodies[BodyIndex].FaceNormals);
		/// 
		///	This pre-calculation saves some time during evaluation of the contacts, 
		/// but isn't necessary. If you don't want to calculate the face normals 
		/// before construction (or if you have enormous trimeshes and know that 
		/// only very few faces will be touching and want to save time), just pass 
		/// a "NULL" for the Normals argument, and dCollideTTL will take care of the 
		/// normal calculations itself.
		/// </remarks>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3[]</param>
		/// <param name="VertexStride">An int</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		/// <param name="TriStride">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildSingle(dTriMeshDataID g,
			dVector3[] Vertices, int VertexStride, int VertexCount,
			int[] Indices, int IndexCount, int TriStride);
		
		/// <summary>
		/// Build Trimesh data with single precision used in vertex data.
		/// This function takes a normals array which is used as a trimesh-trimesh
		/// optimization.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3[]</param>
		/// <param name="VertexStride">An int</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		/// <param name="TriStride">An int</param>
		/// <param name="Normals">A  dVector3[]</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildSingle1(dTriMeshDataID g,
			dVector3[] Vertices, int VertexStride, int VertexCount,
			int[] Indices, int IndexCount, int TriStride,
			dVector3[] Normals);
		
		/// <summary>
		/// Build Trimesh data with double precision used in vertex data.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3</param>
		/// <param name="VertexStride">An int</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		/// <param name="TriStride">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildDouble(dTriMeshDataID g,
			dVector3 Vertices,  int VertexStride, int VertexCount,
			int[] Indices, int IndexCount, int TriStride);
		
		/// <summary>
		/// Build Trimesh data with double precision used in vertex data.
		/// This function takes a normals array which is used as a trimesh-trimesh
		/// optimization.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3[]</param>
		/// <param name="VertexStride">An int</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		/// <param name="TriStride">An int</param>
		/// <param name="Normals">A  dVector3[]</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildDouble1(dTriMeshDataID g,
			dVector3[] Vertices,  int VertexStride, int VertexCount,
			int[] Indices, int IndexCount, int TriStride,
			dVector3[] Normals);
		
		/// <summary>
		/// Simple trimesh build function provided for convenience.
		/// 
		/// Uses single/double precision vertices and normals depending on the
		/// current value of the dReal alias.
		/// The precision to use depends on which version of the ODE library is being
		/// used - single or double precision.  Depends on whether dSINGLE or dDOUBLE is
		/// defined during ODE compilation.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3[]</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildSimple(dTriMeshDataID g,
			dVector3[] Vertices, int VertexCount,
			int[] Indices, int IndexCount);
		
		/// <summary>
		/// Simple trimesh build function provided for convenience.
		/// This version takes a normals array to use for trimesh-trimesh optimization.
		/// 
		/// Uses single/double precision vertices and normals depending on the
		/// current value of the dReal alias.
		/// The precision to use depends on which version of the ODE library is being
		/// used - single or double precision.  Depends on whether dSINGLE or dDOUBLE is
		/// defined during ODE compilation.
		/// </summary>
		/// <param name="g">A  dTriMeshDataID</param>
		/// <param name="Vertices">A  dVector3[]</param>
		/// <param name="VertexCount">An int</param>
		/// <param name="Indices">An int[]</param>
		/// <param name="IndexCount">An int</param>
		/// <param name="Normals">A  dVector3[]</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshDataBuildSimple1(dTriMeshDataID g,
			dVector3[] Vertices, int VertexCount,
			int[] Indices, int IndexCount,
			dVector3[] Normals);
		#endregion Trimesh data filling functions
		#region Trimesh callback functions
		/// <summary>
		/// Per triangle callback.
		/// Allows user to state if a collision with a particular triangle is wanted
		/// If the return value is zero no contact will be generated.
		/// </summary>
		[DelegateCallingConventionCdecl]
		public delegate int dTriCallback(dGeomID TriMesh, dGeomID RefObject, int TriangleIndex);
		
		/// <summary>
		/// Set per triangle callback for specified trimesh.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="Callback">A  dTriCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshSetCallback(dGeomID g, dTriCallback Callback);
		
		/// <summary>
		/// Get per triangle callback for specified trimesh.
		/// </summary>
		/// <returns>A dTriCallback</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dTriCallback dGeomTriMeshGetCallback(dGeomID g);
		
		/// <summary>
		/// Per object callback.
		/// Allows user to get the list of all intersecting triangles in one shot.
		/// </summary>
		[DelegateCallingConventionCdecl]
		public delegate void dTriArrayCallback(dGeomID TriMesh, dGeomID RefObject, int[] TriIndices, int TriCount);
		
		/// <summary>
		/// Set per object callback for specified trimesh.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="ArrayCallback">A  dTriArrayCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshSetArrayCallback(dGeomID g, dTriArrayCallback ArrayCallback);
		
		/// <summary>
		/// Get per object callback for specified trimesh
		/// </summary>
		/// <returns>A dTriArrayCallback</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dTriArrayCallback dGeomTriMeshGetArrayCallback(dGeomID g);
		
		/// <summary>
		/// Ray callback. 
		/// Allows the user to determine if a ray collides with a triangle based on 
		/// the barycentric coordinates of an intersection. The user can for example 
		/// sample a bitmap to determine if a collision should occur.
		/// </summary>
		[DelegateCallingConventionCdecl]
		public delegate int dTriRayCallback(dGeomID TriMesh, dGeomID Ray, int TriangleIndex, dReal u, dReal v);
		
		/// <summary>
		/// Set ray callback for specified trimesh.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="Callback">A  dTriRayCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshSetRayCallback(dGeomID g, dTriRayCallback Callback);
		
		/// <summary>
		/// Get ray callback for specified trimesh.
		/// </summary>
		/// <returns>A dTriRayCallback</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dTriRayCallback dGeomTriMeshGetRayCallback(dGeomID g);
		
		#endregion Trimesh callback functions
		
		/// <summary>
		/// Trimesh class constructor.
		/// 
		/// The Data member defines the vertex data the newly created triangle mesh will use.
		/// 
		/// Callbacks are optional.
		/// </summary>
		/// <returns>A dGeomID</returns>
		/// <param name="space">A  dSpaceID</param>
		/// <param name="Data">A  dTriMeshDataID</param>
		/// <param name="Callback">A  dTriCallback</param>
		/// <param name="ArrayCallback">A  dTriArrayCallback</param>
		/// <param name="RayCallback">A  dTriRayCallback</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dGeomID dCreateTriMesh(dSpaceID space, dTriMeshDataID Data, dTriCallback Callback, dTriArrayCallback ArrayCallback, dTriRayCallback RayCallback);
		
		/// <summary>
		/// Replaces the current vertex data.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="Data">A  dTriMeshDataID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshSetData(dGeomID g, dTriMeshDataID Data);
		
		// enable/disable/check temporal coherence
		/// <summary>
		/// Enable/disable the use of temporal coherence during tri-mesh collision checks. 
		/// Temporal coherence can be enabled/disabled per tri-mesh instance/geom class pair, 
		/// currently it works for spheres and boxes. The default for spheres and boxes is 'false'.
		/// The 'enable' param should be 1 for true, 0 for false.
		/// Temporal coherence is optional because allowing it can cause subtle efficiency problems
		/// in situations where a tri-mesh may collide with many different geoms during its lifespan. 
		/// If you enable temporal coherence on a tri-mesh then these problems can be eased by 
		/// intermittently calling dGeomTriMeshClearTCCache for it.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="geomClass">An int</param>
		/// <param name="enable">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshEnableTC(dGeomID g, int geomClass, int enable);
		
		/// <summary>
		/// Checks whether the use of temporal coherence during tri-mesh collision checks is enabled.
		/// 
		/// Returns 1 if enabled, 0 if not enabled.
		/// </summary>
		/// <returns>An int</returns>
		/// <param name="g">A  dGeomID</param>
		/// <param name="geomClass">An int</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static int dGeomTriMeshIsTCEnabled(dGeomID g, int geomClass);
		
		/// <summary>
		/// Clears the internal temporal coherence caches. When a geom has its
		/// collision checked with a trimesh once, data is stored inside the trimesh.
		/// With large worlds with lots of seperate objects this list could get huge.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshClearTCCache(dGeomID g);
		
		/// <summary>
		/// Returns the TriMeshDataID for the specified geom.
		/// </summary>
		/// <returns>A dTriMeshDataID</returns>
		/// <param name="g">A  dGeomID</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static dTriMeshDataID dGeomTriMeshGetTriMeshDataID(dGeomID g);
		
		/// <summary>
		/// Retrieves a triangle in object space. The v0, v1 and v2 arguments are optional.
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="Index">An int</param>
		/// <param name="v0">A  dVector3</param>
		/// <param name="v1">A  dVector3</param>
		/// <param name="v2">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshGetTriangle(dGeomID g, int Index, ref dVector3 v0, ref dVector3 v1, ref dVector3 v2);
		
		/// <summary>
		/// Retrieves a position on the requested triangle and the given
		/// barycentric coordinates
		/// </summary>
		/// <param name="g">A  dGeomID</param>
		/// <param name="Index">An int</param>
		/// <param name="u">A  dReal</param>
		/// <param name="v">A  dReal</param>
		/// <param name="Out">A  dVector3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dGeomTriMeshGetPoint(dGeomID g, int Index, dReal u, dReal v, ref dVector3 Out);
		#endregion TriMesh functions

		#region Rotation Functions
		
		/// <summary>
		/// Set R to the identity matrix (i.e. no rotation).
		/// </summary>
		/// <param name="R">A dMatrix3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dRSetIdentity(out dMatrix3 R);

		/// <summary>
		/// Compute the rotation matrix R as a rotation of angle radians along the axis (ax,ay,az).
		/// </summary>
		/// <param name="R">A dMatrix3</param>
		/// <param name="ax">A dReal</param>
		/// <param name="ay">A dReal</param>
		/// <param name="az">A dReal</param>
		/// <param name="angle">A dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dRFromAxisAndAngle (out dMatrix3 R, dReal ax, dReal ay, dReal az, dReal angle);

		/// <summary>
		/// Compute the rotation matrix R from the three Euler rotation angles.
		/// </summary>
		/// <param name="R">A dMatrix3</param>
		/// <param name="phi">A dReal</param>
		/// <param name="theta">A dReal</param>
		/// <param name="psi">A dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dRFromEulerAngles (out dMatrix3 R, dReal phi, dReal theta, dReal psi);

		/// <summary>
		/// Compute the rotation matrix R from the two vectors `a' (ax,ay,az) and `b' (bx,by,bz). `a' and `b' are the desired x and y axes of the rotated coordinate system. If necessary, `a' and `b' will be made unit length, and `b' will be projected so that it is perpendicular to `a'. The desired z axis is the cross product of `a' and `b'.
		/// </summary>
		/// <param name="R">A dMatrix3</param>
		/// <param name="ax">A dReal</param>
		/// <param name="ay">A dReal</param>
		/// <param name="az">A dReal</param>
		/// <param name="bx">A dReal</param>
		/// <param name="by">A dReal</param>
		/// <param name="bz">A dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dRFrom2Axes (out dMatrix3 R, dReal ax, dReal ay, dReal az, dReal bx, dReal by, dReal bz);

		/// <summary>
		/// Set q to the identity rotation (i.e. no rotation).
		/// </summary>
		/// <param name="q">A dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQSetIdentity (out dQuaternion q);

		/// <summary>
		/// Compute q as a rotation of angle radians along the axis (ax,ay,az).
		/// </summary>
		/// <param name="q">A dQuaternion</param>
		/// <param name="ax">A dReal</param>
		/// <param name="ay">A dReal</param>
		/// <param name="az">A dReal</param>
		/// <param name="angle">A dReal</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQFromAxisAndAngle (out dQuaternion q, dReal ax, dReal ay, dReal az, dReal angle);

		/// <summary>
		/// Set qa = qb*qc. This is that same as qa = rotation qc followed by rotation qb. The 0/1/2 versions are analogous to the multiply functions, i.e. 1 uses the inverse of qb, and 2 uses the inverse of qc. Option 3 uses the inverse of both.
		/// </summary>
		/// <param name="qa">A dQuaternion</param>
		/// <param name="qb">A returning dQuaternion</param>
		/// <param name="qc">A returning dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQMultiply0 (out dQuaternion qa, ref dQuaternion qb, ref dQuaternion qc);

		/// <summary>
		/// Set qa = qb*qc. This is that same as qa = rotation qc followed by rotation qb. The 0/1/2 versions are analogous to the multiply functions, i.e. 1 uses the inverse of qb, and 2 uses the inverse of qc. Option 3 uses the inverse of both.
		/// </summary>
		/// <param name="qa">A dQuaternion</param>
		/// <param name="qb">A returning dQuaternion</param>
		/// <param name="qc">A returning dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQMultiply1 (out dQuaternion qa, ref dQuaternion qb, ref dQuaternion qc);

		/// <summary>
		/// Set qa = qb*qc. This is that same as qa = rotation qc followed by rotation qb. The 0/1/2 versions are analogous to the multiply functions, i.e. 1 uses the inverse of qb, and 2 uses the inverse of qc. Option 3 uses the inverse of both.
		/// </summary>
		/// <param name="qa">A dQuaternion</param>
		/// <param name="qb">A returning dQuaternion</param>
		/// <param name="qc">A returning dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQMultiply2 (out dQuaternion qa, ref dQuaternion qb, ref dQuaternion qc);

		/// <summary>
		/// Set qa = qb*qc. This is that same as qa = rotation qc followed by rotation qb. The 0/1/2 versions are analogous to the multiply functions, i.e. 1 uses the inverse of qb, and 2 uses the inverse of qc. Option 3 uses the inverse of both.
		/// </summary>
		/// <param name="qa">A dQuaternion</param>
		/// <param name="qb">A returning dQuaternion</param>
		/// <param name="qc">A returning dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQMultiply3 (out dQuaternion qa, ref dQuaternion qb, ref dQuaternion qc);

		/// <summary>
		/// Convert quaternion q to rotation matrix R.
		/// </summary>
		/// <param name="q">A dQuaternion</param>
		/// <param name="R">A dMatrix3</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dQtoR (ref dQuaternion q, out dMatrix3 R);

		/// <summary>
		/// Convert rotation matrix R to quaternion q.
		/// </summary>
		/// <param name="R">A dMatrix3</param>
		/// <param name="q">A dQuaternion</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dRtoQ (ref dMatrix3 R, out dQuaternion q);

		/// <summary>
		/// Given an existing orientation q and an angular velocity vector w, return in dq the resulting dq/dt.
		/// </summary>
		/// <param name="w">A dVector3</param>
		/// <param name="q">A dQuaternion</param>
		/// <param name="dq">A dVector4</param>
		[DllImport(ODE_NATIVE_LIBRARY, CallingConvention=CALLING_CONVENTION), SuppressUnmanagedCodeSecurity]
		public extern static void dWtoDQ (ref dVector3 w, ref dQuaternion q, out dVector4 dq);

		#endregion Rotation Functions

		#endregion Public Externs
	}
}
