using Microsoft.EntityFrameworkCore;
using properties.core.entities;
using properties.core.interfaces;
using properties.infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace properties.infraestructure.repositories
{
    public class OwnerRepository: IOwnerRepository
    {
        private readonly propertiesContext _dbcontext;
            public OwnerRepository(propertiesContext propertiesContext) {
            _dbcontext = propertiesContext;
        } 

        public async Task<IEnumerable<PropertyOwner>> getOwners() {
            var Owners = await _dbcontext.PropertyOwner.ToListAsync();
            return Owners; 
        }

        public async Task<PropertyOwner> getOwner(int? id)
        {
            var Owner = await _dbcontext.PropertyOwner.FirstOrDefaultAsync(x => x.IdOwner == id);
            return Owner;
        }
    }
}
