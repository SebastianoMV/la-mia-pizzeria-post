using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_post.Models
{
    [Table("pizze")]
    public class Pizza
    {
        public Pizza(string nome, string descrizione, string image, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Image = image;
            Prezzo = prezzo;
        }

        public Pizza()
        {

        }

        [Key]

        public int Id { get; set; }
      
        [Required(ErrorMessage = "Il campo nome è obbligatorio")]
        [StringLength(30, ErrorMessage = "Il nome non può avere più di 30 caratteri")]
        public string Nome { get; set; }
        
        [StringLength(100, ErrorMessage = "La descrizione non può avere più di 100 caratteri")]
        public string Descrizione { get; set; }
        [Url(ErrorMessage = "Il campo immagine deve essere un Link")]
        public string Image { get; set; }
        [Required]
        [Range(1, 99)]
        public double Prezzo { get; set; }
    }
}
