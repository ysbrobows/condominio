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
    public class MoradorController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Morador
        public ActionResult Index()
        {
            var tbl_Morador = db.tbl_Morador.Include(t => t.tbl_Casa);
            return View(tbl_Morador.ToList());
        }

        public JsonResult Listar()
        {

            var retorno = (from m in db.tbl_Morador.ToList()
                           join c in db.tbl_Casa on m.Id_Casa equals c.ID
                           join r in db.tbl_Rua on c.Id_Rua equals r.ID
                           select new MoradorVM
                           {
                               ID = m.ID.ToString(),
                               Nome_Morador = m.Nome_Morador,
                               CPF = m.CPF.ToString(),
                               Telefone = m.Telefone,
                               Email = m.Email,
                               Id_Casa = m.Id_Casa.ToString(),
                               Casa = c.Casa,
                               Rua = r.Rua,
                               Id_Rua = r.ID.ToString()

                        }).ToList();

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Salvar(tbl_Morador morador)
        {
            if (db.tbl_Morador.Any(x => x.CPF == morador.CPF))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            db.Configuration.ValidateOnSaveEnabled = false;
            db.tbl_Morador.Add(morador);
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Editar(tbl_Morador morador)
        {
            //if (db.tbl_Morador.Any(x => x.CPF == morador.CPF))
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            db.Entry(morador).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Deletar(int id)
        {
            
            try
            {
                tbl_Morador morador = db.tbl_Morador.Where(x => x.ID == id).FirstOrDefault();

                if (morador != null)
                {
                    db.tbl_Morador.Remove(morador);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
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
