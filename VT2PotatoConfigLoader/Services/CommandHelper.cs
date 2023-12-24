using System.Diagnostics;

namespace VT2PotatoConfigLoader.Services
{
    internal class CommandHelper
    {
        /// <summary>
        /// Reads user input from console.
        /// </summary>
        /// <returns></returns>
        public static void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Write("> ");
                string userInput = Console.ReadLine() ?? "";

                string[] commandArgs = userInput.Split(' ');
                string command = commandArgs[0].ToLower();

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please enter a command.");
                    continue;
                }

                switch (command)
                {
                    case "help":
                        ShowHelp();
                        break;

                    case "greet":
                        if (commandArgs.Length > 1)
                        {
                            string name = commandArgs[1];
                            Greet(name);
                        }
                        else
                        {
                            Console.WriteLine("Please provide a name to greet.");
                        }
                        break;

                    case "exit":
                        // Console.WriteLine("Exiting Console. Goodbye!");
                        isRunning = false;
                        break;

                    case "folder":
                        try
                        {
                            // Use ProcessStartInfo to specify the file or folder to open
                            ProcessStartInfo psi = new ProcessStartInfo
                            {
                                FileName = "explorer.exe",
                                Arguments = Environment.CurrentDirectory,
                                UseShellExecute = true
                            };

                            // Start the process
                            Process.Start(psi);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("Please enter valid command.");
                        break;
                }
            }
        }

        private static void ShowHelp()
        {
            Console.WriteLine("Available commands:");
            Console.WriteLine("  help        - Show available commands");
            Console.WriteLine("  greet <name>- Greet the specified name");
            Console.WriteLine("  exit        - Exit the CommandHandler");
        }

        private static void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
