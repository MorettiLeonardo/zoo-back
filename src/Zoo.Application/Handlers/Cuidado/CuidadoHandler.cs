using Zoo.Application.Handlers.Cuidado.Requests;
using Zoo.Application.Handlers.Cuidado.Responses;
using Zoo.Domain.Contexts.Interfaces;

namespace Zoo.Application.Handlers.Cuidado;

public class CuidadoHandler
{
    private readonly ICuidadoRepository _cuidadoRepository;
    private readonly IAnimalRepository _animalRepository;

    public CuidadoHandler(ICuidadoRepository cuidadoRepository,  IAnimalRepository animalRepository)
    {
        _cuidadoRepository = cuidadoRepository;
        _animalRepository = animalRepository;
    }

    private static CuidadoResponse ToResponse(Domain.Contexts.Cuidado c)
    {
        return new CuidadoResponse(
            c.Id,
            c.Nome,
            c.Descricao,
            c.Frequencia
        );
    }

    public async Task<IEnumerable<CuidadoResponse>> GetAllAsync()
    {
        var cuidados = await _cuidadoRepository.GetAllAsync();
        return cuidados.Select(ToResponse);
    }

    public async Task<CuidadoResponse?> GetByIdAsync(Guid id)
    {
        var c = await _cuidadoRepository.GetByIdAsync(id);
        return c == null ? null : ToResponse(c);
    }

    public async Task<CuidadoResponse> CreateAsync(CreateCuidadoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ArgumentException("Nome do cuidado é obrigatório.");

        var animal = await _animalRepository.GetByIdAsync(request.AnimalId);

        var cuidado = new Domain.Contexts.Cuidado(
            request.Nome,
            request.Descricao,
            request.Frequencia,
            animal.Id
        );

        animal.Cuidados.Add(cuidado);

        await _cuidadoRepository.AddAsync(cuidado);

        return ToResponse(cuidado);
    }

    public async Task<bool> UpdateAsync(UpdateCuidadoRequest request)
    {
        var existing = await _cuidadoRepository.GetByIdAsync(request.Id);
        if (existing == null) return false;

        existing.SetNome(request.Nome);
        existing.SetDescricao(request.Descricao);
        existing.SetFrequencia(request.Frequencia);

        await _cuidadoRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var exists = await _cuidadoRepository.GetByIdAsync(id);
        if (exists == null) return false;

        await _cuidadoRepository.DeleteAsync(id);
        return true;
    }
}
