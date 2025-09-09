using RepositoryLibrery.Data.Helper;
using RepositoryLibrery.Data.Interface;
using System;
using System.Data;

namespace RepositoryLibrery.Data.Implementations
{
    public class BookRepository : IRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

    

        public List<Book> GetAll(bool v)
        {
            List<Book> lst = new List<Book>();


            var dt = DataHelper.GetInstance().ExecuteSPQuery("SP_RECUPERAR_ARTICULOS");

            NewMethod(lst, dt);
            return lst;
        }

        private static void NewMethod(List<Book> lst, object dt)
        {
            foreach (DataRow row in dt.Row)
            {
                Book p = new Book();
                p.Codigo = (int)row["cod_libro"];
                p.Nombre = (string)row["nombre"];
                p.Precio = Convert.ToDouble(row["pre_unitario"]);
                p.Stock = Convert.ToInt32(row["stock"]);



                lst.Add(p);
            }
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save(Book book)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository
    {
        List<Book> GetAll();
    }
}