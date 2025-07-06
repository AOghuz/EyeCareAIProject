using BusinnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Controllers
{
    [AllowAnonymous]
    public class TreatmentController : Controller
    {
        TreatmentManager _treatmentManager = new TreatmentManager(new EfTreatmentDal());
        public IActionResult Index()
        {
            var values = _treatmentManager.GetList();

            return View(values);
        }
        public IActionResult Details(int id)
        {
            // ViewBag.i = id;
            //ViewBag.destID = id;
            // var values = await _userManager.FindByNameAsync(User.Identity.Name);
            // ViewBag.userID = values.Id;
            //ViewBag.Id = values.Id;
            ViewBag.SelectedTreatmentId = id;
            var value = _treatmentManager.GetById(id);
            return View(value);
        }
    }
}
