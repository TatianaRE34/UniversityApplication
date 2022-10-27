using DAL.BusinessLogic;
using DAL.DataAccessLayer;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessLogic
{
    public interface ILoginBL
    {
        bool UserAuthentication(User user);
    }
    public class LoginBL:ILoginBL
    {
        public ILoginDAL loginDAL;

        public LoginBL()
        {
            this.loginDAL = new LoginDAL();
        }

        public LoginBL(ILoginDAL loginDAL)
        {
            this.loginDAL = loginDAL;
        }
        public bool UserAuthentication(User user)
        {
            return this.loginDAL.UserAuthentication(user);
        }
    }
}
