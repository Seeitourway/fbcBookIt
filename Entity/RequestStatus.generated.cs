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
	
	// Table Name: RequestStatus
	public partial class RequestStatus: BASE_Entity
	{
		// Primary Keys
		public System.Int32 RequestStatusId { get; set; }
	
		// Non-Primary columns
		public System.Boolean Active { get; set; }
		public System.String StatusDescription { get; set; }
	
	}
	
	public class RequestStatusMap: EntityTypeConfiguration<RequestStatus>
	{
		public RequestStatusMap()
		{
			// Map entity to table
			ToTable("RequestStatus");
	
			// Map property to column
			Property(t => t.Active).HasColumnName("Active");
			Property(t => t.RequestStatusId).HasColumnName("RequestStatusId");
			Property(t => t.StatusDescription).HasColumnName("StatusDescription");
	
			// Primary Key
			HasKey(t => t.RequestStatusId);
	
			// Additional property mappings
			Property(t => t.Active)
				.IsRequired();
	
			Property(t => t.RequestStatusId)
				.IsRequired();
	
	
		}
	}
	
	public static partial class RequestStatusHelper
	{
		public static void AssignNewPK
			(this RequestStatus aRequestStatus)
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
			(this RequestStatus aRequestStatus)
		{
			if (aRequestStatus == null)
			{
				throw 
					new ArgumentNullException
						(
							"aRequestStatus"
							, "Entity instance cannot be null!"
						);
			}
			bool vResult = 
				(aRequestStatus.RequestStatusId < 1);
			return vResult;
		}
	
		public static void AssignTo
			(RequestStatus aFrom, RequestStatus aTo)
		{
			aTo.Active = aFrom.Active;
			aTo.RequestStatusId = aFrom.RequestStatusId;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignToNoPrimaryKeys
			(RequestStatus aFrom, RequestStatus aTo)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignToJustPrimaryKeys
			(RequestStatus aFrom, RequestStatus aTo)
		{
			aTo.RequestStatusId = aFrom.RequestStatusId;
		}
	
		public static void AssignFrom
			(this RequestStatus aTo, RequestStatus aFrom)
		{
			aTo.Active = aFrom.Active;
			aTo.RequestStatusId = aFrom.RequestStatusId;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignFromNoPrimaryKeys
			(this RequestStatus aTo, RequestStatus aFrom)
		{
			aTo.Active = aFrom.Active;
			aTo.StatusDescription = aFrom.StatusDescription;
		}
	
		public static void AssignFromJustPrimaryKeys
			(this RequestStatus aTo, RequestStatus aFrom)
		{
			aTo.RequestStatusId = aFrom.RequestStatusId;
		}
	
	}
}
