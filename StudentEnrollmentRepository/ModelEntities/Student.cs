using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.ModelEntities
{
    public class Student
    {
        public int StudentId { set; get; }
        public int UserId { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public string Address { set; get; }
        public string PhoneNumber { set; get; }
        public string DateOfBirth { set; get; }
        public string Email { set; get; }
        public string NationalIdentificationCard { set; get; }
        public string GuardianName { set; get; }
        public List<Result> Results { set; get; }
        public string Status { set; get; }
        public int TotalGradePoint { set; get; }
        public Student(){}
       
    }
}
