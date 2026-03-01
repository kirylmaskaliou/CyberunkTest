using Microsoft.AspNetCore.Mvc;
using CyberpunkBackend.Data;
using System;

namespace CyberpunkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext _context;

        public ContactsController(ContactsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContactModel model)
        {
            if (model == null || !ModelState.IsValid)
                return BadRequest("Invalid data");

            var contact = new Contact
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Timestamp = DateTime.UtcNow
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return Ok(new { message = "Contact saved", contact });
        }
    }
}
