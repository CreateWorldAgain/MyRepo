using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TEst2.Controllers
{
    public class AdministrationController : Controller
    {
        [HttpGet]
        [Route("~/administration/users",Name="Users")]
        public IActionResult Users()
        {

            return View();
        }
    }
}