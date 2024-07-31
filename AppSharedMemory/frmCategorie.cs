using AppSharedMemory.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using AppSharedMemory.Model;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppSharedMemory
{
    public partial class frmCategorie : Form
    {
        public frmCategorie()
        {
            InitializeComponent();
        }

        CategorieService service = new CategorieService();

        private void dgCategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            dgCategorie.DataSource = service.GetCategories();
        }

        /// <summary>
        /// permet d'ajouter une nouvelle categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            Categorie c = new Categorie();
            c.codeCategorie = txtCode.Text;
            c.libelleCategorie = txtLibelle.Text;
            

            if(txtCode.Text != "" && txtLibelle.Text != "") 
            {
                var success = service.AddCategorie(c);
                if (success)
                {
                    MessageBox.Show("Categorie ajouter avec success.", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    effacer();
                }
                else
                {
                    MessageBox.Show("Une erreur est survenu lors de l'ajout de la categorie.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez bien remplir les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        /// <summary>
        /// permet de vider les champs
        /// </summary>
        private void effacer()
        {
            txtCode.Text = string.Empty;
            txtLibelle.Text = string.Empty;
            dgCategorie.DataSource = service.GetCategories();
            txtCode.Focus();
        }

        /// <summary>
        /// permet de recuperer les infos de la ligne selectionner dans le dgview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgCategorie.CurrentRow != null)
                {
                    if (dgCategorie.CurrentRow.Cells.Count > 2)
                    {
                        string codeCategorie = dgCategorie.CurrentRow.Cells[1].Value.ToString();
                        string libelle = dgCategorie.CurrentRow.Cells[2].Value.ToString();

                        MessageBox.Show($"Code Catégorie: {codeCategorie}, Libellé: {libelle}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtCode.Text = codeCategorie;
                        txtLibelle.Text = libelle;
                    }
                    else
                    {
                        MessageBox.Show("Les colonnes nécessaires ne sont pas disponibles dans la grille.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune ligne sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// permet de modifier une categorie apres selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                // Vérification de la sélection
                if (dgCategorie.CurrentRow != null)
                {
                    // Récupération et validation de l'ID de la catégorie sélectionnée dans le DataGridView
                    int id;
                    if (int.TryParse(dgCategorie.CurrentRow.Cells[0].Value.ToString(), out id))
                    {
                        // Recherche de la catégorie par ID
                        var c = service.Find(id);

                        if (c != null)
                        {
                            // Mise à jour des propriétés de la catégorie avec les valeurs des champs de texte
                            c.codeCategorie = txtCode.Text;
                            c.libelleCategorie = txtLibelle.Text;

                            // Affichage des valeurs avant la mise à jour (pour le débogage)
                            MessageBox.Show($"Valeurs avant mise à jour : Code - {c.codeCategorie}, Libellé - {c.libelleCategorie}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Appel de la méthode UpdateCategorie pour enregistrer les modifications
                            bool success = service.UpdateCategorie(c);

                            // Affichage d'un message en fonction du résultat de la mise à jour
                            if (success)
                            {
                                MessageBox.Show("La catégorie a été mise à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("La mise à jour de la catégorie a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            // Réinitialisation du formulaire après la mise à jour
                            effacer();
                        }
                        else
                        {
                            MessageBox.Show("Catégorie non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID de catégorie non valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune catégorie sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// permet de supprimer une categorie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                // Vérification de la sélection
                if (dgCategorie.CurrentRow != null)
                {
                    // Récupération et validation de l'ID de la catégorie sélectionnée dans le DataGridView
                    int id;
                    if (int.TryParse(dgCategorie.CurrentRow.Cells[0].Value.ToString(), out id))
                    {
                        // Recherche de la catégorie par ID
                        var c = service.Find(id);

                        if (c != null)
                        {
                            // Suppression de la catégorie
                           
                            bool success = service.DeleteCategorie(id);
                            

                            // Affichage d'un message en fonction du résultat de la mise à jour
                            if (success)
                            {
                                MessageBox.Show("La catégorie a été supprimer avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("La suppression de la catégorie a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            // Réinitialisation du formulaire après la mise à jour
                            effacer();
                        }
                        else
                        {
                            MessageBox.Show("Catégorie non trouvée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID de catégorie non valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Aucune catégorie sélectionnée.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // Gestion des exceptions
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
