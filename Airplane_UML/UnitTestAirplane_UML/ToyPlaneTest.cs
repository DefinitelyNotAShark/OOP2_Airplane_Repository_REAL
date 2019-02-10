using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airplane_UML;

namespace UnitTestAirplane_UML
{
    [TestClass]
    public class ToyPlaneTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            ToyPlane t = new ToyPlane();

            int defaultMaxAltitude = t.MaxAltitude;

            Assert.AreEqual(50, defaultMaxAltitude);
        }

        [TestMethod]
        public void TestAbout()
        {
            ToyPlane t = new ToyPlane();

            //Default vars in about
            int maxAltitudeDefault = t.MaxAltitude;//this shouldn't change
            string windUpStringDefault = t.GetWindUpString();
            int defaultCurrentAltitude = t.currentAltitude;

            t.WindUp();
            //Vars after winding up
            string windUpAfterWindUp = t.GetWindUpString();

            t.StartEngine();//gotta have the engine started to fly up
            t.TakeOff();

            //vars after flying up
            string windUpStringAfterFly = t.GetWindUpString();//making sure these are being displayed correctly as they change
            int currentAltitudeAfterFly = t.currentAltitude;

            //Default Values
            Assert.AreEqual(50, maxAltitudeDefault);
            Assert.AreEqual("The toy plane is not wound up.", windUpStringDefault);
            Assert.AreEqual(0, defaultCurrentAltitude);

            Assert.AreEqual("The toy plane is wound up.", windUpAfterWindUp);

            Assert.AreEqual("The toy plane is not wound up.", windUpStringAfterFly);
            Assert.AreEqual(50, currentAltitudeAfterFly);
        }

        [TestMethod]
        public void TestGetWindUpString()
        {
            ToyPlane t = new ToyPlane();

            //test when isWound = false
            bool defaultIsWound = t.isWoundUp;
            string defaultGetWindUp = t.GetWindUpString();

            t.WindUp();

            //test when isWound = true
            bool isWoundUpAfterWindUp = t.isWoundUp;
            string GetWindUpAfterWindUp = t.GetWindUpString();

            Assert.AreEqual(false, defaultIsWound);
            Assert.AreEqual("The toy plane is not wound up.", defaultGetWindUp);
            Assert.AreEqual(true, isWoundUpAfterWindUp);
            Assert.AreEqual("The toy plane is wound up.", GetWindUpAfterWindUp);
        }

        [TestMethod]
        public void TestStartEngine()
        {
            ToyPlane t = new ToyPlane();

            bool isWoundUpBeforeWindUp = t.isWoundUp;
            t.WindUp();
            bool isWoundUpAfterWindUp = t.isWoundUp;//check to see that winding it up changes the bool to true

            bool engineStartedBeforeStartEngine = t.Engine.IsStarted;
            t.StartEngine();
            bool engineStartedAfterStartEngine = t.Engine.IsStarted;

            //StartEngineTesting
            Assert.AreEqual(false, isWoundUpBeforeWindUp);
            Assert.AreEqual(true, isWoundUpAfterWindUp);

            Assert.AreEqual(false, engineStartedBeforeStartEngine);
            Assert.AreEqual(true, engineStartedAfterStartEngine);
        }

        [TestMethod]
        public void TestTakeOff()
        {
            ToyPlane t = new ToyPlane();

            //Defaults
            bool isWoundUpDefault = t.isWoundUp;//should be false upon starting without winding up
            string takeOffDefault = t.TakeOff();//trying to take off without winding up should return error string

            //Starting wind up
            t.WindUp();//calling stuff needed to actually take off
            bool isWoundUpAfterWindUp = t.isWoundUp;

            //Starting engine 
            t.StartEngine();
            bool isWoundUpAfterStartEngine = t.isWoundUp;

            //Taking off with engine started
            string takeOffWithEngineStarted = t.TakeOff();
            bool isWoundUpAfterTakeOff = t.isWoundUp;

            //Defaults //Calling take off without starting the engine
            Assert.AreEqual(false, isWoundUpDefault);
            Assert.AreEqual(t.GetType().Name + " cannot take off. It's engine is not started.", takeOffDefault);

            //Starting the engine
            Assert.AreEqual(true, isWoundUpAfterWindUp);
            Assert.AreEqual(true, isWoundUpAfterStartEngine);

            //Calling take off with engine started
            Assert.AreEqual(t.GetType().Name + " is flying", takeOffWithEngineStarted);
            Assert.AreEqual(false, isWoundUpAfterTakeOff);
        }

        [TestMethod]
        public void TestWindUpAndUnwind()
        {
            ToyPlane t = new ToyPlane();

            bool defaultIsWound = t.isWoundUp;//should start false
            t.WindUp();
            bool isWoundAfterWindUp = t.isWoundUp;//wind should make it true
            t.UnWind();
            bool isWoundAfterUnwind = t.isWoundUp;//unwind should make it false

            Assert.AreEqual(false, defaultIsWound);
            Assert.AreEqual(true, isWoundAfterWindUp);
            Assert.AreEqual(false, isWoundAfterUnwind);
        }
    }
}
