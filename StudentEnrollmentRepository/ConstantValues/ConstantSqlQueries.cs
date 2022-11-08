using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.ConstantValues
{
    public  class ConstantSqlQueries
    {
        public const string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password],[RoleId]) VALUES (@name,@email,@password,)";
        public int UndefinedId = -1;
        public int MinimumPoints = 10;
        public string SqlGetCountOPAccepted = @"SELECT COUNT(Status) as AcceptedCount FROM Student WHERE Status='Accepted'";
        public int MaxAccepted = 15;
        public string SqlGetSubject = @"SELECT [SubjectId],[SubjectName] FROM HSCSubjects";
        public string SqlGetStudent = @"SELECT [NIC],[PhoneNumber],[Email] FROM Student WHERE [NIC]=@nic OR [PhoneNumber]=@phoneNumber OR [Email]=@email";
        public string SqlInsertInStudents =
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
        public string SqlInsertInHSCResults = @"INSERT INTO StudentResult
            ([StudentId],
            [SubjectId],
            [Grade])
            VALUES
            (@studentId,
            @subjectId,
            @grade)
            ";
        public string SqlGetStudentId = @"SELECT [StudentID] FROM Student WHERE NIC=@nic";
        public string SqlGetSubjectId = @"SELECT [SubjectId] FROM HSCSubjects WHERE SubjectName=@subjectName";
        public enum GradePoints
        {
            A = 10,
            B = 8,
            C = 6,
            D = 4,
            E = 2,
            F = 0
        }

    }

}
