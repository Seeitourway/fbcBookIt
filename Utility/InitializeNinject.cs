namespace FbcBookIt.Utility
{
	using System;
	using FbcBookIt.Utility.AWEFramework.AWEIoC;
	using Ninject;
	using Ninject.Extensions.Conventions;

	public delegate void PerformAdditionalBindings(IKernel aKernel);

	public static class InitializeNinject
	{
		public static IKernel NewKernel()
		{
			IKernel vResult = new StandardKernel();
			return vResult;
		}

		public static void RegisterServices
			(IKernel aKernel, PerformAdditionalBindings aPerformAdditionalBindings)
		{
			string vPath = AssemblyHelpers.GetAssemblyLocation();
			// VooDoo Magic comes from Remo Stack Overflow item
			aKernel.Bind
				(
					aScanResult =>
						aScanResult
							.FromAssembliesInPath(vPath)
							.SelectAllClasses()
							.BindDefaultInterface()
				//.Configure(b => b.InSingletonScope())
				);

			// Add other bindings as necessary
			if (aPerformAdditionalBindings != null)
			{
				aPerformAdditionalBindings(aKernel);
			}
			// Ninject has trouble finding generics thus...
			// aKernel.Bind<IT>().To<T>()
		}

		public static void RegisterServices
			(
				IKernel aKernel
				, Type aType
				, bool aBindAllClasses
				, PerformAdditionalBindings aPerformAdditionalBindings
			)
		{
			string vPath = AssemblyHelpers.GetAssemblyLocation();
			string vApplicationNamespace = aType.Namespace;
			//AssemblyHelpers.NamespaceOfType(aType);
			string vThisNamespace = typeof(InitializeNinject).Namespace;
			//AssemblyHelpers.NamespaceOfType(typeof(InitializeNinject));
			// VooDoo Magic comes from Remo Stack Overflow item
			if (aBindAllClasses)
			{
				aKernel.Bind
					(
						aScanResult =>
							aScanResult
								.FromAssembliesInPath(vPath)
								.SelectAllClasses()
								.BindDefaultInterface()
					);
			}
			else
			{
				aKernel.Bind
					(
						aScanResult =>
							aScanResult
								.FromAssembliesInPath(vPath)
								.Select
								(
									aClass =>
										aClass.IsClass
											&& !aClass.IsAbstract
											&&
											(
												aClass.FullName.StartsWith(vApplicationNamespace)
													|| aClass.FullName.StartsWith(vThisNamespace)
												)
								)
								.BindDefaultInterface()
					);
			}

			// Add other bindings as necessary
			if (aPerformAdditionalBindings != null)
			{
				aPerformAdditionalBindings(aKernel);
			}

			// Ninject has trouble finding generics thus...
			// aKernel.Bind<IT>().To<T>()
		}

		public static void StartUp
			(PerformAdditionalBindings aPerformAdditionalBindings = null)
		{
			IKernel vKernel = NewKernel();
			StartUpWithExternalKernel(vKernel, aPerformAdditionalBindings);
		}

		public static void StartUp
			(
				Type aType
				, bool aBindAllClasses = false
				, PerformAdditionalBindings aPerformAdditionalBindings = null
			)
		{
			IKernel vKernel = NewKernel();
			StartUpWithExternalKernel
				(vKernel, aType, aBindAllClasses, aPerformAdditionalBindings);
		}

		public static IKernel StartupAndReturnKernel
			(
				Type aType
				, bool aBindAllClasses
				, PerformAdditionalBindings aPerformAdditionalBindings = null
			)
		{
			IKernel vResult = NewKernel();
			StartUpWithExternalKernel
				(vResult, aType, aBindAllClasses, aPerformAdditionalBindings);
			return vResult;
		}

		public static void StartUpWithExternalKernel
			(
				IKernel aKernel
				, PerformAdditionalBindings aPerformAdditionalBindings = null
			)
		{
			RegisterServices(aKernel, aPerformAdditionalBindings);
			// Connect the generic IoC container "InstanceFactory" InstanceGenerator 
			// generator to the ninject kernel method that generates instances from 
			// types
			InstanceFactory.InstanceGenerator = aKernel.GetService;
		}

		public static void StartUpWithExternalKernel
			(
				IKernel aKernel
				, Type aType
				, bool aBindAllClasses
				, PerformAdditionalBindings aPerformAdditionalBindings = null
			)
		{
			RegisterServices
				(aKernel, aType, aBindAllClasses, aPerformAdditionalBindings);
			// Connect the generic IoC container "InstanceFactory" InstanceGenerator 
			// generator to the ninject kernel method that generates instances from 
			// types
			InstanceFactory.InstanceGenerator = aKernel.GetService;
		}

	}
}