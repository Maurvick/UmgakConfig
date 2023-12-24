using VT2PotatoConfigLoader.Services;

namespace VT2PotatoConfigLoader
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Find FatShark folder with user config
            DiskUtils.FindFolder();

            CommandHelper.Run();            
        }
    }
}
