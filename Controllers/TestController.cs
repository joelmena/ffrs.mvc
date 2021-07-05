using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ffrs.mvc.Data;
using ffrs.mvc.Models;
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

        public TestController(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task<IActionResult> Index(Contacto model)
        {
            var result = await _db.Contactos.ToListAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await Task.Yield();
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Register(Contacto model)
        {
            if (model != null)
            {
                model.Id = Guid.NewGuid().ToString();
                try
                {
                    await _db.AddAsync<Contacto>(model);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (System.Exception ex)
                {
                    
                    if (ex.InnerException != null)
                    {
                        return new JsonResult(ex.InnerException.Message);
                    }
                    else
                    {
                        return new JsonResult(ex.Message);
                    }
                }
            }
            else
            {
                
                return View(model);
            }
            
        }
    }
}