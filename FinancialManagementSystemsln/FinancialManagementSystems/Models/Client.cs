namespace FinancialManagementSystems.Models
{
    public class Client
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string? Company { get; set; } 
        public string? Phone { get; set; } 
        public DateTime CreatedAt { get; set; } 

       
        public virtual ICollection<Project> Projects { get; set; }
    }
}
