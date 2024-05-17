using DAL.Enum;

using System.ComponentModel.DataAnnotations;

namespace Representation.Models
{
    public class CreateTaskModelView
    {
        [Required(ErrorMessage = "Введите название задачи")]
        [Display(Name = "Название задачи")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Введите описание задачи")]
        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }

        [Display(Name = "Приоритет задачи")]
        public Priority Priority { get; set; }
    }
}
