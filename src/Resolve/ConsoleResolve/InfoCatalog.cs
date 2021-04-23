using System;
using System.Text;
using Catalog.Models.Entities;

namespace ConsoleResolve
{
    //Подсказка для решения, так удобней будет вывести всю info  на экран
    public record InfoCatalog
    {
        public Guid Id { get; init; }

        public Guid? CatalogId { get; init; }

        public string Name { get; init; }

        public ushort TabulatorsCount { get; set; }

        public uint Count { get; set; }

        public double Value { get; set; }

        public InfoCatalog() { }

        public InfoCatalog(Catalog.Models.Entities.Catalog catalog)
        {
            Id = catalog.Id;
            CatalogId = catalog.CatalogId;
            Name = catalog.Name;
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            if (string.IsNullOrWhiteSpace(Name))
                sb.Append("Вне какого либо каталога содержится ");
            else
            {
                for (int i = 0; i < TabulatorsCount; i++) sb.Append('\t');
                sb.Append('[' + Name.ToUpper() + ']');
                sb.Append(" содержит ");
            }
            sb.Append(Count);
            sb.Append(" товаров на общую сумму ");
            sb.Append(Value.ToString("C"));
            sb.Append('.');

            return sb.ToString();
        }
    }
}
