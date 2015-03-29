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
	
	// Table Name: FormatType
	public partial interface IFormatTypeR
		: IBASE_RepositoryDbTable
	{
		bool Any();
	
		bool Exists(System.Int32 aFormatTypeId);
	
		// The only difference between "Find" and "Get" is that "Get" will return
		// a null if the record sought is not found whereas "Find" will throw
		// an exception.
		FormatType Find(System.Int32 aFormatTypeId);
	
		// The only difference between "Find" and "Get" is that "Get" will return
		// a null if the record sought is not found whereas "Find" will throw
		// an exception.
		FormatType Get(System.Int32 aFormatTypeId);
	
		List<FormatType> GetAll();
	
		// GetByActive will return the first occurrence of a record that
		// matches the criteria. If no record matches, the method will return null.
		FormatType GetByActive(System.Boolean aActive);
	
			List<FormatType> GetByActiveAsList(System.Boolean aActive);
	
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
		FormatType Add(FormatType aFormatType);
	
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
		void Insert(FormatType aFormatType);
	
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
		System.Int32 InsertAndReturnPrimaryKey(FormatType aFormatType);
	
		void Update(FormatType aFormatType);
	
		void Delete(System.Int32 aFormatTypeId);
	
			void DeleteByActive(System.Boolean aActive);
	
		bool IsActive(System.Int32 aFormatTypeId);
	
		void Remove(System.Int32 aFormatTypeId);
	
		void Restore(System.Int32 aFormatTypeId);
	
		void DeleteAllRemoved();
	
	}
	
	public partial class FormatTypeR
		: BASE_RepositoryDbTable, IFormatTypeR
	{
		public FormatTypeR
			(IBookInventoryContext aDb): base(aDb)
		{
		}
	
		public bool Any()
		{
			bool vResult;
			vResult = _Db.FormatTypeDb.Any();
			return vResult;
		}
	
		public bool Exists(System.Int32 aFormatTypeId)
		{
			bool vResult;
				vResult = _Db.FormatTypeDb.Any(aRec => (aRec.FormatTypeId == aFormatTypeId));
			return vResult;
		}
	
		public FormatType Find(System.Int32 aFormatTypeId)
		{
			FormatType vResult;
			vResult = _Db.FormatTypeDb.Single(aRec => (aRec.FormatTypeId == aFormatTypeId));
			return vResult;
		}
	
		public FormatType Get(System.Int32 aFormatTypeId)
		{
			FormatType vResult;
			vResult = _Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatTypeId);
			return vResult;
		}
	
		public List<FormatType> GetAll()
		{
			List<FormatType> vResult;
			vResult = _Db.FormatTypeDb.ToList();
			return vResult;
		}
	
		public FormatType GetByActive(System.Boolean aActive)
		{
			FormatType vResult;
			vResult = 
				_Db.FormatTypeDb
					.Where(aRec => aRec.Active == aActive)
					.FirstOrDefault();
			return vResult;
		}
	
		public List<FormatType> GetByActiveAsList(System.Boolean aActive)
		{
			List<FormatType> vResult;
			vResult = 
				_Db.FormatTypeDb
					.Where(aRec => aRec.Active == aActive)
					.ToList();
			return vResult;
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public FormatType Add(FormatType aFormatType)
		{
			if (aFormatType == null)
			{
				throw new ArgumentNullException("aFormatType", " cannot be null!");
			}
	/*
			if (!aFormatType.IsRootEntity())
			{
				aFormatType.ClearToRootEntity();
			}
	*/
			if (!aFormatType.IsNew())
			{
				const string MESSAGE = 
					"FormatType Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
				aFormatType.AssignNewPK();
			aFormatType = _Db.FormatTypeDb.Add(aFormatType);
			_Db.SaveChanges();
			return aFormatType;
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public void Insert(FormatType aFormatType)
		{
			if (aFormatType == null)
			{
				throw new ArgumentNullException("aFormatType", " cannot be null!");
			}
	/*
			if (!aFormatType.IsRootEntity())
			{
				aFormatType.ClearToRootEntity();
			}
	*/
			if (!aFormatType.IsNew())
			{
				const string MESSAGE = 
					"FormatType Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
			aFormatType.AssignNewPK();
			_Db.FormatTypeDb.Add(aFormatType);
			_Db.SaveChanges();
		}
	
		/// <remark>
		/// Fragile:	This method presumes that any integer keys are
		///						auto-incrementing.
		/// </remark>
		public System.Int32 InsertAndReturnPrimaryKey(FormatType aFormatType)
		{
			if (aFormatType == null)
			{
				throw new ArgumentNullException("aFormatType", " cannot be null!");
			}
	/*
			if (!aFormatType.IsRootEntity())
			{
				aFormatType.ClearToRootEntity();
			}
	*/
			if (!aFormatType.IsNew())
			{
				const string MESSAGE = 
					"FormatType Insert failed. Record has failed \"IsNew\" test.";
				throw new Exception(MESSAGE);
			}
			aFormatType.AssignNewPK();
			aFormatType = _Db.FormatTypeDb.Add(aFormatType);
			_Db.SaveChanges();
			System.Int32 vResult = aFormatType.FormatTypeId;
			return vResult;
		}
	
		public void Update(FormatType aFormatType)
		{
			FormatType vRec = 
				_Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatType.FormatTypeId);
			vRec.AssignFromNoPrimaryKeys(aFormatType);
			_Db.SaveChanges();
		}
	
		public void Delete(System.Int32 aFormatTypeId)
		{
			FormatType vRec = 
				_Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatTypeId);
			if (vRec == null)
			{
				return; // Record is already gone, no worries!
			}
			_Db.FormatTypeDb.Remove(vRec);
			_Db.SaveChanges();
		}
	
		public void DeleteByActive(System.Boolean aActive)
		{
				List<FormatType> vListToDelete = 
					_Db.FormatTypeDb
						.Where(aRec => aRec.Active == aActive)
						.ToList();
				if (vListToDelete.Count < 1)
				{
					return;
				}
				foreach (FormatType vRec in vListToDelete)
				{
					_Db.FormatTypeDb.Remove(vRec);
				}
				_Db.SaveChanges();
		}
	
		public bool IsActive(System.Int32 aFormatTypeId)
		{
			FormatType vRec = 
				_Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatTypeId);
			bool vResult = (vRec != null) && vRec.Active;
			return vResult;
		}
	
		public void Remove(System.Int32 aFormatTypeId)
		{
			FormatType vRec = 
				_Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatTypeId);
			if (vRec == null)
			{
				return;
			}
			vRec.Active = false;
			_Db.SaveChanges();
		}
	
		public void Restore(System.Int32 aFormatTypeId)
		{
			FormatType vRec = 
				_Db.FormatTypeDb.FirstOrDefault(aRec => aRec.FormatTypeId == aFormatTypeId);
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
			List<FormatType> vToDelete =
				_Db.FormatTypeDb
					.Where(aRec => !aRec.Active).ToList();
			if (vToDelete.Count < 1)
			{
				return;
			}
			foreach (FormatType vRec in vToDelete)
			{
				_Db.FormatTypeDb.Remove(vRec);
			}
			_Db.SaveChanges();
		}
	
	}
}
