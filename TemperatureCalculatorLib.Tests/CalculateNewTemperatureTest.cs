using TemperatureCalculatorLib;
using AutoCimateControlSystem;

namespace TemperatureCalculatorLib.Tests
{
    public class TempCalculatorFixture : IDisposable
    {
        public ITempCalculator TempCalculator { get; }

        public TempCalculatorFixture()
        {
            TempCalculator = new TempCalculator();
        }

        public void Dispose()
        { }
    }

    public class TemperatureCalculatorTests : IClassFixture<TempCalculatorFixture>
    {
        private ITempCalculator tempCalculator;

        public TemperatureCalculatorTests(TempCalculatorFixture fixture)
        {
            tempCalculator = fixture.TempCalculator;
        }

        public class TestData : TheoryData<int, int, int>
        {
            public TestData()
            {
                Add(0, 25, 25);     // Test case 1
                Add(2, 30, 26);     // Test case 2
                Add(5, 20, 16);     // Test case 3
                Add(3, 45, 26);     // Test case 4
                Add(1, -1, 16);
            }
        }

        public class InvalidTestData : TheoryData<int, int>
        {
            public InvalidTestData()
            {
                Add(-1, 20);    // Test case 5
                Add(-2, -2);    // Test case 6
            }
        }

        [Theory]
        [ClassData(typeof(TestData))]
        public void TestCalculateNewTemperature_ValidInputs(int peopleCount, int outsideTemp, int expectedTemperature)
        {

            // Act
            int newTemperature = tempCalculator.CalculateNewTemperature(peopleCount, outsideTemp);

            // Assert
            Assert.Equal(expectedTemperature, newTemperature);
        }

        [Theory]
        [ClassData(typeof(InvalidTestData))]
        public void TestCalculateNewTemperature_InvalidInputs(int peopleCount, int outsideTemp)
        {

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tempCalculator.CalculateNewTemperature(peopleCount, outsideTemp));
        }
    }
}