using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key] 
        public int TestimonialId { get; set; }

        [StringLength(1000)] 
        public string TestimonialContent { get; set; }
        
        [StringLength(20)] 
        public string Name { get; set; }
        
        public DateTime Date { get; set; }

        public bool Approved { get; set; }
    }
}
