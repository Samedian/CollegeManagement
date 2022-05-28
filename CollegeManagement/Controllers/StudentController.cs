using CollegeManagementEntity;
using CollegeManagementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentSer _student;
        public StudentController(IStudentSer studentService)
        {
            _student = studentService;
        }

        /// <summary>
        /// Post Method to add student details
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddStudent")]
        [BasicAuthentication]
        public async Task<IActionResult> AddStudent(StudentEntity student)
        {
            try
            {
                bool result;
                result = await _student.AddStudent(student);

                return Ok();
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
        /// Post Method to add Campus Details
        /// </summary>
        /// <param name="campusEntity"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("AddCampus")]
        [BasicAuthentication]
        public async Task<IActionResult> AddCampus(CampusEntity campusEntity)
        {
            try
            {
                bool result;
                result = await _student.AddCampus(campusEntity);

                return Ok();
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
        /// Put Method To Update Student Details
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>

        [HttpPut]
        [Route("UpdateStudent")]
        [BasicAuthentication]
        public async Task<IActionResult> UpdateStudent(StudentEntity student)
        {
            try
            {
                bool result;
                result = await _student.UpdateStudent(student);

                return Ok();
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
        /// Get Method to get placed student
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPlacedStudent")]
        public async Task<ActionResult> GetStudentPlaced()
        {

            try
            {
                List<StudentEntity> studentEntities =  _student.GetStudentPlaced();
                return Ok(studentEntities);
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
        /// get method to get student by marks above 7
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetStudentByGrade")]
        public async Task<ActionResult> GetStudentByGrade()
        {

            try
            {
                List<StudentEntity> studentEntities = _student.GetStudentByGrade();
                return Ok(studentEntities);
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
