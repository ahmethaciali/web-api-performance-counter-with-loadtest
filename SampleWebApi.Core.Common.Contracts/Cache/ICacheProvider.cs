using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Core.Common.Contracts.Cache
{
    public interface ICacheProvider
    {
        void Set(string key, object value, int expireAsMinute);
        T Get<T>(string key);
        void Remove(string key);
        bool IsExist(string key);
    }
}
