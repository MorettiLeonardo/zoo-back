using Zoo.Domain.Contexts.Common;

namespace Zoo.Domain.Contexts;

public class Animal : BaseEntity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Especie { get; private set; }
    public string Habitat { get; private set; }
    public string PaisOrigem { get; private set; }

    public List<Cuidado> Cuidados { get; private set; } = new();

    protected Animal() { }

    public Animal(
        string nome,
        string descricao,
        DateTime dataNascimento,
        string especie,
        string habitat,
        string paisOrigem)
    {
        SetNome(nome);
        SetDescricao(descricao);
        SetDataNascimento(dataNascimento);
        SetEspecie(especie);
        SetHabitat(habitat);
        SetPaisOrigem(paisOrigem);
    }

    #region Setters com validação
    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do animal é obrigatório.");

        Nome = nome.Trim();
    }

    public void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição é obrigatória.");

        Descricao = descricao.Trim();
    }

    public void SetDataNascimento(DateTime dataNascimento)
    {
        if (dataNascimento > DateTime.UtcNow)
            throw new ArgumentException("A data de nascimento não pode ser no futuro.");

        DataNascimento = dataNascimento;
    }

    public void SetEspecie(string especie)
    {
        if (string.IsNullOrWhiteSpace(especie))
            throw new ArgumentException("Espécie é obrigatória.");

        Especie = especie.Trim();
    }

    public void SetHabitat(string habitat)
    {
        if (string.IsNullOrWhiteSpace(habitat))
            throw new ArgumentException("Habitat é obrigatório.");

        Habitat = habitat.Trim();
    }

    public void SetPaisOrigem(string pais)
    {
        if (string.IsNullOrWhiteSpace(pais))
            throw new ArgumentException("País de origem é obrigatório.");

        PaisOrigem = pais.Trim();
    }
    #endregion
}
