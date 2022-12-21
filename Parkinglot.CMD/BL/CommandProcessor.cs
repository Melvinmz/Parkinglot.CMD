using Parkinglot.CMD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parkinglot.CMD.BL
{
    public class CommandProcessor
    {


        public static string Process(string command)
        {
            if (!string.IsNullOrEmpty(command))
            {
                var appCommand = GetCommand(command);
                var argumentOne = GetArguments(command).Item1;
                var argumentTwo = GetArguments(command).Item2;                        
                return CallFunction(appCommand, argumentOne, argumentTwo);
            }
            else
            {
                throw new Exception("Please enter a valid command");
            }

        }

        private static string CallFunction(string appCommand, string argumentOne,string argumentTwo)
        {
            switch (appCommand.ToLower().Trim())
            {
                case "create_parking_lot":
                    if (argumentOne == null && int.TryParse(argumentOne, out int result) == true)
                    {
                        throw new ArgumentOutOfRangeException("Parking lot should be a number");
                    }
                    else
                    {
                        return Parking.CreateParkingLot(Convert.ToInt32(argumentOne));
                    }

                case "park":
                    if (string.IsNullOrEmpty(argumentOne) && string.IsNullOrEmpty(argumentTwo))
                    {
                        throw new ArgumentOutOfRangeException("Registration number and color are mandatory");
                    }
                    else
                    {
                        return Parking.Park(argumentOne, argumentTwo);
                    }
                case "leave":
                    if (argumentOne == null && int.TryParse(argumentOne, out int outResult) == true)
                    {
                        throw new ArgumentOutOfRangeException("Please provide parking lot number");
                    }
                    else
                    {
                        return Parking.Leave(Convert.ToInt32(argumentOne));
                    }
                case "status":

                    {
                        return Parking.Status();
                    }


                case "registration_numbers_for_cars_with_colour":
                    if (string.IsNullOrEmpty(argumentOne))
                    {
                        throw new ArgumentNullException("Please pass color");
                    }
                    else
                    {
                        return Parking.GetRegistrationNumberByColor(argumentOne);
                    }
                case "slot_numbers_for_cars_with_colour":
                    if (string.IsNullOrEmpty(argumentOne))
                    {
                        throw new ArgumentNullException("Please pass color");
                    }
                    else
                    {
                        return Parking.GetSlotNumberByColor(argumentOne);
                    }
                case "slot_number_for_registration_number":
                    if (string.IsNullOrEmpty(argumentOne))
                    {
                        throw new ArgumentNullException("Please give a registration number");
                    }
                    else
                    {
                        return Parking.GetSlotNumberByCarNumber(argumentOne);
                    }
                default:
                    return "Please enter a valid command";
            }
        }
        private static string GetCommand(string command)
        {
            string[] commandArray = command.Split(" ");
            if (commandArray.Length > 0)
            {
                return commandArray[0];
            }
            else
            {
                return string.Empty;
            }
        }
        private static Tuple<string, string> GetArguments(string command)
        {
            string[] commandArray = command.Split(" ");
            if (commandArray.Length > 2)
            {
                return new Tuple<string, string>(commandArray[1], commandArray[2]);
            }
            else if (commandArray.Length > 1)
            {
                return new Tuple<string, string>(commandArray[1], string.Empty);
            }
            else
            {
                return new Tuple<string, string>(string.Empty, string.Empty);
            }
        }
    }
}
