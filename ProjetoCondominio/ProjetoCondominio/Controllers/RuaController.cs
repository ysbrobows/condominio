using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCondominio.Models;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace ProjetoCondominio.Controllers
{
    public class RuaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Rua
        public ActionResult Index()
        {
            return View(db.tbl_Rua.ToList());
        }

        public JsonResult Listar()
        {
              var retorno = (from x in db.tbl_Rua.ToList()
                           select new RuaVM
                           {
                               ID = x.ID.ToString(),
                               Rua = x.Rua                               
                           }).ToList();


            return Json(retorno, JsonRequestBehavior.AllowGet);
        }
          /*      
        public JsonResult Deletar(tbl_Rua obj)
        {
            //tbl_Rua tbl_Rua = db.tbl_Rua.Find(ID);
            db.Entry(obj).State = EntityState.Deleted;
            //db.tbl_Rua.Remove(obj);
            //db.tbl_Rua.Remove(obj);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        */
        
        public JsonResult Deletar(int id) {
            bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;
            try { db.Configuration.ValidateOnSaveEnabled = false;
                var customer = new tbl_Rua { ID = id };
                db.tbl_Rua.Attach(customer); db.Entry(customer).State = EntityState.Deleted;
                //db.tbl_Rua.Remove(tbl_Rua);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            finally { db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled; }
            /*
            tbl_Rua tbl_Rua = db.tbl_Rua.Find(id);
            db.tbl_Rua.Remove(tbl_Rua);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
            */

        }

        //public JsonResult Salvar([Bind(Include = "ID,Rua")] tbl_Rua tbl_rua) { 
        public JsonResult Salvar(tbl_Rua rua, string nome)
        {
              if (db.tbl_Rua.Any(x => x.Rua == rua.Rua))
              {
                  return Json(false, JsonRequestBehavior.AllowGet);
              }
                   

            db.tbl_Rua.Add(rua);            
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Editar(tbl_Rua rua)
        {
            db.Entry(rua).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
