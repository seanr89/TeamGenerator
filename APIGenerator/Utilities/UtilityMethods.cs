using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;

namespace APIGenerator.Utilities
{
    /// <summary>
    /// Static UtilityMethods that can be used across a multitude of classes and objects
    /// </summary>
    public static class UtilityMethods
    {
        private static readonly ILogger _Logger;

        /// <summary>
        /// Static constructor method
        /// Includes method to generate ApplicationLogger object
        /// </summary>
        static UtilityMethods()
        {
            _Logger = ApplicationLoggerProvider.CreateLogger(typeof(UtilityMethods).ToString());
        }

        /// <summary>
        /// Static operation to get the name of the method calling this method
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The method calling name</returns>
        public static string GetCallerMemberName([CallerMemberName]string name = "")
        {
            return name;
        }
        /// <summary>
        /// Static operation to check if the provided Datareader object has the provided column name
        /// </summary>
        /// <param name="r">the datareader object</param>
        /// <param name="columnName">the column name to search for</param>
        /// <returns>A boolean variable</returns>
        public static bool HasColumn(this IDataRecord r, string columnName)
        {
            try
            {
                return r.GetOrdinal(columnName) >= 0;
            }
            catch (IndexOutOfRangeException)
            {
                //_Logger.LogError(LoggingEvents.GENERAL_ERROR, $"Method: {UtilityMethods.GetCallerMemberName()} for column {columnName}");
                return false;
            }
        }

        /// <summary>
        /// Static operation to create a string name for datastore search/query parameter
        /// </summary>
        /// <param name="classObject">the object to be searched</param>
        /// <param name="parameterName">The parameter name to be combined with the class object name</param>
        /// <returns>A string combined parameter to query for the '_'</returns>
        public static string CreateDataReaderNameSearchParameter(this object classObject, string parameterName)
        {
            string result = "";
            result = string.Format($"{classObject.GetType().Name}_{parameterName}");
            return result;
        }

        /// <summary>
        /// Return a provide date formatted to a string for usage with SQL query parameters
        /// </summary>
        /// <param name="date">Date in question to format</param>
        /// <returns>A date string formatted to yyyy-MM-dd HH:mm:ss</returns>
        public static string GenerateSQLFormattedDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static object ConvertJsonStringToObject(string json)
        {
            throw new NotImplementedException();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ConvertJsonStringToProvidedGenericType<T>(string json)
        {
            T result;
            if(string.IsNullOrWhiteSpace(json))
            {
                //throw new ArgumentException();  
                _Logger.LogError("1", $"Exception with method {UtilityMethods.GetCallerMemberName()} but parameter content is empty");
                return default(T);
            }
            try
            {
                result = JsonConvert.DeserializeObject<T>(json);
                return (T)(object) result;
            }
            catch(JsonSerializationException e)
            {
                _Logger.LogError("1", $"Exception with method {UtilityMethods.GetCallerMemberName()} with exception: {e.Message}");
                return default(T);
            }
        }
    }
}