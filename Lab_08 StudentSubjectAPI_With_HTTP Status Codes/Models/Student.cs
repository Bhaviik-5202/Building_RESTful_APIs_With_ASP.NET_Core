using System.ComponentModel.DataAnnotations;

namespace Lab_08_StudentSubjectAPI_With_HTTP_Status_Codes.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int SubjectId { get; set; }
    }
}



/*
 GET
  ├── Found      → 200 OK
  └── Not Found  → 404 Not Found

POST
   ├── Valid + New ID → 201 Created
   ├── Duplicate ID   → 409 Conflict
   └── Invalid Data   → 400 Bad Request

PUT
   ├── Found      → 204 No Content
   ├── Not Found  → 404 Not Found
   └── Invalid    → 400 Bad Request

DELETE
   ├── Found      → 204 No Content
   └── Not Found  → 404 Not Found
*/
