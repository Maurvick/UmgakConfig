namespace UmgakConfig.Services
{
    internal class DiskUtils
    {
        private static readonly List<string> _tempList = [];

        private const string APP_SETTINGS = "app_settings.txt";
        private const string CONFIG_FILE = "config.txt";
        private const string PRESETS_DIR = "Presets";
        private const string BACKUP_DIR = "Backups";

        private static string _path;

        public static string ConfigPath
        {
            get { return _path; }
        }

        /// <summary>
        /// Create folder structure to organize settings files.
        /// </summary>
        private static void EnsureCreated() 
        {
            if (!Directory.Exists(PRESETS_DIR))
            {
                Directory.CreateDirectory(PRESETS_DIR);
            }
            if (!Directory.Exists(BACKUP_DIR))
            {
                Directory.CreateDirectory(BACKUP_DIR);
            }
        }

        public static void FindConfig()
        {
            // Specify the target file path
            string targetFilePath = @"AppData\Roaming\Fatshark\Vermintide 2\user_settings.config";

            // Get the user's profile directory
            string userProfileDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            // Combine the profile directory with the target file path
            string fullPath = Path.Combine(userProfileDirectory, targetFilePath);

            // Check if the file exists
            if (File.Exists(fullPath))
            {
                // Set path property.
                _path = fullPath;

                Console.WriteLine("File found: " + fullPath);
            }
            else
            {
                Console.WriteLine("File not found: " + fullPath);

                // Ask user to enter config path manually.
                AskPath();
            }
        }

        public static void FindFolder()
        {
            string[] file = GetDataFromFile(APP_SETTINGS);

            EnsureCreated();

            // Check if file is not empty
            if (file.Length > 0)
            {
                foreach (var line in file)
                {
                    if (line.Contains("user_settings.config"))
                    {
                        _tempList.Add(line);
                    }
                }

                // Set Path 
                _path = _tempList.First();

                Console.WriteLine($"FatShark config folder found.");
            }
            else
            {
                // Create file with path
                AskPath();
            }
        }

        private static void AskPath()
        {
            Console.Write("Write path to FatShark folder: ");
            string path = Console.ReadLine() ?? "";

            // Add path to list 
            _tempList.Add(path);

            File.CreateText(APP_SETTINGS).Close();
            File.WriteAllText(APP_SETTINGS, path);
        }

        public static void CopyFile(string source, string destination)
        {
            if (source == destination)
            {
                throw new Exception("Source path and destination path are same!");
            }

            if (File.Exists(destination))
            {
                Console.WriteLine("File is already copied. Skipping this step.");
                return;
            }

            try
            {
                File.Copy(source, destination);
                Console.WriteLine($"Copied file to: {destination}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string[] GetDataFromFile(string path)
        {
            try
            {
                string[] file = File.ReadAllLines(path);

                return file;
            }
            catch (IOException)
            {
                Console.WriteLine($"Failed to read file: {path}");

                AskPath();

                return [];
            }
        }

        public static void MakeFileReadOnly(string filePath)
        {
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Make the file readonly
                    File.SetAttributes(filePath, File.GetAttributes(filePath) | FileAttributes.ReadOnly);

                    Console.WriteLine("File is now readonly.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void MakeFileNormal(string filePath)
        {
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Remove the read-only attribute
                    File.SetAttributes(filePath, File.GetAttributes(filePath) & ~FileAttributes.ReadOnly);

                    Console.WriteLine("File is now editible.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void RestoreSettings()
        {
            // File.Replace(Path, "./user_settings.config", null);
            Console.WriteLine("Config restored to saved copy.");
        }
    }
}
