using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.Repository;
using Configuration.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class RegistrationDataAccess:IRegistrationDataAccess
    {
        public const string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password]) VALUES (@name,@email,@password)";
        public void CheckPassword(User user)
        {
            throw new NotImplementedException();
        }
        public bool IsNewUserRegistered(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", user.Username));
            parameters.Add(new SqlParameter("@email", user.Email));
            parameters.Add(new SqlParameter("@password", user.Password));
            DbConnect.InsertUpdateDatabase(SqlInsertUser, parameters);
            return true;
        }

   
    }
}

