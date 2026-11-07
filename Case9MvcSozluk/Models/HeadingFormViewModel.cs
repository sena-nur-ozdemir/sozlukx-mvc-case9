using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class HeadingFormViewModel
    {
        public int HeadingID { get; set; }
        [Required(ErrorMessage = "Başlık adı zorunludur.")]
        [StringLength(150, MinimumLength = 3, ErrorMessage = "Başlık 3–150 karakter olmalıdır.")]
        [Display(Name = "Başlık adı")]
        public string HeadingName { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Kategori seçiniz.")]
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        [Display(Name = "Yazar")]
        public int WriterID { get; set; }
    }
}