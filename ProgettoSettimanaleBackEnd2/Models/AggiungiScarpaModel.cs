using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanaleBackEnd2.Models
{
    public class AggiungiScarpaModel
    {

        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Il nome è obbligatorio!")]
        [StringLength(20, ErrorMessage = "Il nome deve essere compreso tra 5 e 20 caratteri", MinimumLength = 5)]
        public string? Nome { get; set; }

        [Display(Name = "Prezzo")]
        [Required(ErrorMessage = "Il prezzo è obbligatorio!")]
        [Range(1, 10000, ErrorMessage = "Il prezzo deve essere in un range compreso tra 1 e 10000 euro")]
        public decimal? Prezzo { get; set; }

        [Display(Name = "Descrizione")]
        [Required(ErrorMessage = "La descrizione è obbligatoria!")]
        [StringLength(2000, ErrorMessage = "La descrizione deve essere compresa tra 5 e 2000 caratteri", MinimumLength = 5)]
        public string? Descrizione { get; set; }

        [Display(Name = "Immagine di copertina")]
        [Required(ErrorMessage = "Metti un'ulteriore immagine aggiuntiva!")]
        public string? Img { get; set; }

        [Display(Name = "Immagine Aggiuntiva 1")]
        [Required(ErrorMessage = "Metti un'ulteriore immagine aggiuntiva!")]
        public string? AddImg1 { get; set; }

        [Display(Name = "Immagine Aggiuntiva 2")]
        [Required(ErrorMessage = "Metti un'altra immagine aggiuntiva!")]
        public string? AddImg2 { get; set; }
    }
}
