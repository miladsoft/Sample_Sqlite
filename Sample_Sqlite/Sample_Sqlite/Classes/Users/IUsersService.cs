using Sample_Sqlite.Models.Domeins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Sqlite.Classes.Users
{
    public interface IUsersService
    {
        void AddRecord(TblUsers _user);

        void EditRecord(TblUsers _user);

        void DeleteRecord(int _userId);

        Task<TblUsers> SeletRecord(int _userId);

        Task<List<TblUsers>> SeletAllRecord();




    }
}
