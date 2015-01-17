using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TpASPGestionCours.Models.EF
{
    //TODO: metadata link
    [MetadataType(typeof(UtilisateurMetaData))]
    public partial class Utilisateur
    {
        public static Boolean Save(Utilisateur pModel)
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                if (pModel.Id > 0)
                {//modifier
                   
                    //prendre l item qu on veut updater dans la bd
                    Utilisateur modelToSave = GetById(pModel.Id, db);
                    //modifier les colonnes desirees
                    modelToSave.Nom = pModel.Nom;
                    modelToSave.Prenom = pModel.Prenom;
                   
                    modelToSave.Sexe = pModel.Sexe;
                    modelToSave.Tel = pModel.Tel;
                    modelToSave.UserProfileId = pModel.UserProfileId;
                    modelToSave.Age = pModel.Age;
                    modelToSave.Email = pModel.Email;

                }
                else
                {//ajouter

                    db.Utilisateurs.AddObject(pModel);
                }
                //mettre a jour le context(pour saver nos mis a jours)
                db.SaveChanges();

            }
            return true;
        }
        public static List<Utilisateur> GetAll()
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                var rValue = db.Utilisateurs.ToList();
                return rValue;
            }
        }
        public static void Delete(int id)
        {
            using (GestionCoursEntities1 db = new GestionCoursEntities1())
            {
                Utilisateur itemToDelete = GetById(id, db);
                db.Utilisateurs.DeleteObject(itemToDelete);

                db.SaveChanges();
            }
        }

        public static Utilisateur GetById(int pId, GestionCoursEntities1 pCurrentContent = null)
        {//option de recevoir le context courant ou pas. pour vouloir faire une mise a jour il faut le meme context que celui on fait un db.savechange()
            Boolean dbwaNull = false;
            if (pCurrentContent == null)
            {
                pCurrentContent = new GestionCoursEntities1();
                dbwaNull = true;
            }
            // recuper l item de la bd
            Utilisateur item = pCurrentContent.Utilisateurs.Where(m => m.Id == pId).FirstOrDefault();
            if (dbwaNull)
            {
                pCurrentContent.Dispose();

            }
            return item;
        }

    }

    public class UtilisateurMetaData { 
        //TODO: Mettre les metadata
     
        [Required(ErrorMessage = "Le Nom doit etre entre. il est obligatoire")]
        [MaxLength(50)]
        
        [RegularExpression(@" /^([A-Z\- ]*)(.*)$/", ErrorMessage = "le nom doit etre en majuscule")]
 
        public String Nom { get; set; }
         [Remote("verifierEmail", "TestForm", AdditionalFields = "Id", ErrorMessage = "email deja existant")]
        [RegularExpression(@"[-0-9a-zA-Z.+_]+@[-0-9a-zA-Z.+_]+\.[a-zA-Z]{2,4}$", ErrorMessage = "email n est pas valide")]
      
        public String Email { get; set; }
       
         [Required]
         [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "le telephone doit etre separe par des anti slaches ")]
         public string Tel { get; set; }
        
    }
}
 