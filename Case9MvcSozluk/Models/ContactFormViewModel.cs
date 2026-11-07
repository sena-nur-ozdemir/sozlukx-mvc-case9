using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class ContactFormViewModel
    {
        [Required, StringLength(80, MinimumLength = 2)]
        [Display(Name = "Adınız")]
        public string Name { get; set; }
        [Required, EmailAddress, StringLength(100)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required, StringLength(3000, MinimumLength = 10)]
        [Display(Name = "Mesajınız")]
        public string Message { get; set; }
    }
}