using System.Collections.Generic;
using System.Reflection;

namespace di_facilitator_lib
{
    public interface IAssemblyCharger
    {
        IList<TypeInfo> GetAssembliesTypeInfo();

        IList<TypeInfo> GetAssembliesTypeInfoWithReferenced();
    }
}
