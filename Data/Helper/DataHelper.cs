using Microsoft.Data.SqlClient;
using RepositoryLibrery.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Data.Helper
{
	public class DataHelper
	{
        private static DataHelper _instance;
        private SqlConnection _connection;

        private DataHelper()
        {
            _connection = new SqlConnection(Properties.Resources.CadenaConexionLocal);
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }

        public DataTable ExecuteSpQuery(string sp, List<SpParameter>? param = null)
        {
            DataTable dt = new DataTable();
            try
            {
                // Abrimos la conexión
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregamos parámetros si los hay
                if (param != null)
                {
                    foreach (SpParameter p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }

                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                // En caso de error, retornamos null
                dt = null;
            }
            finally
            {
                // Cerramos la conexión
                _connection.Close();
            }

            return dt;
        }

        // Método para ejecutar SPs con operaciones DML
        public bool ExecuteSpDml(string sp, List<SpParameter>? param = null)
        {
            bool result;
            try
            {
                // Abrimos la conexión
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Agregamos parámetros si los hay
                if (param != null)
                {
                    foreach (SpParameter p in param)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }

                int affectedRows = cmd.ExecuteNonQuery();

                result = affectedRows > 0;
            }
            catch (SqlException ex)
            {
                // En caso de error, retornamos false
                result = false;
            }
            finally
            {
                // Cerramos la conexión
                _connection.Close();
            }

            return result;
        }

        // Manejo de transacciones para un Maestro-Detalle (sin Unit of Work)
        public bool ExecuteTransaction(Book product)
        {
            _connection.Open();

            // Obtener transaccion a partir de conexion
            SqlTransaction transaction = _connection.BeginTransaction();

            // Ejecutar los comandos que hagan falta
            // Primero tenemos que crear el maestro (en nuestro ejemplo PRODUCTOS)

            // Utilizamos la sobrecarga que utiliza tres parámetros
            var cmd = new SqlCommand("SP_GUARDAR_PRODUCTO", _connection, transaction);
            cmd.CommandType = CommandType.StoredProcedure;

            // Agregamos los parámetros
            cmd.Parameters.AddWithValue("@codigo", product.Codigo);
            cmd.Parameters.AddWithValue("@nombre", product.Nombre);
            cmd.Parameters.AddWithValue("@stock", product.Stock);

            int affectedRows = cmd.ExecuteNonQuery();
            if (affectedRows <= 0)
            {
                // Si no se modificaron filas en la BD -> ROLLBACK
                // Revertimos la transacción y retornamos false
                transaction.Rollback();
                return false;
            }
            else
            {
                (bool flowControl, bool value) = NewMethod(product, transaction);
                if (!flowControl)
                {
                    return value;
                }

                // Ya insertamos el maestro y todos sus detalles sin problemas -> COMMIT
                // Se confirma la transacción y se retorna true
                transaction.Commit();
                return true;
            }
        }

        private (bool flowControl, bool value) NewMethod(Book product, SqlTransaction transaction)
        {
            throw new NotImplementedException();
        }

        internal object ExecuteSPQuery(string v)
        {
            throw new NotImplementedException();
        }
    }

}
