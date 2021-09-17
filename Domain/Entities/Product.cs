using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities
{
    public class Product : EntityBase<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public byte? EstatusId { get; set; }

        //Propiedades de navegación
        public Category Category { get; set; }
        public Estatu Estatu { get; set; }
    }
}
