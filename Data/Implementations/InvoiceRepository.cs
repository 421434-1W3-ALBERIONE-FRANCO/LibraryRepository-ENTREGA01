using Microsoft.Data.SqlClient;
using RepositoryLibrery.Data.Interface;
using RepositoryLibrery.Domaim;
using System.Data;

namespace RepositoryLibrery.Data.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public object DataHelper { get; private set; }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Invoice invoice)
        {
            bool result = true;
            SqlConnection cnn = null;
            SqlTransaction t = null;

            try
            {
                cnn = (SqlConnection?)nuevometGet();
                cnn.Open();
                t = cnn.BeginTransaction();

                var cmd = new SqlCommand("SP_INSERTAR_MAESTRO", cnn, t);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter2 = cmd.Parameters.AddWithValue("@cliente", invoice.Client.GetHashCode);
                SqlParameter sqlParameter = sqlParameter2;
                cmd.Parameters.AddWithValue("@vendedor", invoice.Seller.GetHashCode);

                SqlParameter param = new SqlParameter("@id", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
                int InvoidId = (int)param.Value;

                // Recorro la lista de los detalles donde cargare uno a uno los detalles respectivamente
                foreach (var detail in invoice.DetailInvoices)
                {
                    var cmdDetail = new SqlCommand("SP_INSERTAR_DETALLE_FACTURA", cnn, t);
                    cmdDetail.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlParameter1 = cmdDetail.Parameters.AddWithValue("@libro", detail.Book.Cod);
                    cmdDetail.Parameters.AddWithValue("@factura", InvoidId);
                    cmdDetail.Parameters.AddWithValue("@cantidad", detail.Count);
                    cmdDetail.Parameters.AddWithValue("@precio", detail.UnitPrice);
                    cmdDetail.ExecuteNonQuery();
                }

                t.Commit();
            }
            catch (SqlException e)
            {
                if (t != null)
                {
                    t.Rollback();
                }
                result = false;
            }
            finally
            {
                // Si no es nula y esta abierta, la cerramos
                if (cnn != null && cnn.State == System.Data.ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
            return result;

        }

        private object nuevometGet()
        {
            return NewMethod()
                                .GetConnection();
        }

        private object NewMethod()
        {
            return DataHelper.GetInstance();
        }
    }