namespace FbcBookIt.Utility
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;

	namespace AWEFramework.AWEIoC
	{
		public static class AssemblyHelpers
		{
			private static IEnumerable<string> GetAssemblyNames
				(string aPath, string aPrefix)
			{
				IEnumerable<string> vResult =
					// ReSharper disable once InvokeAsExtensionMethod
					Enumerable.Concat
						(
							Directory.EnumerateFiles(aPath, aPrefix + "*.dll")
							, Directory.EnumerateFiles(aPath, aPrefix + "*.exe")
								.Where(a => !a.Contains("vshost.exe")).ToList()
						);
				return vResult;
			}

			public static List<Assembly> GetAssembliesInPath
				(string aPath, string aNamespace)
			{
				List<Assembly> vResult =
					(
						GetAssemblyNames(aPath, aNamespace).Select
							(
								aName =>
									new
									{
										vName = aName
										,
										vAssembly =
											Assembly.Load
												(Path.GetFileNameWithoutExtension(aName)
													?? String.Empty)
									}
							).Select(aT => aT.vAssembly)
						).ToList();
				return vResult;
			}

			public static string GetAssemblyLocation()
			{
				string vResult =
					new Uri
					// ReSharper disable once AssignNullToNotNullAttribute
						(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase))
							.LocalPath
							.Normalize();
				return vResult;
			}

			//public static string NamespaceOfType(Type aType)
			//{
			//	string vResult =
			//		aType
			//			.FullName
			//			.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[0];
			//	return vResult;
			//}

			//public static string Namespace(this Type aType)
			//{
			//	return NamespaceOfType(aType);
			//}

		}
	}
}
