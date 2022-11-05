using Configuration.DatabaseAccess;
using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class StudentRegistrationDataAccess:IStudentRegistrationDataAccess
    {
        public string SqlGetSubject = @"SELECT [SubjectId],[SubjectName] FROM HSCSubjects";
        public List<Subject> GetSubjectList()
        {
           List<Subject> subjectList = new List<Subject>();
           var datatable= DbConnect.GetQueryData(SqlGetSubject);

            foreach(DataRow row in datatable.Rows)
            {
                Subject subject = new Subject();
                subject.SubjectId = Convert.ToInt32(row["SubjectId"]);
                subject.SubjectName = row["SubjectName"].ToString();
                subjectList.Add(subject);

            }
            return subjectList;

        }
    }
}
