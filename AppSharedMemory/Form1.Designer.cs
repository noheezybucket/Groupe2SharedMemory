namespace AppSharedMemory
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgEncadreurs = new System.Windows.Forms.DataGridView();
            this.txtNom = new System.Windows.Forms.Label();
            this.textN = new System.Windows.Forms.TextBox();
            this.textP = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.Label();
            this.textS = new System.Windows.Forms.TextBox();
            this.txtSpecialite = new System.Windows.Forms.Label();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnSelectionner = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgEncadreurs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgEncadreurs
            // 
            this.dgEncadreurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEncadreurs.Location = new System.Drawing.Point(246, 12);
            this.dgEncadreurs.Name = "dgEncadreurs";
            this.dgEncadreurs.Size = new System.Drawing.Size(542, 385);
            this.dgEncadreurs.TabIndex = 0;
            this.dgEncadreurs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEncadreurs_CellContentClick);
            // 
            // txtNom
            // 
            this.txtNom.AutoSize = true;
            this.txtNom.Location = new System.Drawing.Point(12, 12);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(29, 13);
            this.txtNom.TabIndex = 1;
            this.txtNom.Text = "Nom";
            // 
            // textN
            // 
            this.textN.Location = new System.Drawing.Point(15, 28);
            this.textN.Name = "textN";
            this.textN.Size = new System.Drawing.Size(225, 20);
            this.textN.TabIndex = 2;
            // 
            // textP
            // 
            this.textP.Location = new System.Drawing.Point(15, 92);
            this.textP.Name = "textP";
            this.textP.Size = new System.Drawing.Size(225, 20);
            this.textP.TabIndex = 4;
            // 
            // txtPrenom
            // 
            this.txtPrenom.AutoSize = true;
            this.txtPrenom.Location = new System.Drawing.Point(12, 76);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(43, 13);
            this.txtPrenom.TabIndex = 3;
            this.txtPrenom.Text = "Prenom";
            // 
            // textS
            // 
            this.textS.Location = new System.Drawing.Point(15, 151);
            this.textS.Name = "textS";
            this.textS.Size = new System.Drawing.Size(225, 20);
            this.textS.TabIndex = 6;
            // 
            // txtSpecialite
            // 
            this.txtSpecialite.AutoSize = true;
            this.txtSpecialite.Location = new System.Drawing.Point(12, 135);
            this.txtSpecialite.Name = "txtSpecialite";
            this.txtSpecialite.Size = new System.Drawing.Size(53, 13);
            this.txtSpecialite.TabIndex = 5;
            this.txtSpecialite.Text = "Specialite";
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(15, 195);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(225, 23);
            this.btnAjouter.TabIndex = 7;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click_1);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(15, 224);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(225, 23);
            this.btnModifier.TabIndex = 8;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(15, 253);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(225, 23);
            this.btnSupprimer.TabIndex = 9;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnSelectionner
            // 
            this.btnSelectionner.Location = new System.Drawing.Point(15, 282);
            this.btnSelectionner.Name = "btnSelectionner";
            this.btnSelectionner.Size = new System.Drawing.Size(225, 23);
            this.btnSelectionner.TabIndex = 10;
            this.btnSelectionner.Text = "Selectionner";
            this.btnSelectionner.UseVisualStyleBackColor = true;
            this.btnSelectionner.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelectionner);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.textS);
            this.Controls.Add(this.txtSpecialite);
            this.Controls.Add(this.textP);
            this.Controls.Add(this.txtPrenom);
            this.Controls.Add(this.textN);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.dgEncadreurs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgEncadreurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEncadreurs;
        private System.Windows.Forms.Label txtNom;
        private System.Windows.Forms.TextBox textN;
        private System.Windows.Forms.TextBox textP;
        private System.Windows.Forms.Label txtPrenom;
        private System.Windows.Forms.TextBox textS;
        private System.Windows.Forms.Label txtSpecialite;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnSelectionner;
    }
}

