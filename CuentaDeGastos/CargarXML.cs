using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Net.NetworkInformation;

namespace CuentaDeGastos
{
    public partial class CargarXML : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        public static int count = 0, currentRow, currentCell;
        public static string _Fecha, Nombre, Departamento, DescripcionCuenta, Cuenta, path, filepath, pdfpath;
        float numVersion = 4, auxVersion;
        string auxNombre, auxReporte, auxnombre;
        public static List<Tuple<string, string, string>> Documentos = new List<Tuple<string, string, string>>();
        public ArrayList _Informacion = new ArrayList();
        public ArrayList _Informacion2 = new ArrayList();
        public ArrayList _BorraFilas = new ArrayList();

        private void InfoDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public int BorrarFila;
        public static ArrayList _InformacionCompleta = new ArrayList();

        private void InfoDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _Informacion.RemoveAt(BorrarFila);
                Documentos.RemoveAt(BorrarFila);
            }
        }

        Assembly asm = Assembly.GetExecutingAssembly();

        HomePage HomePage = new HomePage();

        private void CancelBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarXMLBTN_Click(object sender, EventArgs e)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);// dejar este
            openFileDialog.Filter = "XML files (*.xml|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    XmlDocument CFDI = new XmlDocument();
                    try
                    {
                        CFDI.Load(file);
                        //------------------------------------------------------------------------------------------Nodo Comprobante
                        XmlNode NodoComprobante = CFDI.GetElementsByTagName("cfdi:Comprobante").Item(0);
                        string Folio = "N/A", Version = "", FormaPago = "", MetodoPago = "", CP_Emisor = "", auxFecha = "", Fecha = "", RFCEmisor = "", NombreEmisor = "", Descripcion = "", RFCReceptor = "", NombreReceptor = "";
                        double Total = 0, Subtotal = 0, TotalIEPS = 0, TotalIVA = 0, TotalISH = 0, TotalImpuestosRetenidos = 0, Descuento = 0;
                        foreach (XmlAttribute item in NodoComprobante.Attributes)
                        {
                            if (item.Name == "FormaPago")
                            {
                                FormaPago = NodoComprobante.Attributes.GetNamedItem("FormaPago").Value;
                            }
                            if (item.Name == "MetodoPago")
                            {
                                MetodoPago = NodoComprobante.Attributes.GetNamedItem("MetodoPago").Value;
                            }
                            if (item.Name == "Total")
                            {
                                Total = Convert.ToDouble(NodoComprobante.Attributes.GetNamedItem("Total").Value);
                            }
                            if (item.Name == "Folio")
                            {
                                Folio = NodoComprobante.Attributes.GetNamedItem("Folio").Value;
                            }
                            if (item.Name == "Descuento")
                            {
                                Descuento = Convert.ToDouble(NodoComprobante.Attributes.GetNamedItem("Descuento").Value);
                                Descuento = Descuento * -1;
                            }
                            if (item.Name == "Version")
                            {
                                Version = NodoComprobante.Attributes.GetNamedItem("Version").Value;
                            }
                            if (item.Name == "LugarExpedicion")
                            {
                                CP_Emisor = NodoComprobante.Attributes.GetNamedItem("LugarExpedicion").Value;
                            }
                            if (item.Name == "SubTotal")
                            {
                                Subtotal = Convert.ToDouble(NodoComprobante.Attributes.GetNamedItem("SubTotal").Value);
                            }
                            if (item.Name == "Fecha")
                            {
                                auxFecha = NodoComprobante.Attributes.GetNamedItem("Fecha").Value;
                                string[] dato = auxFecha.Split('T');
                                Fecha = dato[0];
                                dato = Fecha.Split('-');
                                Fecha = dato[2] + "/" + dato[1] + "/" + dato[0];
                            }
                        }
                        //------------------------------------------------------------------------------------------Nodo Comprobante
                        //---------------------------------------------------------------------------------------Nodo del Emisor
                        XmlNode Nodo_Emisor = CFDI.GetElementsByTagName("cfdi:Emisor").Item(0);
                        foreach (XmlAttribute item in Nodo_Emisor.Attributes)
                        {
                            if (item.Name == "Rfc")
                            {
                                RFCEmisor = Nodo_Emisor.Attributes.GetNamedItem("Rfc").Value;
                            }
                            if (item.Name == "Nombre")
                            {
                                NombreEmisor = Nodo_Emisor.Attributes.GetNamedItem("Nombre").Value;
                            }
                        }
                        //---------------------------------------------------------------------------------------Nodo del Emisor
                        //---------------------------------------------------------------------------------------Nodo del Receptor
                        XmlNode Nodo_Receptor = CFDI.GetElementsByTagName("cfdi:Receptor").Item(0);
                        foreach (XmlAttribute item in Nodo_Receptor.Attributes)
                        {
                            if (item.Name == "Rfc")
                            {
                                RFCReceptor = Nodo_Receptor.Attributes.GetNamedItem("Rfc").Value;
                            }
                            if (item.Name == "Nombre")
                            {
                                NombreReceptor = Nodo_Receptor.Attributes.GetNamedItem("Nombre").Value;
                            }
                        }
                        //---------------------------------------------------------------------------------------Nodo del Receptor

                        //---------------------------------------------------------------------------------------Nodo de Traslados
                        int Nodos_Traslados = CFDI.GetElementsByTagName("cfdi:Traslados").Count;
                        XmlNode Nodo_ImpuestosTraslados = CFDI.GetElementsByTagName("cfdi:Traslados").Item(Nodos_Traslados - 1);
                        foreach (XmlNode Subnode in Nodo_ImpuestosTraslados.ChildNodes)
                        {
                            if (Subnode.Attributes.GetNamedItem("Impuesto").Value == "002")
                            {
                                try
                                {
                                    TotalIVA = TotalIVA + Convert.ToDouble(Subnode.Attributes.GetNamedItem("Importe").Value);
                                }
                                catch (Exception err)
                                {

                                }
                            }
                            else if (Subnode.Attributes.GetNamedItem("Impuesto").Value == "003")
                            {
                                TotalIEPS = TotalIEPS + Convert.ToDouble(Subnode.Attributes.GetNamedItem("Importe").Value);
                            }
                        }

                        int Nodos_TrasladosLoc = CFDI.GetElementsByTagName("implocal:TrasladosLocales").Count;
                        if (Nodos_TrasladosLoc > 0)
                        {
                            XmlNode Nodo_TrasladosLocales = CFDI.GetElementsByTagName("implocal:TrasladosLocales").Item(Nodos_TrasladosLoc - 1);
                            TotalISH = Convert.ToDouble(Nodo_TrasladosLocales.Attributes.GetNamedItem("Importe").Value);
                        }
                        //---------------------------------------------------------------------------------------Nodo de Traslados
                        //---------------------------------------------------------------------------------------Nodo de Retenciones
                        int Nodos_Retenciones = CFDI.GetElementsByTagName("cfdi:Retencion").Count;
                        if (Nodos_Retenciones > 0)
                        {

                            XmlNode Nodo_Retenciones = CFDI.GetElementsByTagName("cfdi:Retencion").Item(Nodos_Retenciones - 1);
                            TotalImpuestosRetenidos = Convert.ToDouble(Nodo_Retenciones.Attributes.GetNamedItem("Importe").Value);
                            TotalImpuestosRetenidos = TotalImpuestosRetenidos * -1;
                        }
                        //---------------------------------------------------------------------------------------Nodo de Retenciones
                        //---------------------------------------------------------------------------------------Nodo descripcion
                        XmlNode Nodo_Descripciones = CFDI.GetElementsByTagName("cfdi:Conceptos").Item(0);
                        foreach (XmlNode Subnode in Nodo_Descripciones.ChildNodes)
                        {
                            Descripcion = Descripcion + Subnode.Attributes.GetNamedItem("Descripcion").Value + "\n";
                        }
                        //---------------------------------------------------------------------------------------Nodo descripcion

                        //-------------------------------------------------------------------------------Nodo Impuestos Retenidos
                        XmlNode Nodo_Complemento = CFDI.GetElementsByTagName("tfd:TimbreFiscalDigital").Item(0);
                        string UUID = Nodo_Complemento.Attributes.GetNamedItem("UUID").Value;
                        string subUUID = UUID.Substring(0, 8);
                        if (Folio == "N/A")
                        {
                            Folio = subUUID;
                        }
                        if (RFCReceptor == "MEM1112149PA")
                        {
                            Version = Version.Replace(',', '.');
                            auxVersion = float.Parse(Version);
                            count++;
                            string auxTotal = string.Format("{0:C}", Subtotal);
                            string auxSubtotal = string.Format("{0:C}", Subtotal);
                            auxNombre = "_" + RFCEmisor + "_" + subUUID;
                            string informacion = Version + ";;" + MetodoPago + ";;" + FormaPago + ";;" + Fecha + ";;" + CP_Emisor + ";;" + Folio + ";;" + RFCEmisor + ";;" + // Estan bien estos
                                   NombreEmisor + ";;" + Subtotal + ";;" + TotalIVA + ";;" + TotalIEPS + ";;" + TotalISH + ";;" + TotalImpuestosRetenidos + ";;" + Descuento + ";;" + Total + ";;" + auxNombre + ";;" + Descripcion + ";;";//Descripcion -> 16
                            _Informacion.Add(informacion);
                            InfoDGV.Rows.Add(Fecha, auxSubtotal, auxTotal, Descripcion);

                            path = Path.GetDirectoryName(file);
                            filepath = file;
                            pdfpath = Path.ChangeExtension(file, ".pdf");
                            Documentos.Add(new Tuple<string, string, string>(file, pdfpath, auxNombre));

                            if (auxVersion < numVersion)
                            {
                                InfoDGV.Rows[count - 1].DefaultCellStyle.BackColor = Color.Red;
                                AlertaFactura.Visible = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("La factura " + RFCEmisor + " no corresponde con el RFC de MacLean");
                        }
                    }
                    catch (Exception err)
                    {
                        string[] dato = file.Split(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
                        int aux = dato.Count();
                        string datoFact = dato[aux - 1];

                        MessageBox.Show("La factura: \n" + datoFact + "\nNo se cargó correctamente debido a un error inesperado." + "\n" + err);
                    }
                }
                InfoDGV.Visible = true;
                TarjetasGB.Visible = true;
                GastosLBL.Visible = true;
                GastosNUD.Visible = true;
                Info2LBL.Visible = true;
                GenerarBTN.Visible = true;
            }
        }
        private void InfoDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                InfoDGV.ReadOnly = false;
            }
            else InfoDGV.ReadOnly = true;
            if (e.ColumnIndex == -1)
            {
                BorrarFila = e.RowIndex;
            }
        }
        public CargarXML()
        {
            InitializeComponent();
        }
        private void CargarXML_Load(object sender, EventArgs e)
        {
            count = 0;
            FechaLBL.Text = HomePage._Fecha + " " + HomePage.Semana;
            NombreLBL.Text = HomePage.Nombre;
            DepartamentoLBL.Text = HomePage.Departamento;
            VersionTB.Text = HomePage.Version;

            DataGridViewComboBoxColumn DescripcionCBC = new DataGridViewComboBoxColumn();
            DescripcionCBC.HeaderText = "Descripción";
            DescripcionCBC.Name = "_Descripcion";
            DescripcionCBC.Width = 270;
            DescripcionCBC.DisplayIndex = 4;
            ArrayList row = new ArrayList();
            for (int i = 0; i < HomePage.Cuentas.Count; i++)
            {
                if (HomePage.Cuentas[i].Item3 == HomePage.Departamento)
                {
                    row.Add(HomePage.Cuentas[i].Item2);
                }
            }
            row.Sort();
            DescripcionCBC.Items.AddRange(row.ToArray());
            InfoDGV.Columns.Add(DescripcionCBC);
        }
        //--------------------------------------------------Generar Excel
        private void GenerarBTN_Click(object sender, EventArgs e)
        {

            int count = _Informacion.Count;
            if (count == InfoDGV.RowCount)
            {
                Generar();
            }
        }

        public void Generar()
        {
            if (bbvaRD.Checked) HomePage.Tipo_Tarjeta = "BBVA";
            if (amexRB.Checked) HomePage.Tipo_Tarjeta = "AMEX";
            HomePage.countGastos = Convert.ToInt32(GastosNUD.Value) - 1;
            int auxCuenta = Convert.ToInt32(GastosNUD.Value) - 1;
            int aux = HomePage.Array_Reporte_Xml.Count;
            bool _continue = true;
            string concepto, proyecto, serviceorder, descripcionCompra;
            double propina = 0;
            for (int i = 0; i < InfoDGV.RowCount; i++)
            {

                if (InfoDGV.Rows[i].Cells["_Descripcion"].Value != null)
                {
                    proyecto = "N/A";
                    serviceorder = "N/A";
                    if (InfoDGV.Rows[i].Cells["_Propina"].Value == null)
                    {
                        propina = 0;
                    }
                    else
                    {
                        propina = Convert.ToDouble("" + InfoDGV.Rows[i].Cells["_Propina"].Value);
                    }
                    concepto = "" + InfoDGV.Rows[i].Cells["_Descripcion"].Value;//Dropdown
                    descripcionCompra = "" + InfoDGV.Rows[i].Cells["_Desc"].Value;//escrita
                    for (int j = 0; j < HomePage.Cuentas.Count; j++)
                    {
                        if (HomePage.Cuentas[j].Item3 == HomePage.Departamento && HomePage.Cuentas[j].Item2 == concepto)
                        {
                            Cuenta = HomePage.Cuentas[j].Item1;
                        }
                    }
                    _Informacion2.Add(concepto + ";;" + Cuenta + ";;" + proyecto + ";;" + serviceorder + ";;" + propina + ";;" + descripcionCompra+";;");//17 -> 23
                }
                else
                {
                    _continue = false;
                }
            }
            if (_continue)
            {
                for (int i = 0; i < Documentos.Count; i++)
                {
                    System.IO.FileInfo xml = new System.IO.FileInfo(Documentos[i].Item1);
                    auxnombre = Documentos[i].Item3;
                    xml.MoveTo(path + @"\" + (auxCuenta + i + 1) + auxnombre + ".xml");
                    try
                    {
                        System.IO.FileInfo pdf = new System.IO.FileInfo(Documentos[i].Item2);
                        pdf.MoveTo(path + @"\" + (auxCuenta + i + 1) + auxnombre + ".pdf");
                    }
                    catch
                    {
                        MessageBox.Show("No se encontró el PDF para la factura " + auxnombre);
                    }
                }

                for (int i = 0; i < _Informacion.Count; i++)
                {
                    HomePage.Array_Reporte_Xml.Add("" + _Informacion[i] + _Informacion2[i]);
                }

                HomePage._UpdateReportes(0, HomePage.Array_Reporte_Xml.Count);
                Documentos.Clear();
                this.Close();
            }
            else
            {
                MessageBox.Show("Faltan datos por ingresar");
            }
        }

    }
}