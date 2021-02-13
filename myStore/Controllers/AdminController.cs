using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myStore.Controllers
{
    public class AdminController : Controller
    {
        //[Authorize(Roles = "Administrator")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
