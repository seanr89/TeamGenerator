using System;
using System.Collections.Generic;
using APIGenerator.Models;
using APIGenerator.Repository.Interfaces;

namespace APIGenerator.Repository.SQL
{
    /// <summary>
    /// Class object to handle Day Repository events by SQL events
    /// </summary>
    public class SQLDayRepository : IDayRepository
    {
        public int AddNewDay(Day day)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetAllDays()
        {
            throw new NotImplementedException();
        }

        public Day GetDayByID(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Day> GetDaysInDateRange(DateTime Start, DateTime End)
        {
            throw new NotImplementedException();
        }
    }
}