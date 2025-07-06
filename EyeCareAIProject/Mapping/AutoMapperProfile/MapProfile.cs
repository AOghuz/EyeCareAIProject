using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;

using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace EyeCareAIProject.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AnnouncementAddDto, Announcement>();
            CreateMap<Announcement, AnnouncementAddDto>();
            CreateMap<Announcement, AnnouncementListDTO>().ReverseMap();
            CreateMap<Announcement, AnnouncementUpdateDto>().ReverseMap();
            CreateMap<SendMessageDto, ContactUs>().ReverseMap();
        }
    }
}
