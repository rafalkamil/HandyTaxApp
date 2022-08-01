using System.ComponentModel.DataAnnotations;

namespace HandyTaxApp.Models
{
    public class ActualNews
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? Title { get; set; }
        public DataType Data { get; set; }
        public string? Text { get; set; }
    }
}
