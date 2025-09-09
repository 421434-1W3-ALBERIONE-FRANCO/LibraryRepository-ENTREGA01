using RepositoryLibrery.Data.Helper;
using RepositoryLibrery.Data.Implementations;
using RepositoryLibrery.Data.Interface;
using RepositoryLibrery.Domaim;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Services
{
    public class BookServices
    {
        private IRepository _Repository;


        public BookServices ()
        {
            _Repository = new BookRepository();
        }

        public List<Book> GetAll()
        {
            List<Book> list = _Repository.GetAll();
            return list;
        }
    }
}
