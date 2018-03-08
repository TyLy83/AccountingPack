using AccountingPack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingPack.Data
{
    public class CurrentAssetService : IRepositoryService<CurrentAsset>
    {

        private readonly AccPackResource _db;

        public CurrentAssetService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(CurrentAsset model)
        {
            _db.CurrentAssets.Add(model);
        }

        public void Delete(CurrentAsset model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.Entry(model).State = EntityState.Deleted;

        }

        public CurrentAsset Detail(int? id)
        {
            if (id == null)
                throw new ArgumentNullException();

            CurrentAsset model = _db.CurrentAssets.FirstOrDefault(ca => ca.Id == id.Value);

            if (model == null)
                throw new ArgumentNullException();

            return model;

        }

        public void Edit(CurrentAsset model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.Entry(model).State = EntityState.Modified;

        }

        public List<CurrentAsset> List(Func<CurrentAsset, bool> predicate = null)
        {
            return _db.CurrentAssets.Where(predicate)
                                    .ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
