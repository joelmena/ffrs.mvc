using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ffrs.mvc.Models;

namespace ffrs.mvc.Repositories.IRepositories
{
    public interface IContactRepository
    {
         Task<IEnumerable<Contacto>> GetAllContactsAsync();
         Task<IEnumerable<Contacto>> GetContactsAsync(string name);
         Task<Contacto> GetContactAsync(string id);
         Task<bool> CreateContactAsync(Contacto model);
         Task<bool> UpdateContactAsync(Contacto model);
         Task<bool> DeleteContactAsync(Contacto model);
         Task<bool> SavedAsync();
    }
}