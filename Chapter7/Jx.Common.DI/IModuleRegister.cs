using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jx.Common.DI
{
    public interface IModuleRegister
    {
        public void Initialize(IServiceCollection services);
    }
}
