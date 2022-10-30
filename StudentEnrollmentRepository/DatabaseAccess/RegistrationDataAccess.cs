﻿using StudentEnrollmentRepository.ModelEntities;
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

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public class RegistrationDataAccess : IRegistrationDataAccess
    {
        private static int DefaultRoleId = 0;
        public string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password],[RoleId]) VALUES (@name,@email,@password," + DefaultRoleId.ToString() + ")";
        public bool IsNewUserRegistered(RegistrationViewModel user)
        {
            if (IsEmailValid(user) && IsUsernameValid(user) && IsPasswordValid(user) && ArePasswordsTheSame(user)){ 
                List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@name", user.Username));
            parameters.Add(new SqlParameter("@email", user.Email));
            parameters.Add(new SqlParameter("@password", user.Password));
            DbConnect.InsertUpdateDatabase(SqlInsertUser, parameters);
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
        public bool IsEmailValid(RegistrationViewModel user)
        {
            string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
            return Regex.IsMatch(user.Email, regex, RegexOptions.IgnoreCase);

        }
        public bool IsPasswordValid(RegistrationViewModel user)
        {
            int minimumPasswordLength = 8;
            if ((user.Password.Length < minimumPasswordLength) || (user.Password == null))
            {
                return false;
            }
            return true;
        }
        public bool ArePasswordsTheSame(RegistrationViewModel user)
        {
            if (user.Password !=user.ConfirmPassword)
            {
                return false;
            }
            return true;
        }
    }
}

