using Microsoft.EntityFrameworkCore;
using Zoo.Domain.Contexts;
using Zoo.Domain.Contexts.Interfaces;

public class AnimalRepository : IAnimalRepository
{
    private readonly ApplicationDbContext _context;

    public AnimalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Animal> GetByIdAsync(Guid id) =>
        await _context.Animais.FindAsync(id);

    public async Task<IEnumerable<Animal>> GetAllAsync() =>
        await _context.Animais.ToListAsync();

    public async Task AddAsync(Animal animal)
    {
        _context.Animais.Add(animal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Animal animal)
    {
        _context.Animais.Update(animal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Animais.FindAsync(id);
        if (entity != null)
        {
            _context.Animais.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}