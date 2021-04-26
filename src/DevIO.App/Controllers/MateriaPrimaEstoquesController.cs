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
using Microsoft.AspNetCore.Http;
using System.IO;

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

            var imgPrefixo = Guid.NewGuid() + "_";

            if (!await UploadArquivo(model.ImagemUpload, imgPrefixo))
                return View(model);

            model.Imagem = imgPrefixo + model.ImagemUpload.FileName;

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
        public async Task<IActionResult> Edit(Guid id, EditMateriaPrimaEstoqueViewModel model)
        {
            if (id != model.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(model);

            if (model.ImagemUpload != null)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadArquivo(model.ImagemUpload, imgPrefixo))
                    return View(model);

                model.Imagem = imgPrefixo + model.ImagemUpload.FileName;
            }

            await _materiaPrimaEstoqueAppService.Update(_mapper.Map<MateriaPrimaEstoque>(model));

            if (!OperacaoValida())
                return View(model);

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


        #region private methods

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/materia-prima", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }

            return true;
        }

        #endregion
    }
}
