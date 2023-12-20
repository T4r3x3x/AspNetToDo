using System.ComponentModel.DataAnnotations;

namespace DAL.Enum
{
    public enum Priority
    {
        [Display(Name = "Низкий")]
        Low = 1,
		[Display(Name = "Средний")]
		Medium = 2,
		[Display(Name = "Высокий")]
		High = 3,
    }
}
