using System;
using System.ComponentModel.DataAnnotations;

namespace Catalog.Models.Entities
{
    public record EntityBase
    {
        //В комментариях предание реалистичности базе, 
        //ненужно для решения задачи
        //public const string NamePattern = "^[А-ЯЁа-яёA-ZÄÖÜa-zäöüß]";

        public Guid Id { get; init; }

        //[Required(ErrorMessage = "У сущности должно быть имя.")]
        //[MaxLength(255, ErrorMessage = "Имя не должно быть длиннее 255 символов.")]
        //[MinLength(1, ErrorMessage = "Имя должно содержать хотя бы одну букву.")]
        //[RegularExpression(NamePattern, ErrorMessage = "Первый символ в имени должен быть буквой.")]
        public string Name { get; set; }
    }
}
