using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Models.Entities
{
    public record Good : EntityBase
    {
        public uint Count { get; set; }

        [Column(TypeName = "money")]
        [Range(0, double.PositiveInfinity)]
        public double Price { get; set; }

        public Guid? CatalogId { get; set; }
        //НУЖНО ТОЛЬКО ДЛЯ СОЗДАНИИ БАЗЫ!!!
        //(создаст необходимый ключ)
        public virtual Catalog Catalog { get; set; }
    }
}
