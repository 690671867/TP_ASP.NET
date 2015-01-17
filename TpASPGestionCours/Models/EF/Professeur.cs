using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TpASPGestionCours.Models.EF
{
    public partial class Professeur
    {
        public static Boolean Save(Professeur pModel)
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                if (pModel.Id > 0)
                {//modifier
                    // a ne pas faire  car ici on update tous les colonnes de la table
                    //db.ContactUsMsgs.Attach(pModel);
                    //db.ObjectStateManager.ChangeObjectState(pModel, System.Data.EntityState.Modified);
                    // a faire 
                    //prendre l item qu on veut updater dans la bd
                    Professeur modelToSave = GetById(pModel.Id, db);
                    //modifier les colonnes desirees
                    modelToSave.Nom = pModel.Nom;
                    modelToSave.Prenom = pModel.Prenom;
                    modelToSave.Descrition = pModel.Descrition;
                   
                }
                else
                {//ajouter
              
                    db.Professeurs.AddObject(pModel);
                }
                //mettre a jour le context(pour saver nos mis a jours)
                db.SaveChanges();

            }
            return true;
        }
        public static List<Professeur> GetAll()
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                var rValue = db.Professeurs.ToList();
                return rValue;
            }
        }
        public static void Delete(int id)
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                Professeur itemToDelete = GetById(id, db);
                db.Professeurs.DeleteObject(itemToDelete);

                db.SaveChanges();
            }
        }

        public static Professeur GetById(int pId, GestionCoursEntities1 pCurrentContent = null)
        {//option de recevoir le context courant ou pas. pour vouloir faire une mise a jour il faut le meme context que celui on fait un db.savechange()
            Boolean dbwaNull = false;
            if (pCurrentContent == null)
            {
                pCurrentContent = new GestionCoursEntities1();
                dbwaNull = true;
            }
            // recuper l item de la bd
            Professeur item = pCurrentContent.Professeurs.Where(m => m.Id == pId).FirstOrDefault();
            if (dbwaNull)
            {
                pCurrentContent.Dispose();

            }
            return item;
        }

    }
}