using backendRCVUcab.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace backendRCVUcab.Persistence.Database
{
    public interface IRCVDbContext
    {
        DbContext DbContext
        {
            get;
        }
        
        DbSet<TallererEntity> Talleres
        {
            get; set;
        }
         
        DbSet<MarcaCarroEntity> Marcas
        {
            get; set;
        }

        DbSet<TelefonoEntity> Telefonos
        {
            get; set;
        }
         
        DbSet<CotizacionTallerEntity> Cotizaciones
        {
            get; set;
        }
         
        DbSet<OrdenCompraEntity> OrdenesCompras
        {
            get; set;
        }
        
        DbSet<AnalisisEntity> Analisis
        {
            get; set;
        }
        
        DbSet<PiezasEntity> Piezas
        {
            get; set;
        }
    }
}