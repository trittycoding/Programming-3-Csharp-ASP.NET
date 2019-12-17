﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BITCollegeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICollegeRegistration" in both code and config file together.
    [ServiceContract]
    public interface ICollegeRegistration
    {
        [OperationContract]
        bool dropCourse(int registrationId);

        [OperationContract]
        int registerCourse(int studentId, int courseId, string notes);

        [OperationContract]
        void updateGrade(double grade, int registrationId, string notes);
    }
}
