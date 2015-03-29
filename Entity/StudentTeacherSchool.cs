namespace FbcBookIt.Entity
{
	using System.Collections.Generic;

	public partial class StudentTeacherSchool
	{
		IEnumerable<Student> Students { get; set; }

	}
}
