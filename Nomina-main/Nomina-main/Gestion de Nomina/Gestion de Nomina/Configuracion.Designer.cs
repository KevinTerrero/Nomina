﻿namespace Gestion_de_Nomina
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.backupBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backupBtn
            // 
            this.backupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backupBtn.Location = new System.Drawing.Point(106, 158);
            this.backupBtn.Name = "backupBtn";
            this.backupBtn.Size = new System.Drawing.Size(157, 55);
            this.backupBtn.TabIndex = 0;
            this.backupBtn.Text = "Backup";
            this.backupBtn.UseVisualStyleBackColor = true;
            this.backupBtn.Click += new System.EventHandler(this.backupBtn_Click);
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 425);
            this.Controls.Add(this.backupBtn);
            this.Name = "Configuracion";
            this.Text = "Configuracion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backupBtn;
    }
}