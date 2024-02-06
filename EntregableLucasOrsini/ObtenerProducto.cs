using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntregableLucasOrsini
{
    class ObtenerProducto
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString)) 
            {

                using (SqlCommand comand = new SqlCommand("Select * from Productos", connection))
                {
                    connection .Open();

                    using (SqlDataReader reader = comand.ExecuteReader())
                    {
                        if(reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var producto = new ObtenerProducto();
                        }
                    }

                }

                connection.Open();
            
                connection.Close();

                Console.ReadKey();
            
            }
        }

            
             
            
    }
}
    

