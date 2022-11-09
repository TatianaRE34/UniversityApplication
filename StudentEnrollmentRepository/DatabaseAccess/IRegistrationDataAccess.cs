using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.DatabaseAccess
{
    public interface IRegistrationDataAccess
    {
        bool IsNewUserRegistered(RegistrationViewModel user);
        bool IsUsernameValid(RegistrationViewModel user);
        bool DoesUserExist(RegistrationViewModel user);
    }
}
