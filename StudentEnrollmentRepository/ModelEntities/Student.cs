using StudentEnrollmentRepository.ConstantValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.ModelEntities
{
    public class Student
    {
        public int StudentId { set; get; }
        public int UserId { set; get; }
        [Required(ErrorMessage = "Please Enter name")]
        [Display(Name = "name")]
        public string Name { set; get; }
        [Required(ErrorMessage = "Please Enter Surname")]
        [Display(Name = "surrname")]
        public string Surname { set; get; }
        [Required(ErrorMessage = "Please Enter address")]
        [Display(Name = "address")]
        public string Address { set; get; }
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "Please Enter Date of birth")]
        [Display(Name = "dateOfBirth")]
        public string DateOfBirth { set; get; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { set; get; }
        public string NationalIdentificationCard { set; get; }
        [Required(ErrorMessage = "Please Enter Guardian name")]
        [Display(Name = "guardian")]
        public string GuardianName { set; get; }
        public List<Result> Results { set; get; }
        public string Status { set; get; }
        public int TotalGradePoint { set; get; }
        public Student(){}
       
    }
}
