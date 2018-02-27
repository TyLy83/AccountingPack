using AccountingPack.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AccountingPack.Data
{

    public class LoginUserService : IRepositoryService<LoginUser>
    {
        private readonly AccPackResource _db;

        public LoginUserService(AccPackResource db)
        {
            _db = db;
        }

        public void Create(LoginUser model)
        {
            if (model != null)
            {
                _db.LoginUsers.Add(model);
            }
            else
            {
                throw new NullReferenceException("LoginUser Is Null");
            }
        }

        public void Delete(LoginUser model)
        {
            if (model != null)
            {
                _db.Entry(model).State = EntityState.Deleted;
            }
            else
            {
                throw new NullReferenceException("LoginUserModel Is Null");
            }

        }

        public LoginUser Detail(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("LoginUserModel Is Null");
            }

            LoginUser model = _db.LoginUsers.FirstOrDefault(u => u.Id == id.Value);

            return model;

        }

        public void Edit(LoginUser model)
        {
            if (model == null)
                throw new ArgumentNullException("LoginUserModel Is Null");

            _db.Entry(model).State = EntityState.Modified;

        }

        public List<LoginUser> List(Func<LoginUser, bool> predicate = null)
        {

            List<LoginUser> models = _db.LoginUsers.Where(predicate).ToList();

            return models;

        }

        public List<LoginUser> List(int? businessId = null)
        {

            return null;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }

}
