using AutoMapper;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Mappings.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<ContactAddDto, Contact>();
        }
    }
}
