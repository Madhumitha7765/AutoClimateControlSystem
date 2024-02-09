using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCimateControlSystem
{
    public interface ITempCalculator
    {
        int CalculateNewTemperature(int peopleCount, int outsideTemp);
    }
}
