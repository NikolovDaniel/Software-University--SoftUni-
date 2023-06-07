using ContactsPlatform.Models;
using ContactsPlatform.Models.ViewModels;
using ContactsPlatform.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ContactsPlatform.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactService contactService;
        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var contacts = await contactService.GetAllContactsAsync();

            var models = contacts
                .Select(c => new ContactViewModel
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = string.IsNullOrEmpty(c.Address) ? "No address" : c.Address,
                    Website = string.IsNullOrEmpty(c.Website) ? "No address" : c.Website
                })
                .ToList();

            return View(models);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new ContactFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Contact contact = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Website = model.Website,
                Address = model.Address
            };

            await this.contactService.AddContactAsync(contact);

            return RedirectToAction("All", "Contacts");
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var contacts = await this.contactService.GetUserContactsAsync(userId);

            var model = contacts
                .Select(c => new ContactViewModel()
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Website = c.Website,
                    Address = c.Address
                })
                .ToList();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int id)
        {
            var contact = await this.contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.contactService.AddContactToUserTeamAsync(id, userId);

            return RedirectToAction("All", "Contacts");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            await this.contactService.RemoveContactFromUserTeamAsync(id, userId);

            return RedirectToAction("Team", "Contacts");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var contact = await this.contactService.GetContactByIdAsync(id);

            if (contact == null)
            {
                return BadRequest();
            }

            var model = new ContactFormViewModel()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Address = contact.Address,
                Website = contact.Website,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactFormViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var contact = await this.contactService
                .UpdateContactAsync(new Contact()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Website = model.Website
                }, id);

            if (contact == null)
            {
                return BadRequest();
            }

            return RedirectToAction("All", "Contacts");
        }
    }
}
