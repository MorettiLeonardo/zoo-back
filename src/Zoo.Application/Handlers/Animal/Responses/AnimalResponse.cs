public class AnimalResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Especie { get; set; }
    public string Habitat { get; set; }
    public string PaisOrigem { get; set; }

    public AnimalResponse(
        Guid id,
        string nome,
        string descricao,
        DateTime dataNascimento,
        string especie,
        string habitat,
        string paisOrigem
    )
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        DataNascimento = dataNascimento;
        Especie = especie;
        Habitat = habitat;
        PaisOrigem = paisOrigem;
    }

    public AnimalResponse() {}
}