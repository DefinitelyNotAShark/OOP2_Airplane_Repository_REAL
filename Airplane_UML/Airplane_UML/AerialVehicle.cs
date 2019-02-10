using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_UML
{
    public abstract class AerialVehicle
    {
        public int currentAltitude { get; set; }
        public int MaxAltitude { get; set; }
        public Engine Engine { get; set; }
        public bool isFlying { get; set; }

        public AerialVehicle()
        {
            Engine = new Engine();
            currentAltitude = 0;//default to 0;
            isFlying = false;//defaults to false and becomes true when alt = 0;
        }

        public virtual string About()
        {
            return "This " + this.GetType().Name + " has a max altitude of " + MaxAltitude.ToString() +
                ".\nIt's current altitude is " + currentAltitude + " ft." +
                "\n" + GetEngineStartedString();
        }

        public string GetEngineStartedString()
        {
            if (Engine.IsStarted)
                return "Engine is started.";
            else
                return "Engine is not started.";
        }

        public void FlyDown(int howManyFeet)
        {
            if (currentAltitude >= howManyFeet)//can only fly down that amount if it is higher or equal to that amount
                currentAltitude -= howManyFeet;
        }

        public void FlyUp(int howManyFeet)
        {
            if (this.isFlying)
            {
                if (currentAltitude <= MaxAltitude - howManyFeet)
                    currentAltitude += howManyFeet;
            }
        }

        public void FlyUp()
        {
            FlyUp(1000);
        }

        public virtual void StartEngine()
        {
            Engine.Start();
        }

        public virtual void StopEngine()
        {
            Engine.Stop();
        }

        public virtual string TakeOff()
        {
            if (!Engine.IsStarted)
            {
                isFlying = false;
                return this.GetType().Name + " can't fly. It's engine is not started.";            
            }

            else
            {
                isFlying = true;
                return this.GetType().Name + " is flying";
            }
        }
    }
}
