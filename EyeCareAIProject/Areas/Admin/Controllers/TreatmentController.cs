using BusinnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
  

    public class TreatmentController : Controller
    {
        
        private readonly ITreatmentService _treatmentService;
        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }
        //[Route("")]
        //[Route("Index")]
        public IActionResult Index()
        {
            var value = _treatmentService.TGetListWithDoctors();
            return View(value);
        }
        public IActionResult AddTreatment()
        {
            return View();
        }
        //[Route("")]
        //[Route("AddDestination")]
        [HttpPost]
        public async Task<IActionResult> AddTreatment(Treatment treatment, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var fileName = Guid.NewGuid() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TreatmentImages", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                treatment.ImageURL = fileName;
            }

            _treatmentService.TAdd(treatment);
            return RedirectToAction("Index");
        }
        //[Route("")]
        //[Route("DeleteDestination")]
        public IActionResult DeleteTreatment(int id)
        {
            var value = _treatmentService.GetById(id);
            _treatmentService.TDelete(value);
            return RedirectToAction("Index", "Treatment");
        }
        //[Route("")]
        //[Route("UpdateDestination")]
        [HttpGet]
        public IActionResult UpdateTreatment(int id)
        {
            var value = _treatmentService.GetById(id);

            if (value == null)
            {
                return NotFound(); // Eğer id ile eşleşen kayıt yoksa, uygun bir hata döndür.
            }

            return View(value); // Mevcut veriyi düzenleme ekranına gönder.
        }
        //[Route("")]
        //[Route("UpdateDestination")]
        [HttpPost]
        public async Task<IActionResult> UpdateTreatment(Treatment treatment, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extension = Path.GetExtension(ImageFile.FileName);
                var fileName = Guid.NewGuid() + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/TreatmentImages", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                treatment.ImageURL = fileName;
            }

            _treatmentService.TUpdate(treatment);
            return RedirectToAction("Index");
        }

    }
}
