namespace FbcBookIt.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;
	using FbcBookIt.Entity;

	public partial interface IStudentTeacherSchoolR
	{

		// GetByTeacherID will return the first occurrence of a record that
		// matches the criteria. If no record matches, the method will return null.
		StudentTeacherSchool GetByTeacherIdWithStudent(Guid aTeacherId);

		List<StudentTeacherSchool> GetByTeacherIdWithStudentAsList(Guid aTeacherId);

	}

	public partial class StudentTeacherSchoolR
	{
		public StudentTeacherSchool GetByTeacherIdWithStudent(Guid aTeacherId)
		{
			StudentTeacherSchool vResult;
			vResult =
				_Db.StudentTeacherSchoolDb.Include("Student")
					.FirstOrDefault(aRec => aRec.TeacherID == aTeacherId);
			return vResult;
		}

		public List<StudentTeacherSchool> GetByTeacherIdWithStudentAsList(Guid aTeacherId)
		{
			List<StudentTeacherSchool> vResult;
			vResult =
				_Db.StudentTeacherSchoolDb.Include("Student")
					.Where(aRec => aRec.TeacherID == aTeacherId)
					.ToList();
			return vResult;
		}

	}
}
