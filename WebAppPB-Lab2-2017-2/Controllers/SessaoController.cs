using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppPB_Lab2_2017_2.Models;

namespace WebAppPB_Lab2_2017_2.Controllers
{
    public class SessaoController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Sessao
        public ActionResult Index()
        {
            var sessaos = db.Sessaos.Include(s => s.Filme).Include(s => s.Ingresso).Include(s => s.Sala);
            return View(sessaos.ToList());
        }

        // GET: Sessao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessaos.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            return View(sessao);
        }

        // GET: Sessao/Create
        public ActionResult Create()
        {
            ViewBag.FilmeId = new SelectList(db.Filmes, "FilmeId", "Titulo");
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId");
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Descricao");
            return View();
        }

        // POST: Sessao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessaoId,DataHoraInicio,DataHoraFim,ValorInteira,ValorMeia,Encerrada,SalaId,IngressoId,FilmeId")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                db.Sessaos.Add(sessao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmeId = new SelectList(db.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", sessao.IngressoId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Descricao", sessao.SalaId);
            return View(sessao);
        }

        // GET: Sessao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessaos.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmeId = new SelectList(db.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", sessao.IngressoId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Descricao", sessao.SalaId);
            return View(sessao);
        }

        // POST: Sessao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessaoId,DataHoraInicio,DataHoraFim,ValorInteira,ValorMeia,Encerrada,SalaId,IngressoId,FilmeId")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmeId = new SelectList(db.Filmes, "FilmeId", "Titulo", sessao.FilmeId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", sessao.IngressoId);
            ViewBag.SalaId = new SelectList(db.Salas, "SalaId", "Descricao", sessao.SalaId);
            return View(sessao);
        }

        // GET: Sessao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessaos.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            return View(sessao);
        }

        // POST: Sessao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessao sessao = db.Sessaos.Find(id);
            db.Sessaos.Remove(sessao);
            db.SaveChanges();
            return RedirectToAction("Index");
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
