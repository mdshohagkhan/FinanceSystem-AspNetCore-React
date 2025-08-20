namespace FinancialManagementSystems.Models
{
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Done
    }

    public class ProjectTask
    {
        public int Id { get; set; } 
        public int ProjectId { get; set; } 
        public string Title { get; set; } 
        public TaskStatus Status { get; set; } // ENUM
        public DateTime DueDate { get; set; } 

        
        public virtual Project Project { get; set; }
    }
}