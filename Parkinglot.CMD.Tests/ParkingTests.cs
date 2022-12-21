using Xunit;
using Parkinglot.CMD.BL;
namespace Parkinglot.CMD.Tests
{
    [TestCaseOrderer("Parkinglot.CMD.Tests.PriorityOrderer", "Parkinglot.CMD.Tests")]
    public class ParkingTests
    {
       
        [Fact, ParkingTestPriority(1)]
        public void CreateParkingLot_CreateParkLotCommand_ReturnsStringWithlotSize()
        {
            var result = CommandProcessor.Process("create_parking_lot 6");
            Assert.Equal("Created a parking lot with 6 slots", result);
        }
        [Fact, ParkingTestPriority(2)]
        public void Park_ParkCommand_ReturnsStringWithSlotNumber()
        {          
            var result = CommandProcessor.Process("park KA-01-HH-1234 White");
            Assert.Equal("Allocated slot number: 1", result);
        }              
       
        [Fact, ParkingTestPriority(3)]
        public void status_statusCommand_ReturnsStringSlotAndCarDetails()
        {
            
            var result = CommandProcessor.Process("status");
            Assert.Contains("KA-01-HH-1234", result);
            Assert.Contains("White", result);
            Assert.Contains("1", result);
        }
        [Fact, ParkingTestPriority(4)]
        public void GetRegistrationNumberByColor_GetNumberOfSingleCarbyyColor_ReturnsStringWithRegistrationNumber()
        {
            var result = CommandProcessor.Process("registration_numbers_for_cars_with_colour White");
            Assert.Contains("KA-01-HH-1234", result);
        }
        [Fact, ParkingTestPriority(5)]
        public void GetSlotNumberByColor_GetSlotNumberOfSingleCarbyColor_ReturnsStringWithSlotNumber()
        {
            var result = CommandProcessor.Process("slot_numbers_for_cars_with_colour White");
            Assert.Equal("1", result);
        }
        [Fact, ParkingTestPriority(6)]
        public void GetSlotNumberByCarNumber_GetSlotNumberOfSingleCarbyCarNumber_ReturnsStringWithSlotNumber()
        {
            var result = CommandProcessor.Process("slot_number_for_registration_number KA-01-HH-1234");
            Assert.Equal("1", result);
        }
        [Fact, ParkingTestPriority(10)]
        public void Leave_LeaveCommand_ReturnsStringWithVacatedSlotNumber()
        {
            var result = CommandProcessor.Process("leave 1");
            Assert.Equal("Slot number 1 is free", result);
        }
        [Fact, ParkingTestPriority(11)]
        public void GetSlotNumberByColor_GetSlotNumberOfSingleCarbyColor_ReturnsNotFoundString()
        {
            var result = CommandProcessor.Process("slot_numbers_for_cars_with_colour White");
            Assert.Equal("Not found", result);
        }

    }
}