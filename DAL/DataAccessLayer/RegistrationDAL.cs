using DAL.Model;
using DAL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccessLayer
{
    public interface IRegistrationDal
    {
        bool RegisterNew(User user);
        void CheckPassword(User user);


    }
    public class RegistrationDAL:IRegistrationDal
    {
        public const string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password]) VALUES (@name,@email,@password)";
        public void CheckPassword(User user)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNew(User user)
        {
            
            List<SqlParameter> parameters = new List<SqlParameter>();
  
            parameters.Add(new SqlParameter("@name", user.UserName));
            parameters.Add(new SqlParameter("@email", user.Email));
            parameters.Add(new SqlParameter("@password", user.Password));
            DbConnect.InsertUpdateData(SqlInsertUser, parameters);


            return true;
        }
        
            
            
     }
}

