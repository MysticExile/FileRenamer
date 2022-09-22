using System;
using System.IO;

namespace FileRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            Renamer renamer = new Renamer();
            //ask user for folder path where the files are located
            Console.WriteLine("Folder path: ");
            renamer.FolderPath = Console.ReadLine();
            if (renamer.FolderPath == "")
            {
                Console.WriteLine("Path cannot be empty");
            }
            else
            {
                string[] allFiles = Directory.GetFiles(renamer.FolderPath, "*.*", SearchOption.TopDirectoryOnly);
                renamer.rename(allFiles);
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
