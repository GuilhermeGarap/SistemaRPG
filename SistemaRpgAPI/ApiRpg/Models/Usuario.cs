namespace ApiRpg.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public List<Campanha> Campanhas { get; set; }
    public List<Fichas> Fichas { get; set; }
}
