namespace InterfazForms1
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn1 = new System.Windows.Forms.Button();
            this.dtgv1 = new System.Windows.Forms.DataGridView();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.cmbx_Departamento1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textb_Distanciadepartamento = new System.Windows.Forms.TextBox();
            this.lablDistanciadesdecapital = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbx_departamento2 = new System.Windows.Forms.ComboBox();
            this.txtb_distentredepartamentos = new System.Windows.Forms.TextBox();
            this.label_Dis_entreDepartamentos = new System.Windows.Forms.Label();
            this.escalaKm1 = new System.Windows.Forms.Label();
            this.escalaKm2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn1.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1.Location = new System.Drawing.Point(786, 104);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(170, 54);
            this.btn1.TabIndex = 3;
            this.btn1.Text = "Distancia de la Capital a un Departamento";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // dtgv1
            // 
            this.dtgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgv1.Location = new System.Drawing.Point(26, 253);
            this.dtgv1.Name = "dtgv1";
            this.dtgv1.Size = new System.Drawing.Size(709, 214);
            this.dtgv1.TabIndex = 8;
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn2.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn2.Location = new System.Drawing.Point(786, 175);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(170, 54);
            this.btn2.TabIndex = 9;
            this.btn2.Text = "Distancia entre Departamentos";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn3.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn3.Location = new System.Drawing.Point(786, 397);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(170, 54);
            this.btn3.TabIndex = 10;
            this.btn3.Text = "Top  10  Mas Lejanos";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn4.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn4.Location = new System.Drawing.Point(786, 253);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(170, 54);
            this.btn4.TabIndex = 11;
            this.btn4.Text = "Departamentos visitados previos";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn5.Font = new System.Drawing.Font("Microsoft JhengHei", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.Location = new System.Drawing.Point(786, 327);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(170, 54);
            this.btn5.TabIndex = 12;
            this.btn5.Text = "Top 10  Mas Cercanos";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // cmbx_Departamento1
            // 
            this.cmbx_Departamento1.FormattingEnabled = true;
            this.cmbx_Departamento1.Location = new System.Drawing.Point(259, 84);
            this.cmbx_Departamento1.Name = "cmbx_Departamento1";
            this.cmbx_Departamento1.Size = new System.Drawing.Size(334, 21);
            this.cmbx_Departamento1.TabIndex = 13;
            this.cmbx_Departamento1.SelectedIndexChanged += new System.EventHandler(this.cmbx_Departamento_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ingrese el Departamento #1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DodgerBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 10, 10, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(30, 10, 30, 15);
            this.label2.Size = new System.Drawing.Size(1020, 67);
            this.label2.TabIndex = 15;
            this.label2.Text = "Intercomunicacion de la Red Vial De Guatemala";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textb_Distanciadepartamento
            // 
            this.textb_Distanciadepartamento.Location = new System.Drawing.Point(73, 225);
            this.textb_Distanciadepartamento.Name = "textb_Distanciadepartamento";
            this.textb_Distanciadepartamento.ReadOnly = true;
            this.textb_Distanciadepartamento.Size = new System.Drawing.Size(86, 20);
            this.textb_Distanciadepartamento.TabIndex = 16;
            // 
            // lablDistanciadesdecapital
            // 
            this.lablDistanciadesdecapital.AutoSize = true;
            this.lablDistanciadesdecapital.Location = new System.Drawing.Point(17, 188);
            this.lablDistanciadesdecapital.Name = "lablDistanciadesdecapital";
            this.lablDistanciadesdecapital.Size = new System.Drawing.Size(213, 13);
            this.lablDistanciadesdecapital.TabIndex = 17;
            this.lablDistanciadesdecapital.Text = "Distancia entre la capital y el departamento ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(220, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ingrese el Departamento #2";
            // 
            // cmbx_departamento2
            // 
            this.cmbx_departamento2.FormattingEnabled = true;
            this.cmbx_departamento2.Location = new System.Drawing.Point(259, 140);
            this.cmbx_departamento2.Name = "cmbx_departamento2";
            this.cmbx_departamento2.Size = new System.Drawing.Size(334, 21);
            this.cmbx_departamento2.TabIndex = 19;
            // 
            // txtb_distentredepartamentos
            // 
            this.txtb_distentredepartamentos.Location = new System.Drawing.Point(277, 225);
            this.txtb_distentredepartamentos.Name = "txtb_distentredepartamentos";
            this.txtb_distentredepartamentos.ReadOnly = true;
            this.txtb_distentredepartamentos.Size = new System.Drawing.Size(107, 20);
            this.txtb_distentredepartamentos.TabIndex = 20;
            // 
            // label_Dis_entreDepartamentos
            // 
            this.label_Dis_entreDepartamentos.AutoSize = true;
            this.label_Dis_entreDepartamentos.Location = new System.Drawing.Point(261, 188);
            this.label_Dis_entreDepartamentos.Name = "label_Dis_entreDepartamentos";
            this.label_Dis_entreDepartamentos.Size = new System.Drawing.Size(154, 13);
            this.label_Dis_entreDepartamentos.TabIndex = 21;
            this.label_Dis_entreDepartamentos.Text = "Distancia entre departamentos ";
            // 
            // escalaKm1
            // 
            this.escalaKm1.AutoSize = true;
            this.escalaKm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escalaKm1.Location = new System.Drawing.Point(165, 228);
            this.escalaKm1.Name = "escalaKm1";
            this.escalaKm1.Size = new System.Drawing.Size(28, 17);
            this.escalaKm1.TabIndex = 22;
            this.escalaKm1.Text = "Km";
            // 
            // escalaKm2
            // 
            this.escalaKm2.AutoSize = true;
            this.escalaKm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.escalaKm2.Location = new System.Drawing.Point(390, 228);
            this.escalaKm2.Name = "escalaKm2";
            this.escalaKm2.Size = new System.Drawing.Size(28, 17);
            this.escalaKm2.TabIndex = 23;
            this.escalaKm2.Text = "Km";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1018, 505);
            this.Controls.Add(this.escalaKm2);
            this.Controls.Add(this.escalaKm1);
            this.Controls.Add(this.label_Dis_entreDepartamentos);
            this.Controls.Add(this.txtb_distentredepartamentos);
            this.Controls.Add(this.cmbx_departamento2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lablDistanciadesdecapital);
            this.Controls.Add(this.textb_Distanciadepartamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbx_Departamento1);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.dtgv1);
            this.Controls.Add(this.btn1);
            this.Name = "FormPrincipal";
            this.ShowInTaskbar = false;
            this.Text = "Red Vial ";
            ((System.ComponentModel.ISupportInitialize)(this.dtgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.DataGridView dtgv1;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.ComboBox cmbx_Departamento1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textb_Distanciadepartamento;
        private System.Windows.Forms.Label lablDistanciadesdecapital;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbx_departamento2;
        private System.Windows.Forms.TextBox txtb_distentredepartamentos;
        private System.Windows.Forms.Label label_Dis_entreDepartamentos;
        private System.Windows.Forms.Label escalaKm1;
        private System.Windows.Forms.Label escalaKm2;
    }
}

