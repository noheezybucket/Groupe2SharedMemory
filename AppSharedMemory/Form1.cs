using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSharedMemory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            service = new ServiceMetier.Service1Client();
        }

        ServiceMetier.Service1Client service;

        private int encadreurId;

        private void Form1_Load(object sender, EventArgs e)
        {
            dgEncadreurs.DataSource = service.GetAllEncadreurs();
        }

        /// <summary>
        /// permet d'ajouter un nouvel encadreur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            ServiceMetier.Encadreur encadreur = new ServiceMetier.Encadreur();
            encadreur.Nom = textN.Text;
            encadreur.Prenom = textP.Text;
            encadreur.Specialite = textS.Text;
            service.AddEncadreur(encadreur);
            Effacer();
        }

        /// <summary>
        /// cette methode permet d'effacer le contenu de tout les champs
        /// </summary>
        private void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtSpecialite.Text = string.Empty;
            dgEncadreurs.DataSource = service.GetAllEncadreurs();
            textN.Focus();
        }

        /// <summary>
        /// cette methode permet de modifier un encadreur a partir de son id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            ServiceMetier.Encadreur encadreur = new ServiceMetier.Encadreur
            {
                IdPersonne = encadreurId, 
                Nom = textN.Text,
                Prenom = textP.Text,
                Specialite = textS.Text
            };

            service.UpdateEncadreur(encadreur);

            dgEncadreurs.DataSource = service.GetAllEncadreurs();

            Effacer();

        }

        /// <summary>
        /// cette methode permet de supprimer un encadreur a partir de son id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgEncadreurs.CurrentRow != null)
            {
                // Récupérer l'ID de l'encadreur sélectionné
                int encadreurId = (int)dgEncadreurs.CurrentRow.Cells[1].Value;

                // Appeler la méthode de suppression du service
                if (service.DeleteEncadreur(encadreurId))
                {
                    MessageBox.Show("Encadreur supprimé avec succès.");
                    // Rafraîchir le DataGridView
                    dgEncadreurs.DataSource = service.GetAllEncadreurs();
                    Effacer(); // Réinitialiser les champs de texte
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression de l'encadreur.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un encadreur à supprimer.");
            }
        }

        /// <summary>
        /// cette methode permet de selectionner un encadreur et d'afficher ses infos dans les inputs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgEncadreurs != null)
            {
                encadreurId = (int)dgEncadreurs.CurrentRow.Cells[1].Value;
                textN.Text = dgEncadreurs.CurrentRow.Cells[2].Value.ToString();
                textP.Text = dgEncadreurs.CurrentRow.Cells[3].Value.ToString();
                textS.Text = dgEncadreurs.CurrentRow.Cells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("veuillez selectionner");
            }

        }

        private void dgEncadreurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
