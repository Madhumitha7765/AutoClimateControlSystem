using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PeopleCounterLib;
using TemperatureRegulatorLib;


namespace AutoCimateControlSystem
{

    public class ECU
    {
        private readonly IOutsideTempSensor outsideTempSensor;
        private readonly IPeopleCountSensor peopleCountSensor;
        private readonly ITempCalculator tempCalculator;
        private readonly ITempRegulator tempRegulator;
        private int currentTemp; 
        public ECU(IOutsideTempSensor outsideTempSensor, IPeopleCountSensor peopleCountSensor,
                    ITempCalculator tempCalculator, ITempRegulator tempRegulator)
        {
            this.outsideTempSensor = outsideTempSensor;
            this.peopleCountSensor = peopleCountSensor;
            this.tempCalculator = tempCalculator;
            this.tempRegulator = tempRegulator;
        }

        public void RunTemperatureControl(bool iteration)
        {
            do
            {

                int outsideTemp = outsideTempSensor.GetOutsideTemp();
                int peopleCount = peopleCountSensor.GetPeopleCount();

                int newTemperature = tempCalculator.CalculateNewTemperature(peopleCount, outsideTemp);
                currentTemp = newTemperature;
                tempRegulator.RegulateTemperature(newTemperature);

                Thread.Sleep(10000);

            }
            while (iteration);
        }

        public int GetCurrentTemperature()
        {
            return currentTemp;
        }
    }

}
