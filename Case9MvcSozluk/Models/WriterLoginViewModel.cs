using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class WriterLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Parola zorunludur.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
    }
}
