using Moq;
using PeopleCounterLib;
using TemperatureRegulatorLib;

namespace AutoCimateControlSystem.Tests
{
    [TestFixture]
    public class ECUTests
    {
        [Test]
        public void ECU_Initialization_Successful()
        {
            // Arrange, Act
            var outsideTempSensorMock = new Mock<IOutsideTempSensor>();
            var peopleCountSensorMock = new Mock<IPeopleCountSensor>();
            var tempCalculatorMock = new Mock<ITempCalculator>();
            var tempRegulatorMock = new Mock<ITempRegulator>();

            // Assert
            Assert.DoesNotThrow(() => new ECU(
                outsideTempSensorMock.Object,
                peopleCountSensorMock.Object,
                tempCalculatorMock.Object,
                tempRegulatorMock.Object
            ));
        }

        [Test]
        public void RunTemperatureControl_CorrectlyRegulatesTemperature()
        {
            // Arrange
            var outsideTempSensorMock = new Mock<IOutsideTempSensor>();
            var peopleCountSensorMock = new Mock<IPeopleCountSensor>();
            var tempCalculatorMock = new Mock<ITempCalculator>();
            var tempRegulatorMock = new Mock<ITempRegulator>();

            var ecu = new ECU(outsideTempSensorMock.Object, peopleCountSensorMock.Object,
                              tempCalculatorMock.Object, tempRegulatorMock.Object);

            outsideTempSensorMock.Setup(sensor => sensor.GetOutsideTemp()).Returns(25);
            peopleCountSensorMock.Setup(sensor => sensor.GetPeopleCount()).Returns(10);
            tempCalculatorMock.Setup(calculator => calculator.CalculateNewTemperature(10, 25)).Returns(27);

            // Act            
            ecu.RunTemperatureControl(false);       


            // Assert
            tempRegulatorMock.Verify(regulator => regulator.RegulateTemperature(27) , Times.Once);
        }

        [Test]
        public void GetCurrentTemperature_ReturnsCorrectTemperature()
        {
            // Arrange
            var outsideTempSensorMock = new Mock<IOutsideTempSensor>();
            var peopleCountSensorMock = new Mock<IPeopleCountSensor>();
            var tempCalculatorMock = new Mock<ITempCalculator>();
            var tempRegulatorMock = new Mock<ITempRegulator>();

            var ecu = new ECU(outsideTempSensorMock.Object, peopleCountSensorMock.Object,
                              tempCalculatorMock.Object, tempRegulatorMock.Object);

           
            ecu.RunTemperatureControl(false);
            

            // Act
            int currentTemperature = ecu.GetCurrentTemperature();

            // Assert
            Assert.AreEqual(0, currentTemperature); 
        }
    }
}

