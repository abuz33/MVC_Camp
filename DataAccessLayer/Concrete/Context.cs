using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<About> Abouts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<DraftMessage> DraftMessages { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
