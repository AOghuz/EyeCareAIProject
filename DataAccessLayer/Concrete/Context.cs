using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server= DESKTOP-SCO6T6L\\SQLEXPRESS; database=EYECAREPROJECTAIDB;Trusted_Connection=True; integrated security=true; TrustServerCertificate=True;");
            
        }
        public DbSet<About> Abouts { get; set; } // veritabanındaki tablonun ismi
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Home> Homes { get; set; }
        public DbSet<HomeStatistic> HomeStatistics { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        
    }
}
