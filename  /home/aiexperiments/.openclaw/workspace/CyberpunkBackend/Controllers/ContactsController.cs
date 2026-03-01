using Microsoft.AspNetCore.Mvc;
using CyberpunkBackend.Data;
using System;
using Microsoft.Extensions.Logging;

namespace CyberpunkBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactsContext _context;
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ContactsContext context, ILogger<ContactsController> logger)
        {
            _context = context;
            _logger = logger;
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

            _logger.LogInformation("Contact created: {Name} {Surname} {Email}", contact.Name, contact.Surname, contact.Email);

            return Ok(new { message = "Contact saved", contact });
        }
    }
}
