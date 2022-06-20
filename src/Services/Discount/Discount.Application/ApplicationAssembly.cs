using System.Reflection;

namespace Discount.Application
{
    public static class ApplicationAssembly
    {
        public static Assembly GetAssembly()
        {
            return typeof(ApplicationAssembly).GetTypeInfo().Assembly;
        }
    }
}
