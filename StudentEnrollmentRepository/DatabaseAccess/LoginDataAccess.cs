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
using StudentEnrollmentRepository.ViewModel;
using Configuration.Helper;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    
    public class LoginDataAccess: ILoginDataAccess
    { 
        public const string SQLAuthenticationLookup = @"SELECT [Email],[Password] FROM [Users] WHERE Email=@email";
        public const string SQLGetPassword = @"SELECT [Password],[Salt] FROM [Users] WHERE Email=@email";
        public SecurityHelper securityHelper = new SecurityHelper();
        public bool IsUserAuthenticated(LoginViewModel user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            var datatable= DbConnect.GetDataUsingCondition(SQLAuthenticationLookup, parameters);
            return datatable.Rows.Count > 0;
        }
        public bool IsPasswordTheSame(LoginViewModel user)
        {
            string salt=null;
            string password=null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            var datatable= DbConnect.GetDataUsingCondition(SQLGetPassword, parameters);
            foreach (DataRow dataRow in datatable.Rows) {
                salt = dataRow["Salt"].ToString();
                password = dataRow["Password"].ToString();
            }
            string hashedLoginPassword = securityHelper.GenerateSHA256Hash(user.Password, salt);
            if (hashedLoginPassword!= password)
            { 
               return false; 
            }
           return true;
        }
    }
}
