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
using System.Globalization;
using System.Reflection;
namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class LoginDataAccess : ILoginDataAccess
    {
        public const string SQLAuthenticationLookup = @"SELECT [Password],[Salt] FROM [Users] WHERE Email=@email";
        public const string SQLGetUserDetailsWithRoles = @"SELECT U.[UserId],U.[Email],R.[RoleId], R.[RoleName] FROM [Users] as U INNER JOIN [Roles] as R ON U.[RoleId]= R.[RoleId] WHERE U.Email=@email";
        public SecurityHelper securityHelper = new SecurityHelper();
        public bool IsUserAuthenticated(LoginViewModel user)
        {
            string salt = null;
            string password = null;
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            var datatable = DbConnect.GetDataUsingCondition(SQLAuthenticationLookup, parameters);
            foreach (DataRow dataRow in datatable.Rows)
            {
                if (datatable.Rows.Count == 1) {
                    salt = dataRow["Salt"].ToString();
                     password = dataRow["Password"].ToString();
                }
                else { 
                }
            }
            string hashedLoginPassword = securityHelper.GenerateSHA256Hash(user.Password, salt);
            return hashedLoginPassword == password;
        }
        public LoginViewModel GetUserDetailsWithRoles(LoginViewModel user)
        {
            LoginViewModel userLogin = new LoginViewModel();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            var datatable = DbConnect.GetDataUsingCondition(SQLGetUserDetailsWithRoles, parameters);
            foreach (DataRow row in datatable.Rows)
            {
                userLogin.UserID = Convert.ToInt32(row["UserId"]);
                userLogin.RoleId = Convert.ToInt32(row["RoleId"]);
                userLogin.RoleName = row["RoleName"].ToString();
                userLogin.Email = row["Email"].ToString();
            }
            return userLogin;
        }
    }
}
