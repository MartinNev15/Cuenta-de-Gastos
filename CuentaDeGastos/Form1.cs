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
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace CuentaDeGastos
{
    public partial class HomePage : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public static string _Fecha, FechaFolder, Nombre, Departamento, Semana;
        System.Data.DataTable table = new System.Data.DataTable();
        LoadingForm LoadingForm = new LoadingForm();
        public static int countGastos = 0;
        public static List<Tuple<string, string>> Empleados = new List<Tuple<string, string>>();
        public static List<Tuple<string, string, string>> Cuentas = new List<Tuple<string, string, string>>();
        public static ArrayList Array_Cuentas = new ArrayList();
        public static ArrayList Array_CuentasDescripcion = new ArrayList();
        public static ArrayList Array_Reporte_Xml = new ArrayList();
        public static ArrayList Array_Reporte_Horas = new ArrayList();
        public static ArrayList Array_Reporte_Gasolina = new ArrayList();
        public static ArrayList Array_Reporte_Reporte = new ArrayList();
        public static string Tipo_Tarjeta;
        //public static string Version = "Cuenta de Gastos 2 v1.1.1";
        //public static string Version = "Cuenta de Gastos 2 v1.2.0";
        public static string Version = "Cuenta de Gastos 2 v1.2.1";

        /*
        Version v1.2.1

        Solucionado los impuestos trasladados
        No registraba los importes excentos

        */
        double numVersion = 4, auxVersion;
        public static DataTable dt;
        Assembly asm = Assembly.GetExecutingAssembly();
        decimal costo;
        private void CancelBTN_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void CargarXMLBTN_Click(object sender, EventArgs e)
        {
            if (DepartamentosCB.Text != "" && NombreCB.Text != "" && SemanaCB.Text != "")
            {
                Nombre = NombreCB.Text;
                Departamento = DepartamentosCB.Text;
                Semana = SemanaCB.Text;
                _Fecha = FechaTP.Text;
                _BloquearCB();
                CargarXML form = new CargarXML();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Debes llenar el Departamento,  Nombre y Semana antes de continuar");
            }
        }
        private void HorasBTN_Click(object sender, EventArgs e)//--------descomentar lo interno
        {
            if (DepartamentosCB.Text != "" && NombreCB.Text != "" && SemanaCB.Text != "")
            {
                _Fecha = FechaTP.Text;
                Nombre = NombreCB.Text;
                Departamento = DepartamentosCB.Text;
                Semana = SemanaCB.Text;
                _BloquearCB();
                ReportedeHoras RH = new ReportedeHoras();
                RH.Show();
            }
            else
            {
                MessageBox.Show("Debes llenar el Departamento y Nombre antes de continuar");
            }
        }
        private void GasolinaBTN_Click(object sender, EventArgs e)
        {
            if (DepartamentosCB.Text != "" && NombreCB.Text != "" && SemanaCB.Text != "")
            {
                Nombre = NombreCB.Text;
                Departamento = DepartamentosCB.Text;
                _Fecha = FechaTP.Text;
                Semana = SemanaCB.Text;
                _BloquearCB();
                ReporteGasolina ReporteGasolina = new ReporteGasolina();
                ReporteGasolina.Show();
            }
            else
            {
                MessageBox.Show("Debes llenar el Departamento y Nombre antes de continuar");
            }
        }

        public HomePage()
        {
            InitializeComponent();
        }


        private void HomePage_Load(object sender, EventArgs e)
        {
            FechaTP.Format = DateTimePickerFormat.Custom;
            FechaTP.CustomFormat = "MMMM yyyy";
            FechaTP.ShowUpDown = true;
            FechaTP.MaxDate = DateTime.Today;
            FechaTP.Value = DateTime.Today;
            VersionTB.Text = Version;
            LoadingPanel.Enabled = false;
            LoadingPanel.Visible = false;

            DepartamentosCB.DropDownStyle = ComboBoxStyle.DropDownList;
            NombreCB.DropDownStyle = ComboBoxStyle.DropDownList;
            SemanaCB.DropDownStyle = ComboBoxStyle.DropDownList;
            string path2 = System.IO.Path.GetDirectoryName(asm.Location);

            string rutaEmpleados = System.IO.Path.GetDirectoryName(asm.Location) + @"\Empleados.xlsx";
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(rutaEmpleados);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            //----------------------------------------------------------------------------------------------
            for (int i = 2; i <= rowCount; i++)
            {
                Empleados.Add(new Tuple<string, string>(xlRange.Cells[i, 1].Value2.ToString(), xlRange.Cells[i, 2].Value2.ToString()));
            }
            ArrayList _Departamentos = new ArrayList();
            for (int i = 2; i <= rowCount; i++)
            {
                _Departamentos.Add(xlRange.Cells[i, 2].Value2.ToString());
            }
            IEnumerable<string> Departamentos = _Departamentos.Cast<string>().Distinct();
            Departamentos = Departamentos.OrderBy(a => a).ToList();
            foreach (var item in Departamentos)
            {
                DepartamentosCB.Items.Add(item);
            }

            string rutaCosto = System.IO.Path.GetDirectoryName(asm.Location) + @"\Costo.xlsx";
            Microsoft.Office.Interop.Excel.Application xlAppCosto = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbookCosto = xlAppCosto.Workbooks.Open(rutaCosto);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheetCosto = xlWorkbookCosto.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRangeCosto = xlWorksheetCosto.UsedRange;

            costo = Convert.ToDecimal(xlRangeCosto.Cells[1, 1].Value2.ToString());
            //----------------------------------------------------------------------------------------------
            string rutaCuentas = System.IO.Path.GetDirectoryName(asm.Location) + @"\Cuentas.xlsx";
            Microsoft.Office.Interop.Excel.Application xlApp2 = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook2 = xlApp2.Workbooks.Open(rutaCuentas);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet2 = xlWorkbook2.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange2 = xlWorksheet2.UsedRange;

            int rowCount2 = xlRange2.Rows.Count;
            for (int i = 3; i <= rowCount2; i++)
            {
                Cuentas.Add(new Tuple<string, string, string>(xlRange2.Cells[i, 1].Value2.ToString(), xlRange2.Cells[i, 2].Value2.ToString(), xlRange2.Cells[i, 3].Value2.ToString()));
            }

            releaseObject(xlWorksheet);
            releaseObject(xlWorksheet2);
            releaseObject(xlWorksheetCosto);
            xlApp.Quit();
            xlApp2.Quit();
            releaseObject(xlApp);
            releaseObject(xlApp2);

            dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Tipo de Reporte");
            dt.Columns.Add("Cantidad");
            DataRow newRow = dt.NewRow();
            DataRow newRow2 = dt.NewRow();
            DataRow newRow3 = dt.NewRow();
            newRow["Tipo de Reporte"] = "Reportes de XML";
            newRow["Cantidad"] = "0";
            dt.Rows.Add(newRow);
            newRow2["Tipo de Reporte"] = "Reportes de Horas";
            newRow2["Cantidad"] = "0";
            dt.Rows.Add(newRow2);
            newRow3["Tipo de Reporte"] = "Reportes de Gasolina";
            newRow3["Cantidad"] = "0";
            dt.Rows.Add(newRow3);
            InfoDGV.DataSource = dt;
            InfoDGV.Columns[0].Width = 300;
            InfoDGV.Columns[1].Width = 100;
        }
        private void FechaTP_ValueChanged(object sender, EventArgs e)
        {

        }
        private void CargarCuentadeGastosBTN_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                openFileDialog.Filter = "Excel files (*.xlsx|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                string NombreEmpleado = "";
                string Departamento = "";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
                    Excel._Worksheet Hoja = xlWorkbook.ActiveSheet;
                    Excel.Range Datos = Hoja.UsedRange;
                    MessageBox.Show(Hoja.Name);
                    //try
                    //{
                    //    NombreEmpleado = Datos.Cells[1, 5].Value2.ToString();
                    //    Departamento = Datos.Cells[2, 5].Value2.ToString();
                    //    DepartamentosCB.Text = Departamento;
                    //    NombreCB.Text = NombreEmpleado;
                    //    NombreCB.Enabled = false;
                    //    DepartamentosCB.Enabled = false;
                    //}
                    //catch (Exception err)
                    //{
                    //    MessageBox.Show("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaNo se cargó correctamente" + err);
                    //}
                    foreach (Excel._Worksheet sheet in xlWorkbook.Sheets)
                    {
                        switch (sheet.Name)
                        {
                            case "ReporteGastos":

                                

                                Excel.Range GastosRange = sheet.UsedRange;
                                int rowsGastos = GastosRange.Rows.Count - 4;
                                MessageBox.Show(rowsGastos+"");
                                for (int i = 0; i < rowsGastos; i++)
                                {
                                    try
                                    {

                                        string _Folio = "N/A", _Version = "", _FormaPago = "", _MetodoPago = "", _CP_Emisor = "", _Fecha = "", _RFCEmisor = "", _NombreEmisor = "", _AuxNombre = "";//10
                                        string _Descripcion = "", _Concepto = "", _Proyecto = "", _Serviceorder = "", _DescripcionCompra = "", _Cuenta = "", _EdoCuenta = "";//7
                                        double _Total = 0, _Subtotal = 0, _TotalIEPS = 0, _TotalIVA = 0, _TotalISH = 0, _TotalImpuestosRetenidos = 0, _Descuento = 0, _Propina = 0;//8
                                        int cell = i + 5;                                                                                                                                        //Revisar posiciones de las celdas
                                        _Version = GastosRange.Cells[cell, 2].Value2.ToString();
                                        _MetodoPago = GastosRange.Cells[cell, 3].Value2.ToString();
                                        _FormaPago = GastosRange.Cells[cell, 4].Value2.ToString();
                                        _Fecha = GastosRange.Cells[cell, 5].Value2.ToString();
                                        _CP_Emisor = GastosRange.Cells[cell, 6].Value2.ToString();
                                        _Folio = GastosRange.Cells[cell, 7].Value2.ToString();
                                        _RFCEmisor = GastosRange.Cells[cell, 8].Value2.ToString();
                                        _NombreEmisor = GastosRange.Cells[cell, 9].Value2.ToString();
                                        _Cuenta = GastosRange.Cells[cell, 10].Value2.ToString();// SI
                                        _Concepto = GastosRange.Cells[cell, 11].Value2.ToString();
                                        _DescripcionCompra = GastosRange.Cells[cell, 12].Value2.ToString();
                                        _Subtotal = Convert.ToDouble(GastosRange.Cells[cell, 13].Value2.ToString());
                                        _TotalIVA = Convert.ToDouble(GastosRange.Cells[ cell, 14].Value2.ToString());
                                        _TotalIEPS = Convert.ToDouble(GastosRange.Cells[cell, 15].Value2.ToString());
                                        _Propina = Convert.ToDouble(GastosRange.Cells[cell, 16].Value2.ToString());
                                        _TotalISH = Convert.ToDouble(GastosRange.Cells[cell, 17].Value2.ToString());
                                        _TotalImpuestosRetenidos = Convert.ToDouble(GastosRange.Cells[cell, 18].Value2.ToString());
                                        _Descuento = Convert.ToDouble(GastosRange.Cells[cell, 19].Value2.ToString());
                                        _Total = Convert.ToDouble(GastosRange.Cells[cell, 20].Value2.ToString());
                                        _EdoCuenta = GastosRange.Cells[cell, 21].Value2.ToString();
                                        _AuxNombre = GastosRange.Cells[cell, 22].Value2.ToString();
                                        _Proyecto = GastosRange.Cells[cell, 23].Value2.ToString();
                                        _Serviceorder = GastosRange.Cells[cell, 24].Value2.ToString();

                                        //Revisar posiciones de guardado en el vector

                                        Array_Reporte_Xml.Add(_Version + ";;" + _MetodoPago + ";;" + _FormaPago + ";;" + _Fecha + ";;" + _CP_Emisor + ";;" + _Folio + ";;" + _RFCEmisor + ";;" + _NombreEmisor + ";;" + _Subtotal + ";;" +
                                            _TotalIVA + ";;" + _TotalIEPS + ";;" + _TotalISH + ";;" + _TotalImpuestosRetenidos + ";;" + _Descuento + ";;" + _Total + ";;" + _AuxNombre + ";;" + _Descripcion + ";;" +
                                            _Concepto + ";;" + _Cuenta + ";;" + _Proyecto + ";;" + _Serviceorder + ";;" + _Propina + ";;" + _EdoCuenta + ";;");
                                    }
                                    catch (Exception err)
                                    {
                                        MessageBox.Show("ERROR::::::   " + err);
                                    }
                                    //Array_Reporte_Xml.Add(auxVerssion2 +
                                    //    ";;" + GastosRange.Cells[i + 6, 3].Value2.ToString() + ";;" + GastosRange.Cells[i + 6, 4].Value2.ToString() +
                                    //    ";;" + GastosRange.Cells[i + 6, 5].Value2.ToString() + ";;" + GastosRange.Cells[i + 6, 6].Value2.ToString() +
                                    //    ";;" + GastosRange.Cells[i + 6, 8].Value2.ToString() + ";;" + GastosRange.Cells[i + 6, 7].Value2.ToString() +//--
                                    //    ";;" + GastosRange.Cells[i + 6, 16].Value2.ToString() + ";" + GastosRange.Cells[i + 6, 17].Value2.ToString() +
                                    //    ";;" + importe + ";;" + auxiva +
                                    //    ";;" + auxIVAPorcentaje + ";;" + auxtotal +
                                    //    ";;" + auxISH + ";;" + GastosRange.Cells[i + 6, 11].Value2.ToString() +
                                    //    ";;" + GastosRange.Cells[i + 6, 12].Value2.ToString() + ";;" + GastosRange.Cells[i + 6, 9].Value2.ToString() +
                                    //    ";;" + GastosRange.Cells[i + 6, 10].Value2.ToString() + ";;" + auxpropina + ";;");
                                }
                                NombreEmpleado = Datos.Cells[1, 5].Value2.ToString();
                                Departamento = Datos.Cells[2, 5].Value2.ToString();
                                DepartamentosCB.Text = Departamento;
                                NombreCB.Text = NombreEmpleado;
                                NombreCB.Enabled = false;
                                DepartamentosCB.Enabled = false;
                                _UpdateReportes(0, Array_Reporte_Xml.Count);
                                releaseObject(sheet);
                                break;
                            case "ReporteHoras":
                                Excel.Range HorasRange = sheet.UsedRange;
                                int rowsHoras = HorasRange.Rows.Count - 5;
                                for (int i = 0; i < rowsHoras; i++)
                                {
                                    Array_Reporte_Horas.Add(HorasRange.Cells[i + 6, 2].Value2.ToString() +
                                        ";" + HorasRange.Cells[i + 6, 3].Value2.ToString() + ";" + HorasRange.Cells[i + 6, 4].Value2.ToString() +
                                        ";" + HorasRange.Cells[i + 6, 5].Value2.ToString() + ";" + HorasRange.Cells[i + 6, 6].Value2.ToString() +
                                        ";" + HorasRange.Cells[i + 6, 7].Value2.ToString() + ";");
                                }
                                _UpdateReportes(1, Array_Reporte_Horas.Count);
                                releaseObject(sheet);
                                break;
                            case "ReporteGasolina":
                                Excel.Range GasolinaRange = sheet.UsedRange;
                                int rowsGasolina = GasolinaRange.Rows.Count - 5;
                                for (int i = 0; i < rowsGasolina; i++)
                                {
                                    Array_Reporte_Gasolina.Add(GasolinaRange.Cells[i + 6, 2].Value2.ToString() +
                                        ";" + GasolinaRange.Cells[i + 6, 3].Value2.ToString() + ";" + GasolinaRange.Cells[i + 6, 4].Value2.ToString() +
                                        ";" + GasolinaRange.Cells[i + 6, 5].Value2.ToString() + ";");
                                }
                                _UpdateReportes(2, Array_Reporte_Gasolina.Count);
                                releaseObject(sheet);
                                break;
                        }
                    }
                    xlApp.Quit();
                    releaseObject(xlApp);
                    AbrirExcelCheck.Location = new Point(470, 570);



                }
            }
            catch (Exception err)
            {
                MessageBox.Show("___" + err);
                xlApp.Quit();
                releaseObject(xlApp);
            }
        }
        public void _UpdateReportes(int row, int cantidad)
        {
            dt.Rows[row]["Cantidad"] = cantidad;
        }
        private void DepartamentosCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string departamento = DepartamentosCB.Text;
            NombreCB.Items.Clear();
            for (int i = 0; i < Empleados.Count; i++)
            {
                if (Empleados[i].Item2 == departamento)
                {
                    NombreCB.Items.Add(Empleados[i].Item1);
                }
            }
            if (departamento == "SERVICIO A CAMPO")
            {
                GasolinaBTN.Enabled = true;
                GasolinaBTN.Visible = true;
                HorasBTN.Enabled = true;
                HorasBTN.Visible = true;
            }
            else
            {
                GasolinaBTN.Enabled = false;
                GasolinaBTN.Visible = false;
                HorasBTN.Enabled = false;
                HorasBTN.Visible = false;
            }
        }

        private void GenerarBTN_Click(object sender, EventArgs e)//--------descomentar lo interno
        {
            if (DepartamentosCB.Text != "" && NombreCB.Text != "" && SemanaCB.Text != "")
            {
                bool auxAML, auxHoras, auxGasolina;
                if (Array_Reporte_Xml.Count > 0) auxAML = true;
                else auxAML = false;
                if (Array_Reporte_Horas.Count > 0) auxHoras = true;
                else auxHoras = false;
                if (Array_Reporte_Gasolina.Count > 0) auxGasolina = true;
                else auxGasolina = false;
                if (DepartamentosCB.Text == "SERVICIO A CAMPO")
                {
                    if (auxAML || auxHoras || auxGasolina)
                    {
                        _GenerarExcel(auxAML, auxHoras, auxGasolina, true);
                    }
                }
                else
                {
                    if (auxAML)
                    {
                        _GenerarExcel(auxAML, false, false, false);

                    }
                }
                if (!auxAML && !auxHoras && !auxGasolina)
                {
                    MessageBox.Show("No hay datos para generar el Excel.");
                }
            }
            else
            {
                MessageBox.Show("Ingresa el todos los datos antes de continuar.");
            }
        }
        public void _GenerarExcel(bool xml, bool horas, bool gasolina, bool reporte)
        {
            Semana = SemanaCB.Text;
            Nombre = NombreCB.Text;
            _Fecha = FechaTP.Text;
            Departamento = DepartamentosCB.Text;
            LoadingPanel.Enabled = true;
            LoadingPanel.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "(*.xlsx)|*.xlsx";
            saveFileDialog1.Title = "Guardar archivo como";
            string Iniciales = String.Concat(Nombre.Where(x => Char.IsUpper(x)));
            saveFileDialog1.FileName = Tipo_Tarjeta + "_" + Iniciales + "_Cta. Gtos. " + Semana + "_" + _Fecha;
            saveFileDialog1.ShowDialog();
            string Ruta = saveFileDialog1.FileName;
            Excel.Application excel = new Excel.Application();
            Excel._Workbook libro = null;
            Excel._Worksheet XMLSheet = null;
            Excel._Worksheet HorasSheet = null;
            Excel._Worksheet GasolinaSheet = null;
            Excel._Worksheet ReporteSheet = null;
            Excel.Range rango = null;

            libro = excel.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            if (xml)
            {
                XMLSheet = libro.Worksheets.Add();
                XMLSheet.Name = "ReporteGastos";
                XMLSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                XMLSheet.PageSetup.CenterHeader = "&\"Arial\"&B&18&K22543fCuenta de Gastos";
                XMLSheet.PageSetup.LeftHeaderPicture.Filename = System.IO.Path.GetDirectoryName(asm.Location) + @"\Logo.png";
                XMLSheet.PageSetup.LeftHeader = "&G";
                XMLSheet.PageSetup.LeftHeaderPicture.Height = 20;
                Excel.Worksheet actived = libro.ActiveSheet;
                excel.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;
                _Encabezados(true, false, false, false, ref XMLSheet);
                for (int i = 0; i < Array_Reporte_Xml.Count; i++)
                {
                    string[] separatingStrings = { ";;" };
                    string[] dato = Array_Reporte_Xml[i].ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    XMLSheet.Cells[i + 6, 1] = (countGastos + i + 1);//#                      A
                    XMLSheet.Cells[i + 6, 2] = dato[0];//Version                      B
                    XMLSheet.Cells[i + 6, 3] = dato[1];//metodo                 C
                    XMLSheet.Cells[i + 6, 4] = dato[2];//forma                  D
                    XMLSheet.Cells[i + 6, 5] = dato[3];//FECHA                  E
                    XMLSheet.Cells[i + 6, 6] = dato[4];//CP                     F------
                    XMLSheet.Cells[i + 6, 7] = dato[5];//FOLIO                  G
                    XMLSheet.Cells[i + 6, 8] = dato[6];//RFC EMISOR             H
                    XMLSheet.Cells[i + 6, 9] = dato[7];//Nombre del emisor      I
                    XMLSheet.Cells[i + 6, 10] = dato[18];//Cuenta                J
                    XMLSheet.Cells[i + 6, 11] = dato[17];//Concepto             K
                    XMLSheet.Cells[i + 6, 12] = dato[16];//descripcion           M ---------
                    XMLSheet.Cells[i + 6, 13] = dato[8];  //Importe             N
                    XMLSheet.Cells[i + 6, 14] = dato[9];// Iva                 O
                    XMLSheet.Cells[i + 6, 15] = dato[10]; // IEPS               P
                    XMLSheet.Cells[i + 6, 16] = dato[21];//propina              Q
                    XMLSheet.Cells[i + 6, 17] = dato[11];//ish                  R
                    XMLSheet.Cells[i + 6, 18] = dato[12];// Impuesto retenido   S
                    XMLSheet.Cells[i + 6, 19] = dato[13];// Descuento           T
                    XMLSheet.Cells[i + 6, 20] = dato[14];//total                U
                    XMLSheet.Cells[i + 6, 21] = "0.00";// Edo de cuenta         V
                    XMLSheet.Cells[i + 6, 22] = (countGastos + i + 1) + dato[15]; //Nombre  del archivo  W
                    XMLSheet.Cells[i + 6, 23] = dato[19];//proy                 X
                    XMLSheet.Cells[i + 6, 24] = dato[20];//SO                   Y



                    auxVersion = Convert.ToDouble(dato[0]);
                    if (auxVersion < numVersion)
                    {
                        rango = XMLSheet.Range["A" + (i + 6), "X" + (i + 6)];
                        rango.Interior.Color = Color.Red;
                    }
                    else
                    {
                        if (i % 2 == 0)
                        {
                            rango = XMLSheet.Range["A" + (i + 6), "X" + (i + 6)];
                            rango.Interior.Color = Color.LightGray;
                        }
                    }

                }//------
                int totalXML = 5 + Array_Reporte_Xml.Count;
                rango = XMLSheet.Range["E6", "E" + totalXML];
                rango.NumberFormat = "MM/DD/YYYY";

                rango = XMLSheet.Range["M6", "U" + totalXML];
                rango.NumberFormat = "$ ###,##0.00";

                rango = XMLSheet.Range["A5", "X" + totalXML];
                rango.RowHeight = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.WrapText = true;
                rango.Cells.Font.Name = "Arial";
                rango.Cells.Font.Size = 8;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //}
            }
            if (horas)
            {
                HorasSheet = libro.Worksheets.Add();
                HorasSheet.Name = "ReporteHoras";
                HorasSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                HorasSheet.PageSetup.CenterHeader = "&\"Arial\"&B&18&K22543fReporte de Horas";
                HorasSheet.PageSetup.LeftHeaderPicture.Filename = System.IO.Path.GetDirectoryName(asm.Location) + @"\Logo.png";
                HorasSheet.PageSetup.LeftHeader = "&G";
                HorasSheet.PageSetup.LeftHeaderPicture.Height = 20;

                Excel.Worksheet actived = libro.ActiveSheet;
                excel.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;

                _Encabezados(false, true, false, false, ref HorasSheet);

                for (int i = 0; i < Array_Reporte_Horas.Count; i++)
                {
                    string datocompleto = Array_Reporte_Horas[i].ToString();
                    string[] dato = datocompleto.Split(';');
                    for (int j = 0; j < dato.Length; j++)
                    {
                        HorasSheet.Cells[i + 6, 1] = (i + 1);
                        HorasSheet.Cells[i + 6, 2] = dato[0];//B
                        HorasSheet.Cells[i + 6, 3] = dato[1];//C
                        HorasSheet.Cells[i + 6, 4] = dato[2];//D
                        HorasSheet.Cells[i + 6, 5] = dato[3];//E
                        HorasSheet.Cells[i + 6, 6] = dato[4];//F
                        HorasSheet.Cells[i + 6, 7] = dato[5];//G

                        if (i % 2 == 0)
                        {
                            rango = HorasSheet.Range["A" + (i + 6), "G" + (i + 6)];
                            rango.Interior.Color = Color.LightGray;
                        }
                    }
                }
                int total = 5 + Array_Reporte_Horas.Count;

                rango = HorasSheet.Range["B6", "B" + total];
                rango.NumberFormat = "MM/DD/YYYY";

                rango = HorasSheet.Range["A5", "G" + total];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.WrapText = true;
                rango.Cells.Font.Name = "Arial";
                rango.Cells.Font.Size = 8;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (gasolina)
            {
                GasolinaSheet = libro.Worksheets.Add();
                GasolinaSheet.Name = "ReporteGasolina";
                GasolinaSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                GasolinaSheet.PageSetup.CenterHeader = "&\"Arial\"&B&18&K22543fReporte de Gasolina";
                GasolinaSheet.PageSetup.LeftHeaderPicture.Filename = System.IO.Path.GetDirectoryName(asm.Location) + @"\Logo.png";
                GasolinaSheet.PageSetup.LeftHeader = "&G";
                GasolinaSheet.PageSetup.LeftHeaderPicture.Height = 20;

                Excel.Worksheet actived = libro.ActiveSheet;
                excel.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;

                _Encabezados(false, false, true, false, ref GasolinaSheet);

                for (int i = 0; i < Array_Reporte_Gasolina.Count; i++)
                {
                    string datocompleto = Array_Reporte_Gasolina[i].ToString();
                    string[] dato = datocompleto.Split(';');
                    for (int j = 0; j < dato.Length; j++)
                    {
                        GasolinaSheet.Cells[i + 6, 1] = (i + 1);
                        GasolinaSheet.Cells[i + 6, 2] = dato[0];//B
                        GasolinaSheet.Cells[i + 6, 3] = dato[1];//C
                        GasolinaSheet.Cells[i + 6, 4] = dato[2];//D
                        GasolinaSheet.Cells[i + 6, 5] = dato[3];//E

                        if (i % 2 == 0)
                        {
                            rango = GasolinaSheet.Range["A" + (i + 6), "E" + (i + 6)];
                            rango.Interior.Color = Color.LightGray;
                        }
                    }
                }
                int total = 5 + Array_Reporte_Gasolina.Count;
                rango = GasolinaSheet.Range["E6", "E" + total];
                rango.NumberFormat = "$ ###,##0.00";

                rango = GasolinaSheet.Range["B6", "B" + total];
                rango.NumberFormat = "MM/DD/YYYY";

                rango = GasolinaSheet.Range["A5", "E" + total];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.WrapText = true;
                rango.Cells.Font.Name = "Arial";
                rango.Cells.Font.Size = 8;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (reporte)
            {
                ReporteSheet = libro.Worksheets.Add();
                ReporteSheet.Name = "ReporteServicio";
                ReporteSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                ReporteSheet.PageSetup.CenterHeader = "&\"Arial\"&B&18&K22543fReporte de Servicios";
                ReporteSheet.PageSetup.LeftHeaderPicture.Filename = System.IO.Path.GetDirectoryName(asm.Location) + @"\Logo.png";
                ReporteSheet.PageSetup.LeftHeader = "&G";
                ReporteSheet.PageSetup.LeftHeaderPicture.Height = 20;

                Excel.Worksheet actived = libro.ActiveSheet;
                excel.ActiveWindow.View = Excel.XlWindowView.xlPageLayoutView;
                _Encabezados(false, false, false, true, ref ReporteSheet);
                int totalRegistros = Array_Reporte_Xml.Count + Array_Reporte_Horas.Count + Array_Reporte_Gasolina.Count;
                int aux = 0;

                for (int i = 0; i < Array_Reporte_Xml.Count; i++)
                {
                    string[] separatingStrings = { ";;" };
                    string[] dato = Array_Reporte_Xml[i].ToString().Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);
                    ReporteSheet.Cells[aux + 6, 2] = "N/A";//B            N/A TODOS
                    ReporteSheet.Cells[aux + 6, 3] = "GASTO";//C               GASTOS TODOS
                    ReporteSheet.Cells[aux + 6, 4] = "N/A";//D        N/A TODOS
                    ReporteSheet.Cells[aux + 6, 5] = "COSTO";//E         COSTO TODOS
                    ReporteSheet.Cells[aux + 6, 6] = dato[17];//F              Concepto / MANO DE OBRA EN HORAS 
                    ReporteSheet.Cells[aux + 6, 7] = dato[5];//G            FOLIO
                    ReporteSheet.Cells[aux + 6, 8] = dato[6];//H                RFC EMISOR
                    ReporteSheet.Cells[aux + 6, 9] = dato[3];//I              FECHA DE EMISION
                    ReporteSheet.Cells[aux + 6, 10] = dato[16];//J          DESCRIPCION DE LA FACTURA
                    ReporteSheet.Cells[aux + 6, 11] = dato[7];//K            NOMBRE DEL EMISOR
                    ReporteSheet.Cells[aux + 6, 12] = dato[14];//L             costo
                    ReporteSheet.Cells[aux + 6, 13] = "";//M
                    ReporteSheet.Cells[aux + 6, 14] = Nombre;//N
                    ReporteSheet.Cells[aux + 6, 15] = "";//O
                    ReporteSheet.Cells[aux + 6, 16] = "";//P
                    ReporteSheet.Cells[aux + 6, 17] = "";//Q
                    ReporteSheet.Cells[aux + 6, 18] = "";//R
                    ReporteSheet.Cells[aux + 6, 19] = _Fecha;//S
                    aux++;
                }//------
                for (int i = 0; i < Array_Reporte_Horas.Count; i++)
                {
                    string datocompleto = Array_Reporte_Horas[i].ToString();
                    string[] dato = datocompleto.Split(';');
                    int TotalHoras = Convert.ToInt32(dato[1]) + Convert.ToInt32(dato[2]);
                    ReporteSheet.Cells[aux + 6, 2] = "N/A";//B            N/A TODOS
                    ReporteSheet.Cells[aux + 6, 3] = "GASTO";//C               GASTOS TODOS
                    ReporteSheet.Cells[aux + 6, 4] = "N/A";//D        N/A TODOS
                    ReporteSheet.Cells[aux + 6, 5] = "COSTO";//E         COSTO TODOS
                    ReporteSheet.Cells[aux + 6, 6] = "M. O.";//F              DESCRIPCION DE LA CUENTA EN FACTURAS / MANO DE OBRA EN HORAS 
                    ReporteSheet.Cells[aux + 6, 7] = "";//G            FOLIO
                    ReporteSheet.Cells[aux + 6, 8] = "";//H                RFC EMISOR
                    ReporteSheet.Cells[aux + 6, 9] = dato[0];//I              FECHA DE EMISION
                    ReporteSheet.Cells[aux + 6, 10] = dato[3];//J          DESCRIPCION DE LA FACTURA / actividad
                    ReporteSheet.Cells[aux + 6, 11] = "";//K            NOMBRE DEL EMISOR
                    ReporteSheet.Cells[aux + 6, 12] = ((Convert.ToDecimal(dato[1]) + Convert.ToDecimal(dato[2])) * costo).ToString("N2"); ;//L
                    ReporteSheet.Cells[aux + 6, 13] = TotalHoras;//M
                    ReporteSheet.Cells[aux + 6, 14] = Nombre;//N
                    ReporteSheet.Cells[aux + 6, 15] = dato[2];//O lab
                    ReporteSheet.Cells[aux + 6, 16] = dato[1];//P tras
                    ReporteSheet.Cells[aux + 6, 17] = "";//Q
                    ReporteSheet.Cells[aux + 6, 18] = "";//R
                    ReporteSheet.Cells[aux + 6, 19] = _Fecha;//S
                    aux++;
                }
                for (int i = 0; i < Array_Reporte_Gasolina.Count; i++)
                {
                    string datocompleto = Array_Reporte_Gasolina[i].ToString();
                    string[] dato = datocompleto.Split(';');
                    ReporteSheet.Cells[aux + 6, 2] = "N/A";//B            N/A TODOS
                    ReporteSheet.Cells[aux + 6, 3] = "GASTO";//C               GASTOS TODOS
                    ReporteSheet.Cells[aux + 6, 4] = "N/A";//D        N/A TODOS
                    ReporteSheet.Cells[aux + 6, 5] = "COSTO";//E         COSTO TODOS
                    ReporteSheet.Cells[aux + 6, 6] = "GASOLINA";//F              DESCRIPCION DE LA CUENTA EN FACTURAS / MANO DE OBRA EN HORAS 
                    ReporteSheet.Cells[aux + 6, 7] = "";//G            FOLIO
                    ReporteSheet.Cells[aux + 6, 8] = "";//H                RFC EMISOR
                    ReporteSheet.Cells[aux + 6, 9] = dato[0];//I              FECHA DE EMISION
                    ReporteSheet.Cells[aux + 6, 10] = dato[2];//J          DESCRIPCION DE LA FACTURA / actividad / DETALLES (GASOLINA)
                    ReporteSheet.Cells[aux + 6, 11] = "";//K            NOMBRE DEL EMISOR
                    ReporteSheet.Cells[aux + 6, 12] = dato[3];//L
                    ReporteSheet.Cells[aux + 6, 13] = "";//M
                    ReporteSheet.Cells[aux + 6, 14] = Nombre;//N
                    ReporteSheet.Cells[aux + 6, 15] = "";//O lab
                    ReporteSheet.Cells[aux + 6, 16] = "";//P tras
                    ReporteSheet.Cells[aux + 6, 17] = "";//Q
                    ReporteSheet.Cells[aux + 6, 18] = "";//R
                    ReporteSheet.Cells[aux + 6, 19] = _Fecha;//S
                    aux++;
                }
                for (int i = 0; i < aux; i++)
                {
                    if (i % 2 == 0)
                    {
                        rango = ReporteSheet.Range["B" + (i + 6), "S" + (i + 6)];
                        rango.Interior.Color = Color.LightGray;
                    }
                }
                int total = 5 + aux;
                rango = ReporteSheet.Range["H6", "H" + total];
                rango.NumberFormat = "MM/DD/YYYY";

                rango = ReporteSheet.Range["K6", "L" + total];
                rango.NumberFormat = "$ ###,##0.00";

                rango = ReporteSheet.Range["B5", "S" + total];
                rango.RowHeight = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.WrapText = true;
                rango.Cells.Font.Name = "Arial";
                rango.Cells.Font.Size = 8;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            try
            {
                excel.ActiveWorkbook.Sheets["Hoja1"].Delete();

            }
            catch (Exception err)
            {
            }
            libro.SaveAs(Ruta);
            libro.Saved = true;
            libro.Close();
            releaseObject(libro);
            excel.UserControl = false;
            excel.Quit();
            releaseObject(excel);

            if (AbrirExcelCheck.Checked)
            {
                Process.Start(Ruta);
            }
            _UpdateReportes(0, 0);
            _UpdateReportes(1, 0);
            _UpdateReportes(2, 0);
            Array_Reporte_Xml.Clear();
            Array_Reporte_Horas.Clear();
            Array_Reporte_Gasolina.Clear();
            LoadingPanel.Enabled = false;
            LoadingPanel.Visible = false;
            this.Cursor = Cursors.Default;
            DepartamentosCB.Enabled = true;
            NombreCB.Enabled = true;
            SemanaCB.Enabled = true;
            FechaTP.Enabled = true;
        }
        public void _Encabezados(bool xml, bool horas, bool gasolina, bool reporte, ref Excel._Worksheet hoja)
        {
            hoja.PageSetup.LeftFooter = "&\"Arial\"&B&10&K22543fPágina &P";
            hoja.PageSetup.RightFooter = "&\"Arial\"&B&10&K22543f &D";
            hoja.PageSetup.RightHeader = "&\"Arial\"&B&10&K22543fMacLean Engineering Mexicana";
            hoja.PageSetup.CenterFooter = "&\"Arial\"&B&8&K22543f" + Version;

            Excel.Range rango;
            hoja.Cells[5, 1] = "#";//A5
            hoja.Columns[1].ColumnWidth = 4;//#
            if (xml)
            {
                hoja.Cells[2, 2] = "Nombre del Empleado";
                rango = hoja.Range["B2", "D2"];
                rango.Merge();
                hoja.Cells[3, 2] = "Departamento";
                rango = hoja.Range["B3", "D3"];
                rango.Merge();
                rango = hoja.Range["B2", "D3"];
                rango.Font.Bold = true;

                hoja.Cells[2, 5] = Nombre;
                rango = hoja.Range["E2", "H2"];
                rango.Merge();
                hoja.Cells[3, 5] = Departamento;
                rango = hoja.Range["E3", "H3"];
                rango.Merge();
                rango = hoja.Range["B2", "H3"];

                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                hoja.Cells[2, 10] = "Periodo";
                hoja.Cells[3, 10] = "Tarjeta";
                hoja.Cells[2, 11] = Semana + " " + _Fecha;
                hoja.Cells[3, 11] = Tipo_Tarjeta;
                rango = hoja.Range["J2", "K3"];
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                hoja.Cells[5, 2] = "V.";//B5
                hoja.Cells[5, 3] = "Metodo de Pago";//C
                hoja.Cells[5, 4] = "Forma de Pago";//D
                hoja.Cells[5, 5] = "Fecha";//E
                hoja.Cells[5, 6] = "C. P.";//F
                hoja.Cells[5, 7] = "Folio";//G
                hoja.Cells[5, 8] = "RFC Emisor";//H
                hoja.Cells[5, 9] = "Nombre del Emisor";//I
                hoja.Cells[5, 10] = "Cuenta";//J
                hoja.Cells[5, 11] = "Concepto";//K
                hoja.Cells[5, 12] = "Descripción";//L
                hoja.Cells[5, 13] = "Importe";//M
                hoja.Cells[5, 14] = "IVA";//N
                hoja.Cells[5, 15] = "IEPS";//O
                hoja.Cells[5, 16] = "Propina";//P
                hoja.Cells[5, 17] = "ISH";//Q
                hoja.Cells[5, 18] = "Impuesto Retenido";//R
                hoja.Cells[5, 19] = "Descuento";//S
                hoja.Cells[5, 20] = "Total";//T
                hoja.Cells[5, 21] = "Importe Edo. de Cuenta";//U
                hoja.Cells[5, 22] = "Nombre del Archivo";//V
                hoja.Cells[5, 23] = "Proyecto";//W
                hoja.Cells[5, 24] = "Servcie Order";//X


                hoja.Columns[2].ColumnWidth = 4;//VERSION
                hoja.Columns[3].ColumnWidth = 8;//METODO DE PAGO
                hoja.Columns[4].ColumnWidth = 8;//FORMA DE PAGO
                hoja.Columns[5].ColumnWidth = 8;//FECHA
                hoja.Columns[6].ColumnWidth = 8;//CP
                hoja.Columns[7].ColumnWidth = 8;//FOLIO
                hoja.Columns[8].ColumnWidth = 12;//RFC
                hoja.Columns[9].ColumnWidth = 15;//NOMBRE DEL EMISOR
                hoja.Columns[10].ColumnWidth = 18;//CUENTA
                hoja.Columns[11].ColumnWidth = 20;//CONCEPTO(DESCRIPCION DE LA CUENTA)
                hoja.Columns[12].ColumnWidth = 25;//DESCRIPCION DE LA COMPRA
                hoja.Columns[13].ColumnWidth = 8;//IMPORTE
                hoja.Columns[14].ColumnWidth = 8;//IVA
                hoja.Columns[15].ColumnWidth = 8;//TASA %
                hoja.Columns[16].ColumnWidth = 8;//PROPINA
                hoja.Columns[17].ColumnWidth = 8;//ISH
                hoja.Columns[18].ColumnWidth = 8;//IMPUESTO RETENIDO
                hoja.Columns[19].ColumnWidth = 8;//DESCUENTO
                hoja.Columns[20].ColumnWidth = 10;//TOTAL
                hoja.Columns[21].ColumnWidth = 15;//EDO DE CUENTA
                hoja.Columns[22].ColumnWidth = 20;//NOMBRE DEL ARCHIVO
                hoja.Columns[23].ColumnWidth = 8;//PROYECTO
                hoja.Columns[24].ColumnWidth = 8;//SO

                rango = hoja.Range["A5", "X5"];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.Interior.Color = Color.Black;
                rango.Font.Color = Color.White;
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (horas)
            {

                hoja.Cells[2, 2] = "Nombre del Empleado";
                rango = hoja.Range["B2", "C2"];
                rango.Merge();
                hoja.Cells[3, 2] = "Departamento";
                rango = hoja.Range["B3", "C3"];
                rango.Merge();
                rango = hoja.Range["B1", "C3"];

                rango = hoja.Range["D1", "E1"];
                rango.Merge();
                hoja.Cells[2, 4] = Nombre;
                rango = hoja.Range["D2", "E2"];
                rango.Merge();
                hoja.Cells[3, 4] = Departamento;
                rango = hoja.Range["D3", "E3"];
                rango.Merge();
                rango = hoja.Range["B2", "E3"];
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                hoja.Cells[5, 2] = "Fecha";//B5
                hoja.Cells[5, 3] = "Horas de Traslado";
                hoja.Cells[5, 4] = "Horas de Trabajo";
                hoja.Cells[5, 5] = "Actividad";//E4
                hoja.Cells[5, 6] = "Service Order";//F4
                hoja.Cells[5, 7] = "Descripcion";//G5

                hoja.Columns[2].ColumnWidth = 10;
                hoja.Columns[3].ColumnWidth = 10;
                hoja.Columns[4].ColumnWidth = 10;
                hoja.Columns[5].ColumnWidth = 25;
                hoja.Columns[6].ColumnWidth = 25;
                hoja.Columns[7].ColumnWidth = 25;



                rango = hoja.Range["A5", "G5"];
                rango.RowHeight = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.Interior.Color = Color.Black;
                rango.Font.Color = Color.White;
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (gasolina)
            {
                //hoja.Cells[1, 2] = "Periodo";
                //rango = hoja.Range["B1", "C1"];
                //rango.Merge();
                hoja.Cells[2, 2] = "Nombre del Empleado";
                rango = hoja.Range["B2", "C2"];
                rango.Merge();
                hoja.Cells[3, 2] = "Departamento"; rango = hoja.Range["B3", "C3"];
                rango.Merge();
                rango = hoja.Range["B3", "C3"];
                rango.Merge();

                //hoja.Cells[1, 4] = Semana + " " + _Fecha;
                hoja.Cells[2, 4] = Nombre;
                hoja.Cells[3, 4] = Departamento;//4427213714
                rango = hoja.Range["B2", "D3"];

                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                hoja.Cells[5, 2] = "Fecha";//B5
                hoja.Cells[5, 3] = "Service Order";
                hoja.Cells[5, 4] = "Detalles";
                hoja.Cells[5, 5] = "Monto";//E5

                hoja.Columns[2].ColumnWidth = 10;
                hoja.Columns[3].ColumnWidth = 10;
                hoja.Columns[4].ColumnWidth = 70;
                hoja.Columns[5].ColumnWidth = 15;

                rango = hoja.Range["A5", "E5"];
                rango.RowHeight = 30;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.Interior.Color = Color.Black;
                rango.Font.Color = Color.White;
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            }
            if (reporte)
            {
                //hoja.Cells[1, 2] = "Periodo";
                //rango = hoja.Range["B1", "C1"];
                //rango.Merge();
                hoja.Cells[5, 1] = "";
                hoja.Cells[2, 2] = "Nombre del Empleado";
                rango = hoja.Range["B2", "C2"];
                rango.Merge();
                hoja.Cells[3, 2] = "Departamento"; rango = hoja.Range["B3", "C3"];
                rango.Merge();
                rango = hoja.Range["B3", "C3"];
                rango.Merge();

                //hoja.Cells[1, 4] = Semana + " " + _Fecha;
                rango = hoja.Range["D1", "E1"];
                rango.Merge();
                hoja.Cells[2, 4] = Nombre;
                rango = hoja.Range["D2", "E2"];
                rango.Merge();
                hoja.Cells[3, 4] = Departamento;
                rango = hoja.Range["D3", "E3"];
                rango.Merge();
                rango = hoja.Range["B2", "E3"];

                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

                hoja.Cells[5, 2] = "CLIENTE";//B            N/A TODOS
                hoja.Cells[5, 3] = "TEMP";//C               GASTOS TODOS
                hoja.Cells[5, 4] = "S.O / W. O.";//D        N/A TODOS
                hoja.Cells[5, 5] = "MOVIMIENTO";//E         COSTO TODOS
                hoja.Cells[5, 6] = "GRUPO";//F              DESCRIPCION DE LA CUENTA EN FACTURAS / MANO DE OBRA EN HORAS 
                hoja.Cells[5, 7] = "FACTURA";//G            FOLIO
                hoja.Cells[5, 8] = "RFC";//H                RFC EMISOR
                hoja.Cells[5, 9] = "FECHA";//I              FECHA DE EMISION
                hoja.Cells[5, 10] = "CONCEPTO";//J          DESCRIPCION DE LA FACTURA
                hoja.Cells[5, 11] = "NOMBRE";//K            NOMBRE DEL EMISOR
                hoja.Cells[5, 12] = "COSTO MX";//L
                hoja.Cells[5, 13] = "COSTO USD";//M
                hoja.Cells[5, 14] = "TECNICO";//N
                hoja.Cells[5, 15] = "HORAS LABORADAS";//O
                hoja.Cells[5, 16] = "HORAS TRASLADO";//P
                hoja.Cells[5, 17] = "ER";//Q
                hoja.Cells[5, 18] = "REFERENCIA";//R
                hoja.Cells[5, 19] = "MES";//S


                hoja.Columns[2].ColumnWidth = 10;//B    cliente
                hoja.Columns[3].ColumnWidth = 10;//C    TEMP
                hoja.Columns[4].ColumnWidth = 10;//D    SO/WO
                hoja.Columns[5].ColumnWidth = 15;//E    MOVIMIENTO
                hoja.Columns[6].ColumnWidth = 25;//F    GRUPO
                hoja.Columns[7].ColumnWidth = 10;//G    FACTURA
                hoja.Columns[8].ColumnWidth = 25;//H    RFC
                hoja.Columns[9].ColumnWidth = 15;//I    FECHA
                hoja.Columns[10].ColumnWidth = 20;//J    CONCEPTO
                hoja.Columns[11].ColumnWidth = 20;//K    NOMBRE
                hoja.Columns[12].ColumnWidth = 10;//L   COSTO MX
                hoja.Columns[13].ColumnWidth = 10;//M   COSTO US
                hoja.Columns[14].ColumnWidth = 15;//N   TECNICO
                hoja.Columns[15].ColumnWidth = 15;//O   HORAS LAB
                hoja.Columns[16].ColumnWidth = 15;//P    HORAS TRAS
                hoja.Columns[17].ColumnWidth = 15;//Q   ER
                hoja.Columns[18].ColumnWidth = 8;//R    REFERENCIA
                hoja.Columns[19].ColumnWidth = 15;//S   MES


                rango = hoja.Range["B5", "S5"];
                rango.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                rango.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                rango.Interior.Color = Color.Black;
                rango.Font.Color = Color.White;
                rango.Font.Bold = true;
                rango.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Error al linerar el objeto");
            }
        }
        private void _BloquearCB()
        {
            DepartamentosCB.Enabled = false;
            NombreCB.Enabled = false;
            SemanaCB.Enabled = false;
            FechaTP.Enabled = false;
        }
    }
}