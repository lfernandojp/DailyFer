namespace pueba.Presentacion
{
    partial class frmMagic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMagic));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtReporte = new System.Windows.Forms.TextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomReporte = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRDLC = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtId.Location = new System.Drawing.Point(260, 68);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(100, 26);
            this.txtId.TabIndex = 0;
            // 
            // txtReporte
            // 
            this.txtReporte.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReporte.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtReporte.Location = new System.Drawing.Point(260, 117);
            this.txtReporte.Name = "txtReporte";
            this.txtReporte.Size = new System.Drawing.Size(100, 26);
            this.txtReporte.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnReport.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnReport.Location = new System.Drawing.Point(120, 200);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(121, 41);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Reporte";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Desktop;
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(141, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Id de reporte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Desktop;
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(141, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Reporte";
            // 
            // txtNomReporte
            // 
            this.txtNomReporte.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNomReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomReporte.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNomReporte.Location = new System.Drawing.Point(40, 300);
            this.txtNomReporte.Name = "txtNomReporte";
            this.txtNomReporte.ReadOnly = true;
            this.txtNomReporte.Size = new System.Drawing.Size(475, 26);
            this.txtNomReporte.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(36, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre del reporte:";
            // 
            // btnRDLC
            // 
            this.btnRDLC.BackColor = System.Drawing.SystemColors.Desktop;
            this.btnRDLC.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.btnRDLC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRDLC.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnRDLC.Location = new System.Drawing.Point(311, 200);
            this.btnRDLC.Name = "btnRDLC";
            this.btnRDLC.Size = new System.Drawing.Size(121, 41);
            this.btnRDLC.TabIndex = 7;
            this.btnRDLC.Text = "Mueve reporte";
            this.btnRDLC.UseVisualStyleBackColor = false;
            this.btnRDLC.Click += new System.EventHandler(this.btnRDLC_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.InfoText;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.Olive;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnSalir.Location = new System.Drawing.Point(404, 404);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(138, 39);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(64, 375);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 28);
            this.comboBox1.TabIndex = 14;
            // 
            // frmMagic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(580, 475);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRDLC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNomReporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.txtReporte);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMagic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Magic";
            this.Load += new System.EventHandler(this.frmMagic_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtReporte;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomReporte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRDLC;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}