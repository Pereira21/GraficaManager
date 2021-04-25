using DevIO.Business.Interfaces;
using DevIO.Business.Models;

namespace DevIO.Data.Data.Repositories
{
    public class MateriaPrimaEstoqueRepository : Repository<MateriaPrimaEstoque>, IMateriaPrimaEstoqueRepository
    {
        public MateriaPrimaEstoqueRepository(GraficaDbContext context) : base(context) { }
    }
}
