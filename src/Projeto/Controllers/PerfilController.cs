using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Models;

namespace Projeto.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PerfilController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;

        public PerfilController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public ViewResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                {
                    //Serilog.Log.Information("Ação: Create; Objeto: Perfil; Perfil: {0}; Usuario: {1}; ", name, User.Identity.Name);
                    return RedirectToAction("Index");
                }
                else
                    Errors(result);
            }
            return View(name);
        }


        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }


        public async Task<IActionResult> Edit(string id)
        {
            var modelo = await _roleManager.FindByIdAsync(id);
            return View(modelo);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(string id, IdentityRole modelo)
        {
            if (id != modelo.Id) return NotFound();

            if (!ModelState.IsValid) return NotFound();

            try
            {
                await _roleManager.UpdateAsync(modelo);
                //Serilog.Log.Information("Ação: Update; Objeto: Perfil; Perfil: {0}; Usuario: {1}; ", modelo.Name, User.Identity.Name);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExist(modelo.Id).Result)
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete(string id)
        {
            var modelo = await _roleManager.FindByIdAsync(id);
            if (modelo == null) return NotFound();

            return View(modelo);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirm(string id)
        {
            var modelo = await _roleManager.FindByIdAsync(id);
            if (modelo != null)
            {
                var result = await _roleManager.DeleteAsync(modelo);
                if (result.Succeeded)
                {
                    //Serilog.Log.Information("Ação: Delete; Objeto: Perfil; Perfil: {0}; Usuario: {1}; ", modelo.Name, User.Identity.Name);
                    return RedirectToAction("Index");
                }
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");

            return View("Index", _roleManager.Roles);

        }



        public async Task<IActionResult> Details(string id)
        {
            var modelo = await _roleManager.FindByIdAsync(id);

            if (modelo == null) return NotFound();

            return View(modelo);
        }



        private async Task<bool> ModelExist(string id)
        {
            var modelo = await _roleManager.FindByIdAsync(id);
            return await _roleManager.RoleExistsAsync(modelo.Name);
        }



    }
}