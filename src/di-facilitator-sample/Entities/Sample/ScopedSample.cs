using di_facilitator_lib;
using Microsoft.Extensions.DependencyInjection;

namespace difacilitatorsample.Entities
{
    [Inject(ServiceLifetime.Scoped, typeof(ISampleSimpleText))]
    public class ScopedSample : ISampleSimpleText
    {

        public string print()
        {
            return "This is a scoped object";
        }
    }
}
