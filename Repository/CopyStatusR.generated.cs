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

namespace FbcBookIt.Repository
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	//using AWEFramework.AWECmn;
	//using Entity;
	using FbcBookIt.DataAccess;
	using FbcBookIt.Entity;
	
	// Table Name: CopyStatus
	public partial interface ICopyStatusR
		: IBASE_RepositoryDbTable
	{
		bool Any();
	
		bool Exists(System.Int32 aCopyStatusId);
	
		// The only difference between "Find" and "Get" is that "Get" will return
		// a null if the record sought is not found whereas "Find" will throw
		// an exception.
		CopyStatus Find(System.Int32 aCopyStatusId);
	
		// The only difference between "Find" and "Get" is that "Get" will return
		// a null if the record sought is not found whereas "Find" will throw
		// an exception.
		CopyStatus Get(System.Int32 aCopyStatusId);
	
		List<CopyStatus> GetAll();
	
		// There are several methods that add a record to a table:
		//	1. Add
		//  2. Insert
		//  3. InsertAndReturnPrimaryKey
		// - Add will add the record if possible and return the entity updated with
		// the primary key information
		// - Insert will add the record if possible and return void.
		// - InsertAndReturnPrimaryKey will add the record if possible and then 
		// return the new primary key (a single value for single primary key
		// tables, an instance of a custom class containing all portions of the 
		// primary key for a table with a compound primary key).
		CopyStatus Add(CopyStatus aCopyStatus);
	
		// There are several methods that add a record to a table:
		//	1. Add
		//  2. Insert
		//  3. InsertAndReturnPrimaryKey
		// - Add will add the record if possible and return the entity updated with
		// the primary key information
		// - Insert will add the record if possible and return void.
		// - InsertAndReturnPrimaryKey will add the record if possible and then 
		// return the new primary key (a single value for single primary key
		// tables, an instance of a custom class containing all portions of the 
		// primary key for a table with a compound primary key).
		void Insert(CopyStatus aCopyStatus);
	
		// There are several methods that add a record to a table:
		//	1. Add
		//  2. Insert
		//  3. InsertAndReturnPrimaryKey
		// - Add will add the record if possible and return the entity updated with
		// the primary key information
		// - Insert will add the record if possible and return void.
		// - InsertAndReturnPrimaryKey will add the record if possible and then 
		// return the new primary key (a single value for single primary key
		// tables, an instance of a custom class containing all portions of the 
		// primary key for a table with a compound primary key).
		System.Int32 InsertAndReturnPrimaryKey(CopyStatus aCopyStatus);
	
		void Update(CopyStatus aCopyStatus);
	
		void Delete(System.Int32 aCopyStatusId);
	
		bool IsActive(System.Int32 aCopyStatusId);
	
		void Remove(System.Int32 aCopyStatusId);
	
		void Restore(System.Int32 aCopyStatusId);
	
		void DeleteAllRemoved();
	
	}
	
	public partial class CopyStatusR
		: BASE_RepositoryDbTable, ICopyStatusR
	{
		public CopyStatusR
			(IBookInventoryContext aDb): base(aDb)
		{
		}
	
		public bool Any()
		{
			bool vResult;
			vResult = _Db.CopyStatusDb.Any();
			return vResult;
		}
	
		public bool Exists(System.Int32 aCopyStatusId)
		{
			bool vResult;
				vResult = _Db.CopyStatusDb.Any(aRec => (aRec.CopyStatusId == aCopyStatusId));
			return vResult;
		}
	
		public CopyStatus Find(System.Int32 aCopyStatusId)
		{
			CopyStatus vResult;
			vResult = _Db.CopyStatusDb.Single(aRec => (aRec.CopyStatusId == aCopyStatusId));
			return vResult;
		}
	
		public CopyStatus Get(System.Int32 aCopyStatusId)
		{
			CopyStatus vResult;
			vResult = _Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatusId);
			return vResult;
		}
	
		public List<CopyStatus> GetAll()
		{
			List<CopyStatus> vResult;
			vResult = _Db.CopyStatusDb.ToList();
			return vResult;
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public CopyStatus Add(CopyStatus aCopyStatus)
		{
			if (aCopyStatus == null)
			{
				throw new ArgumentNullException("aCopyStatus", " cannot be null!");
			}
	/*
			if (!aCopyStatus.IsRootEntity())
			{
				aCopyStatus.ClearToRootEntity();
			}
	*/
			if (!aCopyStatus.IsNew())
			{
				const string MESSAGE = 
					"CopyStatus Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
				aCopyStatus.AssignNewPK();
			aCopyStatus = _Db.CopyStatusDb.Add(aCopyStatus);
			_Db.SaveChanges();
			return aCopyStatus;
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public void Insert(CopyStatus aCopyStatus)
		{
			if (aCopyStatus == null)
			{
				throw new ArgumentNullException("aCopyStatus", " cannot be null!");
			}
	/*
			if (!aCopyStatus.IsRootEntity())
			{
				aCopyStatus.ClearToRootEntity();
			}
	*/
			if (!aCopyStatus.IsNew())
			{
				const string MESSAGE = 
					"CopyStatus Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
			aCopyStatus.AssignNewPK();
			_Db.CopyStatusDb.Add(aCopyStatus);
			_Db.SaveChanges();
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public System.Int32 InsertAndReturnPrimaryKey(CopyStatus aCopyStatus)
		{
			if (aCopyStatus == null)
			{
				throw new ArgumentNullException("aCopyStatus", " cannot be null!");
			}
	/*
			if (!aCopyStatus.IsRootEntity())
			{
				aCopyStatus.ClearToRootEntity();
			}
	*/
			if (!aCopyStatus.IsNew())
			{
				const string MESSAGE = 
					"CopyStatus Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
			aCopyStatus.AssignNewPK();
			aCopyStatus = _Db.CopyStatusDb.Add(aCopyStatus);
			_Db.SaveChanges();
			System.Int32 vResult = aCopyStatus.CopyStatusId;
			return vResult;
		}
	
		public void Update(CopyStatus aCopyStatus)
		{
			CopyStatus vRec = 
				_Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatus.CopyStatusId);
			vRec.AssignFromNoPrimaryKeys(aCopyStatus);
			_Db.SaveChanges();
		}
	
		public void Delete(System.Int32 aCopyStatusId)
		{
			CopyStatus vRec = 
				_Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatusId);
			if (vRec == null)
			{
				return; // Record is already gone, no worries!
			}
			_Db.CopyStatusDb.Remove(vRec);
			_Db.SaveChanges();
		}
	
		public bool IsActive(System.Int32 aCopyStatusId)
		{
			CopyStatus vRec = 
				_Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatusId);
			bool vResult = (vRec != null) && vRec.Active;
			return vResult;
		}
	
		public void Remove(System.Int32 aCopyStatusId)
		{
			CopyStatus vRec = 
				_Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatusId);
			if (vRec == null)
			{
				return;
			}
			vRec.Active = false;
			_Db.SaveChanges();
		}
	
		public void Restore(System.Int32 aCopyStatusId)
		{
			CopyStatus vRec = 
				_Db.CopyStatusDb.FirstOrDefault(aRec => aRec.CopyStatusId == aCopyStatusId);
			if (vRec == null)
			{
				return;
			}
			vRec.Active = true;
			_Db.SaveChanges();
		}
	
		/// <remark>
		/// Note that this method in EF is Really Ugly in that EF requires that 
		/// each record to be deleted must first be brought into the context, then 
		/// "removed", then SaveChanges called to actually delete the record(s).
		/// For a large number of records this gets memory intensive.
		/// </remark>
		public void DeleteAllRemoved()
		{
			List<CopyStatus> vToDelete =
				_Db.CopyStatusDb
					.Where(aRec => !aRec.Active).ToList();
			if (vToDelete.Count < 1)
			{
				return;
			}
			foreach (CopyStatus vRec in vToDelete)
			{
				_Db.CopyStatusDb.Remove(vRec);
			}
			_Db.SaveChanges();
		}
	
	}
}
