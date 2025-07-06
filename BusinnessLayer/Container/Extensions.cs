using BusinnessLayer.Abstract;
using BusinnessLayer.Concrete;
using BusinnessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.Container
{
    public static class Extension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IDoctorService, DoctorManager>();
            services.AddScoped<IDoctorDal, EfDoctorDal>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();
            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IAppointmentDal, EfAppointmentDal>();
            services.AddScoped<ITreatmentService, TreatmentManager>();
            services.AddScoped<ITreatmentDal, EfTreatmentDal>();
            services.AddScoped<IContactUsService, ContactUsManager>();
            services.AddScoped<IContactUsDal, EfContactUsDal>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<IBlogDal, EfBlogDal>();
            services.AddScoped<IAnnouncementService, AnnouncementManager>();
            services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            services.AddScoped<IAppointmentDal, EfAppointmentDal>();
            services.AddScoped<IAppointmentService, AppointmentManager>();




        }
        public static void CustomValidator(this IServiceCollection Services)
        {
            Services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>();
        }

    }
}
