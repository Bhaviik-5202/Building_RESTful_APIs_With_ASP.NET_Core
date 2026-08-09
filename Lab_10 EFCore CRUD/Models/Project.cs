namespace Lab_10_EFCore_CRUD.Models
{
    public class Project
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

        public ICollection<ProjectAllocation> Allocations { get; set; } = new List<ProjectAllocation>();
    }
}
