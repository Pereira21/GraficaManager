using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.Models.MateriaPrimaEstoqueViewModel;
using DevIO.Business.Interfaces;
using AutoMapper;
using DevIO.Business.Models;
using DevIO.App.Controllers.Base;
using System.Collections.Generic;
using static DevIO.App.Extensions.CustomAuthorization;

namespace DevIO.App.Controllers
{
    [Route("MateriaPrimaEstoque")]
    public class MateriaPrimaEstoquesController : BaseController
    {
        private readonly IMateriaPrimaEstoqueAppService _materiaPrimaEstoqueAppService;

        public MateriaPrimaEstoquesController(IMapper mapper, INotificator notificator, IMateriaPrimaEstoqueAppService materiaPrimaEstoqueAppService) : base(mapper, notificator)
        {
            _materiaPrimaEstoqueAppService = materiaPrimaEstoqueAppService;
        }

        [Route("Lista")]
        public async Task<IActionResult> Index()
        {
            var materiaPrimaEstoques = await _materiaPrimaEstoqueAppService.GetAllAsync();
            var model = _mapper.Map<List<MateriaPrimaEstoqueViewModel>>(materiaPrimaEstoques);
            return View(model);
        }

        [Route("Detalhe/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var materiaPrimaEstoque = await _materiaPrimaEstoqueAppService.GetByIdAsync(id);
            var model = _mapper.Map<MateriaPrimaEstoqueViewModel>(materiaPrimaEstoque);

            if (materiaPrimaEstoque == null)
                return NotFound();

            return View(model);
        }

        [Route("Cadastro")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("MateriaPrimaEstoque", "Adicionar")]
        [Route("Cadastro")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMateriaPrimaEstoqueViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _materiaPrimaEstoqueAppService.Add(_mapper.Map<MateriaPrimaEstoque>(model));

            if (!OperacaoValida())
                return View(model);

            TempData["Sucesso"] = "Matéria Prima cadastrada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("MateriaPrimaEstoque", "Editar")]
        [Route("Edicao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cliente = await _materiaPrimaEstoqueAppService.GetByIdAsync(id);
            var model = _mapper.Map<EditMateriaPrimaEstoqueViewModel>(cliente);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [ClaimsAuthorize("MateriaPrimaEstoque", "Editar")]
        [Route("Edicao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditMateriaPrimaEstoqueViewModel materiaPrimaEstoque)
        {
            if (id != materiaPrimaEstoque.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(materiaPrimaEstoque);

            await _materiaPrimaEstoqueAppService.Update(_mapper.Map<MateriaPrimaEstoque>(materiaPrimaEstoque));

            if (!OperacaoValida())
                return View(materiaPrimaEstoque);

            TempData["Sucesso"] = "Matéria Prima atualizada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("MateriaPrimaEstoque", "Deletar")]
        [Route("Exclusao")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _materiaPrimaEstoqueAppService.GetByIdAsync(id);
            var model = _mapper.Map<MateriaPrimaEstoqueViewModel>(cliente);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [ClaimsAuthorize("MateriaPrimaEstoque", "Deletar")]
        [Route("Exclusao")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materiaPrimaEstoque = await _materiaPrimaEstoqueAppService.GetByIdAsync(id);
            var model = _mapper.Map<MateriaPrimaEstoqueViewModel>(materiaPrimaEstoque);

            if (model == null)
                return NotFound();

            await _materiaPrimaEstoqueAppService.Delete(id);

            if (!OperacaoValida())
                return View(model);

            TempData["Sucesso"] = "Matéria Prima excluída com sucesso!";
            return RedirectToAction(nameof(Index));
        }

    }
}
