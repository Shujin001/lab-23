using System.ComponentModel.DataAnnotations;

namespace WebApp2ByChirag.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Student ID is required")]
        [Display(Name = "Student ID")]
        public int StdID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Faculty is required")]
        public string Faculty { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Roll No must be between 1 and 100")]
        [Display(Name = "Roll No")]
        public int RollNo { get; set; }
    }
}
