using Ninject;
using Ninject.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SampleWebApi
{
    public class CustomNinjectDependencyScope : IDependencyScope
    {
        IResolutionRoot resolver;

        public CustomNinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        public object GetService(Type servicetype)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "this scope has benn disposed");
            }
            return resolver.TryGet(servicetype);
        }

        public IEnumerable<object> GetServices(Type servicetype)
        {
            if (resolver == null)
            {
                throw new ObjectDisposedException("this", "this scope has benn disposed");
            }
            return resolver.GetAll(servicetype);
        }
    }
}