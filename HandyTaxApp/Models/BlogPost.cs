using System.ComponentModel.DataAnnotations;

namespace HandyTaxApp.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public string? Text { get; set; }
    }
}
