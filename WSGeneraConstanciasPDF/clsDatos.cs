using System;
using System.Data;
using System.Data.SqlClient;

namespace WSGeneraConstanciasPDF
{
    public class clsDatos
    {
        protected string Conx = "";
        protected SqlParameterCollection parametros = new SqlCommand().Parameters;

        public clsDatos()
        {
            Conx = System.Configuration.ConfigurationManager.ConnectionStrings["BASE"].ConnectionString;
        }

        public void CreaParametro(string Nombre_Parametro, object Valor, SqlDbType Tipo_Dato, int Tamanno = 0)
        {
            SqlParameter param;

            if (Valor != null && Tamanno > 0 && (Tipo_Dato == SqlDbType.NChar || Tipo_Dato == SqlDbType.NVarChar || Tipo_Dato == SqlDbType.Char || Tipo_Dato == SqlDbType.VarChar))
            {
                string ValorAlt;
                param = new SqlParameter(Nombre_Parametro, Tipo_Dato, Tamanno);

                ValorAlt = Valor.ToString();

                if (ValorAlt.Length > Tamanno)
                    ValorAlt = ValorAlt.Substring(0, Tamanno);

                param.Value = Valor;
                parametros.Add(param);
            }
            else if (Valor != null && Tipo_Dato != SqlDbType.NChar && Tipo_Dato != SqlDbType.NVarChar && Tipo_Dato != SqlDbType.Char && Tipo_Dato != SqlDbType.VarChar)
            {
                param = new SqlParameter(Nombre_Parametro, Tipo_Dato);
                param.Value = Valor;
                parametros.Add(param);
            }
            else
            {
                throw new ArgumentNullException("Uno de los parámetros proporcionados no es válido");
            }
        }

        public void LimpiaParametros()
        {
            if (parametros != null)
                parametros.Clear();
        }

        public DataTable EjecutaLectura(string Query)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            DataTable Tabla = new DataTable("Resultados");
            int Count = 0;

            try
            {
                cn = new SqlConnection(Conx);
                cmd = new SqlCommand(Query, cn);
                cmd.CommandType = CommandType.Text;

                if (parametros != null && parametros.Count > 0)
                {
                    for (int w = 0; w < parametros.Count; w++)
                    {
                        if (parametros[w] != null && parametros[w].Size > 0)
                        {
                            cmd.Parameters.Add(parametros[w].ParameterName, parametros[w].SqlDbType, parametros[w].Size);
                            cmd.Parameters[Count].Direction = parametros[w].Direction;
                            cmd.Parameters[Count].Value = parametros[w].Value;
                            Count++;
                        }
                        else if (parametros[w] != null)
                        {
                            cmd.Parameters.Add(parametros[w].ParameterName, parametros[w].SqlDbType);
                            cmd.Parameters[Count].Direction = parametros[w].Direction;
                            cmd.Parameters[Count].Value = parametros[w].Value;
                            Count++;
                        }
                    }
                }

                cn.Open();
                Tabla.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                Tabla = new DataTable("Error");
                DataRow dr;

                Tabla.Columns.Add("Error");
                dr = Tabla.NewRow();
                dr[0] = ex.Message;
                Tabla.Rows.Add(dr);
                Tabla.AcceptChanges();
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }

            return Tabla;
        }
    }
}