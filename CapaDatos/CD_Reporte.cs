using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace CapaDatos
{
    public class CD_Reporte
    {


        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion)
        {
            List<Reporte> lista = new List<Reporte>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    

                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oconexion);

                    cmd.Parameters.AddWithValue("Fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("Fechafin", fechafin);
                    cmd.Parameters.AddWithValue("idtransaccion", idtransaccion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                        while (dr.Read())
                        {
                            lista.Add(

                                new Reporte
                                {
                                    FechaVenta = dr["FechaVenta"].ToString(),
                                    Cliente = dr["Cliente"].ToString(),
                                    Producto = dr["Producto"].ToString(),
                                    Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-MX")),
                                    Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                    Total = Convert.ToDecimal(dr["Total"], new CultureInfo("es-MX")),
                                    IdTransaccion = dr["IdTransaccion"].ToString()
                                }



                             );

                        }
                }

            }
            catch
            {
                lista = new List<Reporte>();
            }

            return lista;

        }

        public DashBoard VerDashBoard()
        {
            DashBoard objeto = new DashBoard();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {                    

                    SqlCommand CMD = new SqlCommand("sp_ReporteDashboard", oconexion);

                    CMD.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();
                    using (SqlDataReader dr = CMD.ExecuteReader())
                        while (dr.Read())
                        {


                            objeto = new DashBoard()
                            {
                                TotalCliente = Convert.ToInt32(dr["TotalCliente"]),
                                TotalVenta = Convert.ToInt32(dr["TotalVenta"]),
                                TotalProducto = Convert.ToInt32(dr["TotalProducto"]),
                            };

                        }
                }

            }
            catch
            {
                objeto = new DashBoard();
            }

            return objeto;

        }


    }
}
