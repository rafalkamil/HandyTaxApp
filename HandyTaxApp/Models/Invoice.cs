using System.ComponentModel.DataAnnotations;

namespace HandyTaxApp.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int? InvoiceNumber { get; set; }
        public string InvoiceContractor { get; set; }
        public string? InvoiceContractorPostalCode { get; set; }
        public string? InvoiceContractorAddress { get; set; }
        public int InvoiceSum { get; set; }
        public int InvoiceSumVat { get; set; }
        public string InvoiceDescription { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string? ImageURL { get; set; }
    }
}
