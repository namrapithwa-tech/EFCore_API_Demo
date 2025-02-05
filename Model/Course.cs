using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_API_Demo.Model
{
    [Table("Courses")]
    public class Course
    {
        #region Properties

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        #endregion
    }
}
