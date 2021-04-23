using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Models.SqlServer
{
    public class ReadOnlyCatalogContext : IDisposable
    {
        private readonly DbContext _dbContext;

        public ReadOnlyCatalogContext() => _dbContext = new CatalogContext();

        public IQueryable<Entities.Catalog> Catalogs =>
            _dbContext.Set<Entities.Catalog>();

        public IQueryable<Good> Goods =>
            _dbContext.Set<Good>();

        //{
        //    var context = _dbContext as CatalogContext;
        //    Catalogs = context?.Catalogs
        //        .Include(c => c.Parent)
        //        .Include(c => c.Goods).ToList();
        //    Goods = context?.Goods
        //        .Include(g => g.Catalog).ToList();
        //}

        //public IQueryable<TEntity> Set<TEntity>() where TEntity : class
        //    => _dbContext.Set<TEntity>().AsNoTracking();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual async void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing) await _dbContext.DisposeAsync();
            _isDisposed = true;
        }

        private bool _isDisposed;

        ~ReadOnlyCatalogContext() => Dispose(false);
    }
}
