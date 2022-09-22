using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    internal class Renamer
    {
        private string fileExtension;
        private string fileNumber;
        private string renamedFileName;
        private string oldFileName;
        private int seasonNumber;
        private string folderPath;

        public string FileExtension { get => fileExtension; set => fileExtension = value; }
        public string OldFileName { get => oldFileName; set => oldFileName = value; }
        public string FileNumber { get => fileNumber; set => fileNumber = value; }
        public string RenamedFileName { get => renamedFileName; set => renamedFileName = value; }
        public int SeasonNumber { get => seasonNumber; set => seasonNumber = value; }
        public string FolderPath { get => folderPath; set => folderPath = value; }

        public void rename(string[] files)
        {
            //check if the included path exists or if it has contents
            if (files.Length < 1)
            {
                Console.WriteLine("Incorrect path and/or folder is empty");
            }
            else if (files.Length > 0)
            {
                //ask user to what the files should be renamed
                Console.WriteLine("What is the name of the show?");
                OldFileName = Console.ReadLine();
                Console.WriteLine("What season is this?");
                SeasonNumber = Convert.ToInt32(Console.ReadLine());
                //go through the array, gather necessary info, rename files
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fi = new FileInfo(files[i]);
                    FileExtension = fi.Extension;
                    FileNumber = (i + 1).ToString();
                    if((i+1) < 10)
                    {
                        FileNumber = "0" + FileNumber;
                        Console.WriteLine(FileNumber);
                    }
                    RenamedFileName = folderPath + "\\" + OldFileName + " Season " + SeasonNumber + " Episode " + FileNumber + FileExtension;
                    File.Move(files[i], RenamedFileName);
                }
                Console.WriteLine("Done!");
            }
        }
    }
}
