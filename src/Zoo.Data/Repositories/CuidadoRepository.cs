using Microsoft.EntityFrameworkCore;
using Zoo.Domain.Contexts;
using Zoo.Domain.Contexts.Interfaces;

namespace Zoo.Data.Repositories
{
    public class CuidadoRepository : ICuidadoRepository
    {
        private readonly ApplicationDbContext _context;

        public CuidadoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cuidado?> GetByIdAsync(Guid id)
        {
            return await _context.Cuidados
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cuidado>> GetAllAsync()
        {
            return await _context.Cuidados.ToListAsync();
        }

        public async Task AddAsync(Cuidado cuidado)
        {
            await _context.Cuidados.AddAsync(cuidado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cuidado cuidado)
        {
            _context.Cuidados.Update(cuidado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var cuidado = await GetByIdAsync(id);

            if (cuidado is null)
                return; // ou lançar exceção de domínio, se preferir

            _context.Cuidados.Remove(cuidado);
            await _context.SaveChangesAsync();
        }
    }
}