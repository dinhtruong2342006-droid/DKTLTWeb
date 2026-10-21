using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using DktLesson10.Models;

namespace MyWebApp.Controllers
{
    [Route("Admin/Student")] // Gom chung du?ng d?n g?c cho s?p t?ng Controller này
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();

        public StudentController()
        {
            // T?o danh sách sinh viên v?i 4 d? li?u m?u
            listStudents = new List<Student>()
            {
                new Student() { Id = 101, Name = "H?i Nam", Branch = Branch.IT,
                    Gender = Gender.Male, IsRegular=true,
                    Address = "A1-2018", Email = "nam@g.com" },
                new Student() { Id = 102, Name = "Minh Tú", Branch = Branch.BE,
                    Gender = Gender.Female, IsRegular=true,
                    Address = "A1-2019", Email = "tu@g.com" },
                new Student() { Id = 103, Name = "Hoàng Phong", Branch = Branch.CE,
                    Gender = Gender.Male, IsRegular=false,
                    Address = "A1-2020", Email = "phong@g.com" },
                new Student() { Id = 104, Name = "Xuân Mai", Branch = Branch.EE,
                    Gender = Gender.Female, IsRegular = false,
                    Address = "A1-2021", Email = "mai@g.com" }
            };
        }

        // Route: /Admin/Student/List (ho?c truy c?p tr?c ti?p /Admin/Student)
        [Route("List")]
        [Route("")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        // Route: /Admin/Student/Add (GET)
        [HttpGet("Add")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View();
        }

        // Route: /Admin/Student/Add (POST)
        [HttpPost("Add")]
        public IActionResult Create(Student s)
        {
            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
    }
}