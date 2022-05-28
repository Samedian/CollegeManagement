using System;
using System.Collections.Generic;

#nullable disable

namespace CollegeManagementRepository.Model
{
    public partial class CampusSelect
    {
        public int? RollNo { get; set; }
        public string Company { get; set; }

        public virtual Student RollNoNavigation { get; set; }
    }
}
