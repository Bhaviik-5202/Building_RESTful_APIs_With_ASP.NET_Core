namespace Lab_10_EFCore_CRUD.Models
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
