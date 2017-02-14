using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_MI
{
    class UserHelper
    {
        public static string user = "";
        public static UserType userType;
    }

    public enum UserType
    {
        Admin,
        Student,
        Teacher
    }
}