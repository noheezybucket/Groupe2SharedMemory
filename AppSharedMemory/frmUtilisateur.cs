using AppSharedMemory.Model;
using AppSharedMemory.Services;
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
    public partial class frmUtilisateur : Form
    {
        public frmUtilisateur()
        {
            InitializeComponent();
        }

        // Instance du service pour gérer les utilisateurs
        UtilisateurService Service = new UtilisateurService();

        // Utilisateur actuellement sélectionné dans la DataGridView
        private Utilisateur selectUser;


        private void frmUtilisateur_Load(object sender, EventArgs e)
        {
            dgUtilisateurs.DataSource = Service.GetListUtilisateur();

        }

        private void dgUtilisateurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            // Vérification si tous les champs sont remplis
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtAge.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs avant d'ajouter un utilisateur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérification que le nom et le prénom contiennent uniquement des lettres
            if (!IsString(txtNom.Text) || !IsString(txtPrenom.Text))
            {
                MessageBox.Show("Le nom et le prénom doivent contenir uniquement des lettres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérification que l'âge est un nombre valide
            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Veuillez entrer un âge valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Création d'un nouvel utilisateur avec les informations saisies
            Utilisateur user = new Utilisateur
            {
                nom = txtNom.Text,
                prenom = txtPrenom.Text,
                age = age
            };

            // Appel du service pour ajouter l'utilisateur et vérifier si l'ajout a réussi
            bool result = Service.AddUtilisateur(user);

            if (result)
            {
                MessageBox.Show("Utilisateur ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("L'ajout de l'utilisateur a échoué.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Effacement des champs de texte et mise à jour de la liste des utilisateurs
            Effacer();
        }

        // Méthode pour réinitialiser les champs de saisie et mettre à jour la liste des utilisateurs
        private void Effacer()
        {
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtAge.Text = string.Empty;
            dgUtilisateurs.DataSource = Service.GetListUtilisateur();
            txtNom.Focus();
        }

        // Méthode pour vérifier si une chaîne contient uniquement des lettres
        private bool IsString(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // Vérifie si un utilisateur est sélectionné
            if (selectUser == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.");
                return;
            }

            // Vérifie si tous les champs sont remplis
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtAge.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Vérifie que le nom et le prénom contiennent uniquement des lettres
            if (!IsString(txtNom.Text) || !IsString(txtPrenom.Text))
            {
                MessageBox.Show("Le nom et le prénom doivent contenir uniquement des lettres.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Vérifie que l'âge est un nombre valide
            if (!int.TryParse(txtAge.Text, out int age))
            {
                MessageBox.Show("Veuillez entrer un âge valide.");
                return;
            }

            // Met à jour l'utilisateur sélectionné avec les nouvelles informations
            selectUser.nom = txtNom.Text;
            selectUser.prenom = txtPrenom.Text;
            selectUser.age = age;

            // Appel du service pour mettre à jour l'utilisateur et vérifier si la mise à jour a réussi
            bool result = Service.UpdateUtilisateur(selectUser);

            if (result)
            {
                MessageBox.Show("Utilisateur mis à jour avec succès.");
                selectUser = null;
            }
            else
            {
                MessageBox.Show("La mise à jour de l'utilisateur a échoué.");
                selectUser = null;
            }

            // Efface les champs de texte et met à jour la liste des utilisateurs après la mise à jour
            Effacer();
        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgUtilisateurs.SelectedRows.Count > 0)
            {
                var selectRow = dgUtilisateurs.SelectedRows[0];
                selectUser = (Utilisateur)selectRow.DataBoundItem;

                txtNom.Text = selectUser.nom;
                txtPrenom.Text = selectUser.prenom;
                txtAge.Text = selectUser.age.ToString();
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (selectUser != null)
            {
                // Appelle le service pour supprimer l'utilisateur et réinitialise les champs après suppression
                Service.DeleteUtilisateur(selectUser.id);
                Effacer();
                selectUser = null;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.");
                return;
            }
        }
    }
}
