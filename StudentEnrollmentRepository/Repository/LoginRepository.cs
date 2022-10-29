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
        public ILoginDataAccess loginDataAccess;
        public LoginRepository()
        {
            this.loginDataAccess = new LoginDataAccess();
        }
        public LoginRepository(ILoginDataAccess loginDataAccess)
        {
            this.loginDataAccess = loginDataAccess;
        }
        public bool IsUserAuthenticated(User user)
        {
            return this.loginDataAccess.IsUserAuthenticated(user);
        }
    }
}
