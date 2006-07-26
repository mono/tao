using NUnit.Framework;
using System;
using Tao.Ode;

namespace Tao_Ode_Tests
{
	/// <summary>
	/// This fixture tests marshalling of Tao.Ode functions using dMatrix3 as a parameter.
	/// dMatrix3 does not marshall correctly itself for some reason, so until this is corrected,
	/// dMatrix3 is passed to ODE as an array and overloaded functions are provided to retain
	/// compatibility with the ODE API.
	///
	/// Strangely enough, dMatrix3 marshalling in the reverse direction (ie. from ODE) seems to work.
	/// </summary>
	[TestFixture]
	public class Matrix3Marshalling
	{
		[SetUp]
		public void SetUp()
		{
			// Nothing to setup right now
		}
		
		[Test]
		public void dGeomSetRotationTest()
		{
    		IntPtr simplespace = Ode.dSimpleSpaceCreate(IntPtr.Zero);
    		IntPtr box = Ode.dCreateBox(
      			simplespace, 25.0f, 5.0f, 25.0f
    		);
    		Ode.dMatrix3 r = new Ode.dMatrix3(
      			new float[] {
        			1.0f, 0.0f, 0.0f, 0.0f,
        			0.0f, 1.0f, 0.0f, 0.0f,
        			0.0f, 0.0f, 1.0f, 0.0f
      			}
    		);
			
			try {
				Ode.dGeomSetRotation(box, r);
			}
			catch (Exception e) {
				Assert.Fail("dGeomSetRotation failed with exception: " + e.GetType());
			}
			
		}
		
		[Test]
		public void dMassRotateTest()
		{
		    Ode.dMass newMass = new Ode.dMass();
			newMass.c = new Ode.dVector4(); // Just to be safe the dMass
			newMass.I = new Ode.dMatrix3(); // structure is initialized
			
			Ode.dMassSetSphere(ref newMass, 0.2f, 3.5f);
			Ode.dMatrix3 r = new Ode.dMatrix3(
				new float[] {
					1.0f, 0.0f, 0.0f , 0.0f,
					0.0f, 1.0f, 0.0f, 0.0f,
					0.0f, 0.0f, 1.0f, 0.0f
				}
			);
			
			try {
				Ode.dMassRotate(ref newMass, r);
			}
			catch (Exception e) {
				Assert.Fail("dMassRotate failed with exception: " + e.GetType());
			}
			
		}

		[Test]
		public void dBodySetRotationTest()
		{
    		IntPtr newWorldId = Ode.dWorldCreate();
    		IntPtr newBodyId = Ode.dBodyCreate(newWorldId);
    		Ode.dMatrix3 r = new Ode.dMatrix3(
      			new float[] {
        			1.0f, 0.0f, 0.0f, 0.0f,
        			0.0f, 1.0f, 0.0f, 0.0f,
        			0.0f, 0.0f, 1.0f, 0.0f
      			}
    		);
			try {
				Ode.dBodySetRotation(newBodyId, r);
			}
			catch (Exception e) {
				Assert.Fail("dBodySetRotation failed with exception: " + e.GetType());
			}
			
		}

		/// <summary>
		/// Test to verify that dMatrix3 is correctly marshalled when *returning* data
		/// from an ODE call.
		/// </summary>
		[Test]
		public void dBodyGetRotationTest()
		{
    		IntPtr newWorldId = Ode.dWorldCreate();
    		IntPtr newBodyId = Ode.dBodyCreate(newWorldId);
    		Ode.dMatrix3 r = new Ode.dMatrix3(
      			new float[] {
        			1.0f, 0.0f, 0.0f, 0.0f,
        			0.0f, 1.0f, 0.0f, 0.0f,
        			0.0f, 0.0f, 1.0f, 0.0f
      			}
    		);
			
			Ode.dMatrix3 r2
			= new Ode.dMatrix3(
      			new float[] {
        			0.0f, 0.0f, 0.0f, 0.0f,
        			0.0f, 0.0f, 0.0f, 0.0f,
        			0.0f, 0.0f, 0.0f, 0.0f
      			}
    		);
			
    		Ode.dBodySetRotation(newBodyId, r);
			
			r2 = Ode.dBodyGetRotation(newBodyId);
			
			Assert.AreEqual(r,r2,"Assigned and returned rotation matrix values are not equal");
		}
		
	}
}
