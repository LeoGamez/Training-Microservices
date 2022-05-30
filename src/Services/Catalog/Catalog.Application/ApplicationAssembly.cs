using System.Reflection;

namespace Catalog.Application
{
    public static class ApplicationAssembly
    {
        public static Assembly GetAssembly()
        {
            return typeof(ApplicationAssembly).GetTypeInfo().Assembly;
        }
    }
}
