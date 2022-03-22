using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Dtos.ContactDtos
{
    public class ContactAddDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CraetedDate { get; set; } = DateTime.Now;
    }
}
