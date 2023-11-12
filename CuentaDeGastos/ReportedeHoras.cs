using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuentaDeGastos
{
    public partial class ReportedeHoras : Form
    {
        HomePage HomePage = new HomePage();
        public ArrayList _Informacion = new ArrayList();
        public static DataTable dt;
        string Actividad, Service_Order, Descripcion;
        public ReportedeHoras()
        {
            InitializeComponent();
        }

        private void ReportedeHoras_Load(object sender, EventArgs e)
        {
            Calendar.MaxDate = DateTime.Today;
            Calendar.SelectionRange = new SelectionRange(DateTime.Today, DateTime.Today);
            VersionTB.Text = HomePage.Version;
            NombreLBL.Text = HomePage.Nombre;
            DepartamentoLBL.Text = HomePage.Departamento;
        }
        private void LLenarTabla()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {           
        }

        private void HorasBTN_Click(object sender, EventArgs e)
        {
            CopiarPegarLBL.Visible = true;
            BorrarFilaLBL.Visible = true;
            InfoDGV.Visible = true;
            DateTime Start_Date = Convert.ToDateTime(Calendar.SelectionStart.ToShortDateString());
            DateTime End_Date = Convert.ToDateTime(Calendar.SelectionEnd.ToShortDateString());
            ArrayList _Days = new ArrayList();
            string s = Start_Date.ToString();
            string[] subs = s.Split(' ');
            _Days.Add(subs[0]);

            while (Start_Date < End_Date)
            {
                Start_Date = Start_Date.AddDays(1);
                string aux = Start_Date.ToString();
                string[] days = aux.Split(' ');
                _Days.Add(days[0]);
            }
            foreach (var item in _Days)
            {
                InfoDGV.Rows.Add(item,0,8,"","N/A","");
            }
            BorrarBTN.Visible = true;
            ContinuarBTN.Visible = true;
        }

        private void InfoDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                InfoDGV.ReadOnly = false;
            }
            if (e.ColumnIndex == 0)
            {
                InfoDGV.ReadOnly = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            InfoDGV.Rows.Clear();
            AgregarDiasBTN.Enabled = true;
            ContinuarBTN.Visible = false;
            BorrarBTN.Visible = false;
        }

        private void InfoDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                if (this.InfoDGV.GetCellCount(DataGridViewElementStates.Selected) > 0)
                {
                    DataObject dataObj = InfoDGV.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);
                }
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                string CopiedContent = Clipboard.GetText();
                string[] Lines = CopiedContent.Split('\n');
                int StartingRow = InfoDGV.CurrentCell.RowIndex;
                int StartingColumn = InfoDGV.CurrentCell.ColumnIndex;
                foreach (var line in Lines)
                {
                    if (StartingRow <= (InfoDGV.Rows.Count - 1))
                    {
                        string[] cells = line.Split('\t');
                        int ColumnIndex = StartingColumn;
                        for (int i = 0; i < cells.Length && ColumnIndex <= (InfoDGV.Columns.Count - 1); i++)
                        {
                            InfoDGV[ColumnIndex++, StartingRow].Value = cells[i];
                        }
                        StartingRow++;
                    }
                }
            }
        }

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ContinuarBTN_Click(object sender, EventArgs e)
        {
            int numerodefilas = InfoDGV.Rows.Count;
            for (int i = 0; i < numerodefilas; i++)
            {
                Actividad = InfoDGV.Rows[i].Cells[3].Value.ToString();
                Service_Order = InfoDGV.Rows[i].Cells[4].Value.ToString();
                Descripcion = InfoDGV.Rows[i].Cells[5].Value.ToString();
                if (InfoDGV.Rows[i].Cells[3].Value.ToString() == "")
                {
                    Actividad = "N/A";
                }
                if (InfoDGV.Rows[i].Cells[4].Value.ToString() == "")
                {
                    Service_Order = "N/A";
                }
                if (InfoDGV.Rows[i].Cells[5].Value.ToString() == "")
                {
                    Descripcion = "N/A";
                }
                HomePage.Array_Reporte_Horas.Add(InfoDGV.Rows[i].Cells[0].Value+";"+ InfoDGV.Rows[i].Cells[1].Value + ";"+ InfoDGV.Rows[i].Cells[2].Value + ";"+ Actividad + ";"+ Service_Order + ";"+ Descripcion + ";");
            }
            HomePage._UpdateReportes(1, HomePage.Array_Reporte_Horas.Count);
            this.Close();
        }
    }
}
