using System.Collections.Generic;
using EntityLayer.Concrete;
namespace Case9MvcSozluk.Models
{
    public class HomeIndexViewModel
    {
        public List<Heading> Headings { get; set; } = new List<Heading>();
        public List<Content> Entries { get; set; } = new List<Content>();
        public int? SelectedHeadingID { get; set; }
        public int? CurrentWriterID { get; set; }
        public string CurrentWriterName { get; set; }
    }
}