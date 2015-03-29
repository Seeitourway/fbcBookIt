namespace FbcBookIt.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using FbcBookIt.Entity;

	public partial interface IStudentR
	{
		List<Teacher> GetTeachersByStudentId(Guid aStudentId);

		List<Student> GetStudentsByTeacherId(Guid aTeacherId);

		List<BookRequest> GetBookRequestsByStudentId(Guid aStudentId);

		List<BookRequest> GetBookRequestByTeacherId(Guid aTeacherId);

		List<Student> GetStudents(List<Guid> aStudentList);

		List<Teacher> GetTeachers(List<Guid> aTeacherList);

		List<BookRequest> GetBookRequests(List<Guid> aBookRequestList);

	}

	public partial class StudentR
	{
		public List<Teacher> GetTeachersByStudentId(Guid aStudentId)
		{
			List<Teacher> vResult =
				(
					from vRec in _Db.StudentTeacherSchoolDb
					join vRec2 in _Db.TeacherDb on vRec.TeacherID equals vRec2.TeacherID
					where (vRec.StudentID == aStudentId) && (vRec2.Active)
					select vRec2
				).ToList();
			return vResult;
		}

		public List<Student> GetStudentsByTeacherId(Guid aTeacherId)
		{
			List<Student> vResult =
				(
					from vRec in _Db.StudentTeacherSchoolDb
					join vRec2 in _Db.StudentDb on vRec.StudentID equals vRec2.StudentID
					where (vRec.TeacherID == aTeacherId) && (vRec2.Active)
					select vRec2
				).ToList();
			return vResult;
		}

		public List<BookRequest> GetBookRequestsByStudentId(Guid aStudentId)
		{
			List<BookRequest> vResult =
				(
					from vRec in _Db.StudentTeacherSchoolDb
					join vRec2 in _Db.BookRequestDb on vRec.ID equals vRec2.StudentTeacherSchoolId
					where (vRec.StudentID == aStudentId) 
					select vRec2
				).ToList();
			return vResult;
		}

		public List<BookRequest> GetBookRequestByTeacherId(Guid aTeacherId)
		{
			List<BookRequest> vResult =
				(
					from vRec in _Db.StudentTeacherSchoolDb
					join vRec2 in _Db.BookRequestDb on vRec.ID equals vRec2.StudentTeacherSchoolId
					where (vRec.TeacherID == aTeacherId)
					select  vRec2
				).ToList();
			return vResult;
		}

		public List<Student> GetStudents(List<Guid> aStudentList)
		{
			List<Student> vResult =
				(
					from vRec in _Db.StudentDb
					where aStudentList.Contains(vRec.StudentID)
					select vRec
				).ToList();

			return vResult;
		}

		public List<Teacher> GetTeachers(List<Guid> aTeacherList)
		{
			List<Teacher> vResult =
				(
					from vRec in _Db.TeacherDb
					where aTeacherList.Contains(vRec.TeacherID)
					select vRec
				).ToList();
			return vResult;
		}

		public List<BookRequest> GetBookRequests(List<Guid> aBookRequestList)
		{
			List<BookRequest> vResult =
				(
					from vRec in _Db.BookRequestDb
					where aBookRequestList.Contains(vRec.BookRequestId)
					select vRec
				).ToList();
			return vResult;
		}

	}
}
