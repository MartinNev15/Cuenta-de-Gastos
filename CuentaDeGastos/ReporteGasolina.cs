using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace CuentaDeGastos
{
    public partial class ReporteGasolina : Form
    {
        public string _Date;
        public ArrayList _Informacion = new ArrayList();
        HomePage HomePage = new HomePage();
        string Service_Order, Detalles;

        public ReporteGasolina()
        {
            InitializeComponent();
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReporteGasolina_Load(object sender, EventArgs e)
        {
            FechaTP.CustomFormat = "dd/MM/yyyy";
            FechaTP.MaxDate = DateTime.Today;
            FechaTP.Value = DateTime.Today;
            NombreLBL.Text = HomePage.Nombre;
            DepartamentoLBL.Text = HomePage.Departamento;
            VersionTB.Text = HomePage.Version;
        }
        public void _AgregarRow()
        {
            string Service_Order = SOTB.Text;
            string Detalles = DetallesTB.Text;
            double Monto;

            if (SOTB.Text == "")
            {
                Service_Order = "N/A";
            }
            if (DetallesTB.Text == "")
            {
                Detalles = "N/A";
            }
            try
            {
                Monto = Convert.ToDouble(MontoTB.Text);
                string datos = FechaTP.Text + ";" + Service_Order + ";" + Detalles + ";" + MontoTB.Text + ";";
                _Informacion.Add(datos);
                InfoDGV.Rows.Add(FechaTP.Text, Service_Order, Detalles, MontoTB.Text);
                FechaTP.Text = "";
                SOTB.Text = "";
                DetallesTB.Text = "";
                MontoTB.Text = "";
                Service_Order = "";
                Detalles = "";
                FechaTP.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("No ingresaste un Monto válido");
                MontoTB.Focus();
            }

        }
        //-------------------------------Clic Enter en los textbox
        private void SOTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _AgregarRow();
            }
        }
        private void DetallesTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _AgregarRow();
            }
        }
        private void MontoTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                _AgregarRow();
            }
        }

        //-------------------------------Generar Excel
        private void GenerarBTN_Click(object sender, EventArgs e)
        {
            int numerodefilas = InfoDGV.Rows.Count;
            if (numerodefilas > 0)
            {
                for (int i = 0; i < numerodefilas; i++)
                {
                    HomePage.Array_Reporte_Gasolina.Add(InfoDGV.Rows[i].Cells[0].Value + ";" + InfoDGV.Rows[i].Cells[1].Value + ";" + InfoDGV.Rows[i].Cells[2].Value + ";" + InfoDGV.Rows[i].Cells[3].Value + ";");
                }
                HomePage._UpdateReportes(2, HomePage.Array_Reporte_Gasolina.Count);
                this.Close();
            }
            else
            {
                MessageBox.Show("No hay datos registrados");
            }          
        }
    }
}
