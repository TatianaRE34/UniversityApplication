﻿using StudentEnrollmentRepository.ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollmentRepository.Repository
{
    public interface IStudentRegRepository
    {
        List<Subject> GetSubjectList();
    }
}
