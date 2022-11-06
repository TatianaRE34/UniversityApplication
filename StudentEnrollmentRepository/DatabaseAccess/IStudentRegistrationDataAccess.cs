using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public interface IStudentRegistrationDataAccess
    {
        bool IsInformationUnique(Student student);
        List<Subject> GetSubjectList();
        bool RegisterStudent(Student student);
    }
}
