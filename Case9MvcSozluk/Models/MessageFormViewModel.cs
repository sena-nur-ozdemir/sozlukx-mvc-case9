using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class MessageFormViewModel
    {
        [Required, EmailAddress, StringLength(100)]
        [Display(Name = "Alıcı e-posta")]
        public string Recipient { get; set; }
        [Required, StringLength(150, MinimumLength = 2)]
        [Display(Name = "Konu")]
        public string Subject { get; set; }
        [Required, StringLength(5000, MinimumLength = 2)]
        [Display(Name = "Mesaj")]
        public string Body { get; set; }
    }
}