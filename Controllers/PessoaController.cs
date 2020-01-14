using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_sem_banco_de_dados.Models;
using CRUD_sem_banco_de_dados.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_sem_banco_de_dados.Controllers {
    public class PessoaController : Controller {

        private readonly IPessoaRepository _pessoaRepository;

        public PessoaController(IPessoaRepository pessoaRepository) {
            _pessoaRepository = pessoaRepository;
        }

        // Lista de pessoas
        public ActionResult Index() {
            var lista = _pessoaRepository.Listar();
            return View(lista);
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id) {
            var pessoa = _pessoaRepository.Buscar(id);
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Pessoa pessoa) {
            try {
                _pessoaRepository.Cadastrar(pessoa);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id) {
            var pessoa = _pessoaRepository.Buscar(id);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Pessoa pessoa) {
            try {
                _pessoaRepository.Editar(pessoa);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id) {
            var pessoa = _pessoaRepository.Buscar(id);
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Pessoa pessoa = null) {
            try {
                _pessoaRepository.Excluir(id);
                return RedirectToAction(nameof(Index));
            } catch {
                return View();
            }
        }
    }
}