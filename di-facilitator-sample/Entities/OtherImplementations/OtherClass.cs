using System;
using di_facilitator_lib;

namespace difacilitatorsample.Entities.OtherImplementations
{
    [Inject(Microsoft.Extensions.DependencyInjection.ServiceLifetime.Singleton, typeof(OtherClass))]
    public class OtherClass
    {
        public String otherPrint(){
            return "This is a other object";
        }
    }
}
