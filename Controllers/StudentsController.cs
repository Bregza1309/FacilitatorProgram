using FacilitatorProgram.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace FacilitatorProgram.Controllers
{
    public class StudentsController : Controller
    {
        public IStudentsRepository Repository;
        public StudentsController(IStudentsRepository repo)
        {
            Repository = repo;
        }
        [HttpGet]
        public async Task<ViewResult> Details(int studentId)
        {
            return View(await Repository.RetreiveStudent(studentId));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                Student? existing = await Repository.RetreiveStudent(student.StudentId);
                if (existing == null)
                {
                    if(await Repository.CreateStudent(student))
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        ModelState.AddModelError("","Student Already exist");
                    }
                }
                else
                {
                    await Repository.SaveStudent(student);
                    return Redirect("/");
                }
                
                
            }
            return View(student);
            
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? studentId)
        {
            if(studentId == null)
            {
                return View();
            }
            Student? EditStudent = await Repository.RetreiveStudent((int)studentId);
            return View(EditStudent);
        }
        
        public async Task<IActionResult> Delete(int studentId)
        {
            await Repository.DeleteStudent(studentId);
            return Redirect("/");
        }
    }
}
