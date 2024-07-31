using MetierSharedMemory.Model;
using MetierSharedMemory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MetierSharedMemory
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        private BdGp2SharedMemoryContext db = new BdGp2SharedMemoryContext();
        Logger logger = new Logger();
  
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// ajoute un encadreur 
        /// </summary>
        /// <param name="encadreur"></param>
        /// <returns>true si ok, fqlse sinon</returns>

       public bool AddEncadreur(Encadreur  encadreur) { 
            try
            {
                db.encadreurs.Add(encadreur);
                db.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service&=AddEncadreur", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// modifie un encadreur suivant son id
        /// </summary>
        /// <param name="encadreur"></param>
        /// <returns></returns>
        public bool UpdateEncadreur(Encadreur encadreur)
        {
            try
            {
                var leEncadreur=db.encadreurs.Find(encadreur.IdPersonne);
                if(leEncadreur  != null)
                {
                    leEncadreur.Prenom = encadreur.Prenom;
                    leEncadreur.Nom = encadreur.Nom;
                    db.SaveChanges();
                    return true;
                }
                return true;

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service&=UpdateEncadreur", ex.ToString());
                return false;
            }
        }

        /// <summary>
        /// supprime un encadreur suivant son id
        /// </summary>
        /// <param name="IdEncadreur"></param>
        /// <returns>true si ok, false sinon</returns>
        public bool DeleteEncadreur(int? IdEncadreur)
        {
            try
            {
                var leEncadreur = db.encadreurs.Find(IdEncadreur);
                if (leEncadreur != null)
                {
                    db.encadreurs.Remove(leEncadreur);
                    db.SaveChanges();
                    return true;
                }
                return true;

            }
            catch (Exception ex)
            {
                logger.WriteDataError("Service&=DeleteEncadreur", ex.ToString());

                return false;
            }
        }

        /// <summary>
        /// recupere tout les encadreurs
        /// </summary>
        /// <returns></returns>
        public List<Encadreur> GetAllEncadreurs()
        {
            return db.encadreurs.ToList();
        }

        /// <summary>
        /// recupere un encadreur unique
        /// </summary>
        /// <param name="IdEncadreur"></param>
        /// <returns>l'encadreur correspondant</returns>
        public Encadreur GetEncadreur(int? IdEncadreur)
        {
            return db.encadreurs.Find(IdEncadreur);
        }

        /// <summary>
        /// recupere les encadreurs en fonction des criteres passer
        /// </summary>
        /// <param name="Nom"></param>
        /// <param name="Prenom"></param>
        /// <param name="Specialite"></param>
        /// <returns></returns>
        public List<Encadreur> GetEncadreurs(string Nom, string Prenom, string Specialite)
        {
            var liste = db.encadreurs.ToList();

            if(!string.IsNullOrEmpty(Nom)) {
                liste=liste.Where(a=>a.Nom.ToUpper().Contains(Nom.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(Prenom)) {
                liste = liste.Where(a => a.Prenom.ToUpper().Contains(Prenom.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(Specialite)) {
                liste = liste.Where(a => a.Specialite.ToUpper().Contains(Specialite.ToUpper())).ToList();
            }


            return liste;
        }
    }
}
