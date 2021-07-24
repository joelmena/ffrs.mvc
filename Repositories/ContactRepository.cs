using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ffrs.mvc.Data;
using ffrs.mvc.Models;
using ffrs.mvc.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ffrs.mvc.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext context;

        public ContactRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> CreateContactAsync(Contacto model)
        {
            await context.Contactos.AddAsync(model);
            return await SavedAsync();
        }

        public async Task<bool> DeleteContactAsync(Contacto model)
        {
            context.Contactos.Remove(model);
            return await SavedAsync();
        }

        public async Task<IEnumerable<Contacto>> GetAllContactsAsync()
        {
            return await context.Contactos.ToListAsync();
        }

        public async Task<Contacto> GetContactAsync(string id)
        {
            return await context.Contactos.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Contacto>> GetContactsAsync(string name)
        {
            return await context.Contactos.Where(x => 
                x.Nombres.Contains(name) || 
                x.Apellidos.Contains(name) ||
                x.Cedula.Contains(name) &&
                !x.Inactivo
            ).ToListAsync();
        }

        public async Task<bool> SavedAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateContactAsync(Contacto model)
        {
            context.Contactos.Update(model);
            return await SavedAsync();
        }
    }
}