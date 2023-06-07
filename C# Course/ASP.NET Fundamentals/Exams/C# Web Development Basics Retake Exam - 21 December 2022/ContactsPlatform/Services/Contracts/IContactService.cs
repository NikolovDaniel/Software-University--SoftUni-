using ContactsPlatform.Models;

namespace ContactsPlatform.Services.Contracts
{
    public interface IContactService
    {
        Task RemoveContactFromUserTeamAsync(int contactId, string userId);

        Task AddContactToUserTeamAsync(int contactId, string userId);

        Task AddContactAsync(Contact contact);
        Task<ICollection<Contact>> GetUserContactsAsync(string id);

        Task<ICollection<Contact>> GetAllContactsAsync();

        Task<Contact> GetContactByIdAsync(int id);

        Task<Contact> UpdateContactAsync(Contact contact, int id);

        Task DeleteContactAsync(int id);
    }
}
