using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ELPO_ProjectUserRelation.Models;

namespace ELPO_ProjectUserRelation.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private Microsoft.Extensions.Hosting.IHostingEnvironment _environment;

        public ProjectController(IProjectService projectService, Microsoft.Extensions.Hosting.IHostingEnvironment environment)
        {
            _projectService = projectService;
            _environment = environment;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminProjectList()
        {
            List<Project> projects = _projectService.GetAll();
            return View(projects);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAProject(int id)
        {
            bool isDelete = _projectService.DeleteByResult(id);
            return RedirectToAction("AdminProjectList");
        }

        [Authorize(Roles = "User")]
        public IActionResult UserProjectList()
        {
            List<Project> projects = _projectService.GetProjectsByUserId(Convert.ToInt32(User.Identity.Name));
            return View(projects);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddProject(string? msg)
        {
            ErrorMsgModel errorMsg = new ErrorMsgModel { Msg = msg };
            return View(errorMsg);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProject(string name, IFormFile icon, string description, int progress)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return RedirectToAction("AddProject", new { msg = "Proje adı giriniz!" });
            }
            if(icon == null || icon.Length == 0)
            {
                return RedirectToAction("AddProject", new {msg = "dosya giriniz!" });
            }
            var extention = Path.GetExtension(icon.FileName).Trim('.').ToLower();
            if (!(new[] {"jpg", "png", "jpeg" }).Contains(extention))
            {
                return RedirectToAction("AddProject", new { msg = ".jpg, .png yada jpeg olarak giriniz!" } );
            }
            string path = Path.Combine(_environment.ContentRootPath, "wwwroot\\Img");
            if (!Directory.Exists(Path.Combine(path)))
            {
                Directory.CreateDirectory(Path.Combine(path));
            }
            string fileName = Path.GetFileName(icon.FileName);
            using (Stream fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                icon.CopyTo(fileStream);
            }
            bool isDelete = _projectService.CreateByResult(name, fileName, description, progress);
            return RedirectToAction("AdminProjectList");
        }

    }
}
