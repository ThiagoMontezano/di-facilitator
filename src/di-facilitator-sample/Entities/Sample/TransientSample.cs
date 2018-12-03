using System;
using di_facilitator_lib;
using Microsoft.Extensions.DependencyInjection;

namespace difacilitatorsample.Entities
{
    [Inject(ServiceLifetime.Transient, typeof(ISampleSimpleText))]
    public class TransientSample : ISampleSimpleText
    {
        public string print()
        {
            return "This is a transient object";
        }
    }
}
