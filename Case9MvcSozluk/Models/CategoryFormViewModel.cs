using System.ComponentModel.DataAnnotations;

namespace Case9MvcSozluk.Models
{
    public class CategoryFormViewModel
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(50,
            ErrorMessage = "Kategori adı en fazla 50 karakter olabilir.")]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }

        [StringLength(250,
            ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        [Display(Name = "Kategori Açıklaması")]
        public string CategoryDescription { get; set; }
    }
}
