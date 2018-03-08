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

            if (id == null)
                throw new ArgumentNullException("Id Is Null");

            Business entity = _db.Businesses
                                 .Include(b=>b.Owner)
                                 .Include(b=>b.Address)
                                 .FirstOrDefault(b => b.Id == id.Value);

            if (entity != null)
                return entity;

            return null;

        }

        public void Edit(Business model)
        {

            if (model == null)
                throw new ArgumentNullException();

            ContactDetail contact = _db.Contacts.FirstOrDefault(c => c.Id == model.AddressId);

            if(contact != null)
            {
                contact.AddressLine1 = model.Address.AddressLine1;
                contact.AddressLine2 = model.Address.AddressLine2;
                contact.AddressState = model.Address.AddressState;
                contact.Country = model.Address.Country;
                contact.ZipCode = model.Address.ZipCode;
                contact.ContactNumber = model.Address.ContactNumber;
                contact.ContactEmail = model.Address.ContactEmail;

                model.Address = contact;
            }

            _db.Entry(model).State = EntityState.Modified;

        }

        public List<Business> List(Func<Business, bool> predicate = null)
        {

            return _db.Businesses
                      .Where(predicate)
                      .ToList();

        }

        public void SaveChanges()
        {

            _db.SaveChanges();

        }
    }
}
