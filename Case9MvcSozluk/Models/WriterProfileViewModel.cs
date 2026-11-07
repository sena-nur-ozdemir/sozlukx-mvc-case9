using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class WriterProfileViewModel
    {
        public int WriterID { get; set; }
        [Required, StringLength(80, MinimumLength = 2)]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required, StringLength(80, MinimumLength = 2)]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [StringLength(100)]
        [Display(Name = "Unvan")]
        public string Title { get; set; }
        [StringLength(1000)]
        [Display(Name = "Hakkımda")]
        public string About { get; set; }
    }
}