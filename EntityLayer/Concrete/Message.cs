using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }

        [Required]
        [StringLength(100)]
        public string SenderMail { get; set; }

        [Required]
        [StringLength(100)]
        public string ReceiverMail { get; set; }

        [StringLength(150)]
        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public DateTime MessageDate { get; set; }

        public bool IsRead { get; set; }

        public bool IsDraft { get; set; }
    }
}
