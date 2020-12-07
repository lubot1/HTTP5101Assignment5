using HTTP5101Assignment5.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101Assignment5.Controllers
{
    public class TeacherDataController : ApiController
    {
        //Instantiates object with credentials to create a connection to the database
        private SchoolDbContext School = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the teachers table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `teachers`";
            //Create an object with results from the query
            MySqlDataReader TeachersResults = cmd.ExecuteReader();
            List<Teacher> Teachers = new List<Teacher>{};
            
            while(TeachersResults.Read())
            {
                //Assign results to variables
                int TeacherId = (int)TeachersResults["teacherid"];
                string TeacherFName = (string)TeachersResults["teacherfname"];
                string TeacherLName = (string)TeachersResults["teacherlname"];
                string EmployeeNumber = (string)TeachersResults["employeenumber"];
                DateTime HireDate = (DateTime)TeachersResults["hiredate"];
                decimal Salary = (decimal)TeachersResults["salary"];
                //Instantiate new teacher object to assign results to
                Teacher NewTeacher = new Teacher();
                //Assign results to the new teacher object properties
                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFName;
                NewTeacher.TeacherLname = TeacherLName;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                //Add the new teacher object to a running list of teacher objects
                Teachers.Add(NewTeacher);
            }

            Conn.Close();

            return Teachers;
        }

        public Teacher FindTeacher(int id)
        {
            //Instantiate new teacher object to assign results to
            Teacher NewTeacher = new Teacher();
            //Establishes a new connection to the database using the AccessDatabase method in the SchoolDbContext class
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command that displays all columns from the teachers table
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `teachers` WHERE `teachers`.teacherid = " + id;

            MySqlDataReader TeacherResult = cmd.ExecuteReader();
            
            while(TeacherResult.Read())
            {
                //Assign results to variables
                int TeacherId = (int)TeacherResult["teacherid"];
                string TeacherFName = (string)TeacherResult["teacherfname"];
                string TeacherLName = (string)TeacherResult["teacherlname"];
                string EmployeeNumber = (string)TeacherResult["employeenumber"];
                DateTime HireDate = (DateTime)TeacherResult["hiredate"];
                decimal Salary = (decimal)TeacherResult["salary"];
                //Assign results to the new teacher object properties
                NewTeacher.Teacherid = TeacherId;
                NewTeacher.TeacherFname = TeacherFName;
                NewTeacher.TeacherLname = TeacherLName;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
            }

            Conn.Close();
            return NewTeacher;
        }

        /// <summary>
        /// Function to delete teacher entries in database
        /// </summary>
        /// <param name="id">Teacher id that will be deleted</param>
        /// <example>
        /// POST ---> /Teacher/Delete
        /// Data: int id
        /// </example>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command object
            MySqlCommand cmd = Conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `teachers` WHERE teacherid=@id";
            //Adds value of id to query safely
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Conn.Close();
        }
        //Function to add Teachers
        /// <summary>
        /// Adds a teacher to the database using data provided in a form
        /// </summary>
        /// <param name="NewTeacher">Teacher object that is passed to the function</param>
        /// <returns>Void</returns>
        /// <example>
        /// POST ---> /Teacher/Create
        /// Data: NewTeacher.TeacherFname,NewTeacher.TeacherLname,NewTeacher.EmployeeNumber,NewTeacher.Salary
        /// </example>
        [HttpPost]
        public void AddTeacher([FromBody]Teacher NewTeacher)
        {
            MySqlConnection Conn = School.AccessDatabase();
            //Opens connection to the database
            Conn.Open();
            //Creates a new MySql command object
            MySqlCommand cmd = Conn.CreateCommand();
            //Query uses MySql CURRENT_DATE() method to generate hire date
            cmd.CommandText = "INSERT INTO `teachers` (teacherfname,teacherlname,employeenumber,salary,hiredate) VALUES " +
                "(@TeacherFname,@TeacherLname,@EmployeeNumber,@Salary,CURRENT_DATE())";
            //Adds value of id to query safely
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);

            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }
}
