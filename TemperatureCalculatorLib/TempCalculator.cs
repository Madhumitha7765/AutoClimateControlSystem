using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCimateControlSystem
{
    public class TempCalculator : ITempCalculator
    {
        public int CalculateNewTemperature(int peopleCount, int outsideTemp)
        {
            return outsideTemp - (peopleCount * 2); 
        }
    }
}
