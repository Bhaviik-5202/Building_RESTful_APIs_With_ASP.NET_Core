using Lab_07_Student_API.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private static List<Student> Students =
    [
        new Student { Id = 1, Name = "Bhaviik", City = "Dwarka" },
        new Student { Id = 2, Name = "Ronak", City = "Kalyanpur" },
        new Student { Id = 3, Name = "Deep", City = "Rajkot" }
    ];

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(new
        {
            message = "All Students fetched successfully.",
            data = Students
        });
    }

    [HttpGet("{Id}")]
    public IActionResult GetByIdStudent(int Id)
    {
        var student = Students.Find(s => s.Id == Id);
        return Ok(new
        {
            message = "Student fetched successfully.",
            data = Students
        });
    }

    [HttpPost]
    public IActionResult AddStudent(Student newStudent)
    {
        Students.Add(newStudent);
        return Ok(new
        {
            message = "Student Add successfully.",
            data = Students
        });
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateStudent(int id, Student updatedStudent)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        student.Name = updatedStudent.Name;
        student.City = updatedStudent.City;

        return Ok(new
        {
            message = "Student Update successfully.",
            data = Students
        });
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = Students.FirstOrDefault(s => s.Id == id);
        Students.Remove(student);

        return Ok(new
        {
            message = "Student Delete successfully.",
            data = Students
        });
    }
}