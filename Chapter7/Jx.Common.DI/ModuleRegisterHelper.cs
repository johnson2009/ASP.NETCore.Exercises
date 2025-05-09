using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Common.DI
{
    public static class ModuleRegisterHelper
    {
        public static IServiceCollection RunModuleRegister(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            foreach(var implType in assemblies.SelectMany(a => a.GetTypes())
                                .Where(t => !t.IsAbstract && typeof(IModuleRegister).IsAssignableFrom(t)))
            {
                services.AddScoped(typeof(IModuleRegister), implType);
            }
            using (var sp = services.BuildServiceProvider())
            {
                var moduleRegisters = sp.GetService<IEnumerable<IModuleRegister>>();
                foreach (var initializer in moduleRegisters)
                {
                    initializer.Initialize(services);
                }
            }

            return services;
        }
    }
}
