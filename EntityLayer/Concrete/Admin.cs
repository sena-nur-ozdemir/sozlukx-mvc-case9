using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Required]
        [StringLength(50)]
        public string AdminUserName { get; set; }

        [Required]
        [StringLength(100)]
        public string AdminMail { get; set; }

        public string AdminPasswordHash { get; set; }
        public string AdminPasswordSalt { get; set; }

        [StringLength(30)]
        public string AdminRole { get; set; }
    }
}
