using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
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
            var cliente = await _clienteRepository.GetById(id);
            return cliente;
        }

        #endregion

        #region Commands
        public async Task Add(Cliente cliente)
        {
            if (!ExecuteValidation(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Add(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            if (!ExecuteValidation(new ClienteValidation(), cliente)) return;

            await _clienteRepository.Update(cliente);
        }

        public async Task Delete(Guid id)
        {
            await _clienteRepository.Delete(id);
        }
        #endregion
    }
}
