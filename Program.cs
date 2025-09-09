using RepositoryLibrery.Domaim;
using RepositoryLibrery.Services;

namespace RepositoryLibrery
{
    internal class Program
    {
       

    BookServices oBookS = new BookServices();
     
    InvoicesService oInvoiceS = new InvoicesService();
        
        List<Detailinvoices> listDetail = new List<Detailinvoices>();
        private static readonly BookServices oBookS1 = oBookS;
        List<Book> books = oBookS1.GetAll();
        
        
     new Detailinvoices()
    {
        Book = books[0],
        UnitPrice  = 1000,
        Count = 2,
    }
  

    Invoice invoice = new Invoice()
    {
        Client = listClient[0],
        Seller = listSeller[0],
        DetailInvoices = listDetail,
        date = DateTime.Now,
    };

    bool seCargo =  oInvoiceS.Save(invoice);

 
