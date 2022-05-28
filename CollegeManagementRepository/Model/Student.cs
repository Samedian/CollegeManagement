using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementRepository.Model
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string StudentName { get; set; }
        public string Branch { get; set; }
        public decimal Marks { get; set; }
    }
}
