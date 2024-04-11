using UmgakConfig.Services;

namespace UmgakConfig
{
    internal class Program
    {
        public static void Main()
        {
            // Find FatShark folder with user config
            DiskUtils.FindConfig();

            // DiskUtils.MakeFileNormal(DiskUtils.ConfigPath);

            // Backup user file ("Better to be safe than sorry")
            //DiskUtils.CopyFile(DiskUtils.ConfigPath, "Backups/user_settings.config");

            // Apply settings to config
            ConfigManager.SetOptimizedSettings();

            // Prevent settings from being change by launcher
            // DiskUtils.MakeFileReadOnly(DiskUtils.ConfigPath);
        }
    }
}
