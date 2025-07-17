using Microsoft.EntityFrameworkCore;
using PositionsAPI.Data;
using PositionsAPI.Models;

namespace PositionsAPI.Repositories
{
    public class PositionsRepository : IPositionsRepository
    {
        private readonly PositionsDbContext _context;

        public PositionsRepository(PositionsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAll()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position> GetById(int id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<Position> Create(Position position)
        {
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<Position> Update(Position position)
        {
            _context.Entry(position).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return position;
        }

        public async Task<bool> Delete(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return false;
            }

            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}