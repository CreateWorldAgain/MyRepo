using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TEst2.Models;
using TEst2.Services;
using static TEst2.Models.ImportFileInfo;

namespace TEst2.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private AppDbContext _db;
        private ILogger _logger;
        private UserManager<ApplicationUser> _userManager;

        public HomeController(AppDbContext db, ILogger<HomeController> logger, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }    
        
        public void ChangeLang(string lang)
        {
            
        }

        [HttpGet]
        [Route("/home/testimport", Name ="TestImport")]
        async public Task<IActionResult> TestImport()
        {
            var user= await _userManager.FindByNameAsync(User.Identity.Name);

            string error = ImportFile.ImportExcel(@"c:\temp\a1.xlsx",_db,_logger,user.Id);

            return Json(new { error=error});
        }
       
    }
}
