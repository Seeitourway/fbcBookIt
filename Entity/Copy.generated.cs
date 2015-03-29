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
	
	// Table Name: Copy
	public partial class Copy: BASE_Entity
	{
		// Primary Keys
		public System.Guid CopyId { get; set; }
	
		// Non-Primary columns
		public System.String AccessionNumber { get; set; }
		public System.DateTime? AcquisitionDate { get; set; }
		public System.Boolean Active { get; set; }
		public System.String Comment { get; set; }
		public System.Boolean Consumable { get; set; }
		// Foreign Key to CopyStatus
		public System.Int32? CopyStatusID { get; set; }
		public System.DateTime? DiscardedDate { get; set; }
		public System.String EndLocation { get; set; }
		// Foreign Key to FormatType
		public System.Int32? FormatTypeID { get; set; }
		public System.Boolean MasterCopy { get; set; }
		public System.Int32? NumberOfTactiles { get; set; }
		public System.Decimal? Price { get; set; }
		public System.Boolean ProofRead { get; set; }
		public System.String StartLocation { get; set; }
		// Foreign Key to Title
		public System.Guid TitleID { get; set; }
	
	}
	
	public class CopyMap: EntityTypeConfiguration<Copy>
	{
		public CopyMap()
		{
			// Map entity to table
			ToTable("Copy");
	
			// Map property to column
			Property(t => t.AccessionNumber).HasColumnName("AccessionNumber");
			Property(t => t.AcquisitionDate).HasColumnName("AcquisitionDate");
			Property(t => t.Active).HasColumnName("Active");
			Property(t => t.Comment).HasColumnName("Comment");
			Property(t => t.Consumable).HasColumnName("Consumable");
			Property(t => t.CopyId).HasColumnName("CopyId");
			Property(t => t.CopyStatusID).HasColumnName("CopyStatusID");
			Property(t => t.DiscardedDate).HasColumnName("DiscardedDate");
			Property(t => t.EndLocation).HasColumnName("EndLocation");
			Property(t => t.FormatTypeID).HasColumnName("FormatTypeID");
			Property(t => t.MasterCopy).HasColumnName("MasterCopy");
			Property(t => t.NumberOfTactiles).HasColumnName("NumberOfTactiles");
			Property(t => t.Price).HasColumnName("Price");
			Property(t => t.ProofRead).HasColumnName("ProofRead");
			Property(t => t.StartLocation).HasColumnName("StartLocation");
			Property(t => t.TitleID).HasColumnName("TitleID");
	
			// Primary Key
			HasKey(t => t.CopyId);
	
			// Additional property mappings
			Property(t => t.AccessionNumber)
				.IsRequired();
	
			Property(t => t.Active)
				.IsRequired();
	
			Property(t => t.Consumable)
				.IsRequired();
	
			Property(t => t.CopyId)
				.IsRequired();
	
			Property(t => t.MasterCopy)
				.IsRequired();
	
			Property(t => t.ProofRead)
				.IsRequired();
	
			Property(t => t.TitleID)
				.IsRequired();
	
	
		}
	}
	
	public static partial class CopyHelper
	{
		public static void AssignNewPK
			(this Copy aCopy)
		{
			aCopy.CopyId = Guid.NewGuid().CombGuid();
		}
	
		/// <summary> 
		/// This code is fragile in that is ASSUMES that integer primary keys ARE
		/// AUTO-INCREMENTING columns whose value is governed by the database 
		/// server and that Guid primary keys are NOT "computed" values but rather 
		/// those whose column value is set by the client and/or server in a 
		/// fashion NOT governed by the database server.
		/// </summary>
		public static bool IsNew
			(this Copy aCopy)
		{
			if (aCopy == null)
			{
				throw 
					new ArgumentNullException
						(
							"aCopy"
							, "Entity instance cannot be null!"
						);
			}
			bool vResult = 
				(aCopy.CopyId == Guid.Empty);
			return vResult;
		}
	
		public static void AssignTo
			(Copy aFrom, Copy aTo)
		{
			aTo.AccessionNumber = aFrom.AccessionNumber;
			aTo.AcquisitionDate = aFrom.AcquisitionDate;
			aTo.Active = aFrom.Active;
			aTo.Comment = aFrom.Comment;
			aTo.Consumable = aFrom.Consumable;
			aTo.CopyId = aFrom.CopyId;
			aTo.CopyStatusID = aFrom.CopyStatusID;
			aTo.DiscardedDate = aFrom.DiscardedDate;
			aTo.EndLocation = aFrom.EndLocation;
			aTo.FormatTypeID = aFrom.FormatTypeID;
			aTo.MasterCopy = aFrom.MasterCopy;
			aTo.NumberOfTactiles = aFrom.NumberOfTactiles;
			aTo.Price = aFrom.Price;
			aTo.ProofRead = aFrom.ProofRead;
			aTo.StartLocation = aFrom.StartLocation;
			aTo.TitleID = aFrom.TitleID;
		}
	
		public static void AssignToNoPrimaryKeys
			(Copy aFrom, Copy aTo)
		{
			aTo.AccessionNumber = aFrom.AccessionNumber;
			aTo.AcquisitionDate = aFrom.AcquisitionDate;
			aTo.Active = aFrom.Active;
			aTo.Comment = aFrom.Comment;
			aTo.Consumable = aFrom.Consumable;
			aTo.CopyStatusID = aFrom.CopyStatusID;
			aTo.DiscardedDate = aFrom.DiscardedDate;
			aTo.EndLocation = aFrom.EndLocation;
			aTo.FormatTypeID = aFrom.FormatTypeID;
			aTo.MasterCopy = aFrom.MasterCopy;
			aTo.NumberOfTactiles = aFrom.NumberOfTactiles;
			aTo.Price = aFrom.Price;
			aTo.ProofRead = aFrom.ProofRead;
			aTo.StartLocation = aFrom.StartLocation;
			aTo.TitleID = aFrom.TitleID;
		}
	
		public static void AssignToJustPrimaryKeys
			(Copy aFrom, Copy aTo)
		{
			aTo.CopyId = aFrom.CopyId;
		}
	
		public static void AssignFrom
			(this Copy aTo, Copy aFrom)
		{
			aTo.AccessionNumber = aFrom.AccessionNumber;
			aTo.AcquisitionDate = aFrom.AcquisitionDate;
			aTo.Active = aFrom.Active;
			aTo.Comment = aFrom.Comment;
			aTo.Consumable = aFrom.Consumable;
			aTo.CopyId = aFrom.CopyId;
			aTo.CopyStatusID = aFrom.CopyStatusID;
			aTo.DiscardedDate = aFrom.DiscardedDate;
			aTo.EndLocation = aFrom.EndLocation;
			aTo.FormatTypeID = aFrom.FormatTypeID;
			aTo.MasterCopy = aFrom.MasterCopy;
			aTo.NumberOfTactiles = aFrom.NumberOfTactiles;
			aTo.Price = aFrom.Price;
			aTo.ProofRead = aFrom.ProofRead;
			aTo.StartLocation = aFrom.StartLocation;
			aTo.TitleID = aFrom.TitleID;
		}
	
		public static void AssignFromNoPrimaryKeys
			(this Copy aTo, Copy aFrom)
		{
			aTo.AccessionNumber = aFrom.AccessionNumber;
			aTo.AcquisitionDate = aFrom.AcquisitionDate;
			aTo.Active = aFrom.Active;
			aTo.Comment = aFrom.Comment;
			aTo.Consumable = aFrom.Consumable;
			aTo.CopyStatusID = aFrom.CopyStatusID;
			aTo.DiscardedDate = aFrom.DiscardedDate;
			aTo.EndLocation = aFrom.EndLocation;
			aTo.FormatTypeID = aFrom.FormatTypeID;
			aTo.MasterCopy = aFrom.MasterCopy;
			aTo.NumberOfTactiles = aFrom.NumberOfTactiles;
			aTo.Price = aFrom.Price;
			aTo.ProofRead = aFrom.ProofRead;
			aTo.StartLocation = aFrom.StartLocation;
			aTo.TitleID = aFrom.TitleID;
		}
	
		public static void AssignFromJustPrimaryKeys
			(this Copy aTo, Copy aFrom)
		{
			aTo.CopyId = aFrom.CopyId;
		}
	
	}
}
