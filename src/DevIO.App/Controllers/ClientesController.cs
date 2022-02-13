using AutoMapper;
using DevIO.App.Controllers.Base;
using DevIO.App.Models.ClienteViewModel;
using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static DevIO.App.Extensions.CustomAuthorization;

namespace DevIO.App.Controllers
{
    [Route("Cliente")]
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IMapper mapper, INotificator notificator, IClienteAppService clienteAppService) : base(mapper, notificator)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("Lista")]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteAppService.GetAllAsync();
            var model = _mapper.Map<List<ClienteViewModel>>(clientes);
            return View(model);
        }

        [ClaimsAuthorize("Cliente", "Adicionar")]
        [Route("Cadastro")]
        public async Task<IActionResult> Create()
        {
            return View(new CreateClienteViewModel());
        }

        [ClaimsAuthorize("Cliente", "Adicionar")]
        [Route("Cadastro")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _clienteAppService.Add(_mapper.Map<Cliente>(model));

            if (!OperacaoValida())
                return View(model);

            TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [Route("Detalhe/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var cliente = await _clienteAppService.GetByIdAsync(id);
            var model = _mapper.Map<ClienteViewModel>(cliente);

            if (cliente == null)
                return NotFound();

            return View(model);
        }

        [ClaimsAuthorize("Cliente", "Editar")]
        [Route("Edicao/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var cliente = await _clienteAppService.GetByIdAsync(id);
            var model = _mapper.Map<EditClienteViewModel>(cliente);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [ClaimsAuthorize("Cliente", "Editar")]
        [Route("Edicao/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditClienteViewModel cliente)
        {
            if (id != cliente.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(cliente);

            await _clienteAppService.Update(_mapper.Map<Cliente>(cliente));

            if(!OperacaoValida())
                return View(cliente);

            TempData["Sucesso"] = "Cliente atualizado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Cliente", "Deletar")]
        [Route("Exclusao/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteAppService.GetByIdAsync(id);
            var model = _mapper.Map<ClienteViewModel>(cliente);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [ClaimsAuthorize("Cliente", "Deletar")]
        [Route("Exclusao/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await _clienteAppService.GetByIdAsync(id);
            var model = _mapper.Map<ClienteViewModel>(cliente);

            if (model == null)
                return NotFound();

            await _clienteAppService.Delete(id);

            if (!OperacaoValida())
                return View(model);

            TempData["Sucesso"] = "Cliente excluído com sucesso!";
            return RedirectToAction(nameof(Index));
        }
    }
}
