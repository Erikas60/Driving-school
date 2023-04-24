namespace Driving_school.Models
{
    public class Mistake
    {
        public int Id { get; set; }
        public string Name { get; set; }      
		public string StudentUsername { get; set; }
		public string InstructorName { get; set; }
		public string Description { get; set; }      
	}
}
