using Sample_Sqlite.Classes.Users;
using Sample_Sqlite.Models.Context;
using Sample_Sqlite.Models.Domeins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sample_Sqlite
{
    public partial class frm_AddEdit : Sample_Sqlite.Master
    {

        private readonly IUsersService usersService;
        private readonly Iunitofwork iunitofwork;

        public frm_AddEdit(IUsersService _usersService, Iunitofwork _iunitofwork)
        {
            this.usersService = _usersService;
            this.iunitofwork = _iunitofwork;
            InitializeComponent();

        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
          this.DialogResult=  DialogResult.Cancel;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            TblUsers user = new TblUsers();
            user.FirstName = firstNameTextBox.Text;
            user.LastName = lastNameTextBox.Text;
            user.UserName = userNameTextBox.Text;
            user.Password = passwordTextBox.Text;
            user.RegDate = DateTime.Now;

            usersService.AddRecord(user);
           

            this.DialogResult = DialogResult.OK;

        }
    }
}
