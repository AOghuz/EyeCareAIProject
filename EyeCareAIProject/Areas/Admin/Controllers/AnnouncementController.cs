using AutoMapper;
using BusinnessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EyeCareAIProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());
            //List<AnnouncementListDTO> list = _announcementService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }
        public IActionResult DeleteAnnouncement(int Id)
        {
            var value = _announcementService.GetById(Id);
            _announcementService.TDelete(value);
            return RedirectToAction("Index","Announcement");
        }
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var value = _mapper.Map<AnnouncementUpdateDto>(_announcementService.GetById(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement()
                {
                    Id = model.Id,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement");
            }
            return View(model);
        }
    }
}
