using AccountingPack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingPack.Data
{
    public class BusinessService : IRepositoryService<Business>
    {

        private readonly AccPackResource _db;

        public BusinessService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(Business model)
        {

            if (model == null)
                throw new ArgumentNullException();

            _db.Businesses.Add(model);

        }

        public void Delete(Business model)
        {

            if (model == null)
            throw new ArgumentNullException();

            _db.Entry(model).State = EntityState.Deleted;

        }

        public Business Detail(int? id)
        {

            if (id==null)
                throw new ArgumentNullException("Id Is Null");

            Business entity = _db.Businesses.FirstOrDefault(b => b.Id == id.Value);

            if (entity != null)
                return entity;

            return null;

        }

        public void Edit(Business model)
        {
            throw new NotImplementedException();
        }

        public List<Business> List(Func<Business, bool> predicate = null)
        {

            List<Business> models = _db.Businesses.Where(predicate).ToList();

            return models;

        }

        public List<Business> List(int? businessId = null)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {

            _db.SaveChanges();

        }
    }
}
