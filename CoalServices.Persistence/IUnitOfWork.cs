using CoalServices.Carousel.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace CoalServices.Carousel.Persistence
{
    public interface IUnitOfWork
    {
        IImageRepository ImageRepository { get; }

        Int32 Complete();
        Task<Int32> CompleteAsync();
    }
}
