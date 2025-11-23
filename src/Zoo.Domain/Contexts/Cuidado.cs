using Zoo.Domain.Contexts.Common;

namespace Zoo.Domain.Contexts;

public class Cuidado : BaseEntity
{
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Frequencia { get; private set; }

    // 🔥 RELACIONAMENTO
    public Guid AnimalId { get; private set; }
    public Animal Animal { get; private set; }

    protected Cuidado() { }

    public Cuidado(string nome, string descricao, string frequencia, Guid animalId)
    {
        SetNome(nome);
        SetDescricao(descricao);
        SetFrequencia(frequencia);
        AnimalId = animalId;
    }

    #region Setters
    public void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome do cuidado é obrigatório.");
        Nome = nome.Trim();
    }

    public void SetDescricao(string descricao)
    {
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Descrição é obrigatória.");
        Descricao = descricao.Trim();
    }

    public void SetFrequencia(string frequencia)
    {
        if (string.IsNullOrWhiteSpace(frequencia))
            throw new ArgumentException("Frequência é obrigatória.");
        Frequencia = frequencia.Trim();
    }
    #endregion
}