using System;
using System.Collections.Generic;
using System.Linq;
using APIGenerator.DataLayer;
using APIGenerator.Models;
using APIGenerator.Models.Utility;
using APIGenerator.Repository.Intefaces;
using APIGenerator.Utilities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace APIGenerator.Repository
{
    public class DayRepository : IDayRepository
    {
        private readonly ILogger _Logger;

        private readonly JSONFileReader _DataFileReader;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        /// <param name="DataFileReader"></param>
        public DayRepository(ILogger<DayRepository> Logger, JSONFileReader DataFileReader)
        {
            _Logger = Logger;
            _DataFileReader = DataFileReader;
        }

        /// <summary>
        /// Operation to add a new day to the data store
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public int AddNewDay(Day day)
        {
            //Request all current days added to the system
            IEnumerable<Day> ModelList = GetAllDays();
            //Append the new day to the list
            ModelList.Append(day);
            //Convert the upgraded list to a JSON object
            string JSONObject = UtilityMethods.ConvertObjectToJSONString(ModelList);
            //Write the contents to a file
            int result = _DataFileReader.WriteToFileForType(JSONObject, FileType.DAY);

            return result;
        }

        /// <summary>
        /// Operation to return all Days stored in the data store
        /// </summary>
        /// <returns>And IEnumerable of Day objects</returns>
        public IEnumerable<Day> GetAllDays()
        {
            string DayFileContents = _DataFileReader.ReadFileContentsForContentType(FileType.DAY);
            List<Day> ModelList = null;

            if(string.IsNullOrWhiteSpace(DayFileContents))
            {
                return ModelList;
            }
            
            try
            {
                ModelList = (List<Day>)UtilityMethods.ConvertJsonStringToProvidedGenericType<IEnumerable<Day>>(DayFileContents);
                return ModelList;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                throw e;
            }
        }

        /// <summary>
        /// Operation to get the first stored Day by "Unique" ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>An individual Day object</returns>
        public Day GetDayByID(int ID)
        {
            Day Result = null;
            try
            {
                IEnumerable<Day> AllDays = GetAllDays();

                if(AllDays != null && AllDays.Count() > 0)
                {
                    Result = AllDays.FirstOrDefault(d => d.ID == ID);
                }
                return Result;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return Result;
            }
        }

        /// <summary>
        /// Operation to get all stored Days by date range
        /// </summary>
        /// <param name="Start">The date to start the search</param>
        /// <param name="End">The date to end the search</param>
        /// <returns>A collection of Day objects</returns>
        public IEnumerable<Day> GetDaysInDateRange(DateTime Start, DateTime End)
        {
            List<Day> Result = null;
            try
            {
                IEnumerable<Day> AllDays = GetAllDays();

                if(AllDays != null && AllDays.Count() > 0)
                {
                    Result = AllDays.Where(d => d.Date >= Start && d.Date <= End).ToList();
                }

                return Result;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError(LoggingEvents.GENERIC_ERROR, $"Error in method {UtilityMethods.GetCallerMemberName()} with exception {e.Message}");
                return Result;
            }
        }
    }
}