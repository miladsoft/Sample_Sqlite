using DNTPersianUtils.Core;
using Sample_Sqlite.Classes.Users;
using Sample_Sqlite.Models.Context;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_Sqlite
{
    public partial class frm_Main : Master
    {
        private readonly IUsersService usersService;
        private readonly Iunitofwork iunitofwork;

        public frm_Main(IUsersService _usersService, Iunitofwork _iunitofwork)
        {
            this.usersService = _usersService;
            this.iunitofwork = _iunitofwork;
            Bootstrap();
            InitializeComponent();

        }
        private static SimpleInjector.Container container;
        private async void frm_Main_Load(object sender, EventArgs e)
        {
            lblDate.Text = "Farsi Date : " + PersianDateTimeUtils.ToPersianDateTimeString(DateTime.Now, "yy/MM/dd dddd").ToPersianNumbers();
            tblUsersBindingSource.DataSource = await usersService.SeletAllRecord();

        }


        private static void Bootstrap()
        {
            container = new SimpleInjector.Container();
            container.Register<IUsersService, UserServices>();
            container.Register<Iunitofwork, SampleContext>();
            container.Register<frm_AddEdit>();
        }

        private async void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            if (container.GetInstance<frm_AddEdit>().ShowDialog() == DialogResult.OK)
            {
                tblUsersBindingSource.DataSource = await usersService.SeletAllRecord();
            }

        }

        private async void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            var currentrow = tblUsersDataGridView.CurrentRow;
            var Id = currentrow.Cells["clmnId"].Value;

            try
            {
                if (MessageBox.Show("Are You Sure ?", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    usersService.DeleteRecord((int)Id);
                    tblUsersBindingSource.DataSource = await usersService.SeletAllRecord();
                }


            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.Message);
            }
        }
    }
}
