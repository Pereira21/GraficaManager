using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class ClienteAppService : BaseAppService, IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteAppService(INotificator notificator, IClienteRepository clienteRepository) : base(notificator)
        {
            _clienteRepository = clienteRepository;
        }

        #region Queries
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var clientes = await _clienteRepository.GetAll();
            return clientes.ToArray();
        }

        public async Task<Cliente> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Commands
        public async Task Add(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);
        }
        #endregion
    }
}
