namespace FinancialManagementSystems.Models
{
    public enum ProjectStatus
    {
        NotStarted,
        InProgress,
        Completed
    }

    public class Project
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int ClientId { get; set; } 
        public ProjectStatus Status { get; set; } // ENUM
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; } 
        public string? AssignedTeam { get; set; } 

        
        public virtual Client Client { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}