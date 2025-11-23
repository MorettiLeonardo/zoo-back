using Zoo.Application.Handlers.Animal.Requests;
using Zoo.Domain.Contexts.Interfaces;

namespace Zoo.Application.Handlers.Animal;

public class AnimalHandler
{
    private readonly IAnimalRepository _animalRepository;

    public AnimalHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    private static AnimalResponse ToResponse(Domain.Contexts.Animal a)
    {
        return new AnimalResponse(
            a.Id,
            a.Nome,
            a.Descricao,
            a.DataNascimento,
            a.Especie,
            a.Habitat,
            a.PaisOrigem
        );
    }

    public async Task<IEnumerable<AnimalResponse>> GetAllAsync()
    {
        var animals = await _animalRepository.GetAllAsync();
        return animals.Select(ToResponse);
    }

    public async Task<AnimalResponse?> GetByIdAsync(Guid id)
    {
        var a = await _animalRepository.GetByIdAsync(id);
        return a == null ? null : ToResponse(a);
    }

    public async Task<AnimalResponse> CreateAsync(CreateAnimalRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ArgumentException("O nome do animal é obrigatório.");

        var entity = new Domain.Contexts.Animal(
            request.Nome,
            request.Descricao,
            request.DataNascimento,
            request.Especie,
            request.Habitat,
            request.PaisOrigem
        );

        await _animalRepository.AddAsync(entity);
        return ToResponse(entity);
    }

    public async Task<bool> UpdateAsync(UpdateAnimalRequest request)
    {
        var existing = await _animalRepository.GetByIdAsync(request.Id);
        if (existing == null) return false;

        existing.SetNome(request.Nome);
        existing.SetDescricao(request.Descricao);
        existing.SetDataNascimento(request.DataNascimento);
        existing.SetEspecie(request.Especie);
        existing.SetHabitat(request.Habitat);
        existing.SetPaisOrigem(request.PaisOrigem);

        await _animalRepository.UpdateAsync(existing);
        return true;
    }


    public async Task<bool> DeleteAsync(Guid id)
    {
        var exists = await _animalRepository.GetByIdAsync(id);
        if (exists == null) return false;

        await _animalRepository.DeleteAsync(id);
        return true;
    }
}
