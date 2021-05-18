using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResultArchive.Models
{
    public class Result
    {
        public int Id { get; set; }

        [Required]
        public string RegNumber { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string CourseCode { get; set; }
        public string CVScore { get; set; }
        public string ExamScore { get; set; }
        public string TotalScore { get; set; }
        public string Department { get; set; }

        //assign result to a school
        [Display(Name = "School")]
        public int SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }

        //assign result to a session
        [Display(Name = "Session")]
        public int SessionId { get; set; }

        [ForeignKey("SessionId")]
        public virtual Session Session { get; set; }

        //specify the semester
        [Required]
        public string Semester { get; set; }

    }
}