using AccountingPack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AccountingPack.Enums;

namespace AccountingPack.Data
{
    public class LongTermAssetService : IRepositoryService<LongTermAsset>
    {

        private readonly AccPackResource _db;

        public LongTermAssetService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(LongTermAsset model)
        {

            Business business = _db.Businesses.FirstOrDefault(b => b.Id == model.BusinessId.Value);

            model.Business = business;

            if (model.Depreciation != null)
            {
                Depreciation dep = new Depreciation()
                {
                    Name = model.Depreciation.Name,
                    Category = AccountCategory.Depreciations
                };

                dep.Business = business;
                dep.BusinessId = business.Id;

                _db.Entry(dep).State = EntityState.Added;

                model.Depreciation = dep;
                model.AccDepId = dep.Id;

            }

            _db.Entry(model).State = EntityState.Added;

        }

        public void Delete(LongTermAsset model)
        {
            if(model == null)
            throw new Exception("Model Null");

            LongTermAsset la = _db.LongTermAssets.FirstOrDefault(l => l.Id == model.Id);

            if(model.AccDepId != null)
            {

                Depreciation dep = _db.Drepreciations.FirstOrDefault(d => d.Id == model.AccDepId);

                _db.Entry(dep).State = EntityState.Deleted;

            }

            _db.Entry(la).State = EntityState.Deleted;

        }

        public LongTermAsset Detail(int? id)
        {

            if (id == null)
                throw new Exception("Id Null");

            LongTermAsset model = _db.LongTermAssets.Include(la=>la.Depreciation).FirstOrDefault(la => la.Id == id.Value);

            return model;

        }

        public void Edit(LongTermAsset model)
        {

            if (model == null)
                throw new ArgumentNullException("Model equal Null");

            LongTermAsset la = _db.LongTermAssets.FirstOrDefault(a => a.Id == model.Id);

            if (la == null)
                throw new Exception("Not Found");

            la.Name = model.Name;

            if (model.Depreciation != null)
            {

                Depreciation dep = null;

                if (model.AccDepId == null)
                {
                    Business business = _db.Businesses.FirstOrDefault(b => b.Id == model.BusinessId.Value);

                    dep = new Depreciation()
                    {
                        Name = model.Depreciation.Name,
                        Category = AccountCategory.Depreciations
                    };

                    dep.Business = business;
                    dep.BusinessId = business.Id;

                    _db.Entry(dep).State = EntityState.Added;

                    la.Depreciation = dep;

                }
                else
                {

                    dep = _db.Drepreciations.FirstOrDefault(d => d.Id == model.AccDepId.Value);
                    dep.Name = model.Depreciation.Name;
                    _db.Entry(dep).State = EntityState.Modified;

                }

            }
            else
            {
                if(model.AccDepId != null)
                {

                    Depreciation dep = _db.Drepreciations
                                          .FirstOrDefault(d => d.Id == model.AccDepId.Value);

                    _db.Entry(dep).State = EntityState.Deleted;

                }
            }

            _db.Entry(la).State = EntityState.Modified;

        }

        public List<LongTermAsset> List(Func<LongTermAsset, bool> predicate = null)
        {
            return _db.LongTermAssets.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
