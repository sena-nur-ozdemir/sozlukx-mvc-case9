using System.ComponentModel.DataAnnotations;
namespace Case9MvcSozluk.Models
{
    public class WriterRegisterViewModel
    {
        [Required(ErrorMessage = "Ad zorunludur.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Ad 2–80 karakter olmalıdır.")]
        [Display(Name = "Ad")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad zorunludur.")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "Soyad 2–80 karakter olmalıdır.")]
        [Display(Name = "Soyad")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        [RegularExpression(@"^[A-Za-z0-9_]{3,50}$", ErrorMessage = "Kullanıcı adı 3–50 karakter olmalı; harf, rakam ve alt çizgi içerebilir.")]
        [Display(Name = "Kullanıcı adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "E-posta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli e-posta adresi giriniz.")]
        [StringLength(100)]
        [Display(Name = "E-posta")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola zorunludur.")]
        [StringLength(128, MinimumLength = 12, ErrorMessage = "Parola 12–128 karakter olmalıdır.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Parolayı tekrar giriniz.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor.")]
        [Display(Name = "Parola tekrarı")]
        public string ConfirmPassword { get; set; }
    }
}
