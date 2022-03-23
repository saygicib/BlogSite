using BlogSite.Entities.Dtos.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Abstract
{
    public interface IContactService
    {
        void SendMailForContact(ContactAddDto dto);
    }
}
