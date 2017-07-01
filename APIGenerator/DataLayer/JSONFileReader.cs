
using System;
using System.Diagnostics;
using System.IO;
using APIGenerator.Models.Utility;
using APIGenerator.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace APIGenerator.DataLayer
{
    /// <summary>
    /// JSON class to provide the geneation and reading of a JSON file for players and teams
    /// </summary>
    public class JSONFileReader
    {
        public readonly ILogger _Logger;
        
        /// <summary>
        /// DI enabled constructor
        /// </summary>
        /// <param name="Logger">Injected Logger object</param>
        public JSONFileReader(ILogger<JSONFileReader> Logger)
        {
            _Logger = Logger;
        }

        /// <summary>
        /// Constructor not to use DI
        /// </summary>
        public JSONFileReader()
        {
            _Logger = ApplicationLoggerProvider.CreateLogger<JSONFileReader>();
        }

        /// <summary>
        /// Request reading of a selected data contents file by type
        /// </summary>
        /// <param name="Type">the FileType to read (based on an enum)</param>
        /// <returns>A string object ("") object if no file can be found</returns>
        public string ReadFileContentsForContentType(IHostingEnvironment env, FileType Type)
        {
            _Logger.LogInformation(LoggingEvents.METHOD_CALL, $"Method: {UtilityMethods.GetCallerMemberName()}");
            string result = "";
            string FileLocation = GenerateFileLocationFromType(env, Type);
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

        /// <summary>
        /// Private method to generate the filelocation string path based on the requested file type
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        string GenerateFileLocationFromType(IHostingEnvironment env, FileType Type)
        {
            string FileLocation = "";
            string location = $"{env.ContentRootPath}/Data";
            FileLocation = String.Format("{0}/{1}.json", location, GetFileNameFromFileType(Type));
            return FileLocation;
        }

        /// <summary>
        /// Private method to handle the provisioning of the name of the file for the enum type
        /// </summary>
        /// <param name="Type">The FileType used to query</param>
        /// <returns>A string object denoting the name of the file</returns>
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
                    result = "Team";
                    break;
                }
                case FileType.DAY:
                {
                    result = "Day";
                    break;
                }
                default:
                {
                    result = "Unknown";
                    break;
                }
            }
            return result;
        }

    }


    /// <summary>
    /// Enum of available file type options
    /// </summary>
    public enum FileType
    {
        PLAYER,
        TEAM,
        RATING,
        DAY

    }
}