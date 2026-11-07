
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }

        [StringLength(50)]
        public string WriterUserName { get; set; }

        public string WriterMail { get; set; }

        public string WriterPasswordHash { get; set; }
        public string WriterPasswordSalt { get; set; }

        public string WriterImage { get; set; }
        public string WriterTitle { get; set; }
        public string WriterAbout { get; set; }
        public bool WriterStatus { get; set; }

        public virtual ICollection<Heading> Headings { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}
