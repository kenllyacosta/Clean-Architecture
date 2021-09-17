using Domain.Common;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category : EntityBase<byte>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public byte? EstatusId { get; set; }

        //Propiedades de navegación
        public Estatu Estatu { get; set; }
    }
}
