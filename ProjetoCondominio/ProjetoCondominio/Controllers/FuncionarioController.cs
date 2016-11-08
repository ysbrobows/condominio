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
    public class FuncionarioController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Funcionario
        public ActionResult Index()
        {
            var tbl_Funcionario = db.tbl_Funcionario.Include(t => t.tbl_Casa);
            return View(tbl_Funcionario.ToList());
        }

        public JsonResult Listar()
        {

            var retorno = (from f in db.tbl_Funcionario.ToList()
                           join c in db.tbl_Casa on f.Id_Casa equals c.ID
                           join r in db.tbl_Rua on c.Id_Rua equals r.ID
                           select new FuncionarioVM
                           {
                               ID = f.ID.ToString(),
                               Nome_Funcionario = f.Nome_Funcionario,
                               CPF = f.CPF.ToString(),
                               Telefone = f.Telefone,
                               Email = f.Email,
                               Id_Casa = f.Id_Casa.ToString(),
                               Casa = c.Casa,
                               Rua = r.Rua,
                               Id_Rua = r.ID.ToString()

                           }).ToList();

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Salvar(tbl_Funcionario funcionario)
        {
                if (db.tbl_Funcionario.Any(x => x.CPF == funcionario.CPF))
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                                
                db.Configuration.ValidateOnSaveEnabled = false;
                db.tbl_Funcionario.Add(funcionario);
                db.SaveChanges();
                return Json(true, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Editar(tbl_Funcionario funcionario)
        {
            //if (db.tbl_Morador.Any(x => x.CPF == morador.CPF))
            //{
            //    return Json(false, JsonRequestBehavior.AllowGet);
            //}
            db.Entry(funcionario).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Deletar(int id)
        {
            try
            {
                tbl_Funcionario tbl_Funcionario = db.tbl_Funcionario.Find(id);

                if (tbl_Funcionario != null)
                {
                    db.tbl_Funcionario.Remove(tbl_Funcionario);
                    db.SaveChanges();
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex){
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
