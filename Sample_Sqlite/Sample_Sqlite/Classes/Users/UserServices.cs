using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample_Sqlite.Models.Context;
using Sample_Sqlite.Models.Domeins;

namespace Sample_Sqlite.Classes.Users
{

    public class UserServices : IUsersService
    {

        private readonly Iunitofwork _unitOfWork;
        private readonly DbSet<TblUsers> _Users;

        public UserServices(Iunitofwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _Users = unitOfWork.Set<TblUsers>();
        }

        public void AddRecord(TblUsers _user)
        {
            _Users.Add(_user);
            _unitOfWork.SaveChanges();
        }

        public void DeleteRecord(int _userId)
        {
            var user = _Users.Find(_userId);
            _Users.Remove(user);
            _unitOfWork.SaveChanges();

        }

        public void EditRecord(TblUsers _user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TblUsers>> SeletAllRecord()
        {
            return await _Users.ToListAsync();
        }

        public Task<TblUsers> SeletRecord(int _userId)
        {
            throw new NotImplementedException();
        }
    }
}
