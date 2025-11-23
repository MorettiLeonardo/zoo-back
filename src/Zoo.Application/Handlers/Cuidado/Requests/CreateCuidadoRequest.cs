namespace Zoo.Application.Handlers.Cuidado.Requests;

public class CreateCuidadoRequest
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Frequencia { get; set; }
    public Guid AnimalId { get; set; }
}
