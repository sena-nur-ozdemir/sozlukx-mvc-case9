using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class GalleryFormViewModel
    {
        [Required, StringLength(100, MinimumLength = 2)]
        [Display(Name = "Görsel adı")]
        public string Name { get; set; }
        [Required, StringLength(300)]
        [Display(Name = "Görsel bağlantısı")]
        public string Path { get; set; }
    }
}