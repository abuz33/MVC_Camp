using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Info
    {
        [Key] public int InfoId { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Institution { get; set; }
        public string Name { get; set; }

    }
}
