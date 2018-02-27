using AccountingPack.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingPack.Data
{
    public class OwnerService : IRepositoryService<AccountOwner>
    {
        private readonly AccPackResource _db;

        public OwnerService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(AccountOwner model)
        {

            if (model == null)
                throw new Exception("Model Is Null");

            _db.AccountOwners.Add(model);

        }

        public void Delete(AccountOwner model)
        {
            throw new NotImplementedException();
        }

        public AccountOwner Detail(int? id)
        {
            throw new NotImplementedException();
        }

        public void Edit(AccountOwner model)
        {
            throw new NotImplementedException();
        }

        public List<AccountOwner> List(Func<AccountOwner, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public List<AccountOwner> List(int? businessId = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
