using CollegeManagementEntity;
using CollegeManagementRepository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollegeManagementRepository
{
    public class ConvertEntityToModel : IConvertEntityToModel
    {
        /// <summary>
        /// Convert Campus entity to model
        /// </summary>
        /// <param name="campusEntity"></param>
        /// <returns></returns>
        public CampusSelect ConvertCampusEntityToModel(CampusEntity campusEntity)
        {
            CampusSelect campusSelect = new CampusSelect();
            campusSelect.RollNo = campusEntity.RollNo;
            campusSelect.Company = campusEntity.Company;

            return campusSelect;
        }

        /// <summary>
        /// convert student entity to model
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <returns></returns>

        public Student ConvertStudentEntityToModel(StudentEntity studentEntity)
        {
            Student student = new Student();
            student.RollNo = studentEntity.RollNo;
            student.StudentName = studentEntity.StudentName;
            student.Branch = studentEntity.Branch;
            student.Marks = (decimal)studentEntity.Marks;

            return student;
        }

        /// <summary>
        /// convert list of student model to entity
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public List<StudentEntity> ConvertStudentModelToEntity(List<Student> student)
        {
            List<StudentEntity> studentEntities = new List<StudentEntity>();
            foreach (var item in student)
            {
                StudentEntity studentEntity = new StudentEntity();
                studentEntity.RollNo = item.RollNo;
                studentEntity.StudentName = item.StudentName;
                studentEntity.Marks = (double)item.Marks;
                studentEntity.Branch = item.Branch;

                studentEntities.Add(studentEntity);
            }
            return studentEntities;
        }
    }
}
