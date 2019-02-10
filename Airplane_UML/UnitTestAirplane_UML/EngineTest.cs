using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airplane_UML;

namespace UnitTestAirplane_UML
{
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void TestConstructor()
        {
            Engine e = new Engine();

            bool engineIsStartedDefault = e.IsStarted;

            Assert.AreEqual(false, engineIsStartedDefault);//the default should be false when constructed
        }

        [TestMethod]
        public void TestAboutString()
        {
            Engine e = new Engine();

            string aboutStringEngineOff = e.About();//upon construction, the engine should be false
            e.Start();
            string aboutStringEngineOn = e.About();

            Assert.AreEqual("The engine is not started.", aboutStringEngineOff);
            Assert.AreEqual("The engine is started.", aboutStringEngineOn);
        }

        [TestMethod]
        public void TestStartAndStop()//can be done in the same function because they use the same bool, so it makes sense
        {
            Engine e = new Engine();

            //Before Starting
            bool defaultIsStarted = e.IsStarted;

            e.Start();

            //After Starting
            bool afterStarted = e.IsStarted;

            e.Stop();

            //After stopping
            bool afterStopped = e.IsStarted;

            Assert.AreEqual(false, defaultIsStarted);
            Assert.AreEqual(true, afterStarted);
            Assert.AreEqual(false, afterStopped);
        }
    }
}
