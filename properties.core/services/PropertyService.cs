using System;
using System.Collections.Generic;
using System.Text;
using properties.core.interfaces;
using properties.core.entities;
using System.Threading.Tasks;

namespace properties.core.services
{
    public class PropertyService : IPropertyService
    {
        public readonly IPropertyRepository _propertyRepository;
        public readonly IOwnerRepository _ownerRepository;
        public PropertyService(IPropertyRepository propertyRepository, IOwnerRepository ownerRepository)
        { 
            _propertyRepository = propertyRepository;
            _ownerRepository = ownerRepository;
        }

        public async Task<bool> deletePorperty(int id)
        {
            return await _propertyRepository.deletePorperty(id);
        }

        public async Task<IEnumerable<Property>> getProperties()
        {
            return await _propertyRepository.getProperties();
        }

        public async Task<Property> getProperty(int id)
        {
            return await _propertyRepository.getProperty(id);
        }

        public async Task postProperty(Property Property)
        {
            var owner = await _ownerRepository.getOwner(Property.IdOwner);

            if (owner == null)
            {
                throw new Exception("Owner not exists");
            }

            if (Property.NameProperty.Contains("negro"))
            {
                throw new Exception("Not exists black houses");
            }

            await _propertyRepository.postProperty(Property);
        }

        public async Task<bool> PutPorperty(Property Property)
        {
           return await _propertyRepository.PutPorperty(Property);
        }
    }
}
