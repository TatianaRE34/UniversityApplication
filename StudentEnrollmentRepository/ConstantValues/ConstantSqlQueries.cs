using Configuration.Helper;
using StudentEnrollmentRepository.ViewModel;
using StudentEnrollmentRepository.ConstantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.ConstantValues
{
    public  class ConstantSqlQueries
    {
        public const string SqlGetCountOPAccepted = @"SELECT COUNT(Status) as AcceptedCount FROM Student WHERE Status='Accepted'";
        public const string SqlGetSubject = @"SELECT [SubjectId],[SubjectName] FROM HSCSubjects";
        public const string SqlGetStudent = @"SELECT [NIC],[PhoneNumber],[Email] FROM StudentWHERE [NIC]=@nic OR [PhoneNumber]=@phoneNumber OR [Email]=@email";
        public const string SqlInsertInStudents =
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
        public const string SqlInsertInHSCResults = @"INSERT INTO StudentResult
            ([StudentId],
            [SubjectId],
            [Grade])
            VALUES
            (@studentId,
            @subjectId,
            @grade)
           ";
        public const string SqlGetStudentId = @"SELECT [StudentID] FROM Student WHERE NIC=@nic";
        public const string SqlGetSubjectId = @"SELECT [SubjectId] FROM HSCSubjects WHERE SubjectName=@subjectName";
        public const string SqlEditRoleId = @"UPDATE [Users] SET [RoleId]=2 WHERE [UserId]=@UserId";
        public const string SqlGetStudentDetails = @"SELECT [StudentId],[Name],[Surname],[Email],[Status] FROM Student";
        public const string SqlGetStudentResults = @"SELECT [Grade] FROM StudentResult WHERE StudentId=@studentId";
        public const string SQLAuthenticationLookup = @"SELECT [Password],[Salt] FROM [Users] WHERE Email=@email";
        public const string SQLGetUserDetailsWithRoles = @"SELECT U.[UserId],U.[Email],R.[RoleId], R.[RoleName] FROM [Users] as U INNER JOIN [Roles] as R ON U.[RoleId]= R.[RoleId] WHERE U.Email=@email";
        public static string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password],[RoleId],[Salt]) VALUES (@name,@email,@password," + ConstValues.DefaultRoleId.ToString() + ",@salt)";
        public const string SqlGetUsernameAndEmail = @"SELECT [Username],[Email] FROM [Users] WHERE Username=@username OR Email=@email";
    }
}
