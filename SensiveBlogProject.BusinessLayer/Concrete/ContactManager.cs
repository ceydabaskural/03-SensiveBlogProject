﻿using SensiveBlogProject.BusinessLayer.Abstract;
using SensiveBlogProject.DataAccessLayer.Abstract;
using SensiveBlogProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SensiveBlogProject.BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void TDelete(int id)
        {
           _contactDal.Delete(id);
        }

        public List<Contact> TGetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }

        public void TInsert(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void TUpdate(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
