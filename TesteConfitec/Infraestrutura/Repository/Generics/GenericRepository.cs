using Domain.Interfaces.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class GenericRepository<T> : IGenerics<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<CadastroContext> _optionsBuilder;

        public GenericRepository()
        {
            _optionsBuilder = new DbContextOptions<CadastroContext>();
        }

        public async Task Add(T Object)
        {
            using (var data = new CadastroContext(_optionsBuilder))
            {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Object)
        {
            using (var data = new CadastroContext(_optionsBuilder))
            {
                
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }
        
        public async Task<T> FindById(int id)
        {
            using (var data = new CadastroContext(_optionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new CadastroContext(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task Update(T Object)
        {
            using (var data = new CadastroContext(_optionsBuilder))
            {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://docs.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public GenericRepository(DbContextOptions<CadastroContext> optionsBuilder)
        {
            _optionsBuilder = optionsBuilder;
        }


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
        #endregion
    }
}
