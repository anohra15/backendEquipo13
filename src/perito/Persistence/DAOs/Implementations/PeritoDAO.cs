using perito.Persistence.DAOs.Interfaces;
using perito.Persistence.Database;

namespace perito.Persistence.DAOs.Implementations
{
    public class PeritoDAO : IPeritoDAO
    {
        public readonly IRCVDbContext _context;

        public PeritoDAO(IRCVDbContext context)
        {
            _context = context;
        }

        /*public List<BrandDTO> GetProvidersByBrand(string brand)
        {
            try
            {
                var data = _context.Brands
                    .Include(b => b.Providers)
                    .Where(b => b.Name == brand)
                    .Select(b => new BrandDTO
                    {
                        Id = b.Id,
                        Name = b.Name,
                        Providers = b.Providers.Select(p => new ProviderDTO
                        {
                            Id = p.Id,
                            FullName = p.Name + " " + p.LastName,
                            Address = p.Address
                        }).ToList()
                    });

                return data.ToList();
            }
            catch(Exception ex) //es capturada por la capa de presentación del controlador
            {
                throw new RCVException("Ha ocurrido un error al intentar consultar la lista de proveedores para la marca: "
                                       + brand, ex.Message, ex);
            }
        }*/
        
    }
}