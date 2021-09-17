using Domain.Common;

namespace Domain.Entities
{
    public class Estatu : EntityBase<byte>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
