using RepositoryLibrery.Domaim;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrery.Data.Interface
{
    internal interface IInvoiceRepository
    {
        List<Invoice> GetAll();
        Invoice GetById(int id);
        bool Save(Invoice seller);
        bool Delete(int id);
    }
}
