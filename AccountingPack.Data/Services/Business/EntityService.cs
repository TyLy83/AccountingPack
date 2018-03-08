using AccountingPack.Models;
using System;
using System.Collections.Generic;
using System.Text;
using AccountingPack.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AccountingPack.Data
{
    public class EntityService : IRepositoryService<AccountBaseEntitie>
    {

        private readonly AccPackResource _db;

        public EntityService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(AccountBaseEntitie model)
        {
            Business business = _db.Businesses.FirstOrDefault(b => b.Id == model.BusinessId);
            model.Business = business;

            switch (model.Category)
            {
                case AccountCategory.CurrentAssets:
                    _db.CurrentAssets.Add((CurrentAsset)model);
                    break;

                case AccountCategory.LongTermAssets:
                    
                    _db.LongTermAssets.Add((LongTermAsset)model);
                    break;
            }
        }

        public void Delete(AccountBaseEntitie model)
        {
            _db.Entry(model).State = EntityState.Deleted;
        }

        public AccountBaseEntitie Detail(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            return _db.AccountEntities
                      .FirstOrDefault(m => m.Id == id.Value);

        }

        public void Edit(AccountBaseEntitie model)
        {
            _db.Entry(model).State = EntityState.Modified;
        }

        public List<AccountBaseEntitie> List(Func<AccountBaseEntitie, bool> predicate = null)
        {
            return _db.AccountEntities
                      .Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
