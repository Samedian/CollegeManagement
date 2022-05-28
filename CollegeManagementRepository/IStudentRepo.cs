using CollegeManagementEntity;
using CollegeManagementRepository.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementRepository
{
    public interface IStudentRepo
    {
        Task<bool> AddStudent(StudentEntity studentEntity);
        Task<bool> UpdateStudent(StudentEntity studentEntity);
        List<StudentEntity> GetStudent();
        Task<bool> AddCampus(CampusEntity campusEntity);
        List<StudentEntity> GetStudentByGrade();
    }
}