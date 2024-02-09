using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCimateControlSystem
{
    public class OutsideTempSensor : IOutsideTempSensor
    {
        public int GetOutsideTemp()
        {
           
            Random rand = new Random();
            return rand.Next(0, 50); 
        }
    }
}
