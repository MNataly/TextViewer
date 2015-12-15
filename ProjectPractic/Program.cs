using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextView.BL;

namespace ProjectPractic
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1();
            
            MessageService messageService = new MessageService();
            FileManager fileManager = new FileManager();

            MainPresenter presenter = new MainPresenter(form, fileManager, messageService);
            Application.Run(form);
        }
    }
}
