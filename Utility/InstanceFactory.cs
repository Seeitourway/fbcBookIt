namespace FbcBookIt.Utility
{
	using System;

	namespace AWEFramework.AWEIoC
	{
		/// <summary>
		/// This is a Service Locator pattern gadget.  The preferred mechanism is 
		/// Dependency Injection.  Sometimes that isn't possible.
		/// ASP.NET Web Pages can use parameter injection: aspx, asmx, ascx, etc.
		/// Only 3 uses should consume this
		/// ALL OTHERS SHOULD RECEIVE THEIR DEPENDENCIES VIA CONSTRUCTOR INJECTION
		/// Here are the 3 valid uses:
		/// 1. Used sparingly to kick off the process, e.g. static void Main() and 
		/// Application_Start()
		/// 2. Attributes
		/// 3. Extension method classes
		/// 4. WebForms (which I don't use).
		/// If at all possible, one should create 2 constructors:
		/// - The first constructor takes constructor injection parameters as always
		/// - The second constructor calls the first constructor, e.g. 
		/// : this( ServiceLocator.Get<T>(), ServiceLocator.Get<T>() )
		/// If a second constructor isn't possible (static classes) one should 
		/// initialize each dependency in the static constructor, 
		/// setting private static readonly properties
		/// Any use of ServiceLocator anywhere else is an error and should be 
		/// removed.
		/// </summary>
		public static class InstanceFactory
		// public static class ServiceLocator
		{
			public static Func<Type, object> InstanceGenerator { get; set; }

			/// <summary> 
			/// Returns an instance of the passed in type
			/// </summary>
			public static object GetInstance(Type aType)
			{
				if (InstanceGenerator == null)
				{
					throw new NullReferenceException
						("InstanceFactory (ServiceLocator) has not been initialized");
				}
				return InstanceGenerator(aType);
			}

			/// <summary>
			/// Returns an instance of the passed in type. 
			/// This is the preferred method of generating instance of class
			/// </summary>
			public static T GetInstance<T>()
			{
				return (T)GetInstance(typeof(T));
			}

			///// <summary> 
			///// The below are provided for reference only. The standard, industry
			///// pattern nomenclature is "GetService", the author of this library
			///// prefers "GetInstance" as this more properly documents what is 
			///// actually happening. Just as this is a "ServiceLocator", the author
			///// prefers "InstanceFactory". Same reason.
			///// </summary>
			//public static T GetService<T>()
			//{
			//	return (T)GetService(typeof(T));
			//}

			//public static object GetService(Type aType)
			//{
			//	if (InstanceGenerator == null)
			//	{
			//		throw new NullReferenceException
			//			("InstanceGenerator (ServiceLocator) has not been initialized");
			//	}
			//	return InstanceGenerator(aType);
			//}

		}

	}
}
