using CollegeManagementEntity;
using CollegeManagementRepository.Model;
using System.Collections.Generic;

namespace CollegeManagementRepository
{
    public interface IConvertEntityToModel
    {
        Student ConvertStudentEntityToModel(StudentEntity studentEntity);
        List<StudentEntity> ConvertStudentModelToEntity(List<Student> student);
        CampusSelect ConvertCampusEntityToModel(CampusEntity campusEntity);
    }
}