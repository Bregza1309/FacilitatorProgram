using FacilitatorProgram.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using FacilitatorProgram.Models.Data;
using System.Diagnostics;

namespace FacilitatorProgram.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IStudentsRepository repo;

        public HomeController(ILogger<HomeController> logger, IStudentsRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await repo.GetStudents());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}