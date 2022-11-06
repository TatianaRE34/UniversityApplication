using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.Repository
{
    public class StudentRegRepository: IStudentRegRepository
    {
        public IStudentRegistrationDataAccess _studentRegistrationDA;
        public List<Subject> GetSubjectList()
        {
            return this._studentRegistrationDA.GetSubjectList();
        }
        public bool RegisterStudent(Student student)
        {
            return this._studentRegistrationDA.RegisterStudent(student);
        }
        public bool IsInformationUnique(Student student)
        {
            return this._studentRegistrationDA.IsInformationUnique(student);
        }
    }
}
