using Driving_school.Models;
using static System.Net.Mime.MediaTypeNames;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace Driving_school.Services
{
    public class SecurityDAO
    {

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Users; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent = ReadWrite; MultiSubnetFailover=False";

        public bool FindStudentByNameAndPassword(User user)
        {

            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Students WHERE name = @name AND password = @password";

           using( SqlConnection connection = new SqlConnection(connectionString)){
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 40).Value = user.Name;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if(reader.HasRows)
                    {
                        success = true;
                    }
                }catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;

        }
        public bool FindTeacherByNameAndPassword(User user)
        {

            bool success = false;
            string sqlStatement = "SELECT * FROM dbo.Teachers WHERE name = @name AND password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 40).Value = user.Name;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 40).Value = user.Password;

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return success;

        }
        public void AddNewStudent(RegisterModel student)
        {
            string sqlStatement = "INSERT INTO dbo.Students (Name,Password) VALUES (@name, @password)";

            using (SqlConnection connection = new SqlConnection(connectionString)) { 
                SqlCommand command = new SqlCommand(sqlStatement, connection);

            
            
                try
                {

                    
                        connection.Open();

                        command.Parameters.AddWithValue("@name", student.UserName);
                        command.Parameters.AddWithValue("@password", student.Password);


                        command.ExecuteNonQuery();

                    

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AddNewLesson(Lesson lesson)
        {
            string sqlStatement = "INSERT INTO dbo.Lessons (Name,InstructorName, Date, Duration, StudentUserName, Grade)" +
                " VALUES (@name, @instructorname, @date, @duration, @studentusername, @grade)";

            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);



                try
                {


                    connection.Open();

                    command.Parameters.AddWithValue("@name", lesson.Name);
                    command.Parameters.AddWithValue("@instructorname", lesson.InstructorName);
                    command.Parameters.AddWithValue("@date", lesson.Date);
                    command.Parameters.AddWithValue("@duration", lesson.Duration);
                    command.Parameters.AddWithValue("@studentusername", lesson.StudentUsername);
                    command.Parameters.AddWithValue("@grade", 0);


                    command.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void AddNewMistake(Mistake mistake)
        {
            string sqlStatement = "INSERT INTO dbo.Mistakes (Name, StudentUserName,InstructorName, Description)" +
                " VALUES (@name, @studentusername, @instructorname, @description)";



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);



                try
                {


                    connection.Open();

                    command.Parameters.AddWithValue("@name", mistake.Name);
                    command.Parameters.AddWithValue("@studentusername", mistake.StudentUsername);
                    command.Parameters.AddWithValue("@instructorname", mistake.InstructorName);
                    command.Parameters.AddWithValue("@description", mistake.Description);
                   


                    command.ExecuteNonQuery();



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public List<Lesson> FindLessonsByStudentNameHistory(string user)
        {

            List<Lesson> foundLessons = new List<Lesson>();
            string sqlStatement = "SELECT * FROM dbo.Lessons WHERE StudentUsername = @name AND Date < @date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 40).Value = user;
                command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = DateTime.Now;



                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundLessons.Add(new Lesson { Id = (int)reader[0], Name = (string)reader[1], InstructorName = (string)reader[2], Date = (DateTime)reader[3], Duration = (int)reader[4], StudentUsername = (string)reader[5], Grade = (int)reader[6] });
                    }
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundLessons;

        }
        public List<Lesson> FindLessonsByStudentNameSchedule(string user)
        {

            List<Lesson> foundLessons = new List<Lesson>();
            string sqlStatement = "SELECT * FROM dbo.Lessons WHERE StudentUsername = @name AND Date > @date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 40).Value = user;
                command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = DateTime.Now;



                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundLessons.Add(new Lesson { Id = (int)reader[0], Name = (string)reader[1], InstructorName = (string)reader[2], Date = (DateTime)reader[3], Duration = (int)reader[4], StudentUsername = (string)reader[5], Grade = (int)reader[6] });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundLessons;

        }
        public List<Mistake> FindMistakesByLesson(string lessonname, string username)
        {

            List<Mistake> foundMistakes = new List<Mistake>();
            string sqlStatement = "SELECT * FROM dbo.Mistakes WHERE Name = @lessonname AND StudentUserName = @studentname";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@lessonname", System.Data.SqlDbType.VarChar, 40).Value = lessonname;
                command.Parameters.Add("@studentname", System.Data.SqlDbType.VarChar, 40).Value = username;



                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundMistakes.Add(new Mistake { Id = (int)reader[0], Name = (string)reader[1], StudentUsername = (string)reader[2], InstructorName = (string)reader[3], Description = (string)reader[4] });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundMistakes;

        }
        public List<Lesson> FindLessonsByInstructorName(string user)
        {

            List<Lesson> foundLessons = new List<Lesson>();
            string sqlStatement = "SELECT * FROM dbo.Lessons WHERE InstructorName = @name AND Date < @date";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@name", System.Data.SqlDbType.VarChar, 40).Value = user;
                command.Parameters.Add("@date", System.Data.SqlDbType.DateTime).Value = DateTime.Now;



                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foundLessons.Add(new Lesson { Id = (int)reader[0], Name = (string)reader[1], InstructorName = (string)reader[2], Date = (DateTime)reader[3], Duration = (int)reader[4], StudentUsername = (string)reader[5], Grade = (int)reader[6] });
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return foundLessons;

        }
        public void UpdateLessonGrade(int id, int grade)
        {
            string sqlStatement = "UPDATE dbo.Lessons SET Grade = @grade WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@grade", System.Data.SqlDbType.Int).Value = grade;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void UpdateDescription(int id, string description)
        {
            string sqlStatement = "UPDATE dbo.Lessons SET Description = @description WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                command.Parameters.Add("@description", System.Data.SqlDbType.VarChar, 255).Value = description;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
