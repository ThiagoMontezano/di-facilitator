using di_facilitator_lib;

namespace difacilitatorsample.Entities
{
    [Inject(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton, typeof(ISampleSimpleText))]
    public class SingletonSample : ISampleSimpleText
    {
        public string print()
        {
            return "This is a singleton object";
        }
    }
}
