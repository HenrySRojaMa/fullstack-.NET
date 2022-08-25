using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace pruebAPI.Logica
{
    public class BaseDatos
    {
        public SqlConnection Link { get; set; }

        public BaseDatos()
        {
            this.Link = new SqlConnection(Environment.GetEnvironmentVariable("ConexionBD").ToString());
        }

        public void Open()
        {
            try
            {
                Link.Open();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            
        }
        public void Close()
        {
            try
            {
                Link.Close();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
