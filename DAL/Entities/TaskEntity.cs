using DAL.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    [Table(name: "tasks")]
    public class TaskEntity
    {
        public long Id { get; set; }

        [Display(Name = "Название задачи")]
        public string Title { get; set; }

        [Display(Name = "Описание задачи")]
        public string? Description { get; set; }
        public DateTime Created { get; set; }

        [Display(Name = "Приоритет задачи")]
        public Priority Priority { get; set; }
        public Enum.Status Status { get; set; }

        [Required]
        public Project Project { get; set; }

        [ForeignKey(nameof(User))]
        public User? Responsible { get; set; }
        
    }
}