using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TEst2.Models;
using TEst2.Models.ViewModels;


namespace TEst2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private AppDbContext _db;

        public UserController(UserManager<ApplicationUser> userManager,
            AppDbContext db)
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("~/user/profile", Name = "UserProfile")]
        async public Task<IActionResult> UserProfile()
        {
            var model = new UserViewModel();

            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            model.Id = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.UserName = user.UserName;            

            return PartialView("UserProfile", model);
        }
      
        [HttpPost]
        [Route("~/user/save", Name = "UserSave")]
        public IActionResult UserSave(UserViewModel model)
        {
            string error = "";

            try
            {
                if (!String.IsNullOrWhiteSpace(model.Password))
                {
                    if (!model.Password.Equals(model.ConfirmPassword))
                        throw new Exception("Пароли не совпадают");
                }

                var user = _db.Users.Single(x => x.Id == model.Id);

                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }


                if (!String.IsNullOrWhiteSpace(model.Password))
                {
                    String hashedNewPassword= _userManager.PasswordHasher.HashPassword(user,model.Password);
                    user.PasswordHash = hashedNewPassword;
                    _db.SaveChanges();
                }

                // если есть роли, которые были установлены некоторым Owner-ом и эти роли

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                

                _db.SaveChanges();

                
            }
            catch (Exception ex)
            {                
                error=ex.Message;
            }

            return Json(new { error=error});
        }
    }
}
