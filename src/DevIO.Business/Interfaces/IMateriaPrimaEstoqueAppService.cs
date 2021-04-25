using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IMateriaPrimaEstoqueAppService
    {
        Task<IEnumerable<MateriaPrimaEstoque>> GetAllAsync();
        Task<MateriaPrimaEstoque> GetByIdAsync(Guid id);

        Task Add(MateriaPrimaEstoque cliente);
        Task Update(MateriaPrimaEstoque cliente);
        Task Delete(Guid id);
    }
}
