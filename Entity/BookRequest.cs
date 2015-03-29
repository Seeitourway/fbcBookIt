using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbcBookIt.Entity
{
    partial class BookRequest
    {
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
        public string FormatType { get; set; }
        [NotMapped]
        public RequestStatusE? RequestStatus
        {
            get
            {
                return (RequestStatusE?)RequestStatusId;
            }
            set
            {
                RequestStatusId = (int)value;
            }
        }
        [NotMapped]
        public IList<BookLoan> Loans { get; set; }
    }
}
