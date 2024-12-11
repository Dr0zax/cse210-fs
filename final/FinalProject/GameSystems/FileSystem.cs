namespace FinalProject.GameSystems
{
    class FileSystem
    {
        public static void Save(string fileName)
        {

        }

        public static Player Load(string fileName)
        {
            return new(0, 0, 0, 0, 0, "");
        }
    }
}