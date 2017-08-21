
using APIGenerator.Repository.Interfaces;

namespace APIGenerator.Factories.Interfaces
{
    /// <summary>
    /// Interface for how to handle Repository object factory implementation
    /// </summary>
    public interface IDataRepositoryFactory
    {
        /// <summary>
        /// Interface operation to handle the return of a day repository
        /// </summary>
        /// <returns></returns>
        IDayRepository GetDayRepository();

        /// <summary>
        /// Interface operation to handle the request for all
        /// </summary>
        /// <returns></returns>
        IPlayerRepository GetPlayerRepository();
    }
}