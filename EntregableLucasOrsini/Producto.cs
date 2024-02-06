using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregableLucasOrsini
{
    internal class Producto
    {
        private int _id;
        private string _descripcion;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

        public int Id 
                { 
                    get 
                        {
                            return _id; 
                        } 
                    set 
                        { 
                            _id = value; 
                        } 
                }

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }

        public double Costo
        {
            get
            {
                return _costo;
            }
            set
            {
                _costo = value;
            }
        }

        public double PrecioVenta
        {
            get
            {
                return _precioVenta;
            }
            set
            {
                _precioVenta = value;
            }
        }

        public int Stock
        {
            get
            {
                return _stock;
            }
            set
            {
                _stock = value;
            }
        }

        public int IdUsuario
        {
            get
            {
                return _idUsuario;
            }
            set
            {
                _idUsuario = value;
            }
        }



    }

    //Metodo obtener producto 

    public static List<Producto> ObtenerProducto(int idProducto)
    {
        List<Producto> list = new List<Producto>();

        string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        var query = "SELECT _id, _descripcion, _costo, _precioVenta, _stock, _idUsuario FROM Producto where id=idProducto;";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                var parametro = new SqlParameter();
                parametro.ParameterName = "idProducto";
                parametro.SqlDbType = SqlDbType.Int;
                parametro.Value = idProducto;

                comando.Parameters.Add(parametro);

                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        while (dr.Read())
                        {
                            var producto = new Producto();
                            producto.Id = Convert.ToInt32(dr["_id"]);
                            producto.Descripcion = dr["_descripcion"].ToString();
                            producto.Costo = Convert.ToDecimal(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                            producto.Stock = Convert.ToDecimal(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(dr["IdUsaurio"]);
                            list.Add(producto);
                        }
                        
                    }
                }
            }
        }
        return list;
    }

    //Metodo listar producto

    public static List<Producto> ListaProductos()
    {
        List<Producto> list = new List<Producto>();

        string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        var query = "SELECT _id, _descripcion, _costo, _precioVenta, _stock, _idUsuario FROM Producto where id=idProducto;";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();

            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                using (SqlDataReader dr = comando.ExecuteReader())
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            var producto = new Producto();
                            producto.Id = Convert.ToInt32(dr["_id"]);
                            producto.Descripcion = dr["_descripcion"].ToString();
                            producto.Costo = Convert.ToDecimal(dr["Costo"]);
                            producto.PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]);
                            producto.Stock = Convert.ToDecimal(dr["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(dr["IdUsaurio"]);
                            list.Add(producto);
                        }
                    }
                }
            }
        }
        return list; 
    }

    //Metodo crear producto

    public static void CrearProducto(Producto producto)
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        var query = "INSERT INTO Producto (_id, _descripcion, _costo, _precioVenta, _stock, _idUsuario FROM Producto where id=idProducto)" +
                     "VALUES(@Descripcion, @Costo, @PrecioVenta, @Stock, @IdUsuario )";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion});
                comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });

            }

            conexion.Close();
        }
    }

    //Metodo Modificar Producto

    public static void ModificarProducto (Producto producto)
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        var query = "UPDATE Producto" + "SET Descripcion = @Descripcion" + ", Costo = @Costo" + ", PrecioVenta = @PrecioVEnta" +
            ", Stock = @Stock" + ",IdUsuario = @IdUsuario" + ", Where ID = @Id";

        using (SqlConnection conexion = new SqlConnection(connectionString))
        {
            conexion.Open();
            using (SqlCommand comando = new SqlCommand (query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
                comando.Parameters.Add(new SqlParameter("Descripcion", SqlDbType.VarChar) { Value = producto.Descripcion });
                comando.Parameters.Add(new SqlParameter("Costo", SqlDbType.Money) { Value = producto.Costo });
                comando.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.Money) { Value = producto.PrecioVenta });
                comando.Parameters.Add(new SqlParameter("Stock", SqlDbType.Int) { Value = producto.Stock });
                comando.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar) { Value = producto.IdUsuario });
            }
            conexion.Close();
        }
    }

    //Metodo Eliminar Producto

    public static void EliminarProducto(Producto producto)
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        var query = "DELETE FROM Producto WHERE Id = @Id";

        using (SqlConnection conexion = new SqlConnection (connectionString))
        {
            conexion.Open ();   
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.Add(new SqlParameter("Id", SqlDbType.Int) { Value = producto.Id });
            }
            conexion.Close();
        }
    }


    
   




}
