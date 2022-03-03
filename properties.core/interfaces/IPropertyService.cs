using properties.core.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace properties.core.interfaces
{
    public interface IPropertyService
    { 
        Task<IEnumerable<Property>> getProperties();
        Task<Property> getProperty(int id);
        Task postProperty(Property Property);
        Task<bool> deletePorperty(int id);
        Task<bool> PutPorperty(Property Property);
    }
}