using PositionsAPI.Models;

namespace PositionsAPI.Repositories
{
    public interface IPositionsRepository
    {
        Task<IEnumerable<Position>> GetAll();
        Task<Position> GetById(int id);
        Task<Position> Create(Position position);
        Task<Position> Update(Position position);
        Task<bool> Delete(int id);
    }
}
