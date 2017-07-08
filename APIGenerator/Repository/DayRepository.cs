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

        public DayRepository(ILogger<DayRepository> Logger, JSONFileReader DataFileReader)
        {
            _Logger = Logger;
            _DataFileReader = DataFileReader;
        }

        public int AddNewDay(Day day)
        {
            throw new NotImplementedException();
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

            IEnumerable<Day> Days = null;

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
        /// <returns></returns>
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
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
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