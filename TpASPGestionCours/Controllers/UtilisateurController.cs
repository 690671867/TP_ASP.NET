using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using TpASPGestionCours.Models.EF;

namespace TpASPGestionCours.Controllers
{
    public class UtilisateurController : Controller
    {
        //
        // GET: /Utilisateur/

        public ActionResult Index()
        {
            List<Utilisateur> ListeDesUser = Utilisateur.GetAll();

            return View(ListeDesUser);
        }
        public ActionResult Detail(int? id)
        {
            int localId = 0;
            if (id != null) localId = (int)id;

            Utilisateur ob = Utilisateur.GetById(localId);
            if (ob == null)
            {
                ob = new Utilisateur();
            }

            return View(ob);
        }
        [HttpPost]
        public ActionResult Detail(Utilisateur pModel)
        {
            if (ModelState.IsValid)
            {
                Regex regex = new Regex(@"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}");
                Match match = regex.Match(pModel.Email);
                if (!match.Success)
                {
                    ModelState.AddModelError("", "email non valide:");
                    ModelState.AddModelError("email", "email non valide:");
                }
                else
                {//ajouter dans la table de reference
                    //if (!String.IsNullOrEmpty(pModel.AutreReference))
                    //{
                    //    //save d un nouveau item de reference + prendre le nouveau referenceid
                    //    Reference newref = new Reference();
                    //    newref.Name = pModel.AutreReference;
                    //    int newId = Reference.Ajouter(newref);
                    //    //mettre la propriete reference de l object contactUs a jour
                    //    pModel.ReferenceID = newId;
                    //}
                    Utilisateur.Save(pModel);
                    TempData["FormMessage"] = "Enregistrement reussi!";

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }

            }
            return View(pModel);
        }
        public JsonResult verifierEmail(String Email, int Id)
        {
            Boolean isValid = true;//aller a la bd verifier si email deja avec un autre id que lui meme
            if (isValid)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error message ou object", JsonRequestBehavior.AllowGet);
            }

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Utilisateur.Delete(id);
            TempData["FormMessage"] = "Suppression reussi!";

            //Retourner a la liste de produits
            return RedirectToAction("Index");
        }

    }

}