using Jx.Common.DI;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 服务接口;

namespace 服务实现1
{
    public class ModuleRegister: IModuleRegister
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<IMyService, CnService>();
        }
    }
}
