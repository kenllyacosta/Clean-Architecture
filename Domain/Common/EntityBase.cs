using System;

namespace Domain.Common
{
    public class EntityBase<IdType>
    {
        /// <summary>
        /// Este IdType puede aceptar cualquier tipo de dato como identificador de la entidad
        /// </summary>
        public IdType Id { get; set; }
        public DateTime FechaCreado { get { return DateTime.Now; } set { } }
        public DateTime? FechaModificado { get; set; }
    }
}
