using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Model;

namespace UICHSweb.Services
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IEmergrncySituationVMListRepository>().To<EmergrncySituationVMListRepository>();
        }
    }
}