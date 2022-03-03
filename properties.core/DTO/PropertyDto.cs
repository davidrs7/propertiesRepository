using System;
using System.Collections.Generic;
using System.Text;

namespace properties.core.DTO
{
   public class PropertyDto
    {
        public int IdProperty { get; set; }
        public int? IdOwner { get; set; }
        public string NameProperty { get; set; }
        public string AddressProperty { get; set; }
        public decimal? PriceProperty { get; set; }
        public string CodeInternalProperty { get; set; }
    }
}
