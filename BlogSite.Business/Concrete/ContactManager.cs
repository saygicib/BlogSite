using AutoMapper;
using BlogSite.Business.Abstract;
using BlogSite.Business.Services.Mail;
using BlogSite.DataAccess.Abstract;
using BlogSite.Entities.Concrete;
using BlogSite.Entities.Dtos.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Business.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IMapper _mapper;
        public ContactManager(IContactDal contactDal, IMapper mapper)
        {
            _contactDal = contactDal;
            _mapper = mapper;
        }
        public void SendMailForContact(ContactAddDto dto)
        {
            MailHelper.SendMailForContact(dto);

            var mappedContact = _mapper.Map<Contact>(dto);
            _contactDal.Add(mappedContact);
        }
    }
}
