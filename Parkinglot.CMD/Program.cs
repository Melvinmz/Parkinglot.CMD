// See https://aka.ms/new-console-template for more information
using Parkinglot.CMD.BL;

try
{
    Console.WriteLine("Please Select your option");
    Console.WriteLine("Type 1 to enter commands manually");
    Console.WriteLine("Type 2 to upload a file with the commands");
    string command = Console.ReadLine();
    string appCommands = "";
    while (command != "exit")
    {
        if (command == "1")
        {
            Console.Clear();
            Console.WriteLine("Please specify the size of the parking lot. Use Command 'create_parking_lot {size}'");
            while (appCommands != "exit")
            {
                appCommands = Console.ReadLine();
                var result = CommandProcessor.Process(appCommands);
                Console.WriteLine(result);
            }

        }
        else if (command == "2")
        {
            Console.Clear();
            Console.WriteLine("Please enter file path.");
            while (appCommands != "exit")
            {

                var textFile = Console.ReadLine();
                if (!string.IsNullOrEmpty(textFile))
                {
                    if (File.Exists(textFile))
                    {
                        string[] lines = File.ReadAllLines(textFile);
                        foreach (string line in lines)
                        {
                            try
                            {
                                var result = CommandProcessor.Process(line);
                                Console.WriteLine(result);
                            }
                            catch (Exception ex)

                            {
                                Console.WriteLine(ex.ToString());
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid file path.");
                    }
                }

            }
        }
        else if (command == "exit")
        {
            Environment.Exit(1);
        }
        Console.WriteLine("If you want to exit use 'exit' command");
        command = Console.ReadLine();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}