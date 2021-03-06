using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IClienteAppService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(Guid id);

        Task Add(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(Guid id);
    }
}
