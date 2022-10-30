using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.ConstantValues
{
    public  class ConstantSqlQueries
    {
        public const string SqlInsertUser = @" INSERT INTO [Users] ([Username],[Email],[Password],[RoleId]) VALUES (@name,@email,@password,)";
    }

}
