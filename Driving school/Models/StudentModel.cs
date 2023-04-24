using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Driving_school.Models
{
	public class StudentModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
		
    }
}