using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Data.Interface
{

    // INTERFAZ GENERICA -POR SI NECESITO USAR EL CONTRATO EN OTRA CLASE
    public interface IRepository<Book> 


        {
        List<Book> GetAll();
        Book GetById(int id);
        bool Save(Book entity);
        bool Delete(int id);


         }


}
