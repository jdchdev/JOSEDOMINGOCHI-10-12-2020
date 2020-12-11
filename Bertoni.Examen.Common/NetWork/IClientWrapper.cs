using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bertoni_Examen.Infrastructure.NetWork
{
    public interface IClientWrapper
    {
        Task<T> GetAsync<T>(string url);
    }
}
