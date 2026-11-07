using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class EntryEditViewModel
    {
        public int ContentID { get; set; }
        [Required(ErrorMessage = "Entry boş olamaz.")]
        [StringLength(5000, MinimumLength = 5, ErrorMessage = "Entry 5–5000 karakter olmalıdır.")]
        [Display(Name = "Entry metni")]
        public string ContentValue { get; set; }
    }
}