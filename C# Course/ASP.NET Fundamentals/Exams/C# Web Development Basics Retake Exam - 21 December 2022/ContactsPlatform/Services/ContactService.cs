using ContactsPlatform.Data.Contracts;
using ContactsPlatform.Models;
using ContactsPlatform.Services.Contracts;

namespace ContactsPlatform.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository repository;

        public ContactService(IContactRepository repository)
        {
            this.repository = repository;
        }

        public async Task RemoveContactFromUserTeamAsync(int contactId, string userId)
        {
            await this.repository.RemoveContactFromUserTeamAsync(contactId, userId);
        }

        public async Task AddContactToUserTeamAsync(int contactId, string userId)
        {
            await this.repository.AddContactToUserTeamAsync(contactId, userId);
        }
        public async Task AddContactAsync(Contact contact)
        {
            await this.repository.AddContactAsync(contact);
        }
        public async Task<ICollection<Contact>> GetUserContactsAsync(string id)
        {
            return await repository.GetUserContactsAsync(id);
        }

        public Task DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Contact>> GetAllContactsAsync()
        {
            return await repository.GetAllContactsAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await repository.GetContactByIdAsync(id);
        }

        public async Task<Contact> UpdateContactAsync(Contact contact, int id)
        {
            return await this.repository.UpdateContactAsync(contact, id);
        }
    }
}
