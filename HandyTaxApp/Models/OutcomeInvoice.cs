using System.ComponentModel.DataAnnotations;

namespace HandyTaxApp.Models
{
    public class OutcomeInvoice
    {
        [Key]
        public int Id { get; set; }
        public int? InvoiceNumber { get; set; }
        public string Client { get; set; }
        public string ClientNumber { get; set; }
        public string? ClientPostalCode { get; set; }
        public string? ClientAddress { get; set; }
        public int UnitPrice { get; set; }
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
        public int TotalAmountVAT { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
