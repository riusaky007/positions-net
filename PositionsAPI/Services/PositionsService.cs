using PositionsAPI.Models;
using PositionsAPI.Repositories;

namespace PositionsAPI.Services
{
    public class PositionsService : IPositionsService
    {
        private readonly IPositionsRepository _repository;

        public PositionsService(IPositionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            return await _repository.GetAll();
        }

        public async Task<Position> GetPositionById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<Position> CreatePosition(Position position)
        {
            // Validate required fields
            if (string.IsNullOrEmpty(position.Title) ||
                string.IsNullOrEmpty(position.Description) ||
                string.IsNullOrEmpty(position.Location) ||
                string.IsNullOrEmpty(position.Status) ||
                position.RecruiterId <= 0 ||
                position.DepartmentId <= 0 ||
                position.Budget <= 0)
            {
                throw new ArgumentException("All required fields must be provided");
            }

            return await _repository.Create(position);
        }

        public async Task<Position> UpdatePosition(Position position)
        {
            var existingPosition = await _repository.GetById(position.PositionId);
            if (existingPosition == null)
            {
                throw new KeyNotFoundException($"Position with ID {position.PositionId} not found");
            }

            return await _repository.Update(position);
        }

        public async Task<bool> DeletePosition(int id)
        {
            return await _repository.Delete(id);
        }
    }
}