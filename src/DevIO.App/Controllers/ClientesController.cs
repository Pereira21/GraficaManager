using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevIO.Business.Interfaces;
using DevIO.App.Controllers.Base;
using DevIO.App.Models.ClienteViewModel;
using AutoMapper;
using DevIO.Business.Models;

namespace DevIO.App.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IMapper mapper, IClienteAppService clienteAppService) : base (mapper)
        {
            _clienteAppService = clienteAppService;
        }

        [Route("Listar")]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteAppService.GetAllAsync();
            return View(clientes);
        }

        public async Task<IActionResult> Create()
        {
            return View(new CreateClienteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateClienteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _clienteAppService.Add(_mapper.Map<Cliente>(model));
            return RedirectToAction(nameof(Index));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var cliente = await _context.Clientes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (cliente == null)
            //{
            //    return NotFound();
            //}

            //return View(cliente);
            return View();
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var cliente = await _context.Clientes.FindAsync(id);
            //if (cliente == null)
            //{
            //    return NotFound();
            //}
            //return View(cliente);

            return View();
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditClienteViewModel cliente)
        {
            //if (id != cliente.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(cliente);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!ClienteExists(cliente.Id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(cliente);
            return View();
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var cliente = await _context.Clientes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (cliente == null)
            //{
            //    return NotFound();
            //}

            //return View(cliente);

            return View();
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var cliente = await _context.Clientes.FindAsync(id);
            //_context.Clientes.Remove(cliente);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));

            return View();
        }

        private bool ClienteExists(Guid id)
        {
            //return _context.Clientes.Any(e => e.Id == id);

            return true;
        }
    }
}
