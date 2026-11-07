using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class ImageFile
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageName { get; set; }

        [Required]
        [StringLength(300)]
        public string ImagePath { get; set; }
    }
}
