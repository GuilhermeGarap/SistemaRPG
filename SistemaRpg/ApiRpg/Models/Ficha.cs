using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [Range(1, 3, ErrorMessage = "O valor de Vigor deve estar entre 1 e 3.")]
        public int? Vigor { get; set; }

        [Range(1, 3, ErrorMessage = "O valor de Presença deve estar entre 1 e 3.")]
        public int? Presenca { get; set; }

        [Range(1, 3, ErrorMessage = "O valor de Sabedoria deve estar entre 1 e 3.")]
        public int? Sabedoria { get; set; }

        [Range(1, 3, ErrorMessage = "O valor de Força deve estar entre 1 e 3.")]
        public int Forca { get; set; }

        [Range(1, 3, ErrorMessage = "O valor de Agilidade deve estar entre 1 e 3.")]
        public int? Agilidade { get; set; }

        public int ClasseId { get; set; } 
        [JsonIgnore]
        public Classe? Classe { get; set; }
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario? Usuario { get; set; }
        public int CampanhaId { get; set; }
        [JsonIgnore]
        public Campanha? Campanha { get; set; }


    }
}
