
using System;
using System.Collections.Generic;
using APIGenerator.Models;

namespace APIGenerator.Repository.Interfaces
{
    public interface IDayRepository
    {
        /// <summary>
        /// Operation to insert/save a new day event
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        int AddNewDay(Day day);

        /// <summary>
        /// Interface operation to request all stored Days
        /// </summary>
        /// <returns></returns>
        IEnumerable<Day> GetAllDays();

        /// <summary>
        /// Interface operation to requuest a stored Day by unique ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        Day GetDayByID(int ID);

        /// <summary>
        /// Interface operation to request all stored Days within a date range
        /// </summary>
        /// <param name="Start"></param>
        /// <param name="End"></param>
        /// <returns></returns>
        IEnumerable<Day> GetDaysInDateRange(DateTime Start, DateTime End);
    }
}