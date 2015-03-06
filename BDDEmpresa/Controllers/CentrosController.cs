using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BDDEmpresa.Models;

namespace BDDEmpresa.Controllers
{
    public class CentrosController : Controller
    {

        EmpresaEntities1 db=new EmpresaEntities1();

        // GET: Centros
        public ActionResult Index()
        {
            return View(db.Centros);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

    }
}