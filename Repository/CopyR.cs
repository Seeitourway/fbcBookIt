namespace FbcBookIt.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using FbcBookIt.Entity;

	public partial class CopyR
	{
		public List<Copy> GetCopyByTitleIdAndFormatCategory
			(Guid aTitleId, int aFormatId, string aCategory)
		{
			List<Copy> vResult = 
				(
					from vRec in _Db.CopyDb
					join vRec2 in _Db.FormatTypeDb 
						on vRec.FormatTypeID equals vRec2.FormatTypeId
					where (vRec.TitleID == aTitleId ) && (vRec2.Category == aCategory)
					select vRec
				).ToList();
			return vResult;
		}

	}
}
