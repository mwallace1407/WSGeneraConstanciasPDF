using System;
using System.Data;
using System.Web.Services;
using WebSupergoo.ABCpdf7;

namespace WSGeneraConstanciasPDF
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class Generar : System.Web.Services.WebService
    {
        private string Errores = "";

        public struct Archivo
        {
            public byte[] Datos;

            //public bool ProcesoCorrecto;
            public string MsjError;
        }

        public enum TipoPDF
        {
            Acreditado = 1,
            Coacreditado = 2
        }

        private struct ConstanciasPDFData
        {
            public string sNumeroId;
            public string sCurp;
            public string sNombreCom;
            public string sNombres;
            public string sPrimerAp;
            public string sSegundoAp;
            public string sNOMENCLATURA;
            public string sCodigoBar;
            public string sCodigoMun;
            public string sCodigoSec;
            public string sCodigodep;
            public string sCP;
            public string sUbicacionFisGa;
            public string scodigobarrioga;
            public string scodigomuniga;
            public string scodigosectorga;
            public string scodigodepga;
            public string scpga;
            public string sNombreComCoa;
            public string sNombresCoa;
            public string sPrimerApCoa;
            public string sSegundoApCoa;
            public string sNumeroIdCoa;
            public string sCurpCoa;
            public string sNOMENCLATURACoa;
            public string sCodigoBarCoa;
            public string sCodigoMunCoa;
            public string sCodigoSecCoa;
            public string sCodigoDepCoa;
            public string sCpCoa;
            public string sINTNOMDEV;
            public string sINTNOMPAG;
            public string sINTREAL;
            public string sMONTOCRED;
            public string sMONTOCRED_C2;
            public string sINTNOMDEV_C2;
            public string sINTNOMPAG_C2;
            public string sINTREAL_C2;
            public string sMES_INI;
            public string sMES_FIN;
            public string sCVE_MONEDA;
            public string sEjercicio;
            public string sjudicial;
            public string sBaseJit;
            public string sIntNomPag;
            public string sEstado;
            public string RFC_Emp;
            public string RazonSoc_Emp;
            public string Calle_Emp;
            public string NoExt_Emp;
            public string NoInt_Emp;
            public string Col_Emp;
            public string CD_Emp;
            public string CP_Emp;
            public string Edo_Emp;
            public string NomRep_Emp;
            public string RFCRep_Emp;
            public string CURPRep_Emp;
        }

        private void RegistraError(string Modulo, string Titulo, string Descripcion, string Fila, string Numero_Prestamo)
        {
            Errores += "EmptyStringData|" + Fila + "|" + Numero_Prestamo + "|" + DateTime.Now.ToString("HH:mm:ss") + " - " + Descripcion.Replace("|", "") + "\r\n";
        }

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hello World";
        //}

        [WebMethod]
        public Archivo GenerarPDF(int Numero_Prestamo, TipoPDF tipoPDF, int Anno, int Porcentaje, string Fila, bool Forzar = false)
        {
            bool BanProc = false;
            bool NoAplica = false;
            ConstanciasPDFData DatosPDF;
            Archivo ArchivoConstancia;
            DatosPDF.sNumeroId = "";
            DatosPDF.sCurp = "";
            DatosPDF.sNombreCom = "";
            DatosPDF.sNombres = "";
            DatosPDF.sPrimerAp = "";
            DatosPDF.sSegundoAp = "";
            DatosPDF.sNOMENCLATURA = "";
            DatosPDF.sCodigoBar = "";
            DatosPDF.sCodigoMun = "";
            DatosPDF.sCodigoSec = "";
            DatosPDF.sCodigodep = "";
            DatosPDF.sCP = "";
            DatosPDF.sUbicacionFisGa = "";
            DatosPDF.scodigobarrioga = "";
            DatosPDF.scodigomuniga = "";
            DatosPDF.scodigosectorga = "";
            DatosPDF.scodigodepga = "";
            DatosPDF.scpga = "";
            DatosPDF.sNombreComCoa = "";
            DatosPDF.sNombresCoa = "";
            DatosPDF.sPrimerApCoa = "";
            DatosPDF.sSegundoApCoa = "";
            DatosPDF.sNumeroIdCoa = "";
            DatosPDF.sCurpCoa = "";
            DatosPDF.sNOMENCLATURACoa = "";
            DatosPDF.sCodigoBarCoa = "";
            DatosPDF.sCodigoMunCoa = "";
            DatosPDF.sCodigoSecCoa = "";
            DatosPDF.sCodigoDepCoa = "";
            DatosPDF.sCpCoa = "";
            DatosPDF.sINTNOMDEV = "";
            DatosPDF.sINTNOMPAG = "";
            DatosPDF.sINTREAL = "";
            DatosPDF.sMONTOCRED = "";
            DatosPDF.sMONTOCRED_C2 = "";
            DatosPDF.sINTNOMDEV_C2 = "";
            DatosPDF.sINTNOMPAG_C2 = "";
            DatosPDF.sINTREAL_C2 = "";
            DatosPDF.sMES_INI = "";
            DatosPDF.sMES_FIN = "";
            DatosPDF.sCVE_MONEDA = "";
            DatosPDF.sEjercicio = "";
            DatosPDF.sjudicial = "";
            DatosPDF.sBaseJit = "";
            DatosPDF.sIntNomPag = "";
            DatosPDF.sEstado = "";
            DatosPDF.RFC_Emp = "";
            DatosPDF.RazonSoc_Emp = "";
            DatosPDF.Calle_Emp = "";
            DatosPDF.NoExt_Emp = "";
            DatosPDF.NoInt_Emp = "";
            DatosPDF.Col_Emp = "";
            DatosPDF.CD_Emp = "";
            DatosPDF.CP_Emp = "";
            DatosPDF.Edo_Emp = "";
            DatosPDF.NomRep_Emp = "";
            DatosPDF.RFCRep_Emp = "";
            DatosPDF.CURPRep_Emp = "";

            if (Anno < 2008 || Anno > 2012)
            {
                ArchivoConstancia.Datos = null;
                ArchivoConstancia.MsjError = "Año fuera de los parámetros: " + Anno.ToString();

                return ArchivoConstancia;
            }

            //OperacionesBD.HerramientasOracle tool = new OperacionesBD.HerramientasOracle(ConfigurationManager.AppSettings["Usuario"],
            //                                           ConfigurationManager.AppSettings["Pass"],
            //                                           ConfigurationManager.AppSettings["Host"],
            //                                           ConfigurationManager.AppSettings["Service"],
            //                                           ConfigurationManager.AppSettings["Port"],
            //                                           ConfigurationManager.AppSettings["Protocol"]);
            clsDatos tool = new clsDatos();
            Doc theDoc = new Doc();
            DataTable Registros = new DataTable();
            BanProc = false;
            string sHTML = string.Empty;
            string sSQL = string.Empty;

            ArchivoConstancia.MsjError = "";
            //ArchivoConstancia.ProcesoCorrecto = false;
            ArchivoConstancia.Datos = null;
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);
            Registros = tool.EjecutaLectura(Scripts.Constancias_DatosDeClienteXPrestamo);

            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sNumeroId = Registros.Rows[0]["NUMERO_IDENTIFICACION"].ToString();
                    DatosPDF.sCurp = Registros.Rows[0]["CURP"].ToString();
                    DatosPDF.sNombreCom = Registros.Rows[0]["NOMBRE_COMPLETO"].ToString();
                    DatosPDF.sNombres = Registros.Rows[0]["NOMBRES"].ToString();
                    DatosPDF.sPrimerAp = Registros.Rows[0]["PRIMER_APELLIDO"].ToString();
                    DatosPDF.sSegundoAp = Registros.Rows[0]["SEGUNDO_APELLIDO"].ToString();
                    BanProc = true;
                }
                else
                {
                    RegistraError("Constancias_DatosDeClienteXPrestamo", "Error en consulta Constancias_DatosDeClienteXPrestamo", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }
            else
            {
                RegistraError("Constancias_DatosDeClienteXPrestamo", "Error en consulta Constancias_DatosDeClienteXPrestamo", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
            }

            if (!BanProc)
            {
                RegistraError("GenerarPDF", "Proceso interrumpido", "Se detiene proceso para el préstamo " + Numero_Prestamo.ToString() + " por no cumplir todas las validaciones correspondientes. Punto de revisión: Constancias_DatosDeClienteXPrestamo", Fila, Numero_Prestamo.ToString());
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }

            Registros = new DataTable();
            tool.LimpiaParametros();
            BanProc = false;
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);
            Registros = tool.EjecutaLectura(Scripts.Constancias_DatosDeGarantiaXPrestamo);

            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sNOMENCLATURA = Registros.Rows[0]["NOMENCLATURA"].ToString();
                    DatosPDF.sCodigoBar = Registros.Rows[0]["CODIGO_BARRIO"].ToString();
                    DatosPDF.sCodigoMun = Registros.Rows[0]["NOMBRE_MUN"].ToString();
                    DatosPDF.sCodigoSec = Registros.Rows[0]["DESCRIPCION"].ToString();
                    DatosPDF.sCodigodep = Registros.Rows[0]["NOMBRE_DEP"].ToString();
                    DatosPDF.sCP = Registros.Rows[0]["CODIGO_POSTAL"].ToString();
                    BanProc = true;
                }
                else
                {
                    RegistraError("Constancias_DatosDeGarantiaXPrestamo", "Error en consulta Constancias_DatosDeGarantiaXPrestamo", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }
            else
            {
                RegistraError("Constancias_DatosDeGarantiaXPrestamo", "Error en consulta Constancias_DatosDeGarantiaXPrestamo", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
            }

            if (!BanProc)
            {
                RegistraError("GenerarPDF", "Proceso interrumpido", "Se detiene proceso para el préstamo " + Numero_Prestamo.ToString() + " por no cumplir todas las validaciones correspondientes. Punto de revisión: Constancias_DatosDeGarantiaXPrestamo", Fila, Numero_Prestamo.ToString());
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }

            Registros = new DataTable();
            tool.LimpiaParametros();
            BanProc = false;
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);
            Registros = tool.EjecutaLectura(Scripts.Constancias_DireccionGarantiaXPrestamo);

            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sUbicacionFisGa = Registros.Rows[0]["UBICACION_FISICA"].ToString();
                    DatosPDF.scodigobarrioga = Registros.Rows[0]["COLONIA"].ToString();
                    DatosPDF.scodigomuniga = Registros.Rows[0]["MUNICIPIO"].ToString();
                    DatosPDF.scodigosectorga = Registros.Rows[0]["NOMBRE_SECTOR"].ToString();
                    DatosPDF.scodigodepga = Registros.Rows[0]["ESTADO"].ToString();
                    DatosPDF.scpga = Registros.Rows[0]["CODIGO_POSTAL"].ToString();
                    DatosPDF.sEstado = Registros.Rows[0]["ESTADO_PRESTAMO"].ToString();
                    BanProc = true;
                }
                else
                {
                    RegistraError("Constancias_DireccionGarantiaXPrestamo", "Error en consulta Constancias_DireccionGarantiaXPrestamo", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }
            else
            {
                RegistraError("Constancias_DireccionGarantiaXPrestamo", "Error en consulta Constancias_DireccionGarantiaXPrestamo", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
            }

            if (!BanProc)
            {
                RegistraError("GenerarPDF", "Proceso interrumpido", "Se detiene proceso para el préstamo " + Numero_Prestamo.ToString() + " por no cumplir todas las validaciones correspondientes. Punto de revisión: Constancias_DireccionGarantiaXPrestamo", Fila, Numero_Prestamo.ToString());
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }

            Registros = new DataTable();
            tool.LimpiaParametros();
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);
            Registros = tool.EjecutaLectura(Scripts.Constancias_DatosDeCoacreditadoXPrestamo);

            //No es un requerimiento obligatorio obtener estos datos
            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sNombreComCoa = Registros.Rows[0]["NOMBRE_COMPLETO"].ToString();
                    DatosPDF.sNombresCoa = Registros.Rows[0]["NOMBRES"].ToString();
                    DatosPDF.sPrimerApCoa = Registros.Rows[0]["PRIMER_APELLIDO"].ToString();
                    DatosPDF.sSegundoApCoa = Registros.Rows[0]["SEGUNDO_APELLIDO"].ToString();
                    DatosPDF.sNumeroIdCoa = Registros.Rows[0]["NUMERO_IDENTIFICACION"].ToString();
                    DatosPDF.sCurpCoa = Registros.Rows[0]["CURP"].ToString();
                }
                else
                {
                    RegistraError("Constancias_DatosDeCoacreditadoXPrestamo", "Error en consulta Constancias_DatosDeCoacreditadoXPrestamo", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }

            Registros = new DataTable();
            tool.LimpiaParametros();
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);
            Registros = tool.EjecutaLectura(Scripts.Constancias_DatosDeGarantiaXPrestamoXCoacreditado);

            //No es un requerimiento obligatorio obtener estos datos
            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sNOMENCLATURACoa = Registros.Rows[0]["NOMENCLATURA"].ToString();
                    DatosPDF.sCodigoBarCoa = Registros.Rows[0]["CODIGO_BARRIO"].ToString();
                    DatosPDF.sCodigoMunCoa = Registros.Rows[0]["NOMBRE_MUN"].ToString();
                    DatosPDF.sCodigoSecCoa = Registros.Rows[0]["DESCRIPCION"].ToString();
                    DatosPDF.sCodigoDepCoa = Registros.Rows[0]["NOMBRE_DEP"].ToString();
                    DatosPDF.sCpCoa = Registros.Rows[0]["CODIGO_POSTAL"].ToString();
                }
                else
                {
                    RegistraError("Constancias_DatosDeGarantiaXPrestamoXCoacreditado", "Error en consulta Constancias_DatosDeGarantiaXPrestamoXCoacreditado", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }

            string direccionGar = "";
            string[] valoresGar = null;
            Registros = new DataTable();
            tool.LimpiaParametros();
            BanProc = false;
            tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);

            if (Forzar)
            {
                Registros = tool.EjecutaLectura(Scripts.Constancias_HSCConstancias.Replace("@@Anno", Anno.ToString()).Replace("AND Imprimir = 'S'", ""));
            }
            else
            {
                if (Anno > 2008)
                    Registros = tool.EjecutaLectura(Scripts.Constancias_HSCConstancias.Replace("@@Anno", Anno.ToString()));
                else if (Anno == 2008)
                    Registros = tool.EjecutaLectura(Scripts.Constancias_HSCConstancias.Replace("@@Anno", Anno.ToString()).Replace("AND Imprimir = 'S'", ""));
            }

            if (Registros != null && Registros.Rows.Count > 0)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.sIntNomPag = (Convert.ToDecimal(Registros.Rows[0]["INTNOMPAG"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sINTNOMDEV = (Convert.ToDecimal(Registros.Rows[0]["INTNOMDEV"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sINTNOMPAG = Registros.Rows[0]["INTNOMPAG"].ToString();
                    DatosPDF.sMONTOCRED = (Convert.ToDecimal(Registros.Rows[0]["MONTOCRED"].ToString())).ToString("###,###,##0.00");
                    DatosPDF.sINTREAL = (Convert.ToDecimal(Registros.Rows[0]["INTREAL"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sMONTOCRED_C2 = (Convert.ToDecimal(Registros.Rows[0]["MONTOCRED"].ToString())).ToString("###,###,##0.00");
                    DatosPDF.sINTNOMDEV_C2 = (Convert.ToDecimal(Registros.Rows[0]["INTNOMDEV"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sINTNOMPAG_C2 = (Convert.ToDecimal(Registros.Rows[0]["INTNOMPAG"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sINTREAL_C2 = (Convert.ToDecimal(Registros.Rows[0]["INTREAL"].ToString()) * Porcentaje / 100).ToString("###,###,##0.00");
                    DatosPDF.sMES_INI = Registros.Rows[0]["MES_INI"].ToString();
                    DatosPDF.sMES_FIN = Registros.Rows[0]["MES_FIN"].ToString();
                    DatosPDF.sCVE_MONEDA = Registros.Rows[0]["CVE_MONEDA"].ToString();
                    DatosPDF.sEjercicio = Registros.Rows[0]["EJERCICIO"].ToString();
                    DatosPDF.sjudicial = Registros.Rows[0]["JUDICIAL"].ToString();
                    DatosPDF.sBaseJit = Registros.Rows[0]["BASEJIT"].ToString();

                    direccionGar = Registros.Rows[0]["DIRECCION_GAR"].ToString().Trim();
                    valoresGar = direccionGar.Split('?');

                    if (valoresGar.Length == 6 && (DatosPDF.sEstado != "1" && DatosPDF.sEstado != "6" && DatosPDF.sEstado != "9"))
                    {
                        DatosPDF.sUbicacionFisGa = valoresGar[0];
                        DatosPDF.scodigobarrioga = valoresGar[1];
                        DatosPDF.scodigomuniga = valoresGar[2];
                        DatosPDF.scodigosectorga = valoresGar[3];
                        DatosPDF.scodigodepga = valoresGar[4];
                        DatosPDF.scpga = valoresGar[5];
                    }

                    BanProc = true;
                }
                else
                {
                    RegistraError("Constancias_HSCConstancias", "Error en consulta Constancias_HSCConstancias", "Préstamo:" + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }
            }
            else
            {
                Registros = new DataTable();
                tool.LimpiaParametros();
                BanProc = false;
                tool.CreaParametro("@Numero_Prestamo", Numero_Prestamo, SqlDbType.Int);

                if (Anno > 2008)
                    Registros = tool.EjecutaLectura(Scripts.Constancias_HSCConstancias_Error.Replace("@@Anno", Anno.ToString()));
                else if (Anno == 2008)
                    Registros = tool.EjecutaLectura(Scripts.Constancias_HSCConstancias2_Error.Replace("@@Anno", Anno.ToString()));

                if (Registros != null && Registros.Rows.Count > 0)
                {
                    if (Registros.TableName != "Error")
                    {
                        if (Registros.Rows[0][0].ToString().Trim() != "")
                        {
                            RegistraError("Constancias_HSCConstancias_Error", "Error en consulta Constancias_HSCConstancias_Error", Registros.Rows[0][0].ToString().Trim() + ". Préstamo: " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
                            ArchivoConstancia.MsjError = Errores;
                            return ArchivoConstancia;
                        }
                        else
                        {
                            RegistraError("Constancias_HSCConstancias_Error", "Error en consulta Constancias_HSCConstancias_Error", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
                        }
                    }
                    else
                    {
                        RegistraError("Constancias_HSCConstancias_Error", "Error en consulta Constancias_HSCConstancias_Error", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
                    }
                }
                else
                {
                    RegistraError("Constancias_HSCConstancias_Error", "Error en consulta Constancias_HSCConstancias_Error", "No se obtuvieron los datos para el préstamo " + Numero_Prestamo.ToString(), Fila, Numero_Prestamo.ToString());
                }

                NoAplica = false; //Cambiar a true si se desea que en caso de no tener datos se genere con la leyenda: ESTE CRÉDITO NO TIENE CONSTANCIA DE DEDUCIBILIDAD PARA ESTE EJERCICIO
            }

            if (!BanProc && !NoAplica)
            {
                RegistraError("GenerarPDF", "Proceso interrumpido", "Se detiene proceso para el préstamo " + Numero_Prestamo.ToString() + " por no cumplir todas las validaciones correspondientes. Punto de revisión: Constancias_HSCConstancias", Fila, Numero_Prestamo.ToString());
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }

            theDoc.TopDown = true;
            theDoc.Units = "mm";
            theDoc.Font = theDoc.AddFont("Arial");
            theDoc.TextStyle.LineSpacing = 1.1;
            theDoc.TextStyle.CharSpacing = -.1;

            //********************************************************TITULO
            theDoc.Rect.String = "55 11 200 25";
            sHTML += "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += "CONSTANCIA ANUAL DE INTERESES DEVENGADOS Y PAGADOS DE CREDITOS<br>";
            sHTML += "HIPOTECARIOS DESTINADOS A CASA HABITACIÓN";
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            XImage theImg2 = new XImage();
            theImg2.SetFile(Server.MapPath("Images") + "/logo azul small.jpg"); //ODES
            theDoc.Rect.Bottom = 30;
            theDoc.Rect.Left = 10;
            theDoc.Rect.Width = 33.7;
            theDoc.Rect.Height = 20.3;
            theDoc.AddImageObject(theImg2, false);

            theDoc.Rect.String = "55 21 200 35";
            sHTML = "<p align='center'><font size='1' face='Arial'>";
            sHTML += "La presente Constancia se emite de conformidad con lo establecido en los articulos 176 fracción IV y 227 de la Ley del<br>";
            sHTML += "Impuesto Sobre la Renta y del reglamento de la Ley del Impuesto Sobre la Renta, respectivamente.";
            sHTML += "</font></p>";
            theDoc.AddHtml(sHTML);

            //PERIODO Y CREDITO
            theDoc.Rect.String = "134 30 200 60";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += "Periodo que ampara la Constancia<br>";
            sHTML += "<b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "134 35 200 40";
            theDoc.FrameRect(2, 2);
            sHTML = "<p align='center'><font size='2' face='Arial'>";
            sHTML += "Mes Inicial &nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp; Mes Final  &nbsp;&nbsp;&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp; Ejercicio <br>";
            sHTML += "</font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "140 41 155 48";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += DatosPDF.sMES_INI;
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "195 41 140 48";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += DatosPDF.sMES_FIN;
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "205 41 170 48";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += DatosPDF.sEjercicio;
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "100 55 200 60";
            theDoc.Color.String = "255 255 255";
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";
            sHTML += "No. de Prestamo";
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "134 60 200 65";
            theDoc.FrameRect(2, 2);
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='3' face='Arial'><b>";
            sHTML += Numero_Prestamo.ToString();
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            //DATOS DEL DEUDOR
            theDoc.Rect.String = "10 39 205 162";
            theDoc.TextStyle.Size = 2.5;
            string sNomenc1 = "";
            string sNomenc2 = "";
            int iLen = 0;

            if ((int)tipoPDF == 1)
            {
                sHTML = DatosPDF.sNombres + ' ' + DatosPDF.sPrimerAp + ' ' + DatosPDF.sSegundoAp;
                sNomenc1 = DatosPDF.sNOMENCLATURA;
            }
            else
            {
                sNomenc1 = DatosPDF.sNOMENCLATURACoa;
                sHTML = DatosPDF.sNombreComCoa;
            }

            theDoc.AddText(sHTML);

            theDoc.Rect.String = "10 43 205 162";
            theDoc.TextStyle.Size = 2.5;
            theDoc.TextStyle.Bold = false;

            if (sNomenc1.Length > 75)
            {
                iLen = sNomenc1.IndexOf(" ", 60);

                if (iLen >= 0)
                {
                    sNomenc2 = sNomenc1.Substring(iLen, sNomenc1.Length - iLen).Trim();
                    sNomenc1 = sNomenc1.Substring(0, iLen);
                }
            }

            sHTML = sNomenc1 + "<br>";

            if (sNomenc2 != "")
                sHTML += sNomenc2 + "<br>";

            if ((int)tipoPDF == 1)
            {
                sHTML += DatosPDF.sCodigoBar + "<br>";
                sHTML += DatosPDF.sCodigoMun + ", " + DatosPDF.sCodigoSec + "<br>";
                sHTML += DatosPDF.sCodigodep + " " + ". C.P. " + DatosPDF.sCP + "<br>";
            }
            else
            {
                sHTML += DatosPDF.sCodigoBarCoa + "<br>";
                sHTML += DatosPDF.sCodigoMunCoa + ", " + DatosPDF.sCodigoSecCoa + "<br>";
                sHTML += DatosPDF.sCodigoDepCoa + " " + ". C.P. " + DatosPDF.sCpCoa + "<br>";
            }

            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "138 65 200 70 ";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = true;
            sHTML = "R.F.C.";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "134 70 200 75";
            theDoc.FrameRect(2, 2);
            theDoc.TextStyle.Bold = true;
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='2' face='Arial'><b>";

            if ((int)tipoPDF == 1)
                sHTML += DatosPDF.sNumeroId;
            else
                sHTML += DatosPDF.sNumeroIdCoa;

            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            //DATOS DEL CREDITO
            theDoc.Rect.String = "28 78 190 116";
            theDoc.Color.String = "255 255 255";
            theDoc.FillRect();
            theDoc.FrameRect();
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='3' face='Arial'><b>";
            sHTML += "DATOS DEL CRÉDITO";
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Color.String = "0 0 0";
            theDoc.Rect.String = "10 116 205 163";
            theDoc.AddLine(15, 83, 200, 83);

            theDoc.Rect.String = "15 86 205 162";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = false;
            sHTML = "Domicilio de la Garantía:";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "15 92 205 162";
            theDoc.TextStyle.Size = 2.5;
            theDoc.TextStyle.Bold = false;

            if (DatosPDF.sUbicacionFisGa.Length > 78)
            {
                string sAux = string.Empty;
                string[] arrPalabras = DatosPDF.sUbicacionFisGa.Split(' ');
                DatosPDF.sUbicacionFisGa = arrPalabras[0];
                int i = 1;

                while (DatosPDF.sUbicacionFisGa.Length < 70)
                {
                    DatosPDF.sUbicacionFisGa = DatosPDF.sUbicacionFisGa + " " + arrPalabras[i];
                    i++;
                }

                if (arrPalabras.Length < i)
                {
                    sAux = arrPalabras[i];
                    while (sAux.Length < 70 && i < arrPalabras.Length)
                    {
                        sAux = sAux + " " + arrPalabras[i];
                        i++;
                    }
                }

                sHTML = DatosPDF.sUbicacionFisGa + "<br>";
                sHTML += sAux + "<br>";
            }
            else
                sHTML = DatosPDF.sUbicacionFisGa + "<br>";

            sHTML += DatosPDF.scodigobarrioga + "<br>";
            sHTML += DatosPDF.scodigomuniga + ", " + DatosPDF.scodigosectorga + "<br>";
            sHTML += DatosPDF.scodigodepga + " " + ". C.P. " + DatosPDF.scpga + "<br>";
            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "135 86 205 162";
            theDoc.TextStyle.Size = 3;
            sHTML = "Denominación:";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "165 86 205 162";
            theDoc.TextStyle.Size = 3.5;
            theDoc.TextStyle.Bold = true;

            switch (DatosPDF.sCVE_MONEDA)
            {
                case "1":
                    sHTML = "PESOS";
                    break;

                case "2":
                    sHTML = "DOLARES";
                    break;

                case "3":
                    sHTML = "UDIS";
                    break;

                case "4":
                    sHTML = "SALARIOS MINIMOS";
                    break;
            }

            theDoc.AddText(sHTML);
            theDoc.Rect.String = "135 95 205 180";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = false;
            sHTML = "Saldo Insoluto al <br>";
            sHTML += "31 de diciembre de " + Anno.ToString();
            theDoc.AddHtml(sHTML);
            theDoc.Rect.String = "175 99 205 162";
            theDoc.TextStyle.Size = 3.5;
            theDoc.TextStyle.Bold = true;

            if ((int)tipoPDF == 1)
                sHTML = DatosPDF.sMONTOCRED;
            else
                sHTML = DatosPDF.sMONTOCRED_C2;

            if (DatosPDF.sCVE_MONEDA == "UDI")
                sHTML += " UDIS";

            theDoc.AddText(sHTML);

            //INFORMATIVO DE INTERESES
            theDoc.Rect.String = "10 112 210 162";
            theDoc.Color.String = "255 255 255";
            theDoc.FillRect();
            theDoc.FrameRect();
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='3' face='Arial'><b>";
            sHTML += "INFORMATIVO DE INTERESES EN EL EJERCICIO";
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Color.String = "0 0 0";
            theDoc.Rect.String = "10 150 205 163";
            theDoc.AddLine(15, 117, 205, 117);

            theDoc.Rect.String = "15 120 205 262";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = false;
            sHTML = "Intereses Nominales Devengados";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "60 120 115 262";
            theDoc.TextStyle.Size = 3.5;
            theDoc.TextStyle.Bold = true;

            if ((int)tipoPDF == 1)
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sINTNOMDEV;
            else
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sINTNOMDEV_C2;

            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "15 127 205 262";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = false;
            sHTML = "Intereses Nominales Pagados en el Ejercicio";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "60 127 115 262";
            theDoc.TextStyle.Size = 3.5;
            theDoc.TextStyle.Bold = true;

            if ((int)tipoPDF == 1)
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sIntNomPag;
            else
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sINTNOMPAG_C2;

            theDoc.AddHtml(sHTML);

            theDoc.Rect.String = "15 134 205 262";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = false;
            sHTML = "Intereses Reales Pagados en el Ejercicio";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "60 134 115 262";
            theDoc.TextStyle.Size = 3.5;
            theDoc.TextStyle.Bold = true;

            if ((int)tipoPDF == 1)
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sINTREAL;
            else
                sHTML = "<p align='right'><font size='3' face='Arial'>" + DatosPDF.sINTREAL_C2;

            theDoc.AddHtml(sHTML);

            //DATOS DEL ACREEDOR
            theDoc.Rect.String = "20 142  99 200";
            theDoc.Color.String = "255 255 255";
            theDoc.FillRect();
            theDoc.FrameRect();
            theDoc.Color.String = "0 0 0";
            sHTML = "<p align='center'><font size='3' face='Arial'><b>";
            sHTML += "DATOS DEL ACREEDOR HIPOTECARIO";
            sHTML += "</b></font></p>";
            theDoc.AddHtml(sHTML);

            theDoc.Color.String = "0 0 0";
            theDoc.Rect.String = "15 148 104 200";
            theDoc.FrameRect(2, 2);

            theDoc.Rect.String = "17 188 205 262";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = true;
            sHTML = "RFC:";
            theDoc.AddText(sHTML);

            theDoc.Rect.String = "28 188 205 262";
            theDoc.TextStyle.Size = 3;
            theDoc.TextStyle.Bold = true;

            //OBTENEMOS LOS DATOS DE LAS HIPOTECARIAS
            Registros = new DataTable();
            tool.LimpiaParametros();
            BanProc = false;
            tool.CreaParametro("@sBaseJit", DatosPDF.sBaseJit, SqlDbType.VarChar, 4000);
            Registros = tool.EjecutaLectura(Scripts.Constancias_EmpresasSiglasEmp);

            if (Registros != null && Registros.Rows.Count > 0 && !NoAplica)
            {
                if (Registros.TableName != "Error")
                {
                    DatosPDF.RFC_Emp = Registros.Rows[0]["RFC"].ToString();
                    DatosPDF.RazonSoc_Emp = Registros.Rows[0]["RAZON_SOC2"].ToString();
                    DatosPDF.Calle_Emp = Registros.Rows[0]["CALLE"].ToString();
                    DatosPDF.NoExt_Emp = Registros.Rows[0]["NOEXT"].ToString();
                    DatosPDF.NoInt_Emp = Registros.Rows[0]["NOINT"].ToString();
                    DatosPDF.Col_Emp = Registros.Rows[0]["COLONIA"].ToString();
                    DatosPDF.CD_Emp = Registros.Rows[0]["CIUDAD"].ToString();
                    DatosPDF.CP_Emp = Registros.Rows[0]["CODPOS"].ToString();
                    DatosPDF.Edo_Emp = Registros.Rows[0]["ESTADO"].ToString();
                    DatosPDF.NomRep_Emp = Registros.Rows[0]["NOM_REPRESENTANTE"].ToString();
                    DatosPDF.RFCRep_Emp = Registros.Rows[0]["RFC_REPRESENTANTE"].ToString();
                    DatosPDF.CURPRep_Emp = Registros.Rows[0]["CURP_REPRESENTANTE"].ToString();
                    BanProc = true;
                }
                else
                {
                    RegistraError("Constancias_EmpresasSiglasEmp", "Error en consulta Constancias_EmpresasSiglasEmp", "Préstamo: " + Numero_Prestamo.ToString() + ". Error: " + Registros.Rows[0][0].ToString(), Fila, Numero_Prestamo.ToString());
                }

                if (!BanProc)
                {
                    theDoc.TopDown = true;
                    theDoc.Units = "mm";
                    theDoc.Font = theDoc.AddFont("Arial");
                    theDoc.TextStyle.LineSpacing = 1.1;
                    theDoc.TextStyle.CharSpacing = -.1;

                    //TITULO
                    theDoc.Rect.String = "16 180 200 25";
                    sHTML += "<br><br><br><br><br><br><br><br><br><p align='center'><font size='38' face='Arial'><b>";
                    sHTML += "ESTE CRÉDITO NO TIENE CONSTANCIA <br>";
                    sHTML += "DE DEDUCIBILIDAD PARA ESTE EJERCICIO";
                    sHTML += "</b></font></p>";
                    theDoc.AddHtml(sHTML);

                    //byte[] theData = theDoc.GetData();
                    //theDoc.Save(fbd01.SelectedPath + "\\" + Numero_Prestamo.ToString() + "_" + Anno.ToString() + ".pdf");
                    ArchivoConstancia.Datos = theDoc.GetData();
                    ArchivoConstancia.MsjError = Errores;
                    return ArchivoConstancia;
                }

                sHTML = DatosPDF.RFC_Emp + " ";
                theDoc.AddText(sHTML);

                theDoc.Rect.String = "17 155 205 300";
                theDoc.TextStyle.Size = 3;
                theDoc.TextStyle.Bold = true;

                string sNomenc3 = "";
                string sNomenc4 = "";
                int iLen1 = 0;

                sNomenc3 = DatosPDF.RazonSoc_Emp;

                if (sNomenc3.Length > 75)
                {
                    iLen1 = sNomenc3.IndexOf(" ", 65);
                    sNomenc4 = sNomenc3.Substring(iLen1, sNomenc3.Length - iLen1).Trim();
                    sNomenc3 = sNomenc3.Substring(0, iLen1);
                }

                sHTML = sNomenc3 + "<br>";

                if (sNomenc4 != "")
                    sHTML += sNomenc4 + "<br>";

                theDoc.AddHtml(sHTML);

                theDoc.TextStyle.LineSpacing = 1.1;
                theDoc.TextStyle.WordSpacing = 0;

                theDoc.Rect.String = "17 168 205 262";
                theDoc.TextStyle.Size = 3;
                sHTML = DatosPDF.Calle_Emp + " No." + DatosPDF.NoExt_Emp + ", " + DatosPDF.NoInt_Emp + "<br>";
                sHTML += "Col. " + DatosPDF.Col_Emp + "<br>";
                sHTML += DatosPDF.CD_Emp + ", " + DatosPDF.Edo_Emp + ", C.P." + DatosPDF.CP_Emp + "<br>";

                theDoc.AddHtml(sHTML);

                //DATOS DEL REPRESENTANTE
                theDoc.Rect.String = "220 142 105 190";
                theDoc.Color.String = "255 255 255";
                theDoc.FillRect();
                theDoc.FrameRect();
                theDoc.Color.String = "0 0 0";
                sHTML = "<p align='center'><font size='3' face='Arial'><b>";
                sHTML += "DATOS DEL REPRESENTANTE LEGAL";
                sHTML += "</b></font></p>";
                theDoc.AddHtml(sHTML);

                theDoc.Color.String = "0 0 0";
                theDoc.Rect.String = "205 148 119 200";
                theDoc.FrameRect(2, 2);

                theDoc.Rect.String = "123 165 205 262";
                theDoc.TextStyle.Size = 3;
                theDoc.TextStyle.Bold = false;
                sHTML = "RFC:";
                theDoc.AddText(sHTML);

                theDoc.Rect.String = "140 165 205 262";
                theDoc.TextStyle.Size = 3;
                sHTML = DatosPDF.RFCRep_Emp;

                theDoc.AddText(sHTML);

                theDoc.Rect.String = "123 173 205 262";
                theDoc.TextStyle.Size = 3;
                sHTML = "CURP:";
                theDoc.AddText(sHTML);

                theDoc.Rect.String = "140 173 205 262";
                theDoc.TextStyle.Size = 3;
                sHTML = DatosPDF.CURPRep_Emp;

                theDoc.AddText(sHTML);

                theDoc.Rect.String = "123 155 195 170";
                theDoc.TextStyle.Size = 3;
                //theDoc.TextStyle.Bold = true;
                sHTML = DatosPDF.NomRep_Emp;

                theDoc.AddHtml(sHTML);

                //PIE DE PAGINA
                theDoc.Rect.String = "48 234 205 275";
                theDoc.Color.String = "0 0 0";
                theDoc.TextStyle.LineSpacing = 1;
                theDoc.TextStyle.ParaSpacing = -1;
                theDoc.TextStyle.Justification = 1;
                sHTML = "<font size='2' face='Arial'><p>";
                sHTML += "L0S DATOS CONTENIDOS EN ESTA CONSTANCIA SERÁN COTEJADOS CON LA INFORMACIÓN QUE OBRA ";
                sHTML += "EN PODER DE LA AUTORIDAD FISCAL, CUANDO SE UTILICE COMO DEDUCCIÓN PERSONAL EN LA ";
                sHTML += "DECLARACIÓN ANUAL DE LAS PERSONAS FISICAS.</p>";
                sHTML += "<p>PARA CUALQUIER ACLARACIÓN O INFORMACIÓN REFERENTE A ESTA CONSTANCIA, FAVOR DE ";
                sHTML += "COMUNICARSE AL 01 800 712 1212";
                sHTML += "</p></font>";
                theDoc.AddHtml(sHTML);

                //IMAGEN DEL RFC
                XImage theImg = new XImage();

                switch (DatosPDF.sBaseJit.Trim())
                {
                    case "HSC":
                        theImg.SetFile(Server.MapPath("Images") + "/RFC_HSC_2008.jpg"); //ODES
                        theDoc.Rect.Bottom = 259;
                        theDoc.Rect.Left = 15;
                        theDoc.Rect.Width = 27.7;//theImg.Width / 7;
                        theDoc.Rect.Height = 51.4;//theImg.Height / 7;
                        break;

                    case "SHF":
                        theImg.SetFile(Server.MapPath("Images") + "/RFC_SHF.jpg"); //ODES
                        theDoc.Rect.Bottom = 259;
                        theDoc.Rect.Left = 15;
                        theDoc.Rect.Width = 28.4;//theImg.Width / 6.8;
                        theDoc.Rect.Height = 52.2;//theImg.Height / 6.8;
                        break;

                    case "GMAC":
                        theImg.SetFile(Server.MapPath("Images") + "/RFC_GMAC_2008.jpg"); //ODES
                        theDoc.Rect.Bottom = 259;
                        theDoc.Rect.Left = 15;
                        theDoc.Rect.Width = 28.2;//theImg.Width / 11.3;
                        theDoc.Rect.Height = 52.2;//theImg.Height / 11.3;
                        break;
                }

                theDoc.AddImageObject(theImg, false);

                //theDoc.Save(fbd01.SelectedPath + "\\" + Numero_Prestamo.ToString() + "_" + Anno.ToString() + ".pdf");
                ArchivoConstancia.Datos = theDoc.GetData();
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }
            else
            {
                theDoc.TopDown = true;
                theDoc.Units = "mm";
                theDoc.Font = theDoc.AddFont("Arial");
                theDoc.TextStyle.LineSpacing = 1.1;
                theDoc.TextStyle.CharSpacing = -.1;

                //********************************************************TITULO
                theDoc.Rect.String = "16 180 200 25";
                sHTML += "<br><br><br><br><br><br><br><br><br><p align='center'><font size='38' face='Arial'><b>";
                sHTML += "ESTE CRÉDITO NO TIENE CONSTANCIA <br>";
                sHTML += "DE DEDUCIBILIDAD PARA ESTE EJERCICIO";
                sHTML += "</b></font></p>";
                theDoc.AddHtml(sHTML);

                //theDoc.Save(fbd01.SelectedPath + "\\" + Numero_Prestamo.ToString() + "_" + Anno.ToString() + ".pdf");
                ArchivoConstancia.Datos = theDoc.GetData();
                ArchivoConstancia.MsjError = Errores;
                return ArchivoConstancia;
            }

            //MessageBox.Show("Ya");
        }
    }
}