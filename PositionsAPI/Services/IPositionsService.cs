using PositionsAPI.Models;

namespace PositionsAPI.Services
{
    public interface IPositionsService
    {
        Task<IEnumerable<Position>> GetAllPositions();
        Task<Position> GetPositionById(int id);
        Task<Position> CreatePosition(Position position);
        Task<Position> UpdatePosition(Position position);
        Task<bool> DeletePosition(int id);
    }
}