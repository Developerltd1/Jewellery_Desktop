using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new AddItemsForm());
           //Application.Run(new StockManagementForm());
          // Application.Run(new InvoicesForm());
           // Application.Run(new SaleForm());
           // Application.Run(new GoldRatesForm());
           //Application.Run(new Sale_Invoices_Form());
            Application.Run(new Home());
            
            
                   
        }
    }
}
