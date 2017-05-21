
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Logging;

namespace APIGenerator.DataLayer
{
    public class JSONFileReader
    {
        public readonly ILogger _Logger;
        
        public JSONFileReader()
        {

        }

        /// <summary>
        /// Request reading of a selected data contents file by type
        /// </summary>
        /// <param name="Type">the FileType to read (based on an enum)</param>
        /// <returns>A string object ("") object if no file can be found</returns>
        public string ReadFileContentsForContentType(FileType Type)
        {
            throw new NotImplementedException();

            string result = "";
            string FileLocation = GenerateFileLocationFromType(Type);
            FileStream File = new  FileStream(FileLocation, FileMode.Open);

            try
            {
                using (StreamReader r = new StreamReader(File))
                {
                    result = r.ReadToEnd();
                    return result;
                }
            }
            //No File with matching name found!
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("FileNotFound: " + FileLocation + " " + e.Message);
                return result;
            }
        }

        string GenerateFileLocationFromType(FileType Type)
        {
            throw new NotImplementedException();
            string FileName = "";
            string location = @"..\APIGenerator\Data\";
            FileName = String.Format("{0}{1}.json", location, GetFileNameFromFileType(Type));
        }

        string GetFileNameFromFileType(FileType Type)
        {
            string result = "";
            
            switch(Type)
            {
                case FileType.PLAYER:
                {
                    result = "Players";
                    break;
                }
                case FileType.TEAM:
                {
                    result = "Teams";
                    break;
                }
                default:
                {
                    break;
                }
            }
            return result;
        }

    }


    public enum FileType
    {
        PLAYER,
        TEAM,
        RATING

    }
}