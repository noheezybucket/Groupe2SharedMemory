using MetierSharedMemory.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MetierSharedMemory.Utils
{
    public class Logger
    {
        BdGp2SharedMemoryContext db = new BdGp2SharedMemoryContext();



        /// <summary>
        ///  
        /// </summary>
        /// <param name="TitreErreur"></param>
        /// <param name="erreur"></param>
        public void WriteDataError(string TitreErreur, string erreur)
        {
            try
            {
                Td_Erreur log = new Td_Erreur();
                log.DateErreur = DateTime.Now;
                log.DescriptionErreur = erreur.Length > 3000 ? erreur.Substring(0, 1000) : erreur;
                log.TitreErreur = TitreErreur;
                db.td_Erreurs.Add(log);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                WriteLogSystem(ex.ToString(), "WriteDataError");
            }

        }

        /// <summary>
        /// cette methode enregistre les logs au niveau du systeme d'exploitation
        /// </summary>
        /// <param name="libelle"></param>
        /// <param name="erreur"></param>
        public static void WriteLogSystem(string libelle, string erreur)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Shared Memory";
                eventLog.WriteEntry(String.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur), EventLogEntryType.Information, 101, 1);
            }
        }
    }
}