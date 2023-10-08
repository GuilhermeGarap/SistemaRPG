namespace ApiRpg.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public List<Ficha>? Fichas { get; set; } 
}
