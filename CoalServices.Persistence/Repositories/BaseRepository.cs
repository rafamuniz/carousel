namespace CoalServices.Carousel.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity>
    {
        protected readonly CoalServicesContext _context;

        public BaseRepository(CoalServicesContext context)
        {
            _context = context;
        }
    }
}
