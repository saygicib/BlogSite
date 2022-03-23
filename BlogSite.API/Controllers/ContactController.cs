using BlogSite.Business.Abstract;
using BlogSite.Entities.Dtos.ContactDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost("SendMailForContact")]
        public IActionResult SendMailForContact(ContactAddDto dto)
        {
            _contactService.SendMailForContact(dto);
            return Ok();
        }

    }
}
