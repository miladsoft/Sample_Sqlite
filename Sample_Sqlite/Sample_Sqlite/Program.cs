using Sample_Sqlite.Classes.Users;
using Sample_Sqlite.Models.Context;
using SimpleInjector;
using SimpleInjector.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_Sqlite
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
            Bootstrap();
            Application.Run(container.GetInstance<frm_Main>());
        }
        private static  Container container;
        private static void Bootstrap()
        {
            container = new Container();
            container.Register<IUsersService, UserServices>();
            container.Register<Iunitofwork, SampleContext>();
            container.Register<frm_Main>();
        }
    }
}
