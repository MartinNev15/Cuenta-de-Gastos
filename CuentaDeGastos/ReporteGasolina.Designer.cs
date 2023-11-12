namespace CuentaDeGastos
{
    partial class ReporteGasolina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteGasolina));
            this.DepartamentoLBL = new System.Windows.Forms.Label();
            this.NombreLBL = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MontoTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SOTB = new System.Windows.Forms.TextBox();
            this.DetallesTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this._Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._SO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Detalles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GenerarBTN = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.VersionTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DepartamentoLBL
            // 
            this.DepartamentoLBL.AutoSize = true;
            this.DepartamentoLBL.Location = new System.Drawing.Point(7, 28);
            this.DepartamentoLBL.Name = "DepartamentoLBL";
            this.DepartamentoLBL.Size = new System.Drawing.Size(0, 19);
            this.DepartamentoLBL.TabIndex = 30;
            // 
            // NombreLBL
            // 
            this.NombreLBL.AutoSize = true;
            this.NombreLBL.Location = new System.Drawing.Point(7, 9);
            this.NombreLBL.Name = "NombreLBL";
            this.NombreLBL.Size = new System.Drawing.Size(0, 19);
            this.NombreLBL.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Euromode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(615, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(557, 18);
            this.label7.TabIndex = 59;
            this.label7.Text = "Usa TAB para navegar entre los campos de texto. Clic en ENTER desde el teclado pa" +
    "ra agregar.";
            // 
            // MontoTB
            // 
            this.MontoTB.Location = new System.Drawing.Point(784, 114);
            this.MontoTB.Name = "MontoTB";
            this.MontoTB.Size = new System.Drawing.Size(328, 26);
            this.MontoTB.TabIndex = 4;
            this.MontoTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MontoTB_KeyDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(715, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 58;
            this.label6.Text = "Monto:";
            // 
            // SOTB
            // 
            this.SOTB.Location = new System.Drawing.Point(254, 114);
            this.SOTB.Name = "SOTB";
            this.SOTB.Size = new System.Drawing.Size(328, 26);
            this.SOTB.TabIndex = 2;
            this.SOTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SOTB_KeyDown);
            // 
            // DetallesTB
            // 
            this.DetallesTB.Location = new System.Drawing.Point(784, 85);
            this.DetallesTB.Name = "DetallesTB";
            this.DetallesTB.Size = new System.Drawing.Size(328, 26);
            this.DetallesTB.TabIndex = 3;
            this.DetallesTB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetallesTB_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(703, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 57;
            this.label4.Text = "Detalles:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(126, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 19);
            this.label5.TabIndex = 56;
            this.label5.Text = "Service Order:";
            // 
            // FechaTP
            // 
            this.FechaTP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechaTP.Location = new System.Drawing.Point(254, 85);
            this.FechaTP.MaxDate = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            this.FechaTP.MinDate = new System.DateTime(2021, 1, 1, 0, 0, 0, 0);
            this.FechaTP.Name = "FechaTP";
            this.FechaTP.Size = new System.Drawing.Size(328, 26);
            this.FechaTP.TabIndex = 1;
            this.FechaTP.Value = new System.DateTime(2022, 2, 22, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 55;
            this.label3.Text = "Fecha:";
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
            this._Fecha,
            this._SO,
            this._Detalles,
            this._Monto});
            this.InfoDGV.GridColor = System.Drawing.Color.White;
            this.InfoDGV.Location = new System.Drawing.Point(115, 176);
            this.InfoDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InfoDGV.MultiSelect = false;
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.ReadOnly = true;
            this.InfoDGV.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.InfoDGV.Size = new System.Drawing.Size(1070, 285);
            this.InfoDGV.TabIndex = 61;
            this.InfoDGV.TabStop = false;
            // 
            // _Fecha
            // 
            this._Fecha.Frozen = true;
            this._Fecha.HeaderText = "Fecha";
            this._Fecha.Name = "_Fecha";
            this._Fecha.ReadOnly = true;
            this._Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._Fecha.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._Fecha.Width = 200;
            // 
            // _SO
            // 
            this._SO.HeaderText = "Service Order";
            this._SO.Name = "_SO";
            this._SO.ReadOnly = true;
            this._SO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this._SO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this._SO.Width = 200;
            // 
            // _Detalles
            // 
            this._Detalles.HeaderText = "Detalles";
            this._Detalles.Name = "_Detalles";
            this._Detalles.ReadOnly = true;
            this._Detalles.Width = 410;
            // 
            // _Monto
            // 
            this._Monto.HeaderText = "Monto";
            this._Monto.Name = "_Monto";
            this._Monto.ReadOnly = true;
            this._Monto.Width = 200;
            // 
            // GenerarBTN
            // 
            this.GenerarBTN.BackColor = System.Drawing.Color.White;
            this.GenerarBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GenerarBTN.ForeColor = System.Drawing.Color.Black;
            this.GenerarBTN.Location = new System.Drawing.Point(550, 484);
            this.GenerarBTN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GenerarBTN.Name = "GenerarBTN";
            this.GenerarBTN.Size = new System.Drawing.Size(200, 47);
            this.GenerarBTN.TabIndex = 62;
            this.GenerarBTN.TabStop = false;
            this.GenerarBTN.Text = "Continuar";
            this.GenerarBTN.UseVisualStyleBackColor = false;
            this.GenerarBTN.Click += new System.EventHandler(this.GenerarBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CuentaDeGastos.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(1150, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 64;
            this.pictureBox1.TabStop = false;
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
            this.VersionTB.TabIndex = 65;
            this.VersionTB.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 47);
            this.label1.TabIndex = 68;
            this.label1.Text = "***Para eliminar una fila, selecciona la fila en la primer columna y dar clic en " +
    "suprimir desde el teclado.";
            // 
            // ReporteGasolina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VersionTB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.GenerarBTN);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MontoTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.SOTB);
            this.Controls.Add(this.DetallesTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.FechaTP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DepartamentoLBL);
            this.Controls.Add(this.NombreLBL);
            this.Font = new System.Drawing.Font("Euromode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReporteGasolina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteGasolina";
            this.Load += new System.EventHandler(this.ReporteGasolina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DepartamentoLBL;
        private System.Windows.Forms.Label NombreLBL;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox MontoTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox SOTB;
        private System.Windows.Forms.TextBox DetallesTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker FechaTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView InfoDGV;
        private System.Windows.Forms.Button GenerarBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox VersionTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn _SO;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Detalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Monto;
    }
}