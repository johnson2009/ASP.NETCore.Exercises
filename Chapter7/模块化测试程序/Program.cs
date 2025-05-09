using Jx.Common;
using Jx.Common.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using 服务接口;

ServiceCollection services = new ServiceCollection();
var assemblies = ReflectionHelper.GetAllReferencedAssemblies();

services.RunModuleRegister(assemblies);

using var sp = services.BuildServiceProvider();
var items = sp.GetServices<IMyService>();
foreach (var item in items)
{
    item.SayHello();
}