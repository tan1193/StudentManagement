using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementAPI.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }

        public string Phone { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstMidName;
            }
        }
    }

    public class StudentPaging
    {
        public List<Student> Students { get; set; }
        public int TotalRow { get; set; }

    } 
}
