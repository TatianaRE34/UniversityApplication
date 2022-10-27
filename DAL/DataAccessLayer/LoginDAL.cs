using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.BusinessLogic;

namespace DAL.DataAccessLayer
{

    public interface ILoginDAL
    {
        bool UserAuthentication(User user);
    }

    public class LoginDAL:ILoginDAL
    {

        public const string SQLAuthenticationLookup = @"SELECT * FROM [Users] WHERE Email=@email and Password=@password";
         public bool UserAuthentication(User user)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@email", user.Email));
            parameters.Add(new SqlParameter("@password", user.Password));

            var datatable= DbConnect.GetDataWithConditions(SQLAuthenticationLookup, parameters);


            return datatable.Rows.Count > 0;
        }
    }
}
