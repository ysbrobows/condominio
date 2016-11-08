using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoCondominio.Models;

namespace ProjetoCondominio.Controllers
{
    public class CasaController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Casa
        public ActionResult Index()
        {
            var tbl_Casa = db.tbl_Casa.Include(t => t.tbl_Rua);
            return View(tbl_Casa.ToList());
        }

        public JsonResult ListarTodos()
        {

            var retorno = (from c in db.tbl_Casa.ToList()
                           join r in db.tbl_Rua on c.Id_Rua equals r.ID
                           select new CasaVM
                           {
                               ID = c.ID.ToString(),
                               Casa = c.Casa,
                               Id_Rua = c.Id_Rua.ToString(),
                               Rua = r.Rua
                           }).ToList();

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Listar(int id_rua)
        {
            var retorno = (from c in db.tbl_Casa.ToList() join r in db.tbl_Rua on c.Id_Rua equals r.ID where c.Id_Rua == id_rua
                           select new CasaVM {
                               ID = c.ID.ToString(),
                               Casa = c.Casa,
                               Id_Rua = c.Id_Rua.ToString(),
                               Rua = r.Rua
        }).ToList();

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Salvar(tbl_Casa casa)
        {
            if (db.tbl_Casa.Any(x => x.Casa == casa.Casa && x.Id_Rua == casa.Id_Rua))     
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            db.Configuration.ValidateOnSaveEnabled = false;
            db.tbl_Casa.Add(casa);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Editar(tbl_Casa casa)
        {
            if (db.tbl_Casa.Any(x => x.Casa == casa.Casa && x.Id_Rua == casa.Id_Rua))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            db.Entry(casa).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Deletar(int id)
        {
            tbl_Casa tbl_Casa = db.tbl_Casa.Find(id);
            db.tbl_Casa.Remove(tbl_Casa);
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
