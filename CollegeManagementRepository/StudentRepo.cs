using CollegeManagementEntity;
using CollegeManagementRepository.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CollegeManagementRepository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly IConvertEntityToModel _convertEntityToModel;
        public StudentRepo(IConvertEntityToModel convertEntityToModel)
        {
            _convertEntityToModel = convertEntityToModel;
        }

        /// <summary>
        /// Add Campus data to database
        /// </summary>
        /// <param name="campusEntity"></param>
        /// <returns></returns>
        public async Task<bool> AddCampus(CampusEntity campusEntity)
        {
            CampusSelect campusSelect = _convertEntityToModel.ConvertCampusEntityToModel(campusEntity);
            Student student;
            try
            {

                using (var context = new CollegeSystemContext())
                {
                    student = context.Students.Find(campusSelect.RollNo);
                    campusSelect.RollNoNavigation = student;

                }
                using (var context = new CollegeSystemContext())
                {
                    context.CampusSelects.Add(campusSelect);
                    context.SaveChanges();
                }
                return await new Task<bool>(() => true);
            }
            catch (SqlException exception)
            {
                throw exception.InnerException;
            }
            catch (Exception exception)
            {
                throw exception.InnerException;
            }

        }

        /// <summary>
        /// add student data to database
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <returns></returns>
        public async Task<bool> AddStudent(StudentEntity studentEntity)
        {
            Student student = _convertEntityToModel.ConvertStudentEntityToModel(studentEntity);

            try
            {
                using (var context = new CollegeSystemContext())
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                return await new Task<bool>(() => true);
            }
            catch (SqlException exception)
            {
                throw exception.InnerException;
            }
            catch (Exception exception)
            {
                throw exception.InnerException;
            }

        }

        /// <summary>
        /// get placed student list
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetStudent()
        {
            try
            {
                using (var context = new CollegeSystemContext())
                {
                    var student = (from s in context.Students
                                  join c in context.CampusSelects
                                  on s.RollNo equals c.RollNo 
                                  select s).ToList();


                    List<StudentEntity> studentEntities = _convertEntityToModel.ConvertStudentModelToEntity(student);
                    return studentEntities;

                }
            }
            catch (SqlException exception)
            {
                throw exception.InnerException;
            }
            catch (Exception exception)
            {
                throw exception.InnerException;
            }

        }

        /// <summary>
        /// get student whose marks are greater then 7
        /// </summary>
        /// <returns></returns>
        public List<StudentEntity> GetStudentByGrade()
        {
            try
            {
                using (var context = new CollegeSystemContext())
                {
                    var student = (from s in context.Students where s.Marks>=7
                                   select s).ToList();


                    List<StudentEntity> studentEntities = _convertEntityToModel.ConvertStudentModelToEntity(student);
                    return studentEntities;

                }
            }
            catch (SqlException exception)
            {
                throw exception.InnerException;
            }
            catch (Exception exception)
            {
                throw exception.InnerException;
            }

        }

        /// <summary>
        /// update personal details of student
        /// </summary>
        /// <param name="studentEntity"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStudent(StudentEntity studentEntity)
        {
            Student student = _convertEntityToModel.ConvertStudentEntityToModel(studentEntity);

            try
            {
                using (var context = new CollegeSystemContext())
                {
                    var data = context.Students.Find(student.RollNo);
                    data.StudentName = student.StudentName;
                    data.Marks = student.Marks;
                    data.Branch = student.Branch;

                    context.Students.Add(student);
                    context.SaveChanges();
                }
                return await new Task<bool>(() => true);
            }
            catch (SqlException exception)
            {
                throw exception.InnerException;
            }
            catch (Exception exception)
            {
                throw exception.InnerException;
            }

        }
    }
}
