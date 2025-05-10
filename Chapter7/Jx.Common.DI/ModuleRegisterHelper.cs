using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Jx.Common.DI
{
    public static class ModuleRegisterHelper
    {
        //public static IServiceCollection RegisterDbContexts(this IServiceCollection services, Action<DbContextOptionsBuilder> builder, IEnumerable<Assembly> assemblies)
        //{
        //    Type[] types = new Type[] {
        //        typeof(IServiceCollection), 
        //        typeof(DbContextOptionsBuilder),
        //        typeof(Action<DbContextOptionsBuilder>),
        //        typeof(ServiceLifetime),
        //        typeof(ServiceLifetime)
        //    };
        //    var methodAddDbContext = typeof(EntityFrameworkServiceCollectionExtensions).GetMethods()
        //        .Where(m => m.Name == "AddDbContext" && m.IsGenericMethod)
        //        .FirstOrDefault(m => m.GetParameters().Select(p => p.ParameterType).SequenceEqual(types));

        //    foreach (var asmToLoad in assemblies)
        //    {
        //        foreach(var dbCtxType in asmToLoad.GetTypes().Where(t => !t.IsAbstract && typeof(DbContext).IsAssignableFrom(t)))
        //        {
        //            //假设有些项目把DBContext 的访问修饰符设为internal
        //            var methodGenericAddDbContext = methodAddDbContext.MakeGenericMethod(dbCtxType);
        //            methodGenericAddDbContext.Invoke(null, new object[] { services, builder, ServiceLifetime.Scoped, ServiceLifetime.Scoped });
        //        }
        //    }

        //    return services;
        //}

        public static IServiceCollection AddAllDbContexts(this IServiceCollection services, Action<DbContextOptionsBuilder> builder, IEnumerable<Assembly> assemblies)
        {
            Type[] types = new Type[] { typeof(IServiceCollection),
                typeof(Action<DbContextOptionsBuilder>),
                typeof(ServiceLifetime),
                typeof(ServiceLifetime)
            };
            var methodAddDbContext = typeof(EntityFrameworkServiceCollectionExtensions)
                .GetMethod("AddDbContext", 1, types);

            foreach (var asmToLoad in assemblies)
            {
                foreach (var dbCtxType in asmToLoad.GetTypes().Where(t => !t.IsAbstract && typeof(DbContext).IsAssignableFrom(t)))
                {
                    var methodGenericAddDbContext = methodAddDbContext.MakeGenericMethod(dbCtxType);
                    methodGenericAddDbContext.Invoke(null, new object[] { services, builder, ServiceLifetime.Scoped, ServiceLifetime.Singleton });
                }
            }

            return services;
        }

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
