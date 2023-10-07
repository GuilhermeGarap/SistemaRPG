namespace ApiRpg.Models;

public class Campanha
{
    public int CampanhaId { get; set; }
    public string Nome { get; set; }
    public string Sinopse { get; set; }
    public List<Fichas> Fichas { get; set; }
}
