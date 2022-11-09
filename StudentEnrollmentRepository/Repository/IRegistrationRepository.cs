using StudentEnrollmentRepository.ModelEntities;
using StudentEnrollmentRepository.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudentEnrollmentRepository.Repository
{
    public interface IRegistrationRepository
    {
        bool IsNewUserRegistered(RegistrationViewModel user);
        bool DoesUserExist(RegistrationViewModel user);
    }
}
