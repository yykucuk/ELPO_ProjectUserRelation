using ELPO_ProjectUserRelation.Bussiness.Abstract;
using ELPO_ProjectUserRelation.Entities.ELPOContextDir;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELPO_ProjectUserRelation.Controllers
{
    public class MemberController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProjectUserRelationService _projectUserRelationService;

        public MemberController(IUserService userService, IProjectUserRelationService projectUserRelationService)
        {
            _userService = userService;
            _projectUserRelationService = projectUserRelationService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminMemberList()
        {
            List<User> users = _userService.GetAll();
            return View(users);
        }

        [Authorize(Roles = "User")]
        public IActionResult UserMemberList()
        {
            List<User> users = _userService.GetUsersByUserId(Convert.ToInt32(User.Identity.Name));
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAProjectUserRelation(int id)
        {
            bool isDelete = _projectUserRelationService.DeleteByResult(id);
            return RedirectToAction("AdminMemberList");
        }
    }
}
