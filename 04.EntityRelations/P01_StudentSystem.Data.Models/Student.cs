using P01_StudentSystem.Common;
using System.ComponentModel.DataAnnotations;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentsCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string Name { get; set; } = null!;

        [StringLength(10)]
        public int PhoneNumber { get; set; }
        [Required]
        public DateTime RegisteredOn { get; set; }

        public string? Birthday { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}