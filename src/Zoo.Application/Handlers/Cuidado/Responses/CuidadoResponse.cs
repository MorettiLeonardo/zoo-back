namespace Zoo.Application.Handlers.Cuidado.Responses;

public class CuidadoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Frequencia { get; set; }

    public CuidadoResponse(Guid id, string nome, string descricao, string frequencia)
    {
        Id = id;
        Nome = nome;
        Descricao = descricao;
        Frequencia = frequencia;
    }
}

