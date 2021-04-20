using DevIO.Business.Interfaces;
using DevIO.Business.Models;

namespace DevIO.Data.Data.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(GraficaDbContext context) : base(context) { }


    }
}
