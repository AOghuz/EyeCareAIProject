﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Hasta.Controllers
{
    [Area("Hasta")]
    [Authorize(Roles = "Patient")]
    public class ResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
