using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ELPO_ProjectUserRelation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;
        private readonly IRoleService _roleService;
        private readonly ICategoryService _categoryService;

        public HomeController(IUserService userService,
            IProjectService projectService,
            IRoleService roleService,
            ICategoryService categoryService)
        {
            _userService = userService;
            _projectService = projectService;
            _roleService = roleService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
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