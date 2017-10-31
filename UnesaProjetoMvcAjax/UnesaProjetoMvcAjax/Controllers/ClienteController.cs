using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UnesaProjetoMvcAjax.Models;
using UnesaProjetoMvcAjax.Repositories.Contracts;

namespace UnesaProjetoMvcAjax.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _repository;

        public ClienteController(IClienteRepository repository)
        {
            _repository = repository;
        }

        // GET: Cliente
        public ActionResult Index(string nome)
        {
            var cliente = _repository.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                cliente = cliente.Where(p => p.Nome.Contains(nome));

                cliente = cliente.OrderBy(p => p.Nome);
            }

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Cliente", cliente.ToList());
            }

            return View(cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _repository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(cliente);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(cliente);        
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _repository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(cliente);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cliente = _repository.GetById(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }

            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var cliente = _repository.GetById(id);
            _repository.Remove(cliente);
            _repository.Save();

            return RedirectToAction("Index");
        }
    }
}
