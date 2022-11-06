using Configuration.DatabaseAccess;
using Microsoft.SqlServer.Server;
using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class StudentRegistrationDataAccess:IStudentRegistrationDataAccess
    {   private int UndefinedId = -1;
        private string SqlGetSubject = @"SELECT [SubjectId],[SubjectName] FROM HSCSubjects";
        private string SqlGetStudent = @"SELECT [NIC],[PhoneNumber],[Email] FROM Student WHERE [NIC]=@nic OR [PhoneNumber]=@phoneNumber OR [Email]=@email";
        private string SqlInsertInStudents =
            @"INSERT INTO Student 
            ([UserId],
            [Name],
            [Surname],
            [Address],
            [PhoneNumber],
            [DateOfBirth],
            [NIC],
            [GuardianName],
            [Status],
            [Email])
            VALUES
            (@userId,
            @name,
            @surname,
            @address,
            @phoneNumber,
            @dateOfBirth,
            @nationalIdentity,
            @guardianName,
            @status,
            @email)  ";
        private string SqlInsertInHSCResults =@"INSERT INTO StudentResult
            ([StudentId],
            [SubjectId],
            [Grade])
            VALUES
            (@studentId,
            @subjectId,
            @grade)
            ";
        private string SqlGetStudentId = @"SELECT [StudentID] FROM Student WHERE NIC=@nic";
        private string SqlGetSubjectId = @"SELECT [SubjectId] FROM HSCSubjects WHERE SubjectName=@subjectName";
        private enum GradePoints
        {
            A=10,
            B=8,
            C=6,
            D=4,
            E=2,
            F=0
        }
        public bool IsInformationUnique(Student student)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@nic", student.NationalIdentificationCard));
            parameter.Add(new SqlParameter("@email", student.Email));
            parameter.Add(new SqlParameter("@phoneNumber", student.PhoneNumber));
            var datatable=DbConnect.GetDataUsingCondition(SqlGetStudent, parameter);
            if (datatable.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
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
        public bool RegisterStudent(Student student)
        {
            InsertInStudentTable(student);
            student.StudentId = GetStudentID(student);
            InsertInSubjectResultTable(student);
            return true;
        }
        private void InsertInStudentTable(Student student)
        {
            List<SqlParameter> parameterStudentTable = new List<SqlParameter>();
            parameterStudentTable.Add(new SqlParameter("@userId", student.UserId));
            parameterStudentTable.Add(new SqlParameter("@name", student.Name));
            parameterStudentTable.Add(new SqlParameter("@surname",student.Surname));
            parameterStudentTable.Add(new SqlParameter("@address",student.Address));
            parameterStudentTable.Add(new SqlParameter("@phoneNumber",student.PhoneNumber));  
            parameterStudentTable.Add(new SqlParameter("@dateOfBirth", student.DateOfBirth));
            parameterStudentTable.Add(new SqlParameter("@email",student.Email));
            parameterStudentTable.Add(new SqlParameter("@nationalIdentity", student.NationalIdentificationCard));
            parameterStudentTable.Add(new SqlParameter("@guardianName", student.GuardianName));
            ObtainStatus(student);
            parameterStudentTable.Add(new SqlParameter("@status", student.Status));
            DbConnect.InsertUpdateDatabase(SqlInsertInStudents,parameterStudentTable);
        }
        private int GetStudentID(Student student) {
            int studentId= UndefinedId;
            List<SqlParameter> parameterStudent= new List<SqlParameter>();
            parameterStudent.Add(new SqlParameter("@nic", student.NationalIdentificationCard));
            var datatable =DbConnect.GetDataUsingCondition(SqlGetStudentId, parameterStudent);
            foreach(DataRow dataRow in datatable.Rows)
            {
                studentId = Convert.ToInt32(dataRow["StudentID"]);
            }
            return studentId;
        }
        private void InsertInSubjectResultTable(Student student)
        {
            int subjectId=UndefinedId;
            Result[] studentResult = student.Results;
            for (int index = 0; index < studentResult.Length; index++)
            {
                subjectId = GetSubjectId(studentResult[index].SubjectName);
                List<SqlParameter> parameterSubject= new List<SqlParameter>();
                parameterSubject.Add(new SqlParameter("@studentId", student.StudentId));
                parameterSubject.Add(new SqlParameter("@subjectId", subjectId));
                string grade=studentResult[index].Grade;
                parameterSubject.Add(new SqlParameter("@grade",grade));
                DbConnect.InsertUpdateDatabase(SqlInsertInHSCResults, parameterSubject);
            } 
        }
        private int GetSubjectId(string subjectName)
        {
            int subjectId=UndefinedId;
            List<SqlParameter>parametersSubjectName= new List<SqlParameter>();
            parametersSubjectName.Add(new SqlParameter("@subjectName",subjectName));
            var datatable =DbConnect.GetDataUsingCondition(SqlGetSubjectId, parametersSubjectName);
            foreach(DataRow dataRow in datatable.Rows)
            {
                subjectId = Convert.ToInt32(dataRow["SubjectId"]);
            }
            return subjectId;
        }
        private void ObtainStatus(Student student)
        {
            int sum=CalculateGradePoints(student);
            if (sum >= 10)
            {
                student.Status = "Waiting";
            }
            else
            {
                student.Status="Rejected";
            }  
        }
        private int CalculateGradePoints(Student student)
        {
            int[] grades = (int[])Enum.GetValues(typeof(GradePoints));
            int counter;
            int sum = 0 ;
            Result[] studentResult = student.Results;
            for (int index = 0; index < studentResult.Length; index++)
            {   counter = 0;
                foreach (var gradepoint in GradePoints.GetNames(typeof(GradePoints)))
                {
                    string grade = studentResult[index].Grade;
                    if (studentResult[index].Grade.Equals(gradepoint))
                    {
                        sum += grades[counter];
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            return sum;
        }        
    }
}
