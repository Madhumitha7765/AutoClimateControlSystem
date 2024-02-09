using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCounterLib
{
    public class PeopleCountSensor : IPeopleCountSensor
    {
        public int GetPeopleCount()
        {
            Random rand = new Random();
            return rand.Next(1, 6); 
        }
    }
}
