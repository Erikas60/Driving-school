using System;
using System.Collections;
using System.Collections.Generic;

namespace Driving_school.Models
{
    public class Lesson : IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InstructorName { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string StudentUsername { get; set; }
        public int Grade { get; set; }
        public string Description { get; set; }
        public IEnumerator GetEnumerator()
        {
            yield return Id;
            yield return Name;
            yield return InstructorName;
            yield return Date;
            yield return Duration;
            yield return StudentUsername;
            yield return Grade;
            yield return Description;
        }
    }
}
