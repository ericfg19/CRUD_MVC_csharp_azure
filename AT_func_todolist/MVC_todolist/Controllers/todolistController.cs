using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_todolist.Infra;
using MVC_todolist.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_todolist.Controllers
{
    public class todolistController : Controller
    {
        private readonly ListaRest agendaRest;

        public todolistController()
        {
            this.agendaRest = new ListaRest();
        }
        // GET: todolistController
        public ActionResult Index()
        {
            var model = this.agendaRest.GetAll();
            return View(model);
        }

        // GET: todolistController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = this.agendaRest.GetById(id);

            return View(model);
        }

        // GET: todolistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: todolistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ListaModel model)
        {
            try
            {
                this.agendaRest.Save(model);


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: todolistController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var model = this.agendaRest.GetById(id);
            return View(model);
           
        }

        // POST: todolistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, ListaModel model)
        {
            try
            {
                model.Id = id;
                this.agendaRest.Update(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: todolistController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = this.agendaRest.GetById(id);
            return View(model);


            
        }

        // POST: todolistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, ListaModel model)
        {

            this.agendaRest.Delete(id);


            return RedirectToAction(nameof(Index));


        }
    }
}
