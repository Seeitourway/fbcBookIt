namespace FbcBookIt.Entity
{
	using System.Collections.Generic;

	partial class Copy
	{
		public IList<Volume> Volumes { get; set; }
		public FormatType FormatType { get; set; }

	}
}