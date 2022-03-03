using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using properties.core.entities; 

namespace properties.core.interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> getProperties();
        Task<Property> getProperty(int id);         
        Task postProperty(Property Property); 
        Task<bool> deletePorperty(int id); 
        Task<bool> PutPorperty(Property Property);
    }
}
