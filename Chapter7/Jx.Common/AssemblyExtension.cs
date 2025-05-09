using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Common
{
    public static class AssemblyExtension
    {
        public static List<Assembly> GetReferanceAssemblies(this AppDomain domain)
        {
            var list = new List<Assembly>();
            foreach (var assembly in domain.GetAssemblies())
            {
                GetReferanceAssemblies(assembly, list);
            }
            return list;
        }

        static void GetReferanceAssemblies(Assembly assembly, List<Assembly> list)
        {
            foreach (var referencedAssemblyName in assembly.GetReferencedAssemblies())
            {
                var ass = Assembly.Load(referencedAssemblyName);
                if (!list.Contains(ass))
                {
                    list.Add(ass);
                    GetReferanceAssemblies(ass, list);
                }
            }
        }

        public static List<Assembly> GetSolutionAssemblies(this AppDomain domain)
        {
            var assemblies = Directory.GetFiles(domain.BaseDirectory, "*.dll")
                                .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)));

            return assemblies.ToList();
        }
    }
}
