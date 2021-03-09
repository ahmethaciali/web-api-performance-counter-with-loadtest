using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SampleWebApi
{
    public class CustomNinjectDependencyResolver : CustomNinjectDependencyScope, IDependencyResolver
    {
        private readonly IKernel kernel;

        public CustomNinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new CustomNinjectDependencyScope(kernel.BeginBlock());
        }
    }
}