﻿namespace Gestion_de_Nomina
{
    partial class UsuariosConsultas
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
            this.filterTxtBox = new System.Windows.Forms.TextBox();
            this.FilterBtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CargarBtn = new System.Windows.Forms.Button();
            this.reporteBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // filterTxtBox
            // 
            this.filterTxtBox.Location = new System.Drawing.Point(419, 24);
            this.filterTxtBox.Name = "filterTxtBox";
            this.filterTxtBox.Size = new System.Drawing.Size(183, 22);
            this.filterTxtBox.TabIndex = 13;
            // 
            // FilterBtn
            // 
            this.FilterBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilterBtn.Location = new System.Drawing.Point(608, 16);
            this.FilterBtn.Name = "FilterBtn";
            this.FilterBtn.Size = new System.Drawing.Size(87, 38);
            this.FilterBtn.TabIndex = 12;
            this.FilterBtn.Text = "Filtrar";
            this.FilterBtn.UseVisualStyleBackColor = true;
            this.FilterBtn.Click += new System.EventHandler(this.FilterBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 377);
            this.dataGridView1.TabIndex = 11;
            // 
            // CargarBtn
            // 
            this.CargarBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarBtn.Location = new System.Drawing.Point(701, 16);
            this.CargarBtn.Name = "CargarBtn";
            this.CargarBtn.Size = new System.Drawing.Size(87, 37);
            this.CargarBtn.TabIndex = 14;
            this.CargarBtn.Text = "Cargar";
            this.CargarBtn.UseVisualStyleBackColor = true;
            this.CargarBtn.Click += new System.EventHandler(this.CargarBtn_Click);
            // 
            // reporteBtn
            // 
            this.reporteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporteBtn.Location = new System.Drawing.Point(12, 15);
            this.reporteBtn.Name = "reporteBtn";
            this.reporteBtn.Size = new System.Drawing.Size(173, 38);
            this.reporteBtn.TabIndex = 15;
            this.reporteBtn.Text = "Generar reporte";
            this.reporteBtn.UseVisualStyleBackColor = true;
            this.reporteBtn.Click += new System.EventHandler(this.reporteBtn_Click);
            // 
            // UsuariosConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reporteBtn);
            this.Controls.Add(this.CargarBtn);
            this.Controls.Add(this.filterTxtBox);
            this.Controls.Add(this.FilterBtn);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UsuariosConsultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UsuariosConsultas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filterTxtBox;
        private System.Windows.Forms.Button FilterBtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CargarBtn;
        private System.Windows.Forms.Button reporteBtn;
    }
}