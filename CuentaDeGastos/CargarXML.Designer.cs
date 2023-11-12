namespace CuentaDeGastos
{
    partial class CargarXML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarXML));
            this.GenerarBTN = new System.Windows.Forms.Button();
            this.FechaLBL = new System.Windows.Forms.Label();
            this.DepartamentoLBL = new System.Windows.Forms.Label();
            this.NombreLBL = new System.Windows.Forms.Label();
            this.CargarXMLBTN = new System.Windows.Forms.Button();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Propina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info2LBL = new System.Windows.Forms.Label();
            this.VersionTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AlertaFactura = new System.Windows.Forms.Label();
            this.BorrarFilaLBL = new System.Windows.Forms.Label();
            this.bbvaRD = new System.Windows.Forms.RadioButton();
            this.amexRB = new System.Windows.Forms.RadioButton();
            this.TarjetasGB = new System.Windows.Forms.GroupBox();
            this.GastosLBL = new System.Windows.Forms.Label();
            this.GastosNUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TarjetasGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GastosNUD)).BeginInit();
            this.SuspendLayout();
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
            this.GenerarBTN.TabIndex = 28;
            this.GenerarBTN.TabStop = false;
            this.GenerarBTN.Text = "Continuar";
            this.GenerarBTN.UseVisualStyleBackColor = false;
            this.GenerarBTN.Visible = false;
            this.GenerarBTN.Click += new System.EventHandler(this.GenerarBTN_Click);
            // 
            // FechaLBL
            // 
            this.FechaLBL.AutoSize = true;
            this.FechaLBL.Location = new System.Drawing.Point(415, 54);
            this.FechaLBL.Name = "FechaLBL";
            this.FechaLBL.Size = new System.Drawing.Size(0, 20);
            this.FechaLBL.TabIndex = 26;
            // 
            // DepartamentoLBL
            // 
            this.DepartamentoLBL.AutoSize = true;
            this.DepartamentoLBL.Location = new System.Drawing.Point(415, 34);
            this.DepartamentoLBL.Name = "DepartamentoLBL";
            this.DepartamentoLBL.Size = new System.Drawing.Size(0, 20);
            this.DepartamentoLBL.TabIndex = 25;
            // 
            // NombreLBL
            // 
            this.NombreLBL.AutoSize = true;
            this.NombreLBL.Location = new System.Drawing.Point(415, 14);
            this.NombreLBL.Name = "NombreLBL";
            this.NombreLBL.Size = new System.Drawing.Size(0, 20);
            this.NombreLBL.TabIndex = 24;
            // 
            // CargarXMLBTN
            // 
            this.CargarXMLBTN.BackColor = System.Drawing.Color.White;
            this.CargarXMLBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CargarXMLBTN.ForeColor = System.Drawing.Color.Black;
            this.CargarXMLBTN.Location = new System.Drawing.Point(15, 12);
            this.CargarXMLBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CargarXMLBTN.Name = "CargarXMLBTN";
            this.CargarXMLBTN.Size = new System.Drawing.Size(150, 50);
            this.CargarXMLBTN.TabIndex = 1;
            this.CargarXMLBTN.TabStop = false;
            this.CargarXMLBTN.Text = "Abrir Explorador de Archivos";
            this.CargarXMLBTN.UseVisualStyleBackColor = false;
            this.CargarXMLBTN.Click += new System.EventHandler(this.CargarXMLBTN_Click);
            // 
            // InfoDGV
            // 
            this.InfoDGV.AllowUserToAddRows = false;
            this.InfoDGV.AllowUserToResizeColumns = false;
            this.InfoDGV.AllowUserToResizeRows = false;
            this.InfoDGV.BackgroundColor = System.Drawing.Color.White;
            this.InfoDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InfoDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.date,
            this._subtotal,
            this._total,
            this._cuenta,
            this._Desc,
            this._Propina});
            this.InfoDGV.GridColor = System.Drawing.Color.White;
            this.InfoDGV.Location = new System.Drawing.Point(15, 143);
            this.InfoDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InfoDGV.MultiSelect = false;
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.Size = new System.Drawing.Size(1256, 300);
            this.InfoDGV.TabIndex = 20;
            this.InfoDGV.TabStop = false;
            this.InfoDGV.Visible = false;
            this.InfoDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InfoDGV_CellContentClick);
            this.InfoDGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InfoDGV_CellMouseClick);
            this.InfoDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoDGV_KeyDown);
            // 
            // date
            // 
            this.date.Frozen = true;
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            // 
            // _subtotal
            // 
            this._subtotal.Frozen = true;
            this._subtotal.HeaderText = "Subtotal";
            this._subtotal.Name = "_subtotal";
            // 
            // _total
            // 
            this._total.Frozen = true;
            this._total.HeaderText = "Total";
            this._total.Name = "_total";
            // 
            // _cuenta
            // 
            this._cuenta.HeaderText = "Factura";
            this._cuenta.Name = "_cuenta";
            this._cuenta.Width = 220;
            // 
            // _Desc
            // 
            this._Desc.HeaderText = "Descripción de la Compra";
            this._Desc.Name = "_Desc";
            this._Desc.Width = 300;
            // 
            // _Propina
            // 
            this._Propina.HeaderText = "Propina";
            this._Propina.Name = "_Propina";
            // 
            // Info2LBL
            // 
            this.Info2LBL.Location = new System.Drawing.Point(748, 99);
            this.Info2LBL.Name = "Info2LBL";
            this.Info2LBL.Size = new System.Drawing.Size(394, 39);
            this.Info2LBL.TabIndex = 47;
            this.Info2LBL.Text = "Doble clic en Descripción o Propina para editarlo";
            this.Info2LBL.Visible = false;
            // 
            // VersionTB
            // 
            this.VersionTB.BackColor = System.Drawing.Color.White;
            this.VersionTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VersionTB.Enabled = false;
            this.VersionTB.Font = new System.Drawing.Font("Euromode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionTB.Location = new System.Drawing.Point(1000, 585);
            this.VersionTB.Name = "VersionTB";
            this.VersionTB.ReadOnly = true;
            this.VersionTB.Size = new System.Drawing.Size(142, 14);
            this.VersionTB.TabIndex = 49;
            this.VersionTB.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CuentaDeGastos.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(1150, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // AlertaFactura
            // 
            this.AlertaFactura.Font = new System.Drawing.Font("Euromode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlertaFactura.Location = new System.Drawing.Point(18, 448);
            this.AlertaFactura.Name = "AlertaFactura";
            this.AlertaFactura.Size = new System.Drawing.Size(1006, 20);
            this.AlertaFactura.TabIndex = 51;
            this.AlertaFactura.Text = "***Los registros en color ROJO son porque la factura fue emitida en una versión m" +
    "enor a 4.0***";
            this.AlertaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AlertaFactura.Visible = false;
            // 
            // BorrarFilaLBL
            // 
            this.BorrarFilaLBL.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrarFilaLBL.Location = new System.Drawing.Point(10, 468);
            this.BorrarFilaLBL.Name = "BorrarFilaLBL";
            this.BorrarFilaLBL.Size = new System.Drawing.Size(244, 41);
            this.BorrarFilaLBL.TabIndex = 68;
            this.BorrarFilaLBL.Text = "***Para eliminar una fila, selecciona la fila en la primer columna y dar clic en " +
    "suprimir desde el teclado.";
            this.BorrarFilaLBL.Visible = false;
            // 
            // bbvaRD
            // 
            this.bbvaRD.AutoSize = true;
            this.bbvaRD.Checked = true;
            this.bbvaRD.Location = new System.Drawing.Point(6, 22);
            this.bbvaRD.Name = "bbvaRD";
            this.bbvaRD.Size = new System.Drawing.Size(70, 24);
            this.bbvaRD.TabIndex = 69;
            this.bbvaRD.TabStop = true;
            this.bbvaRD.Text = "BBVA";
            this.bbvaRD.UseVisualStyleBackColor = true;
            // 
            // amexRB
            // 
            this.amexRB.AutoSize = true;
            this.amexRB.Location = new System.Drawing.Point(6, 45);
            this.amexRB.Name = "amexRB";
            this.amexRB.Size = new System.Drawing.Size(72, 24);
            this.amexRB.TabIndex = 72;
            this.amexRB.Text = "AMEX";
            this.amexRB.UseVisualStyleBackColor = true;
            // 
            // TarjetasGB
            // 
            this.TarjetasGB.Controls.Add(this.bbvaRD);
            this.TarjetasGB.Controls.Add(this.amexRB);
            this.TarjetasGB.Location = new System.Drawing.Point(15, 67);
            this.TarjetasGB.Name = "TarjetasGB";
            this.TarjetasGB.Size = new System.Drawing.Size(141, 68);
            this.TarjetasGB.TabIndex = 73;
            this.TarjetasGB.TabStop = false;
            this.TarjetasGB.Text = "Tipo de Tarjeta";
            this.TarjetasGB.Visible = false;
            // 
            // GastosLBL
            // 
            this.GastosLBL.AutoSize = true;
            this.GastosLBL.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GastosLBL.Location = new System.Drawing.Point(174, 89);
            this.GastosLBL.Name = "GastosLBL";
            this.GastosLBL.Size = new System.Drawing.Size(111, 16);
            this.GastosLBL.TabIndex = 75;
            this.GastosLBL.Text = "Iniciar gastos en:";
            this.GastosLBL.Visible = false;
            // 
            // GastosNUD
            // 
            this.GastosNUD.ForeColor = System.Drawing.Color.Black;
            this.GastosNUD.Location = new System.Drawing.Point(177, 108);
            this.GastosNUD.Name = "GastosNUD";
            this.GastosNUD.Size = new System.Drawing.Size(101, 27);
            this.GastosNUD.TabIndex = 76;
            this.GastosNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.GastosNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GastosNUD.Visible = false;
            // 
            // CargarXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 600);
            this.Controls.Add(this.GastosNUD);
            this.Controls.Add(this.GastosLBL);
            this.Controls.Add(this.TarjetasGB);
            this.Controls.Add(this.BorrarFilaLBL);
            this.Controls.Add(this.AlertaFactura);
            this.Controls.Add(this.VersionTB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Info2LBL);
            this.Controls.Add(this.GenerarBTN);
            this.Controls.Add(this.FechaLBL);
            this.Controls.Add(this.DepartamentoLBL);
            this.Controls.Add(this.NombreLBL);
            this.Controls.Add(this.CargarXMLBTN);
            this.Controls.Add(this.InfoDGV);
            this.Font = new System.Drawing.Font("Euromode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CargarXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CargarXML";
            this.Load += new System.EventHandler(this.CargarXML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TarjetasGB.ResumeLayout(false);
            this.TarjetasGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GastosNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerarBTN;
        private System.Windows.Forms.Label FechaLBL;
        private System.Windows.Forms.Label DepartamentoLBL;
        private System.Windows.Forms.Label NombreLBL;
        private System.Windows.Forms.Button CargarXMLBTN;
        private System.Windows.Forms.DataGridView InfoDGV;
        private System.Windows.Forms.Label Info2LBL;
        private System.Windows.Forms.TextBox VersionTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label AlertaFactura;
        private System.Windows.Forms.Label BorrarFilaLBL;
        private System.Windows.Forms.RadioButton bbvaRD;
        private System.Windows.Forms.RadioButton amexRB;
        private System.Windows.Forms.GroupBox TarjetasGB;
        private System.Windows.Forms.Label GastosLBL;
        private System.Windows.Forms.NumericUpDown GastosNUD;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn _total;
        private System.Windows.Forms.DataGridViewTextBoxColumn _cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Propina;
    }
}