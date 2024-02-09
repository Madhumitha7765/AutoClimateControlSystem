using PeopleCounterLib;
using System;
using TemperatureRegulatorLib;
using LoggerLib;


namespace AutoCimateControlSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutsideTempSensor outsideTempSensor = new OutsideTempSensor();
            IPeopleCountSensor peopleCountSensor = new PeopleCountSensor();
            ITempCalculator tempCalculator = new TempCalculator();
            ITempRegulator tempRegulator = new TempRegulator();

            ECU ecu = new ECU(outsideTempSensor, peopleCountSensor, tempCalculator, tempRegulator);

            Logger.Log("Auto Climate Control System is running. ");
            ecu.RunTemperatureControl();
        }
    }
}
