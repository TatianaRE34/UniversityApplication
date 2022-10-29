using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.Repository;
using Configuration.DatabaseAccess;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    
    public class LoginDataAccess: ILoginDataAccess
    { 
        public const string SQLAuthenticationLookup = @"SELECT [Email],[Password] FROM [Users] WHERE Email=@email and Password=@password";
         public bool IsUserAuthenticated(User user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            parameters.Add(new SqlParameter("@password", user.Password));
            var datatable= DbConnect.GetDataUsingCondition(SQLAuthenticationLookup, parameters);
            return datatable.Rows.Count > 0;
        }
    }
}
