﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }
        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }
        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }
        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
  
    }
}