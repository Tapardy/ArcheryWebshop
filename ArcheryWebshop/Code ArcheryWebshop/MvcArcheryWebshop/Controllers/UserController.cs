using DAL;
using Microsoft.AspNetCore.Mvc;
using MvcArcheryWebshop.Models;
using WebshopClassLibrary;
using WebshopClassLibrary.Mappers;

namespace MvcArcheryWebshop.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;
        private readonly RoleService _roleService;
        private readonly UserRoleService _userRoleService;

        public UserController()
        {
            _userService = new UserService(new UserDAL());
            _roleService = new RoleService(new RoleDAL());
            _userRoleService = new UserRoleService(new UserRoleDAL());
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            User user = _userService.GetUserByName(userModel.Name);

            if (user != null && user.Password == userModel.Password)
            {
                var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), Path = "/" };
                SetCookie("UserNameCookie", user.Name, cookieOptions);

                List<int> userRoleIDs = _userRoleService.GetRoleIDForUsers(user.ID);
                int lastRoleID = userRoleIDs.LastOrDefault();
                string role = _roleService.GetRoleByID(lastRoleID)?.Name ?? string.Empty;
                SetCookie("UserRoleCookie", role, cookieOptions);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View(userModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            List<Role> roles = _roleService.GetAllRoles();
            ViewBag.Roles = roles;

            return View(new UserModel());
        }

        [HttpPost]
        [Route("User/Register")]
        public IActionResult Register(UserModel userModel, List<int> selectedRoles)
        {
            User existingUser = _userService.GetUserByName(userModel.Name);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return View(userModel);
            }

            User newUser = new User
            {
                Name = userModel.Name,
                Password = userModel.Password
            };

            _userService.AddUser(newUser);
            User createdUser = _userService.GetUserByName(newUser.Name);

            CookieOptions? cookieOptions;
            if (selectedRoles != null)
            {
                foreach (int roleId in selectedRoles)
                {
                    _userRoleService.AddRoleToUser(createdUser.ID, roleId);
                }

                string role = _roleService.GetRoleByID(selectedRoles.LastOrDefault())?.Name ?? string.Empty;
                cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), Path = "/" };
                SetCookie("UserRoleCookie", role, cookieOptions);
            }

            cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(1), Path = "/" };
            SetCookie("UserNameCookie", newUser.Name, cookieOptions);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            DeleteCookie("UserNameCookie");
            DeleteCookie("UserRoleCookie");

            return RedirectToAction("Login", "User");
        }

        private void SetCookie(string key, string value, CookieOptions options)
        {
            Response.Cookies.Append(key, value, options);
        }

        private void DeleteCookie(string key)
        {
            Response.Cookies.Delete(key);
        }
    }
}