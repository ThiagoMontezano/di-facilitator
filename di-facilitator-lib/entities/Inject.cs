using System;
using Microsoft.Extensions.DependencyInjection;

namespace di_facilitator_lib
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class Inject : Attribute
    {
        public ServiceLifetime serviceLifeTime;

        public Type implementationType;

        public Inject(ServiceLifetime serviceLifeTime, Type implementationType)
        {
            this.serviceLifeTime = serviceLifeTime;
            this.implementationType = implementationType;
        }
    }
}

