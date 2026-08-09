namespace Lab_10_EFCore_CRUD.Models
{
    public class ProjectAllocation
    {
        public int ProjectAllocationId { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public string AllocationRole { get; set; } = string.Empty;

        public Project? Project { get; set; }

        public User? User { get; set; }
    }
}
