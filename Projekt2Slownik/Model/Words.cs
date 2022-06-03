using System.ComponentModel.DataAnnotations;

namespace Projekt2Slownik.Model
{
    public class Words
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole jest wymagane")]
        [Display(Name = "słowo")]
        public string? Pl { get; set; }
        public string? No { get; set; }
    }
}
