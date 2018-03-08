using AccountingPack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AccountingPack.Data
{
    public class BusinessOwnerService : IRepositoryService<AccountOwner>
    {
        private readonly AccPackResource _db;

        public BusinessOwnerService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(AccountOwner model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.AccountOwners.Add(model);

        }

        public void Delete(AccountOwner model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.Entry(model).State = EntityState.Deleted;

        }

        public AccountOwner Detail(int? id)
        {

            if (id == null)
                throw new ArgumentNullException("Id Is Null");

            AccountOwner model = _db.AccountOwners
                                    .Include(m => m.Business)
                                    .FirstOrDefault(m => m.Id == id.Value);

            return model;

        }

        public void Edit(AccountOwner model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.Entry(model).State = EntityState.Modified;

        }

        public List<AccountOwner> List(Func<AccountOwner, bool> predicate = null)
        {
            return _db.AccountOwners
                      .Where(predicate)
                      .ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
