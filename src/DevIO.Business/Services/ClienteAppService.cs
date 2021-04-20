using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteAppService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAll();
            return clientes.ToArray();
        }

        public Task<Cliente> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
