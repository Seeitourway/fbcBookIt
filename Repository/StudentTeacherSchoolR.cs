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

        List<Student> GetStudentSTSByTeacherID(Guid aTeacherId);
        List<Student> GetByTeacherIdWithStudentAsList(Guid aTeacherId);

    }

    public partial class StudentTeacherSchoolR
    {
        public StudentTeacherSchool GetByTeacherIdWithStudent(Guid aTeacherId)
        {
            StudentTeacherSchool vResult;
            vResult =
                _Db.StudentTeacherSchoolDb.Include(s => s.Student)
                    .FirstOrDefault(aRec => aRec.TeacherID == aTeacherId);
            return vResult;
        }

        public List<Student> GetStudentSTSByTeacherID(Guid aTeacherId)
        {
            var vResult = (_Db.StudentTeacherSchoolDb.Join
	            (
		            _Db.StudentDb,
		            sts => sts.StudentID,
		            s => s.StudentID,
		            (sts, s) => new
		            {
			            sts,
			            s
		            })
	            .Where(@vT => @vT.sts.TeacherID == aTeacherId)
	            .Select(@vT => @vT.s)).ToList();
                
            return vResult;
        }

        public List<Student> GetByTeacherIdWithStudentAsList
            (Guid aTeacherId)
        {
	        List<Student> vResult = 
						(
			        _Db.StudentTeacherSchoolDb.Where
				        (sts => sts.TeacherID == aTeacherId)
			        .Select(sts => sts.Student)
		        )
		        .Distinct()
		        .ToList();
	        return vResult;
        }
    }
}
