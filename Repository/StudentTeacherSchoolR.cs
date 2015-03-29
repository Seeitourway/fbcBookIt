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

        public List<Student> GetStudentSTSByTeacherID(Guid aTeacherId)
        {
            var vResult = (from sts in _Db.StudentTeacherSchoolDb
                       join s in _Db.StudentDb on sts.StudentID equals s.StudentID
                       where sts.TeacherID == aTeacherId
                       select s).ToList();
                
            return vResult;
        }

    }
}
