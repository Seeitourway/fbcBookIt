using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbcBookIt.Entity
{
    public partial class StudentTeacherSchool
    {
        [NotMapped]
        public Student Student { get; set; }
    }
}
