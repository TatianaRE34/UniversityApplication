using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.Repository
{
    public class RegistrationRepository: IRegistrationRepository
    {
        public IRegistrationDataAccess registrationDataAccess;
        public RegistrationRepository()
        {
            this.registrationDataAccess = new RegistrationDataAccess();
        }
        public RegistrationRepository(IRegistrationDataAccess registrationDAL)
        {
            this.registrationDataAccess = registrationDAL;
        }
        public bool IsNewUserRegistered(User user)
        {
           return this.registrationDataAccess.IsNewUserRegistered(user);
        }
    }
}
