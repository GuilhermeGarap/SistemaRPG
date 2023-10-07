using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiRpg.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }
        public string Nome { get; set; }
        public int? Vida { get; set; }
        public int? Estamina { get; set; }
        public string DesAparencia { get; set; }
        public string Historia { get; set; }
        public int Vigor { get; set; }
        public int Presenca { get; set; }
        public int Sabedoria { get; set; }
        public int Forca { get; set; }
        public int Agilidade { get; set; }
        public int ClasseId { get; set; }

        [ForeignKey("ClasseId")]
        public Classe Classe { get; set; } 
        
        public int UsuarioId { get; set; }
        
        [ForeignKey("UsuarioId")]
        public Usuario Usuario { get; set; }
    }
}
