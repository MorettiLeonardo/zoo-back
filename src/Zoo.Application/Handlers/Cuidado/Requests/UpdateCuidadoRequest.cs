namespace Zoo.Application.Handlers.Cuidado.Requests;

public class UpdateCuidadoRequest
{
    public Guid Id { get; set; }
    public string Nome  { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Frequencia { get; set; } = string.Empty;
}