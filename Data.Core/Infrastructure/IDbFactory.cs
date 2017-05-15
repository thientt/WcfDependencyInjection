using System;

namespace Data.Core.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DIContext Init();
    }
}