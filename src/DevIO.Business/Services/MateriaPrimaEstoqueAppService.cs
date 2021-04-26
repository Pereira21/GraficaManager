using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class MateriaPrimaEstoqueAppService : BaseAppService, IMateriaPrimaEstoqueAppService
    {
        private readonly IMateriaPrimaEstoqueRepository _materiaPrimaEstoqueRepository;
        public MateriaPrimaEstoqueAppService(INotificator notificator, IMateriaPrimaEstoqueRepository materiaPrimaEstoqueRepository) : base(notificator)
        {
            _materiaPrimaEstoqueRepository = materiaPrimaEstoqueRepository;
        }

        #region Queries
        public async Task<IEnumerable<MateriaPrimaEstoque>> GetAllAsync()
        {
            var materiasPrimasEstoque = await _materiaPrimaEstoqueRepository.GetAll();
            return materiasPrimasEstoque.ToArray();
        }

        public async Task<MateriaPrimaEstoque> GetByIdAsync(Guid id)
        {
            var materiaPrimaEstoque = await _materiaPrimaEstoqueRepository.GetById(id);
            return materiaPrimaEstoque;
        }
        #endregion

        #region Commands
        public async Task Add(MateriaPrimaEstoque materiaPrimaEstoque)
        {
            if (!ExecuteValidation(new MateriaPrimaEstoqueValidation(), materiaPrimaEstoque)) return;

            await _materiaPrimaEstoqueRepository.Add(materiaPrimaEstoque);
        }

        public async Task Update(MateriaPrimaEstoque materiaPrimaEstoque)
        {
            if (!ExecuteValidation(new MateriaPrimaEstoqueValidation(), materiaPrimaEstoque)) return;

            await _materiaPrimaEstoqueRepository.Update(materiaPrimaEstoque);
        }

        public async Task Delete(Guid id)
        {
            await _materiaPrimaEstoqueRepository.Delete(id);
        }
        #endregion
    }
}
