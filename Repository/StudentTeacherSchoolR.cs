namespace FbcBookIt.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using FbcBookIt.Entity;

    public partial interface IStudentTeacherSchoolR
    {
      List<Student> GetStudentSTSByTeacherID(Guid aTeacherId);

            List<Student> GetByTeacherIdWithStudentAsList(Guid aTeacherId);

    }

    public partial class StudentTeacherSchoolR
    {
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
