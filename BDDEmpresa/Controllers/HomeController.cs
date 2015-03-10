using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDDEmpresa.Models;

namespace BDDEmpresa.Controllers
{
    public class HomeController : Controller
    {

        EmpresaEntities1 db = new EmpresaEntities1();

        // GET: Home
        public ActionResult Index()
        {
          

                return View(db.Empleado.ToList());
           
        }

        public ActionResult Alta()
        {
            ViewBag.idCargos =
            new SelectList(db.Cargos, "Id", "NombreCargo");
            ViewBag.idCargos = new MultiSelectList(db.Cargos, "Id", "NombreCargo");
            return View(new Models.Empleado());
        }

        [HttpPost]
        public ActionResult Alta(Models.Empleado model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new EmpresaEntities1())
                {
                    db.Empleado.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(model);


        }

        public ActionResult Buscar()  //sniper control +k+x
        {
            var bus = Request.Form["busqueda"];

            var db = new EmpresaEntities1();
            var em = db.Empleado.Where(o => o.Cargos.NombreCargo.Contains(bus));

            return View(em);
        }


  
    
    
    
    }





}