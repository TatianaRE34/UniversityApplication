using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.DatabaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEnrollmentRepository.ViewModel;

namespace StudentEnrollmentRepository.Repository
{
    public class RegistrationRepository: IRegistrationRepository
    {
        public IRegistrationDataAccess registrationDA;
        public RegistrationRepository()
        {
            this.registrationDA = new RegistrationDataAccess();
        }
        public RegistrationRepository(IRegistrationDataAccess registrationDataAccess)
        {
            this.registrationDA = registrationDataAccess;
        }
        public bool IsNewUserRegistered(RegistrationViewModel user)
        {
           return this.registrationDA.IsNewUserRegistered(user);
        }
        public bool DoesUserExist(RegistrationViewModel user)
        {
            return this.registrationDA.DoesUserExist(user);
        }
    }
}
