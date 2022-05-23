using System;
using System.IO;

namespace FileRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            //ask user for folder path where the files are located
            Console.WriteLine("Folder path: ");
            string folderPath = Console.ReadLine();
            if (folderPath == "")
            {
                Console.WriteLine("Path cannot be empty");
            }
            else
            {
                string[] allFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
                if (allFiles.Length < 1)
                {
                    Console.WriteLine("Incorrect path and/or folder is empty");
                }
                else
                {
                    //ask user to what the files should be renamed
                    Console.WriteLine("What would you like to rename the files to?");
                    string renamedFilenamebase = Console.ReadLine();
                    //go through the array, gather necessary info, rename files
                    for (int i = 0; i < allFiles.Length; i++)
                    {
                        FileInfo fi = new FileInfo(allFiles[i]);
                        string fileExtension = fi.Extension;
                        string fileNumber = "0";
                        if (i < 10)
                        {
                            fileNumber = i.ToString();
                            fileNumber = "0" + fileNumber;
                        }
                        string renamedFilenames = folderPath + "\\" + renamedFilenamebase + " " + fileNumber + fileExtension;
                        System.IO.File.Move(allFiles[i], renamedFilenames);
                    }
                    Console.WriteLine("Done!");
                }
            }
            Console.WriteLine("Press any key to close...");
            Console.ReadLine();
        }
    }
}
