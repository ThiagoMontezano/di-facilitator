using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace di_facilitator_lib
{
    public class AssemblyCharger : IAssemblyCharger
    {
        public IList<TypeInfo> GetAssembliesTypeInfo()
        {
            var assemblies = new List<Assembly>();

            assemblies.AddRange(Assembly
                                .GetEntryAssembly()
                                .GetReferencedAssemblies()
                                .Select(Assembly.Load));

            assemblies.AddRange(AppDomain
                                .CurrentDomain
                                .GetAssemblies()
                                .ToList());

            return GetInjectTypeInfos(assemblies).ToList();
        }

        public IList<TypeInfo> GetAssembliesTypeInfoWithReferenced()
        {
            var typeInfos = GetAssembliesTypeInfo().ToList();

            var assembliesReferenced = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory)
                                                .Where(file => Path.GetExtension(file) == ".dll")
                                                .Select(Assembly.LoadFrom)
                                                .ToList();

            typeInfos.AddRange(GetInjectTypeInfos(assembliesReferenced));
            return typeInfos;

        }

        private IEnumerable<TypeInfo> GetInjectTypeInfos(IList<Assembly> assemblies)
        {
            return assemblies
                .Select(assembly =>
                    {
                        var typeInfos = assembly
                                            .DefinedTypes
                                            .Where(ti => ti.GetCustomAttributes(typeof(Inject).GetTypeInfo()).Any());
                        return typeInfos;
                    })
                .FirstOrDefault();
        }
    }
}
