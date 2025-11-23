namespace Zoo.Domain.Contexts.Interfaces;

public interface ICuidadoRepository
{
    Task<Cuidado?> GetByIdAsync(Guid id);
    Task<IEnumerable<Cuidado>> GetAllAsync();
    Task AddAsync(Cuidado cuidado);
    Task UpdateAsync(Cuidado cuidado);
    Task DeleteAsync(Guid id);
}
