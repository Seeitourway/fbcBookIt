using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbcBookIt.Entity
{
    partial class BookLoan
    {
        [NotMapped]
        public string RequestNumber { get; set; }
        [NotMapped]
        public Volume Volume { get; set; }
        [NotMapped]
        public string Title { get; set; }
        [NotMapped]
        public string Teacher { get; set; }
        [NotMapped]
        public string Student { get; set; }
        [NotMapped]
        public string School { get; set; }
        [NotMapped]
        public string District { get; set; }
        [NotMapped]
        public FormatTypeE FormatType { get; set; }
        [NotMapped]
        public LoanStatusE LoanStatus
        {
            get
            {
                return (LoanStatusE)LoanStatusID;
            }
            set
            {
                LoanStatusID = (int)value;
            }
        }
        [NotMapped]
        public IList<Copy> AvailableCopies { get; set; }
    }
}
