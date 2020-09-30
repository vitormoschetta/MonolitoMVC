using Microsoft.AspNetCore.Mvc;
using System;
using Projeto.ViewModels;
using Projeto.Handlers;
using Projeto.Models;
using Projeto.Utils;

namespace Projeto.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteHandler _handler;
        public ClienteController(ClienteHandler handler)
        {
            _handler = handler;
        }

        public IActionResult Index(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            var lista = _handler.GetAll(pageNumber);
            return View(lista);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var result = _handler.Create(viewModel);
            if (result.Success == false)
            {
                var notifications = GroupsNotificationsInString(result);
                ModelState.AddModelError(string.Empty, notifications);
                return View(viewModel);
            }

            viewModel = (ClienteViewModel)result.Objeto;
            TempDataUtil.Put(TempData, "viewModel", viewModel);
            return RedirectToAction("Details", new { message = result.Message });
        }



        public IActionResult Edit(Guid id)
        {
            var viewModel = _handler.GetById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Edit(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var result = _handler.Update(viewModel);
            if (result.Success == false)
            {
                var notifications = GroupsNotificationsInString(result);
                ModelState.AddModelError(string.Empty, notifications);
                return View(viewModel);
            }

            viewModel = (ClienteViewModel)result.Objeto;
            TempDataUtil.Put(TempData, "viewModel", viewModel);
            return RedirectToAction("Details", new { message = result.Message });
        }




        public IActionResult Delete(Guid id)
        {
            var viewModel = _handler.GetById(id);
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Delete(ClienteViewModel viewModel)
        {
            var result = _handler.Delete(viewModel.Id);
            if (result.Success == false)
            {
                var notifications = GroupsNotificationsInString(result);
                ModelState.AddModelError(string.Empty, notifications);
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Details(string message)
        {
            ViewBag.Message = message;
            var viewModel = TempData.Get<ClienteViewModel>("viewModel");
            return View(viewModel);
        }


        public string GroupsNotificationsInString(DataResult result)
        {
            var notifications = result.Message;
            foreach (var item in result.Notifications)
            {
                notifications += $"{item.Message}. ";
            }
            return notifications;
        }


        public IActionResult Pagination(int? pageNumber)
        {
            if (pageNumber == null) pageNumber = 1;
            var lista = _handler.GetAll(pageNumber);
            return PartialView("_TabelaIndex", lista);
        }



        public IActionResult Search(int? pageNumber, string parametro)
        {
            var listaModelo = _handler.Search(pageNumber, parametro);
            return PartialView("_TabelaIndex", listaModelo);
        }

    }
}