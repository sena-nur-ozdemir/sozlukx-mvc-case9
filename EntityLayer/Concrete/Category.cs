using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID {  get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        [StringLength(250)]
        public string CategoryDescription { get; set; }


        public virtual ICollection<Heading> Headings { get; set; }
    }
}
