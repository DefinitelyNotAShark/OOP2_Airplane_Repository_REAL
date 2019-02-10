using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airplane_UML;

namespace UnitTestAirplane_UML
{
    [TestClass]
    public class AirplaneTest
    {
        [TestMethod]
        public void TestConstructor()//really only 1 var here...I think that's all I can test in that class
        {
            Airplane a = new Airplane();

            int maxAltitudeSet = a.MaxAltitude;

            Assert.AreEqual(41000, maxAltitudeSet);//default max altitude is 41,000
        }


        [TestMethod]
        public void TestAerialConstructorOnAirplane()//i guess i gotta test the base class constructor too?
        {
            Airplane a = new Airplane();

            bool defaultIsFlying = a.isFlying;
            int defaultCurrentAltitude = a.currentAltitude;

            Assert.AreEqual(false, defaultIsFlying);//isFlying should start false
            Assert.AreEqual(0, defaultCurrentAltitude);//current altitude should start at 0
        }

    }
}
