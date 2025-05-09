using Jx.Common;
using Jx.Common.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;
using 服务接口;

ServiceCollection services = new ServiceCollection();
//var assemblies = ReflectionHelper.GetAllReferencedAssemblies();

//获取嵌套引用的程序集
//var assemblies = AppDomain.CurrentDomain.GetReferanceAssemblies().Where(a => a.GetName().Name.StartsWith("服务")).ToList() ;

//获取当前目录下的所有dll文件
var assemblies = AppDomain.CurrentDomain.GetSolutionAssemblies().Where(a => a.GetName().Name.StartsWith("服务")).ToList();

services.RunModuleRegister(assemblies);

using var sp = services.BuildServiceProvider();
var items = sp.GetServices<IMyService>();
foreach (var item in items)
{
    item.SayHello();
}