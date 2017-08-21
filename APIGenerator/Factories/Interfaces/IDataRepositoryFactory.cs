
using APIGenerator.Repository.Interfaces;

namespace APIGenerator.Factories.Interfaces
{
    public interface IDataRepositoryFactory
    {
        IDayRepository GetDayRepository();

        IPlayerRepository GetPlayerRepository();
    }
}