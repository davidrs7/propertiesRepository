using Microsoft.EntityFrameworkCore;
using properties.core.entities;
using properties.core.interfaces;
using properties.infraestructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace properties.infraestructure.repositories
{
    public class propertyRepository: IPropertyRepository
    {
        private readonly propertiesContext _dbcontext;

        public propertyRepository(propertiesContext propertiesContext) {
            _dbcontext = propertiesContext; 
        }

        public async Task<IEnumerable<Property>> getProperties() { 
           
            var properties = await _dbcontext.Property.ToListAsync();
            return properties;
        }

        public async Task<Property> getProperty(int id)
        { 
            var property = await _dbcontext.Property.FirstOrDefaultAsync(x => x.IdProperty == id);
            return property;
        } 
        public async Task postProperty(Property Property)
        {
            _dbcontext.Property.Add(Property);
            await _dbcontext.SaveChangesAsync(); 
        }

        public async  Task<bool> PutPorperty(Property Property)
        {
            var propertytoUpdate = await getProperty(Property.IdProperty); 

            propertytoUpdate.IdOwner = Property.IdOwner;
            propertytoUpdate.NameProperty = Property.NameProperty;
            propertytoUpdate.AddressProperty = Property.AddressProperty;
            propertytoUpdate.PriceProperty = Property.PriceProperty;
            propertytoUpdate.CodeInternalProperty = Property.CodeInternalProperty; 

            int rows =  await _dbcontext.SaveChangesAsync(); 
            return rows > 0;
        }
        public async Task<bool> deletePorperty(int id)
        {
            var propertytoDelete = await getProperty(id);
             _dbcontext.Remove(propertytoDelete);
            int rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
