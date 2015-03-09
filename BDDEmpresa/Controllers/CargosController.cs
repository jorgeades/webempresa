using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDDEmpresa.Models;



namespace BDDEmpresa.Controllers
{
    public class CargosController : Controller
    {
        EmpresaEntities1 db = new EmpresaEntities1();





        // GET: Cargos
        public ActionResult Index()
        {
            return View(db.Cargos);
        }
       



        public ActionResult Alta()
        {
            return View(new Cargos());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Alta(Cargos model)
        {
            if (ModelState.IsValid)
            {
                db.Cargos.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }



        public ActionResult Borrar(int id)
        {
            var model = db.Cargos.Find(id);


            try
            {
                db.Cargos.Remove(model);
                db.SaveChanges();

            }
            catch (Exception ee)
            {

                Console.WriteLine(ee);
            }

            return RedirectToAction("Index");

        }

        public ActionResult Modificar(int id)
        {

            var curso = db.Cargos.Find(id);

            return View();
        }

        [HttpPost]

        public ActionResult Modificar(Cargos model)
        {
            if (ModelState.IsValid)
            {
                var m = db.Cargos.Find(model.Id);
                m.NombreCargo = model.NombreCargo;
             

                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View(model);
        }

    
    }



}