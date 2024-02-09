using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCimateControlSystem
{
    public class TempCalculator : ITempCalculator
    {
        private const int MinTemperature = 16;
        private const int MaxTemperature = 26;

        public int CalculateNewTemperature(int peopleCount, int outsideTemp)
        {
            if (peopleCount < 0)
            {
                throw new ArgumentException("Number of people cannot be negative.", nameof(peopleCount));
            }

            int newTemperature = outsideTemp - (peopleCount * 2);

            // Ensure newTemperature is within the limits
            if (newTemperature < MinTemperature)
            {
                newTemperature = MinTemperature;
            }
            else if (newTemperature > MaxTemperature)
            {
                newTemperature = MaxTemperature;
            }

            return newTemperature;
        }
    }
}
