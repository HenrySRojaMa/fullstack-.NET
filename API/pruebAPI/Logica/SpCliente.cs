using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using pruebAPI.Logica;
using pruebAPI.Models;

namespace pruebAPI.Logica
{
    public class SpCliente
    {
        public Transaccion Autenticar(Usuario u)
        {
            Transaccion rpta = new Transaccion();
            try
            {
                BaseDatos bd = new BaseDatos();
                SqlCommand cmd = new SqlCommand("SpCliente",bd.Link);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Metodo", 1);
                cmd.Parameters.AddWithValue("@cedula", u.Codigo);
                cmd.Parameters.AddWithValue("@nombre", null);
                cmd.Parameters.AddWithValue("@apellido", null);
                cmd.Parameters.AddWithValue("@psw", u.Psw);
                cmd.Parameters.AddWithValue("@telefono", null);
                cmd.Parameters.AddWithValue("@dir", null);
                cmd.Parameters.AddWithValue("@dir2", null);
                cmd.Parameters.AddWithValue("@correo", null);

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

        public Transaccion IngresarCliente(Cliente c)
        {
            Transaccion rpta = new Transaccion();
            if (!Validaciones.ValidarCliente(c))
            {
                try
                {
                    BaseDatos bd = new BaseDatos();
                    SqlCommand cmd = new SqlCommand("SpCliente", bd.Link);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Metodo", 2);
                    cmd.Parameters.AddWithValue("@cedula", c.Cedula);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@psw", null);
                    cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@dir", c.Direccion);
                    cmd.Parameters.AddWithValue("@dir2", c.Direccion2);
                    cmd.Parameters.AddWithValue("@correo", c.Correo);

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

            }
            else
            {
                rpta.Codigo = "999";
                rpta.Mensaje = "Llene todos los campos";
            }
            return rpta;
        }

        public Transaccion ActualizarCliente(Cliente c)
        {
            Transaccion rpta = new Transaccion();
            if (!Validaciones.ValidarCliente(c))
            {
                try
                {
                    BaseDatos bd = new BaseDatos();
                    SqlCommand cmd = new SqlCommand("SpCliente", bd.Link);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Metodo", 3);
                    cmd.Parameters.AddWithValue("@cedula", c.Cedula);
                    cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", c.Apellido);
                    cmd.Parameters.AddWithValue("@psw", null);
                    cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                    cmd.Parameters.AddWithValue("@dir", c.Direccion);
                    cmd.Parameters.AddWithValue("@dir2", c.Direccion2);
                    cmd.Parameters.AddWithValue("@correo", c.Correo);

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
            }
            else
            {
                rpta.Codigo = "999";
                rpta.Mensaje = "Llene todos los campos";
            }
            return rpta;
        }

        public Cliente BuscarCliente(string Id)
        {
            Cliente c = new Cliente();
            try
            {
                BaseDatos bd = new BaseDatos();
                SqlCommand cmd = new SqlCommand("SpCliente", bd.Link);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Metodo", 4);
                cmd.Parameters.AddWithValue("@cedula", Id);
                cmd.Parameters.AddWithValue("@nombre", null);
                cmd.Parameters.AddWithValue("@apellido", null);
                cmd.Parameters.AddWithValue("@psw", null);
                cmd.Parameters.AddWithValue("@telefono", null);
                cmd.Parameters.AddWithValue("@dir", null);
                cmd.Parameters.AddWithValue("@dir2", null);
                cmd.Parameters.AddWithValue("@correo", null);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                bd.Open();
                da.Fill(dt);
                bd.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    c.Cedula = dr["Cedula"].ToString();
                    c.Nombre = dr["Nombre"].ToString();
                    c.Apellido = dr["Apellido"].ToString();
                    c.Telefono = dr["Telefono"].ToString();
                    c.Direccion = dr["Direccion"].ToString();
                    c.Direccion2 = dr["Direccion2"].ToString();
                    c.Correo = dr["Correo"].ToString();
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                c = null;
            }
            return c;
        }
    }
}
