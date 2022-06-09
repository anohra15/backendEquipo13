using Microsoft.EntityFrameworkCore;

namespace backendRCVUcab.Persistence.Database
{
    public interface IRCVDbContext
    {
        DbContext DbContext
        {
            get;
        }
        
        //DbSet de las respectivas entidades
        /*
         DbSet<ProviderEntity> Providers
         { 
            get; set; 
         }
        */
    }
}