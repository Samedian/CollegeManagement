using CollegeManagementEntity;
using CollegeManagementRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementService
{
    public class StudentSer : IStudentSer
    {

        private readonly IStudentRepo _studentRepo;
        public StudentSer(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        /// <summary>
        /// Calls Repository Layer AddCampus method to add campus details
        /// </summary>
        /// <param name="campusEntity"></param>
        /// <returns></returns>
        public async Task<bool> AddCampus(CampusEntity campusEntity)
        {
            bool result;
            result = await _studentRepo.AddCampus(campusEntity);
            return true;
        }

        /// <summary>
        /// Calls Repository Layer AddStudent method to add Student details
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> AddStudent(StudentEntity student)
        {
            bool result;
            result = await _studentRepo.AddStudent(student);
            return true;
        }

        /// <summary>
        /// Calls Repository Layer GetStudentByGrade method to get student details whose marks are greater then 7
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetStudentByGrade()
        {
            List<StudentEntity> studentEntities;
            studentEntities = _studentRepo.GetStudentByGrade();

            return studentEntities;
        }

        /// <summary>
        /// Calls Repository Layer GetStudent method to get student details who are placed
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetStudentPlaced()
        {
            List<StudentEntity> studentEntities;
            studentEntities = _studentRepo.GetStudent();

            return studentEntities;
        }

        /// <summary>
        /// call repository layer updateStudent method to update student personal details
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStudent(StudentEntity student)
        {
            bool result;
            result = await _studentRepo.UpdateStudent(student);
            return true;
        }
    }
}
