using Microsoft.EntityFrameworkCore;

namespace backendRCVUcab.Persistence.Database
{
    public class RCVDbContext:DbContext, IRCVDbContext
    {
        public RCVDbContext() {}
        
        public RCVDbContext(DbContextOptions<RCVDbContext> options):base(options) {}

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        //public virtual Microsoft.EntityFrameworkCore.DbSet<TallererEntity> Talleres

        
        
    }
}