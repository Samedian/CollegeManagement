using CollegeManagementEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementService
{
    public interface IStudentSer
    {
        Task<bool> AddStudent(StudentEntity student);
        Task<bool> UpdateStudent(StudentEntity student);
        List<StudentEntity> GetStudentPlaced();
        Task<bool> AddCampus(CampusEntity campusEntity);
        List<StudentEntity> GetStudentByGrade();
    }
}