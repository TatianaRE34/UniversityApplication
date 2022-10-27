using DAL.Model;
using DAL.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessLogic
{
    public interface IRegistrationBL
    {
         bool RegisterNew(User user);

    }

    public class RegistrationBL: IRegistrationBL
    {
        public IRegistrationDal registrationDAL;

        public RegistrationBL()
        {
            this.registrationDAL= new RegistrationDAL();
        }
        public RegistrationBL(IRegistrationDal registrationDAL)
        {
            this.registrationDAL = registrationDAL;
        }
        
        public bool RegisterNew(User user)
        {
           return this.registrationDAL.RegisterNew(user);
        }
    }
}
