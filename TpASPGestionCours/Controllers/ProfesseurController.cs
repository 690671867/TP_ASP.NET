using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TpASPGestionCours.Models.EF;

namespace TpASPGestionCours.Controllers
{
    public class ProfesseurController : Controller
    {
        //
        // GET: /Professeur/
        public ActionResult Index()
        {
            List<Professeur> ListeDesProf = Professeur.GetAll();

            return View(ListeDesProf);
        }
        public ActionResult Detail(int? id)
        {
            int localId = 0;
            if (id != null) localId = (int)id;

            Professeur ob = Professeur.GetById(localId);
            if (ob == null)
            {
                ob = new Professeur();
            }

            return View(ob);
        }
        [HttpPost]
        public ActionResult Detail(Professeur pModel)
        {
            if (ModelState.IsValid)
            {
                Professeur.Save(pModel);
                TempData["FormMessage"] = "Enregistrement reussi!";

                ModelState.Clear();
                  return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Une erreur niveau model");
                ModelState.AddModelError("Prix", "Une erreur niveau propriete");

            }

            return View(pModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Professeur.Delete(id);
            TempData["FormMessage"] = "Suppression reussi!";

            //Retourner a la liste de produits
            return RedirectToAction("Index");
        }

    }

}