namespace CuentaDeGastos
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.GasolinaBTN = new System.Windows.Forms.Button();
            this.HorasBTN = new System.Windows.Forms.Button();
            this.NombreCB = new System.Windows.Forms.ComboBox();
            this.DepartamentosCB = new System.Windows.Forms.ComboBox();
            this.FechaTP = new System.Windows.Forms.DateTimePicker();
            this.CargarXMLBTN = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TittleTB = new System.Windows.Forms.TextBox();
            this.VersionTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.AbrirExcelCheck = new System.Windows.Forms.CheckBox();
            this.GenerarBTN = new System.Windows.Forms.Button();
            this.SemanaCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CargarCuentadeGastosBTN = new System.Windows.Forms.Button();
            this.LoadingPanel = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            this.LoadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // GasolinaBTN
            // 
            this.GasolinaBTN.Enabled = false;
            this.GasolinaBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GasolinaBTN.Location = new System.Drawing.Point(932, 70);
            this.GasolinaBTN.Name = "GasolinaBTN";
            this.GasolinaBTN.Size = new System.Drawing.Size(150, 50);
            this.GasolinaBTN.TabIndex = 5;
            this.GasolinaBTN.Text = "Gasolina";
            this.GasolinaBTN.UseVisualStyleBackColor = true;
            this.GasolinaBTN.Visible = false;
            this.GasolinaBTN.Click += new System.EventHandler(this.GasolinaBTN_Click);
            // 
            // HorasBTN
            // 
            this.HorasBTN.Enabled = false;
            this.HorasBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HorasBTN.Location = new System.Drawing.Point(1092, 70);
            this.HorasBTN.Name = "HorasBTN";
            this.HorasBTN.Size = new System.Drawing.Size(150, 50);
            this.HorasBTN.TabIndex = 6;
            this.HorasBTN.Text = "Reporte de Horas";
            this.HorasBTN.UseVisualStyleBackColor = true;
            this.HorasBTN.Visible = false;
            this.HorasBTN.Click += new System.EventHandler(this.HorasBTN_Click);
            // 
            // NombreCB
            // 
            this.NombreCB.BackColor = System.Drawing.Color.White;
            this.NombreCB.FormattingEnabled = true;
            this.NombreCB.Location = new System.Drawing.Point(134, 70);
            this.NombreCB.Name = "NombreCB";
            this.NombreCB.Size = new System.Drawing.Size(376, 28);
            this.NombreCB.TabIndex = 2;
            // 
            // DepartamentosCB
            // 
            this.DepartamentosCB.FormattingEnabled = true;
            this.DepartamentosCB.Location = new System.Drawing.Point(134, 40);
            this.DepartamentosCB.Name = "DepartamentosCB";
            this.DepartamentosCB.Size = new System.Drawing.Size(376, 28);
            this.DepartamentosCB.TabIndex = 1;
            this.DepartamentosCB.SelectedIndexChanged += new System.EventHandler(this.DepartamentosCB_SelectedIndexChanged);
            // 
            // FechaTP
            // 
            this.FechaTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaTP.Location = new System.Drawing.Point(134, 100);
            this.FechaTP.MaxDate = new System.DateTime(2022, 2, 14, 0, 0, 0, 0);
            this.FechaTP.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.FechaTP.Name = "FechaTP";
            this.FechaTP.Size = new System.Drawing.Size(376, 27);
            this.FechaTP.TabIndex = 3;
            this.FechaTP.Value = new System.DateTime(2022, 2, 14, 0, 0, 0, 0);
            this.FechaTP.ValueChanged += new System.EventHandler(this.FechaTP_ValueChanged);
            // 
            // CargarXMLBTN
            // 
            this.CargarXMLBTN.BackColor = System.Drawing.Color.White;
            this.CargarXMLBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CargarXMLBTN.ForeColor = System.Drawing.Color.Black;
            this.CargarXMLBTN.Location = new System.Drawing.Point(772, 70);
            this.CargarXMLBTN.Name = "CargarXMLBTN";
            this.CargarXMLBTN.Size = new System.Drawing.Size(150, 50);
            this.CargarXMLBTN.TabIndex = 4;
            this.CargarXMLBTN.Text = "Cargar XML";
            this.CargarXMLBTN.UseVisualStyleBackColor = false;
            this.CargarXMLBTN.Click += new System.EventHandler(this.CargarXMLBTN_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Fecha:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Departamento:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Nombre:";
            // 
            // TittleTB
            // 
            this.TittleTB.BackColor = System.Drawing.Color.White;
            this.TittleTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TittleTB.Font = new System.Drawing.Font("Euromode", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TittleTB.Location = new System.Drawing.Point(500, 0);
            this.TittleTB.Name = "TittleTB";
            this.TittleTB.ReadOnly = true;
            this.TittleTB.Size = new System.Drawing.Size(300, 39);
            this.TittleTB.TabIndex = 15;
            this.TittleTB.TabStop = false;
            this.TittleTB.Text = "Cuenta de Gastos";
            this.TittleTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // VersionTB
            // 
            this.VersionTB.BackColor = System.Drawing.Color.White;
            this.VersionTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionTB.Enabled = false;
            this.VersionTB.Font = new System.Drawing.Font("Euromode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionTB.Location = new System.Drawing.Point(995, 585);
            this.VersionTB.Name = "VersionTB";
            this.VersionTB.ReadOnly = true;
            this.VersionTB.Size = new System.Drawing.Size(142, 14);
            this.VersionTB.TabIndex = 17;
            this.VersionTB.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CuentaDeGastos.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(1150, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // InfoDGV
            // 
            this.InfoDGV.AllowUserToAddRows = false;
            this.InfoDGV.AllowUserToDeleteRows = false;
            this.InfoDGV.AllowUserToResizeColumns = false;
            this.InfoDGV.AllowUserToResizeRows = false;
            this.InfoDGV.BackgroundColor = System.Drawing.Color.White;
            this.InfoDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDGV.GridColor = System.Drawing.Color.White;
            this.InfoDGV.Location = new System.Drawing.Point(450, 255);
            this.InfoDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InfoDGV.MultiSelect = false;
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.ReadOnly = true;
            this.InfoDGV.RowHeadersVisible = false;
            this.InfoDGV.Size = new System.Drawing.Size(404, 127);
            this.InfoDGV.TabIndex = 23;
            this.InfoDGV.TabStop = false;
            // 
            // AbrirExcelCheck
            // 
            this.AbrirExcelCheck.AutoSize = true;
            this.AbrirExcelCheck.Checked = true;
            this.AbrirExcelCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AbrirExcelCheck.Location = new System.Drawing.Point(550, 564);
            this.AbrirExcelCheck.Name = "AbrirExcelCheck";
            this.AbrirExcelCheck.Size = new System.Drawing.Size(199, 24);
            this.AbrirExcelCheck.TabIndex = 46;
            this.AbrirExcelCheck.TabStop = false;
            this.AbrirExcelCheck.Text = "  Abrir Excel al Crearlo";
            this.AbrirExcelCheck.UseVisualStyleBackColor = true;
            // 
            // GenerarBTN
            // 
            this.GenerarBTN.BackColor = System.Drawing.Color.White;
            this.GenerarBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerarBTN.ForeColor = System.Drawing.Color.Black;
            this.GenerarBTN.Location = new System.Drawing.Point(550, 509);
            this.GenerarBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GenerarBTN.Name = "GenerarBTN";
            this.GenerarBTN.Size = new System.Drawing.Size(200, 50);
            this.GenerarBTN.TabIndex = 45;
            this.GenerarBTN.TabStop = false;
            this.GenerarBTN.Text = "Generar Excel";
            this.GenerarBTN.UseVisualStyleBackColor = false;
            this.GenerarBTN.Click += new System.EventHandler(this.GenerarBTN_Click);
            // 
            // SemanaCB
            // 
            this.SemanaCB.BackColor = System.Drawing.Color.White;
            this.SemanaCB.FormattingEnabled = true;
            this.SemanaCB.Items.AddRange(new object[] {
            "Semana 1",
            "Semana 2",
            "Semana 3",
            "Semana 4",
            "Semana 5"});
            this.SemanaCB.Location = new System.Drawing.Point(134, 130);
            this.SemanaCB.Name = "SemanaCB";
            this.SemanaCB.Size = new System.Drawing.Size(376, 28);
            this.SemanaCB.TabIndex = 47;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "Semana:";
            // 
            // CargarCuentadeGastosBTN
            // 
            this.CargarCuentadeGastosBTN.BackColor = System.Drawing.Color.White;
            this.CargarCuentadeGastosBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CargarCuentadeGastosBTN.ForeColor = System.Drawing.Color.Black;
            this.CargarCuentadeGastosBTN.Location = new System.Drawing.Point(12, 538);
            this.CargarCuentadeGastosBTN.Name = "CargarCuentadeGastosBTN";
            this.CargarCuentadeGastosBTN.Size = new System.Drawing.Size(200, 50);
            this.CargarCuentadeGastosBTN.TabIndex = 49;
            this.CargarCuentadeGastosBTN.Text = "Cargar Cuenta de Gastos";
            this.CargarCuentadeGastosBTN.UseVisualStyleBackColor = false;
            this.CargarCuentadeGastosBTN.Click += new System.EventHandler(this.CargarCuentadeGastosBTN_Click);
            // 
            // LoadingPanel
            // 
            this.LoadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.LoadingPanel.Controls.Add(this.label5);
            this.LoadingPanel.Location = new System.Drawing.Point(12, 172);
            this.LoadingPanel.Name = "LoadingPanel";
            this.LoadingPanel.Size = new System.Drawing.Size(1252, 337);
            this.LoadingPanel.TabIndex = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Euromode", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(410, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(305, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cargando... Favor de Esperar";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 600);
            this.Controls.Add(this.LoadingPanel);
            this.Controls.Add(this.CargarCuentadeGastosBTN);
            this.Controls.Add(this.SemanaCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AbrirExcelCheck);
            this.Controls.Add(this.GenerarBTN);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.GasolinaBTN);
            this.Controls.Add(this.HorasBTN);
            this.Controls.Add(this.NombreCB);
            this.Controls.Add(this.DepartamentosCB);
            this.Controls.Add(this.FechaTP);
            this.Controls.Add(this.CargarXMLBTN);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TittleTB);
            this.Controls.Add(this.VersionTB);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Euromode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            this.LoadingPanel.ResumeLayout(false);
            this.LoadingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GasolinaBTN;
        private System.Windows.Forms.Button HorasBTN;
        private System.Windows.Forms.ComboBox NombreCB;
        private System.Windows.Forms.ComboBox DepartamentosCB;
        private System.Windows.Forms.DateTimePicker FechaTP;
        private System.Windows.Forms.Button CargarXMLBTN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TittleTB;
        private System.Windows.Forms.TextBox VersionTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView InfoDGV;
        private System.Windows.Forms.CheckBox AbrirExcelCheck;
        private System.Windows.Forms.Button GenerarBTN;
        private System.Windows.Forms.ComboBox SemanaCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CargarCuentadeGastosBTN;
        private System.Windows.Forms.Panel LoadingPanel;
        private System.Windows.Forms.Label label5;
    }
}

