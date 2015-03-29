using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbcBookIt.Entity
{
    partial class Copy
    {
        [NotMapped]
        public IList<Volume> Volumes { get; set; }
        [NotMapped]
        public FormatTypeE? FormatType
        {
            get
            {
                return (FormatTypeE?)FormatTypeID;
            }
            set
            {
                if (value.HasValue)
                    FormatTypeID = (int)value.Value;
                else
                    FormatTypeID = null;
            }
        }

        [NotMapped]
        public CopyStatusE? CopyStatus
        {
            get
            {
                return (CopyStatusE?)CopyStatusID;
            }
            set
            {
                if (value.HasValue)
                    CopyStatusID = (int)value;
                else
                    CopyStatusID = null;
            }
        }
    }
}
