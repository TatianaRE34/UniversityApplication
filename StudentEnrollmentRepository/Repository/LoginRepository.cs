using StudentEnrollmentRepository.DatabaseAccess;
using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.Repository
{    
    public class LoginRepository: ILoginRepository
    {
        public ILoginDataAccess loginDA;
        public LoginRepository()
        {
            this.loginDA = new LoginDataAccess();
        }
        public LoginRepository(ILoginDataAccess loginDataAccess)
        {
            this.loginDA = loginDataAccess;
        }
        public bool IsUserAuthenticated(User user)
        {
            return this.loginDA.IsUserAuthenticated(user);
        }
    }
}
