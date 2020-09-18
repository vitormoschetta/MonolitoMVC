using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Projeto.Util;
using System;
using Projeto.Repository;
using Projeto.ViewModels;
using Projeto.Services;

namespace Projeto.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteService _service;
        public ClienteController(ClienteService service)
        {
            _service = service;
        }

        public IActionResult Index(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            var lista = _service.GetAll(pageNumber);
            return View(lista);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var result = _service.Create(viewModel);
            if (result.Success == false)
            {
                var notifications = result.Message;
                foreach (var item in result.Data)
                {
                    notifications += $"{item.Message}. ";
                }
                ModelState.AddModelError(string.Empty, notifications);
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }



        public IActionResult Edit(Guid id)
        {
            var viewModel = _service.GetById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var result = _service.Create(viewModel);
            if (result.Success == false)
            {
                var notifications = result.Message;
                foreach (var item in result.Data)
                {
                    notifications += $"{item.Message}. ";
                }
                ModelState.AddModelError(string.Empty, notifications);
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }




        public IActionResult Delete(Guid id)
        {
            var viewModel = _service.GetById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult DeleteConfirm(ClienteViewModel cliente)
        {
            var commandResult = _service.Delete(cliente.Id);
            if (commandResult.Success == false)
            {
                ModelState.AddModelError(string.Empty, commandResult.Message);
                return View(cliente);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Paginacao(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            var lista = _service.GetAll(pageNumber);
            return PartialView("_TabelaIndex", lista);
        }



        public IActionResult Search(int? pageNumber, string parametro)
        {
            var listaModelo = _service.Search(pageNumber, parametro);
            return PartialView("_TabelaIndex", listaModelo);
        }

    }
}