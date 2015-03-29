using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbcBookIt.Entity
{
    partial class Copy
    {
        public IList<Volume> Volumes { get; set; }
    }
}
