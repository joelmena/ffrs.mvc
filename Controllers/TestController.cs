using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ffrs.mvc.Data;
using ffrs.mvc.Models;
using ffrs.mvc.Repositories;
using ffrs.mvc.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using ffrs.mvc.Models;

namespace ffrs.mvc.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IContactRepository contactRepository;

        public TestController(ApplicationDbContext dbContext, IContactRepository contactRepository)
        {
            _db = dbContext;
            this.contactRepository = contactRepository;
        }

        public async Task<IActionResult> Index()
        {
            var result = await contactRepository.GetAllContactsAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await Task.Yield();
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register([Bind("Id,Nombres,Apellidos,Cedula,FechaNacimiento,Sexo,Telefono,Direccion, CreatedAt, Inactivo")] Contacto model)
        {
            
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            model.Id = Guid.NewGuid().ToString();
            model.CreatedAt = DateTime.Now;
            if(!await contactRepository.CreateContactAsync(model))
            {
                // ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar crear el contacto {model.Nombres.Concat("").Concat(model.Apellidos)}");
                // return StatusCode(500, ModelState);
                ViewData["error"] = $"Ha ocurrido un error al intentar registrar al miembro de nombre {model.Nombres.Concat("").Concat(model.Apellidos)}";
                return View(model);
            }
            return RedirectToAction("Index"); 
        }

        public async Task<IActionResult> Edit(string id)
        {
            var contact = await contactRepository.GetContactAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Nombres,Apellidos,Cedula,FechaNacimiento,Sexo,Telefono,Direccion")] Contacto model)
        {
            if(id != model.Id)
            {
                return BadRequest();
            }

            var contact = await contactRepository.GetContactAsync(id);
            if(contact == null)
            {
                return NotFound();
            }
             
             contact.Nombres = model.Nombres;
             contact.Apellidos = model.Apellidos;
             contact.Cedula = model.Cedula;
             contact.FechaNacimiento = model.FechaNacimiento;
             contact.Sexo = model.Sexo;
             contact.Telefono = model.Telefono;
             contact.Direccion = model.Direccion;

            if(!await contactRepository.UpdateContactAsync(contact))
            {
                ViewData["error"] = $"Ha ocurrido un error al intentar actualizar al miembro de nombre {model.Nombres.Concat("").Concat(model.Apellidos)}";
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}