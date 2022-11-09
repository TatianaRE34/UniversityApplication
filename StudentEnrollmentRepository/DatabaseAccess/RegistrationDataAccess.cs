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
using StudentEnrollmentRepository.ViewModel;
using System.Text.RegularExpressions;
using Configuration.Helper;
using System.Security.Policy;
using StudentEnrollmentRepository.ConstantValues;
namespace StudentEnrollmentRepository.DatabaseAccess
{ 
    public class RegistrationDataAccess : IRegistrationDataAccess
    {       
        public SecurityHelper securityHelper = new SecurityHelper();
        public bool IsNewUserRegistered(RegistrationViewModel user)
        {
            if (IsEmailValid(user) && IsUsernameValid(user) && IsPasswordValid(user) && ArePasswordsTheSame(user))
            {
                List<SqlParameter> parameters = new List<SqlParameter>();
                HashPassword(user);
                parameters.Add(new SqlParameter("@name", user.Username));
                parameters.Add(new SqlParameter("@email", user.Email));
                parameters.Add(new SqlParameter("@password", user.Password));
                parameters.Add(new SqlParameter("@salt", user.Salt));
                DbConnect.InsertUpdateDatabase(ConstantSqlQueries.SqlInsertUser, parameters);
                return true;
            }
            return false;
        }
        public bool IsUsernameValid(RegistrationViewModel user)
        {
            if (user.Username == null)
            {
                return false;
            }
            return true;
        }
        private bool IsEmailValid(RegistrationViewModel user)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(user.Email, regex, RegexOptions.IgnoreCase);
        }
        private bool IsPasswordValid(RegistrationViewModel user)
        {
            int minimumPasswordLength = 8;
            if ((user.Password.Length < minimumPasswordLength) || (user.Password == null))
            {
                return false;
            }
            return true;
        }
        private bool ArePasswordsTheSame(RegistrationViewModel user)
        {
            if (user.Password != user.ConfirmPassword)
            {
                return false;
            }
            return true;
        }
        public bool DoesUserExist(RegistrationViewModel user)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            return DbConnect.GetDataUsingCondition("SELECT [Email] FROM [Users] WHERE Email = @email", parameters).Rows.Count > 0;
        }
       private void HashPassword(RegistrationViewModel user)
        {
            string SaltGenerated=securityHelper.CreateSalt(ConstValues.saltSize);
            user.Salt = SaltGenerated;
            user.Password = securityHelper.GenerateSHA256Hash(user.Password, user.Salt);
        }
    }
}

