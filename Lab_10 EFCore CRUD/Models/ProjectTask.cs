namespace Lab_10_EFCore_CRUD.Models
{
    public class ProjectTask
    {
        public int ProjectTaskId { get; set; }

        public string TaskName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        public Project? Project { get; set; }
    }
}
