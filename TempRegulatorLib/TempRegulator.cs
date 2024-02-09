using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerLib;

namespace TemperatureRegulatorLib
{
    public class TempRegulator : ITempRegulator
    {
        public void RegulateTemperature(int newTemperature)
        {
            Logger.Log($"Regulating temperature to {newTemperature} Celsius");
        }
    }
}
