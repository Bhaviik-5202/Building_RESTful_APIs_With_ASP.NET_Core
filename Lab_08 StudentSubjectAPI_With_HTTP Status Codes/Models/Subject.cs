using System.ComponentModel.DataAnnotations;

namespace Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
    }
}
