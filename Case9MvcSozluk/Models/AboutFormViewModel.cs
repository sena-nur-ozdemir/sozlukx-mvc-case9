using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class AboutFormViewModel
    {
        [Required, StringLength(5000, MinimumLength = 10)]
        [Display(Name = "Hakkımızda — birinci bölüm")]
        public string Details1 { get; set; }
        [StringLength(5000)]
        [Display(Name = "İkinci bölüm")]
        public string Details2 { get; set; }
        [StringLength(300)]
        [Display(Name = "Birinci görsel yolu")]
        public string Image1 { get; set; }
        [StringLength(300)]
        [Display(Name = "İkinci görsel yolu")]
        public string Image2 { get; set; }
    }
}