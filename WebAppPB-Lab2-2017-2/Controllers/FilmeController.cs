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
    public class FilmeController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Filme
        public ActionResult Index()
        {
            return View(db.Filmes.ToList());
        }

        public ActionResult ObterFilmesPor(int? id = null)
        {
            //*** Eager Load **** 
            //é o mecanismo pelo qual uma associação, coleção ou atributo 
            //é carregado imediatamente quando o objeto principal é carregado.
            
            //Exemplos de Eager Loading
            // Carrega todas os Filmes com suas respectivas Sessões  
            var filmes1 = db.Filmes
                .Include(s => s.Sessoes).ToList();

            // Carrega todas os Filmes com suas respectivas Sessões  
            // Usando string como parâmetro para a associação
            var filmes2 = db.Filmes
                .Include("Sessoes").ToList();

            // Carrega todas os Filmes por código com suas respectivas Sessões  
            var filme1 = db.Filmes
                .Where(f => f.FilmeId == id)
                .Include(s => s.Sessoes).ToList();

            // Carrega todas os Filmes por código com suas respectivas Sessões  
            // Usando string como parâmetro para a associação
            var filme2 = db.Filmes
                .Where(f => f.FilmeId == id)
                .Include("Sessoes").ToList();

            // Eager loading com múltiplos níveis
            // Carrega todos os filmes com as sessões e a sala correspondente 
            var filmes3 = db.Filmes
                .Include(b => b.Sessoes.Select(p => p.Sala))
                .ToList();

            // Carrega todos os filmes com as sessões e a sala correspondente 
            var filmes4 = db.Filmes
                .Include("Sessoes.Sala")
                .ToList();

            //*** Lazy Loading *** 
            //é o mecanismo utilizado pelos frameworks de persistência 
            //para carregar informações sobre demanda.  Esse mecanismo torna as entidades mais leves, pois suas associações 
            //são carregadas apenas no momento em que o método que disponibiliza o dado associativo é chamado.

            //Exemplos de Lazy Loading

            //carrega apenas as sessões
            var listaSessoes = db.Sessaos.ToList();
            var sessao = listaSessoes[0];
            
            //carrega as sessoes para um filme particular
            var filmeDaSessao = sessao.Filme;
            //"se o programador não solicitar a carga, o relacionamento 
            //entre entidades não será recuperado."

            //*** Explicitly Loading ***
            //Mesmo com o Lazy Loading desativado, ainda é possível carregar 
            //tardiamente as entidades relacionadas , mas isso deve ser feito 
            //com uma chamada explícita (Explicitly Loading)
            var filme = db.Filmes.Find(id);
            //Quando o lazy loading está desetivado é possível chamadar dados
            //relacionados explicitamente com o método Collection (para coleções)
            db.Entry(filme).Collection(p => p.Sessoes).Load();
            // ou com o método Collection com parâmetros de string 
            db.Entry(filme).Collection("Sessoes").Load();


            var sessao2 = db.Sessaos.Find(2);
            //Quando o lazy loading está desetivado é possível chamadar dados
            //relacionados explicitamente com o método Reference (para único objeto)
            db.Entry(sessao2).Reference(f => f.Filme).Load();
            // ou com o método Reference com parâmetros de string  
            db.Entry(sessao2).Reference("Filme").Load();

            //Aplicando filtros com o método Query do Explicitly Loading
            db.Entry(filme)
                .Collection(s => s.Sessoes)
                .Query()
                .Where(f => f.DataHoraInicio == DateTime.Now)
                .Load();

            return View(filmes1);

        }

        // GET: Filme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeId,Titulo,Duracao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filme/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeId,Titulo,Duracao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
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
