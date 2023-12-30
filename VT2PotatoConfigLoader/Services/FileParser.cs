using System.Text.RegularExpressions;

namespace UmgakConfig.Services
{
    internal class FileParser
    {
        /// <summary>
        /// Removes braces from text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ParseText(string text)
        {
            // Use regular expression to remove text inside square brackets
            string pattern = @"\[.*?\]";
            string result = Regex.Replace(text, pattern, "");

            // Trim any leading or trailing whitespaces
            result = result.Trim();

            return result;
        }

        public static void EditString(string line, string value)
        {
            string pattern = $@"(""{line}""\s*=\s*)\d+";

            EditLine(DiskUtils.ConfigPath, false, pattern, $"\"{line}\" = {value}");
        }

        public static void EditLine(string filePath, bool isShow, string oldLinePattern, string newLine)
        {
            try
            {
                // Read the entire file into a string
                string fileContent = File.ReadAllText(filePath);

                // Use regex to replace the old line with the new line
                string modifiedContent = Regex.Replace(fileContent, oldLinePattern, newLine);

                // Write the modified content back to the file
                File.WriteAllText(filePath, modifiedContent);

                if (isShow)
                {
                    Console.WriteLine($"{modifiedContent}\nReplacement completed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
