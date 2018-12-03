using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace di_facilitator_lib
{
    public static class DependencyRegistryManager
    {
        public static IServiceCollection AddInject(this IServiceCollection services, bool referenced = false)
        {
            var assemblyCharger = new AssemblyCharger();

            var assembliesTypeInfos = referenced ? assemblyCharger.GetAssembliesTypeInfoWithReferenced() : assemblyCharger.GetAssembliesTypeInfo();

            foreach (var assemblyTypeInfo in assembliesTypeInfos)
            {
                Inject inject = (Inject)assemblyTypeInfo.GetCustomAttribute(typeof(Inject));
                var descriptor = new ServiceDescriptor(inject.implementationType, assemblyTypeInfo, inject.serviceLifeTime);
                //var descriptor = new ServiceDescriptor(inject.implementationType, p => Activator.CreateInstance(assemblyTypeInfo), inject.serviceLifeTime);
                services.Add(descriptor);
            }
            return services;
        }
    }
}
