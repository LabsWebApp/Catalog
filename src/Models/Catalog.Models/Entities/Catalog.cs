using System;
using System.Collections.Generic;

namespace Catalog.Models.Entities
{
    public record Catalog : EntityBase
    {
        public Guid? CatalogId { get; set; }
        //НУЖНО ТОЛЬКО ДЛЯ СОЗДАНИИ БАЗЫ!!!
        //(создаст необходимый ключ)
        public virtual IEnumerable<Catalog> Children { get; set; }
    }
}
