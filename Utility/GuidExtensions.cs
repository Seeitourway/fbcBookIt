namespace FbcBookIt.Utility
{
	using System;

	public static class GuidExtensions
	{
		/// <summary>
		///   This routine returns a COMB guid - a guid that is both random in
		///   generation but sequential in result thus allowing for better indexing
		///   in Sql Server databases.
		/// </summary>
		/// <remarks>
		///   This routine was lifted nearly verbatim from the Dapper Extensions
		///   gadget written by Thad Smith as found on GitHub "Dapper Extensions".
		/// </remarks>
		private static Guid GuidNextCombGuid(Guid aGuid)
		{
			byte[] vByteArray = aGuid.ToByteArray();
			DateTime vDateTime = new DateTime(1900, 1, 1);
			DateTime vNow = DateTime.Now;
			TimeSpan vTimeSpan = new TimeSpan(vNow.Ticks - vDateTime.Ticks);
			TimeSpan vTimeOfDay = vNow.TimeOfDay;
			byte[] vBytes1 = BitConverter.GetBytes(vTimeSpan.Days);
			byte[] vBytes2 = BitConverter.GetBytes
				((long)(vTimeOfDay.TotalMilliseconds / 3.333333));
			Array.Reverse(vBytes1);
			Array.Reverse(vBytes2);
			Array.Copy
				(vBytes1, vBytes1.Length - 2, vByteArray, vByteArray.Length - 6, 2);
			Array.Copy
				(vBytes2, vBytes2.Length - 4, vByteArray, vByteArray.Length - 4, 4);
			Guid vResult = new Guid(vByteArray);
			return vResult;
		}

		public static Guid GetNextCombGuid()
		{
			return GuidNextCombGuid(Guid.NewGuid());
		}

		public static Guid CombGuid(this Guid aGuid)
		{
			return GuidNextCombGuid(aGuid);
		}
	}
}