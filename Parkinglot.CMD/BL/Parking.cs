using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parkinglot.CMD.Model;
namespace Parkinglot.CMD.BL
{
    internal class Parking
    {
        public static int LotSize { get; set; }
        public static List<ParkingSpace> ParkSpaces { get; set; }
        public static string CreateParkingLot(int lotSize)
        {
            LotSize = lotSize;
            ParkSpaces = new List<ParkingSpace>();
            for (int i = 1; i <= lotSize; i++)
            {
                ParkingSpace space = new ParkingSpace();
                space.Id = i;
                space.Occupied = false;
                ParkSpaces.Add(space);

            }
            return $"Created a parking lot with {lotSize} slots";

        }
        public static string Park(string carNumber, string carColor)
        {
            if (ParkSpaces != null)
            {
                if (ParkSpaces.Where(m => m.Occupied == false).Any())
                {
                    var space = ParkSpaces.Where(m => m.Occupied == false).OrderBy(m => m.Id).FirstOrDefault();
                    space.Occupied = true;
                    space.CarNumber = carNumber;
                    space.Color = carColor;
                    return $"Allocated slot number: {space.Id}";

                }

                else
                {
                    return "Sorry, parking lot is full";
                }
            }
            else
            {
                return "Please create a parking lot first";
            }
        }
        public static string Leave(int slotNumber)
        {
            if (ParkSpaces != null)
            {
                var space = ParkSpaces.Where(m => m.Id == slotNumber).FirstOrDefault();
                if (space != null)
                {
                    space.Occupied= false;
                    space.CarNumber=String.Empty;
                    space.Color=String.Empty;
                    return $"Slot number {slotNumber} is free";
                }
                else
                {
                    return "Please enter a valid parking slot";
                }
            }
            else
            {
                return "Please create a parking lot first";
            }
        }
        public static string Status()
        {
            StringBuilder parkStatus = new StringBuilder();
            parkStatus.AppendLine("Slot No.	Registration No.	Colour");
            if (ParkSpaces != null)
            {
                foreach (var space in ParkSpaces)
                {
                    if (space.Occupied)
                    {
                        parkStatus.AppendLine($"{space.Id}	         {space.CarNumber}	      {space.Color}");
                    }
                }
            }
            return parkStatus.ToString();
        }
        public static string GetRegistrationNumberByColor(string carColor)
        {
            StringBuilder parkStatus = new StringBuilder();
            if (ParkSpaces != null)
            {
                var carsbyColor = ParkSpaces.Where(m => m.Color == carColor).ToList();
                foreach (var car in carsbyColor)
                {
                    parkStatus.Append($"{ car.CarNumber}, ");
                }
            }
            if (string.IsNullOrEmpty(parkStatus.ToString()))
            {
                parkStatus.AppendLine("Not found");
            }
            return parkStatus.ToString().Trim().TrimEnd(',');
        }
        public static string GetSlotNumberByColor(string carColor)
        {
            StringBuilder parkStatus = new StringBuilder();
            if (ParkSpaces != null)
            {
                var carsbyColor = ParkSpaces.Where(m => m.Color == carColor).ToList();
                foreach (var car in carsbyColor)
                {
                    parkStatus.Append($"{ car.Id}, ");
                }
            }
            if (string.IsNullOrEmpty(parkStatus.ToString()))
            {
                parkStatus.AppendLine("Not found");
            }
            return parkStatus.ToString().Trim().TrimEnd(',');
        }
        public static string GetSlotNumberByCarNumber(string carNumber)
        {
            StringBuilder parkStatus = new StringBuilder();
            if (ParkSpaces != null)
            {
                var carsbyColor = ParkSpaces.Where(m => m.CarNumber == carNumber).ToList();
                foreach (var car in carsbyColor)
                {
                    parkStatus.Append($"{ car.Id}, ");
                }
            }
            if(string.IsNullOrEmpty(parkStatus.ToString()))
            {
                parkStatus.AppendLine("Not found");
            }
            return parkStatus.ToString().Trim().TrimEnd(',');
        }
    }
}
