//-----------------------------------------------------------------------------
// <auto-generated> 
// ^^^ Comment out the above line to allow ReSharper to validate the 
//  using clauses.
//	This code was generated from a template.
//
//	Manual changes to this file may cause unexpected behavior in your 
//	application.
//	Manual changes to this file will be overwritten if the code is 
//	regenerated.
// </auto-generated>
//-----------------------------------------------------------------------------

namespace FbcBookIt.Entity
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Data.Entity.ModelConfiguration;
	using System.ComponentModel.DataAnnotations.Schema;
	//using AWEFramework.AWEExtensions;
	using FbcBookIt.Utility;
	using System.Collections.Generic;
	
	// Table Name: VolumeStatus
	public partial class VolumeStatus: BASE_Entity
	{
		// Primary Keys
		public System.Int32 VolumeStatusId { get; set; }
	
		// Non-Primary columns
		public System.Boolean Active { get; set; }
		public System.String StatusDescription { get; set; }
	
	}
	
	public class VolumeStatusMap: EntityTypeConfiguration<VolumeStatus>
	{
		public VolumeStatusMap()
		{
			// Map entity to table
			ToTable("VolumeStatus");
	
			// Map property to column
			Property(t => t.Active).HasColumnName("Active");
			Property(t => t.StatusDescription).HasColumnName("StatusDescription");
			Property(t => t.VolumeStatusId).HasColumnName("VolumeStatusId");
	
			// Primary Key
			HasKey(t => t.VolumeStatusId);
	
			// Additional property mappings
			Property(t => t.Active)
				.IsRequired();
	
			Property(t => t.VolumeStatusId)
				.IsRequired();
	
	
		}
	}
	
	public static partial class VolumeStatusHelper
	{
		public static void AssignNewPK
			(this VolumeStatus aVolumeStatus)
		{
		}
	
		/// <summary> 
		/// This code is fragile in that is ASSUMES that integer primary keys ARE
		/// AUTO-INCREMENTING columns whose value is governed by the database 
		/// server and that Guid primary keys are NOT "computed" values but rather 
		/// those whose column value is set by the client and/or server in a 
		/// fashion NOT governed by the database server.
		/// </summary>
		public static bool IsNew
			(this VolumeStatus aVolumeStatus)
		{
			if (aVolumeStatus == null)
			{
				throw 
					new ArgumentNullException
						(
							"aVolumeStatus"
							, "Entity instance cannot be null!"
						);
			}
			bool vResult = 
				(aVolumeStatus.VolumeStatusId < 1);
			return vResult;
		}
	
		public static void AssignTo
			(VolumeStatus aFrom, VolumeStatus aTo)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
			aTo.VolumeStatusId = aFrom.VolumeStatusId;
		}
	
		public static void AssignToNoPrimaryKeys
			(VolumeStatus aFrom, VolumeStatus aTo)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignToJustPrimaryKeys
			(VolumeStatus aFrom, VolumeStatus aTo)
		{
			aTo.VolumeStatusId = aFrom.VolumeStatusId;
		}
	
		public static void AssignFrom
			(this VolumeStatus aTo, VolumeStatus aFrom)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
			aTo.VolumeStatusId = aFrom.VolumeStatusId;
		}
	
		public static void AssignFromNoPrimaryKeys
			(this VolumeStatus aTo, VolumeStatus aFrom)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignFromJustPrimaryKeys
			(this VolumeStatus aTo, VolumeStatus aFrom)
		{
			aTo.VolumeStatusId = aFrom.VolumeStatusId;
		}
	
	}
}
