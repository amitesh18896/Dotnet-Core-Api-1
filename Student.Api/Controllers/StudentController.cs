using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.PresentationLayer.ViewModel;
using Student.Service.Iservice;

namespace Student.Api.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IEnumerable<StudentViewModel> GetAll()
        {
            return _studentService.GetAll();
        }
        [HttpPut]
        public void Update(StudentViewModel model)
        {
            _studentService.UpdateStudent(model);
        }
        [HttpPost]
        public void AddStudent(StudentViewModel model)
        {
            _studentService.AddStudent(model);
        }
        [HttpDelete]
        public void DeleteStudentByID(int Id)
        {
            _studentService.DeleteStudentByID(Id);
        }

    }
}