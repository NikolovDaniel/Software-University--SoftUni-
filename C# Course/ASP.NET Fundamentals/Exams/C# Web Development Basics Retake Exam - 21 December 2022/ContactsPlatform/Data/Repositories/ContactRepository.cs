using ContactsPlatform.Data.Contracts;
using ContactsPlatform.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ContactsPlatform.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {

        private readonly ApplicationDbContext context;

        public ContactRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task RemoveContactFromUserTeamAsync(int contactId, string userId)
        {
            var userContact = await this.context.ApplicationUsersContacts
                .FirstOrDefaultAsync(au => au.ContactId == contactId && au.ApplicationUserId == userId);
       
            if (userContact == null)
            {
                return;
            }

            this.context.ApplicationUsersContacts.Remove(userContact);
            await this.context.SaveChangesAsync();
        }
        public async Task AddContactToUserTeamAsync(int contactId, string userId)
        {
            var userContact = new ApplicationUserContact()
            {
                ContactId = contactId,
                ApplicationUserId = userId
            };

            if (this.context.ApplicationUsersContacts.Contains(userContact))
            {
                return;
            }

            await this.context.ApplicationUsersContacts
                .AddAsync(userContact);

            await this.context.SaveChangesAsync();
        }

        public async Task AddContactAsync(Contact contact)
        {
            await this.context.Contacts.AddAsync(contact);
            await this.context.SaveChangesAsync();
        }

        public async Task<ICollection<Contact>> GetUserContactsAsync(string id)
        {
            return await this.context.ApplicationUsersContacts
                .Where(u => u.ApplicationUserId == id)
                .Select(c => c.Contact)
                .ToListAsync();
        }

        public Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Contact>> GetAllContactsAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await this.context.Contacts.FindAsync(id);
        }

        public async Task<Contact> UpdateContactAsync(Contact contact, int id)
        {
            var userContact = await this.context.Contacts.FindAsync(id);

            if (userContact == null)
            {
                return null;
            }

            userContact.FirstName = contact.FirstName;
            userContact.LastName = contact.LastName;
            userContact.Email = contact.Email;
            userContact.PhoneNumber = contact.PhoneNumber;
            userContact.Address = contact.Address;
            userContact.Website = contact.Website;

            await this.context.SaveChangesAsync();

            return userContact;
        }
    }
}
