using System.Reflection;

namespace Basket.Application
{
    public static class ApplicationAssembly
    {
        public static Assembly GetAssembly()
        {
            return typeof(ApplicationAssembly).GetTypeInfo().Assembly;
        }
    }
}
