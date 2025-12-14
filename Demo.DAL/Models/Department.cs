using System.ComponentModel.DataAnnotations;

namespace Demo.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required!")]
        public string Code { get; set; } = null!; // الحل هنا: اديناها قيمة ابتدائية وهمية

        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; } = null!; // وهنا كمان

        public DateTime DateOfCreation { get; set; }
    }
}