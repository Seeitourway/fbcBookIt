using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbcBookIt.Entity
{
    partial class Student
    {
        [NotMapped]
        public IList<Teacher> Teachers { get; set; }
        [NotMapped]
        public IList<BookRequest> BookRequests { get; set; }
    }
}
