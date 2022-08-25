using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using pruebAPI.Models;

namespace pruebAPI.Logica
{
    public class SpProducto
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> lista = new List<Producto>();
            try
            {
                BaseDatos bd = new BaseDatos();
                SqlCommand cmd = new SqlCommand("SpProducto", bd.Link);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Metodo", 1);
                cmd.Parameters.AddWithValue("@codigo", null);
                cmd.Parameters.AddWithValue("@nombre", null);
                cmd.Parameters.AddWithValue("@descripcion", null);
                cmd.Parameters.AddWithValue("@precio", null);
                cmd.Parameters.AddWithValue("@stock", null);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                bd.Open();
                da.Fill(dt);
                bd.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    lista.Add(new Producto() {
                        Codigo=int.Parse(dr["Codigo"].ToString()),
                        Descripcion = dr["Descripcion"].ToString(),
                        Nombre = dr["Nombre"].ToString(),
                        Precio =double.Parse(dr["Precio"].ToString()),
                        Stock = int.Parse(dr["Stock"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                lista = null;
            }
            return lista;
        }

        public Transaccion ActualizarProducto(Producto p)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                BaseDatos bd = new BaseDatos();
                SqlCommand cmd = new SqlCommand("SpProducto", bd.Link);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Metodo", 2);
                cmd.Parameters.AddWithValue("@codigo", p.Codigo);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@precio", p.Precio);
                cmd.Parameters.AddWithValue("@stock", p.Stock);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                bd.Open();
                da.Fill(dt);
                bd.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    rpta.Codigo = dr["Codigo"].ToString();
                    rpta.Mensaje = dr["Mensaje"].ToString();
                }
            }
            catch (Exception ex)
            {
                rpta.Codigo = "666";
                rpta.Mensaje = ex.Message;
            }
            return rpta;
        }

    }
}
