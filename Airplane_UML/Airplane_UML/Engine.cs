using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airplane_UML
{
    public class Engine
    {
        public bool IsStarted;

        public string About()
        {
            if (IsStarted)
                return "The engine is started.";

            else return "The engine is not started.";
        }

        public Engine()
        {
            IsStarted = false;
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            IsStarted = false;
        }
    }
}
