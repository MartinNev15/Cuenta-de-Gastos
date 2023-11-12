namespace CuentaDeGastos
{
    partial class ReportedeHoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportedeHoras));
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.InfoDGV = new System.Windows.Forms.DataGridView();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HorasTraslado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._HorasTrabajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Actividad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._ServiceOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VersionTB = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AgregarDiasBTN = new System.Windows.Forms.Button();
            this.BorrarBTN = new System.Windows.Forms.Button();
            this.ContinuarBTN = new System.Windows.Forms.Button();
            this.DepartamentoLBL = new System.Windows.Forms.Label();
            this.NombreLBL = new System.Windows.Forms.Label();
            this.BorrarFilaLBL = new System.Windows.Forms.Label();
            this.SeleccionarDiasLBL = new System.Windows.Forms.Label();
            this.CopiarPegarLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.Calendar.Location = new System.Drawing.Point(346, 1);
            this.Calendar.MaxDate = new System.DateTime(2022, 3, 17, 0, 0, 0, 0);
            this.Calendar.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.Calendar.Name = "Calendar";
            this.Calendar.ShowToday = false;
            this.Calendar.ShowTodayCircle = false;
            this.Calendar.TabIndex = 0;
            this.Calendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateChanged);
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
            this._HorasTraslado,
            this._HorasTrabajo,
            this._Actividad,
            this._ServiceOrder,
            this._Descripcion});
            this.InfoDGV.GridColor = System.Drawing.Color.White;
            this.InfoDGV.Location = new System.Drawing.Point(115, 175);
            this.InfoDGV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.InfoDGV.MultiSelect = false;
            this.InfoDGV.Name = "InfoDGV";
            this.InfoDGV.ReadOnly = true;
            this.InfoDGV.Size = new System.Drawing.Size(1070, 285);
            this.InfoDGV.TabIndex = 21;
            this.InfoDGV.TabStop = false;
            this.InfoDGV.Visible = false;
            this.InfoDGV.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.InfoDGV_CellMouseClick);
            this.InfoDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InfoDGV_KeyDown);
            // 
            // date
            // 
            this.date.Frozen = true;
            this.date.HeaderText = "Fecha";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 130;
            // 
            // _HorasTraslado
            // 
            this._HorasTraslado.HeaderText = "Horas de Traslado";
            this._HorasTraslado.Name = "_HorasTraslado";
            this._HorasTraslado.ReadOnly = true;
            // 
            // _HorasTrabajo
            // 
            this._HorasTrabajo.HeaderText = "Horas de Trabajo";
            this._HorasTrabajo.Name = "_HorasTrabajo";
            this._HorasTrabajo.ReadOnly = true;
            // 
            // _Actividad
            // 
            this._Actividad.HeaderText = "Actividad";
            this._Actividad.Name = "_Actividad";
            this._Actividad.ReadOnly = true;
            this._Actividad.Width = 250;
            // 
            // _ServiceOrder
            // 
            this._ServiceOrder.HeaderText = "Service Order";
            this._ServiceOrder.Name = "_ServiceOrder";
            this._ServiceOrder.ReadOnly = true;
            this._ServiceOrder.Width = 150;
            // 
            // _Descripcion
            // 
            this._Descripcion.HeaderText = "Descripción";
            this._Descripcion.Name = "_Descripcion";
            this._Descripcion.ReadOnly = true;
            this._Descripcion.Width = 299;
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
            this.VersionTB.TabIndex = 51;
            this.VersionTB.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CuentaDeGastos.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(1150, 535);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 52;
            this.pictureBox1.TabStop = false;
            // 
            // AgregarDiasBTN
            // 
            this.AgregarDiasBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarDiasBTN.Location = new System.Drawing.Point(606, 42);
            this.AgregarDiasBTN.Name = "AgregarDiasBTN";
            this.AgregarDiasBTN.Size = new System.Drawing.Size(150, 47);
            this.AgregarDiasBTN.TabIndex = 53;
            this.AgregarDiasBTN.Text = "Agregar los días";
            this.AgregarDiasBTN.UseVisualStyleBackColor = true;
            this.AgregarDiasBTN.Click += new System.EventHandler(this.HorasBTN_Click);
            // 
            // BorrarBTN
            // 
            this.BorrarBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BorrarBTN.Location = new System.Drawing.Point(685, 470);
            this.BorrarBTN.Name = "BorrarBTN";
            this.BorrarBTN.Size = new System.Drawing.Size(150, 47);
            this.BorrarBTN.TabIndex = 54;
            this.BorrarBTN.Text = "Limpiar Tabla";
            this.BorrarBTN.UseVisualStyleBackColor = true;
            this.BorrarBTN.Visible = false;
            this.BorrarBTN.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ContinuarBTN
            // 
            this.ContinuarBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ContinuarBTN.Location = new System.Drawing.Point(475, 470);
            this.ContinuarBTN.Name = "ContinuarBTN";
            this.ContinuarBTN.Size = new System.Drawing.Size(150, 47);
            this.ContinuarBTN.TabIndex = 55;
            this.ContinuarBTN.Text = "Continuar";
            this.ContinuarBTN.UseVisualStyleBackColor = true;
            this.ContinuarBTN.Visible = false;
            this.ContinuarBTN.Click += new System.EventHandler(this.ContinuarBTN_Click);
            // 
            // DepartamentoLBL
            // 
            this.DepartamentoLBL.AutoSize = true;
            this.DepartamentoLBL.Location = new System.Drawing.Point(7, 28);
            this.DepartamentoLBL.Name = "DepartamentoLBL";
            this.DepartamentoLBL.Size = new System.Drawing.Size(0, 19);
            this.DepartamentoLBL.TabIndex = 58;
            // 
            // NombreLBL
            // 
            this.NombreLBL.AutoSize = true;
            this.NombreLBL.Location = new System.Drawing.Point(7, 9);
            this.NombreLBL.Name = "NombreLBL";
            this.NombreLBL.Size = new System.Drawing.Size(0, 19);
            this.NombreLBL.TabIndex = 57;
            // 
            // BorrarFilaLBL
            // 
            this.BorrarFilaLBL.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BorrarFilaLBL.Location = new System.Drawing.Point(7, 486);
            this.BorrarFilaLBL.Name = "BorrarFilaLBL";
            this.BorrarFilaLBL.Size = new System.Drawing.Size(340, 39);
            this.BorrarFilaLBL.TabIndex = 67;
            this.BorrarFilaLBL.Text = "***Para eliminar una fila, selecciona la fila en la primer columna y dar clic en " +
    "suprimir desde el teclado.";
            this.BorrarFilaLBL.Visible = false;
            // 
            // SeleccionarDiasLBL
            // 
            this.SeleccionarDiasLBL.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeleccionarDiasLBL.Location = new System.Drawing.Point(596, 11);
            this.SeleccionarDiasLBL.Name = "SeleccionarDiasLBL";
            this.SeleccionarDiasLBL.Size = new System.Drawing.Size(217, 28);
            this.SeleccionarDiasLBL.TabIndex = 68;
            this.SeleccionarDiasLBL.Text = "*Puedes seleccionar hasta 7 días.";
            // 
            // CopiarPegarLBL
            // 
            this.CopiarPegarLBL.Font = new System.Drawing.Font("Euromode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopiarPegarLBL.Location = new System.Drawing.Point(846, 113);
            this.CopiarPegarLBL.Name = "CopiarPegarLBL";
            this.CopiarPegarLBL.Size = new System.Drawing.Size(274, 57);
            this.CopiarPegarLBL.TabIndex = 69;
            this.CopiarPegarLBL.Text = "**Puedes usar \"CTRL +  C\" para copiar una celda y \"CTRL + V\" para pegar la celda " +
    "copiada";
            this.CopiarPegarLBL.Visible = false;
            // 
            // ReportedeHoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1284, 600);
            this.Controls.Add(this.CopiarPegarLBL);
            this.Controls.Add(this.SeleccionarDiasLBL);
            this.Controls.Add(this.BorrarFilaLBL);
            this.Controls.Add(this.DepartamentoLBL);
            this.Controls.Add(this.NombreLBL);
            this.Controls.Add(this.ContinuarBTN);
            this.Controls.Add(this.BorrarBTN);
            this.Controls.Add(this.AgregarDiasBTN);
            this.Controls.Add(this.VersionTB);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InfoDGV);
            this.Controls.Add(this.Calendar);
            this.Font = new System.Drawing.Font("Euromode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ReportedeHoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportedeHoras";
            this.Load += new System.EventHandler(this.ReportedeHoras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InfoDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.DataGridView InfoDGV;
        private System.Windows.Forms.TextBox VersionTB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AgregarDiasBTN;
        private System.Windows.Forms.Button BorrarBTN;
        private System.Windows.Forms.Button ContinuarBTN;
        private System.Windows.Forms.Label DepartamentoLBL;
        private System.Windows.Forms.Label NombreLBL;
        private System.Windows.Forms.Label BorrarFilaLBL;
        private System.Windows.Forms.Label SeleccionarDiasLBL;
        private System.Windows.Forms.Label CopiarPegarLBL;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HorasTraslado;
        private System.Windows.Forms.DataGridViewTextBoxColumn _HorasTrabajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Actividad;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ServiceOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Descripcion;
    }
}