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
using System.Xml.Schema;
using StudentEnrollmentRepository.ConstantValues;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class StudentRegistrationDataAccess:IStudentRegistrationDataAccess
    {   
        public List<Student> GetStudentsWithGradePoint()
        {
            List<Student>studentList= new List<Student>();
            var datatable=DbConnect.GetQueryData(ConstantSqlQueries.SqlGetStudentDetails);
            foreach(DataRow row in datatable.Rows)
            {
                Student student=new Student();
                student.StudentId = Convert.ToInt32(row["StudentId"]);
                student.Name = row["Name"].ToString();
                student.Surname = row["Surname"].ToString();
                student.Email = row["Email"].ToString();
                student.Status = row["Status"].ToString();
                student.Results = GetStudentGrade(student.StudentId);
                student.TotalGradePoint=CalculateGradePoints(student);
                studentList.Add(student);
            }
            studentList= studentList.OrderByDescending(studentInstance => studentInstance.TotalGradePoint).ThenBy(studentInstance=> studentInstance.Status).ToList();
            return studentList;
        }
        private List<Result> GetStudentGrade(int studentId)
        {
            List<Result> resultsList = new List<Result>();
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@studentId", studentId));
            var datatable = DbConnect.GetDataUsingCondition(ConstantSqlQueries.SqlGetStudentResults, parameter);
            foreach (DataRow row in datatable.Rows)
            {
                Result result = new Result();
                result.Grade = row["Grade"].ToString();
                resultsList.Add(result);
            }
            return resultsList;
        }
        public bool IsInformationUnique(Student student)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@nic", student.NationalIdentificationCard));
            parameter.Add(new SqlParameter("@email", student.Email));
            parameter.Add(new SqlParameter("@phoneNumber", student.PhoneNumber));
            var datatable=DbConnect.GetDataUsingCondition(ConstantSqlQueries.SqlGetStudent, parameter);
            if (datatable.Rows.Count > 0)
            {
                return false;
            }
            return true;
        }
        public List<Subject> GetSubjectList()
        {
           List<Subject> subjectList = new List<Subject>();
           var datatable= DbConnect.GetQueryData(ConstantSqlQueries.SqlGetSubject);
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
            UpdateUserRoleId(student);
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
            DbConnect.InsertUpdateDatabase(ConstantSqlQueries.SqlInsertInStudents,parameterStudentTable);
        }
        private int GetStudentID(Student student) {
            int studentId = ConstValues.UndefinedId;
            List<SqlParameter> parameterStudent= new List<SqlParameter>();
            parameterStudent.Add(new SqlParameter("@nic", student.NationalIdentificationCard));
            var datatable =DbConnect.GetDataUsingCondition(ConstantSqlQueries.SqlGetStudentId, parameterStudent);
            foreach(DataRow dataRow in datatable.Rows)
            {
                studentId = Convert.ToInt32(dataRow["StudentID"]);
            }
            return studentId;
        }
        private void InsertInSubjectResultTable(Student student)
        {
            int subjectId = ConstValues.UndefinedId;
            List<Result> studentResult = student.Results;
            for (int index = 0; index < studentResult.Count; index++)
            {
                subjectId = GetSubjectId(studentResult[index].SubjectName);
                List<SqlParameter> parameterSubject= new List<SqlParameter>();
                parameterSubject.Add(new SqlParameter("@studentId", student.StudentId));
                parameterSubject.Add(new SqlParameter("@subjectId", subjectId));
                string grade=studentResult[index].Grade;
                parameterSubject.Add(new SqlParameter("@grade",grade));
                DbConnect.InsertUpdateDatabase(ConstantSqlQueries.SqlInsertInHSCResults, parameterSubject);
            } 
        }
        private void UpdateUserRoleId(Student student)
        {
            List<SqlParameter> parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@userId", student.UserId));
            DbConnect.InsertUpdateDatabase(ConstantSqlQueries.SqlEditRoleId, parameter);
        }
        private int GetSubjectId(string subjectName)
        {
            int subjectId = ConstValues.UndefinedId;
            List<SqlParameter>parametersSubjectName= new List<SqlParameter>();
            parametersSubjectName.Add(new SqlParameter("@subjectName",subjectName));
            var datatable =DbConnect.GetDataUsingCondition(ConstantSqlQueries.SqlGetSubjectId, parametersSubjectName);
            foreach(DataRow dataRow in datatable.Rows)
            {
                subjectId = Convert.ToInt32(dataRow["SubjectId"]);
            }
            return subjectId;
        }
        private void ObtainStatus(Student student)
        {
            int sum=CalculateGradePoints(student);
            if(sum >= ConstValues.MinimumPoints && CheckAccepted() < ConstValues.MaxAccepted)
            {
                student.Status = "Accepted";
            }
            else if (sum >= ConstValues.MinimumPoints)
            {
                student.Status = "Waiting";
            }
            else
            {
                student.Status="Rejected";
            }  
        }
        private int CheckAccepted()
        {
            int studentsAccepted = ConstValues.UndefinedId;
            var datatable = DbConnect.GetQueryData(ConstantSqlQueries.SqlGetCountOPAccepted);
            foreach(DataRow dataRow in datatable.Rows)
            {
                studentsAccepted = Convert.ToInt32(dataRow["AcceptedCount"]);
            }
            return studentsAccepted;
        }
        public int CalculateGradePoints(Student student)
        {
            int[] grades = (int[])Enum.GetValues(typeof(GradePoints));
            int counter;
            int sum = 0 ;
            List<Result> studentResult = student.Results;
            for (int index = 0; index < studentResult.Count; index++)
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
