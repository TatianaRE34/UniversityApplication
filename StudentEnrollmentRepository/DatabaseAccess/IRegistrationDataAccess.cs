using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.DatabaseAccess
{
    public interface IRegistrationDataAccess
    {
        bool IsNewUserRegistered(User user);
        void CheckPassword(User user);
    }
}
