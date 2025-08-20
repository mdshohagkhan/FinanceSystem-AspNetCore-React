namespace FinancialManagementSystems.Models
{
    public enum InvoiceStatus
    {
        Paid,
        Unpaid,
        Partial
    }

    public class Invoice
    {
        public int Id { get; set; } 
        public int ProjectId { get; set; } 
        public decimal Amount { get; set; } 
        public InvoiceStatus? Status { get; set; } // ENUM
        public DateTime IssueDate { get; set; } 
        public DateTime DueDate { get; set; } 
        public string? InvoiceFile { get; set; } 

       
        public virtual Project Project { get; set; }
    }
}