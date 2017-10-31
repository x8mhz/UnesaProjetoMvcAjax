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
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _repository;

        public ProdutoController(IProdutoRepository repository)
        {
            _repository = repository;
        }

        // GET: Produto
        public ActionResult Index(string categoria)
        {
            var produtos = _repository.GetAll().AsQueryable();

            if (!string.IsNullOrEmpty(categoria))
            {
                produtos = produtos.Where(p => p.Categoria.Contains(categoria));          
            }

            produtos = produtos.OrderBy(p => p.Categoria);

            return View(produtos.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = _repository.GetById(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(produto);
                _repository.Save();

                return RedirectToAction("Index");
            }

                return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _repository.GetById(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(produto);
                _repository.Save();

                return RedirectToAction("Index");
            }

            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = _repository.GetById(id);

            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var produto = _repository.GetById(id);
            _repository.Remove(produto);
            _repository.Save();

            return RedirectToAction("Index");
        }
    }
}
