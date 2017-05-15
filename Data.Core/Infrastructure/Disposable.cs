using System;

namespace Data.Core.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        ~Disposable()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
                DisposeCore();

            isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}