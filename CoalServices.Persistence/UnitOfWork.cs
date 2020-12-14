using CoalServices.Carousel.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CoalServicesContext _context;

        public UnitOfWork(CoalServicesContext context)
        {
            _context = context;
        }

        private IImageRepository _imageRepository;
        public IImageRepository ImageRepository => this._imageRepository ?? (new ImageRepository(_context));

        /// <summary>
        ///     Commit transaction
        /// </summary>
        /// <returns></returns>
        public Int32 Complete()
        {
            return _context.SaveChanges();
        }

        /// <summary>
        ///     Commit transaction
        /// </summary>
        /// <returns></returns>
        public async Task<Int32> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region IDisposable      
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        #endregion IDisposable
    }
}
