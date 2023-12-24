using System.Text;

namespace VT2PotatoConfigLoader.Services
{
    internal class DiskUtils
    {
        private static readonly List<string> _data = new List<string>();

        const string USER_FILE_NAME = "settings.txt";

        public static void FindFolder()
        {
            string[] file = GetDataFromFile(USER_FILE_NAME);

            if (File.Exists(USER_FILE_NAME))
            {
                foreach (var line in file)
                {
                    if (line.Contains("Path:"))
                    {

                    }
                }

                Console.WriteLine("FatShark config folder found.");
            }
            else
            {
                SavePath();
            }
        }

        public static void CopyFile(string source, string destination)
        {
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

        public static void SavePath()
        {
            Console.Write("Write path to FatShark folder: ");
            string path = Console.ReadLine() ?? ""; 

            File.Create(USER_FILE_NAME);
            File.WriteAllLines(path, _data);
        }

        public static string ReadFolderPath()
        {
            string[] lines = GetDataFromFile(USER_FILE_NAME);
            string data = lines[0];

            return data;
        }

        public static string[] FindFileByPath(string path)
        {
            string[] file = File.ReadAllLines(path);

            return file;
        }

        public static string GetDisksName()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            string[] result = new string[allDrives.Length];

            foreach (DriveInfo driveInfo in allDrives)
            {
                for (int i = 0; i < allDrives.Length; i++)
                {
                    result[i] += driveInfo.Name;
                } 
            }

            return result[0];
        }

        public static void CheckFile(string file)
        {
            string fileName = "user_settings.config"; // Replace with the name of the file you're searching for

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    string rootDirectory = drive.RootDirectory.FullName;
                    string filePath = SearchFile(rootDirectory, fileName);

                    if (filePath != null)
                    {
                        Console.WriteLine("File found: " + filePath);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("File NOT found.");
                    }
                }
            }
        }

        public static string SearchFile(string directory, string fileName)
        {
            try
            {
                // Go through files in entered directory
                foreach (string file in Directory.GetFiles(directory, fileName, SearchOption.AllDirectories))
                {
                    return file; // Return the first match found
                }

                foreach (string subDirectory in Directory.GetDirectories(directory))
                {
                    string? filePath = SearchFile(subDirectory, fileName);

                    // Return the first match found in subdirectories
                    if (filePath != null) return filePath; 
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access to directories. Failed to read files in folder.");
            }

            return string.Empty; // File not found
        }

        public static void EditLine(string[] data, string lineToRead, 
            string lineToChange, string newLine, string path)
        {
            StringBuilder newFile = new();

            // Read file lines
            foreach (string line in data)
            {
                if (line.Contains(lineToRead))
                {
                    // Copy file
                    newFile.Append(line + Environment.NewLine);
                }
                else
                {
                    if (line.Contains(lineToChange))
                    {
                        string temp = line.Replace(lineToChange, newLine);

                        newFile.Append(temp + "\r\n");

                        continue;
                    }

                    newFile.Append(line + "\r\n");
                }
            }

            File.WriteAllText(path, newFile.ToString());
        }

        /// <summary>
        /// Returns array with all file data.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetDataFromFile(string path)
        {
            try
            {
                string[] file = File.ReadAllLines(path);

                return file;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
