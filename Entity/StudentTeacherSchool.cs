namespace FbcBookIt.Entity
{
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;

	public partial class StudentTeacherSchool
	{
		public Student Student { get; set; }
	}
}
