using Driving_school.Models;
using System.Collections.Generic;
using System.Linq;

namespace Driving_school.Services
{
    public class SecurityService
    {
     
       
        SecurityDAO securityDAO = new SecurityDAO();

        public SecurityService()
        {
        
        
        
        }

        public bool IsvalidStudent(User user)
        {
            return securityDAO.FindStudentByNameAndPassword(user);
            
        }
        public bool IsvalidTeacher(User user)
        {
            return securityDAO.FindTeacherByNameAndPassword(user);

        }

        public void AddStudent(RegisterModel user)
        {
             securityDAO.AddNewStudent(user);
        }

        public void AddLesson(Lesson lesson)
        {
            securityDAO.AddNewLesson(lesson);
        }
        public void AddMistake(Mistake mistake)
        {
            securityDAO.AddNewMistake(mistake);
        }



    }

   
}
