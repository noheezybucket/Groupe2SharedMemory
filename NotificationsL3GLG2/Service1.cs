using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NotificationsL3GLG2
{
    public partial class Service1 : ServiceBase
    {
        private static System.Timers.Timer aTimer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            aTimer = new System.Timers.Timer(6000);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 600000;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            WriteLogSystem("Demarage du service SenMailDPV", string.Format("Le service a démarré à {0}", DateTime.Now));
        }

        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            try
            {
                ProcessData().Wait();

            }
            catch (Exception ex)
            {
               
            }

            //Thread.Sleep(300000);
            aTimer.Start();
        }

        private static async Task ProcessData()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                //WriteLogSystem(ex.ToString()), string.Format("SendMail");
            }
        }


        protected override void OnStop()
        {
            aTimer.Stop();
            aTimer.Dispose();
            WriteLogSystem("arret du service NotificationGL3G2", string.Format("a {0}", DateTime.Now));
        }

        /// <summary>
        /// cette methode permet de logger dans le systeme
        /// </summary>
        /// <param name="erreur">message dùerreur</param>
        /// <param name="libelle">titre erreur</param>
        public void WriteLogSystem(string erreur, string libelle)
        {
            using (EventLog eventLog = new EventLog("Application" ))
            {
                eventLog.Source = "NotificationGL3 ";
                eventLog.WriteEntry(string.Format("date: {0}, libelle: {1}, description {2}", DateTime.Now, libelle, erreur));
            }
        }
    }
}
