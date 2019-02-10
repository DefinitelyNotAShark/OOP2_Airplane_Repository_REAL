using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_UML
{
    public class ToyPlane: Airplane
    {
        public bool isWoundUp { get; protected set; }

        public ToyPlane()
        {
            MaxAltitude = 50;
        }

        public override string About()
        {
            return "The toy plane's max altitude is " + MaxAltitude.ToString() + ".\n" + GetWindUpString() + "\nThe toy plane's altitude is " + currentAltitude + ".";
        }

        public string GetWindUpString()//tell me whether it's wound up
        {
            if (isWoundUp)
                return "The toy plane is wound up.";

            else return "The toy plane is not wound up.";
        }

        public override void StartEngine()//only start if it's wound up
        {
            if (isWoundUp)
                Engine.IsStarted = true;
        }

        public override string TakeOff()
        {
            if (Engine.IsStarted)
            {
                isFlying = true;
                FlyUp(MaxAltitude);
                UnWind();//I imagine taking off unwinds the engine?
                return this.GetType().Name + " is flying";
            }

            else
            {
                isFlying = false;
                return this.GetType().Name + " cannot take off. It's engine is not started.";
            }
        }

        public void UnWind()
        {
            isWoundUp = false;
        }

        public void WindUp()
        {
            isWoundUp = true;
        }
    }
}
